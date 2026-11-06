using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;
using ParfumApi.Dtos;
using ParfumApi.Models;

namespace ParfumApi.Services;

public interface IKokuAtolyesiServisi
{
    Task<List<EsansDto>> EsanslariGetir();
    Task<(DegerlendirmeSonucu? Sonuc, string? Hata)> Degerlendir(DegerlendirmeIstegi istek);
}

public class KokuAtolyesiServisi : IKokuAtolyesiServisi
{
    private const int KatmanBasinaEnFazla = 3;

    // Aileler arası uyum. Parfümcülükteki "koku çarkı"ndan sadeleştirildi:
    // çarkta yan yana duran aileler iyi kaynaşır, uzak duranlar çatışabilir.
    private static readonly (string A, string B, int Puan)[] AileTablosu =
    [
        ("Narenciye", "Narenciye", 1),
        ("Narenciye", "Meyveli", 2),
        ("Narenciye", "Yeşil", 2),
        ("Narenciye", "Çiçeksi", 1),
        ("Narenciye", "Baharatlı", 1),
        ("Narenciye", "Aromatik", 2),
        ("Narenciye", "Odunsu", 1),
        ("Narenciye", "Reçineli", -1),
        ("Narenciye", "Gurme", -1),
        ("Narenciye", "Misk", 1),
        ("Meyveli", "Meyveli", 1),
        ("Meyveli", "Yeşil", 0),
        ("Meyveli", "Çiçeksi", 2),
        ("Meyveli", "Baharatlı", 0),
        ("Meyveli", "Aromatik", -1),
        ("Meyveli", "Odunsu", 0),
        ("Meyveli", "Reçineli", 0),
        ("Meyveli", "Gurme", 2),
        ("Meyveli", "Misk", 1),
        ("Yeşil", "Yeşil", 1),
        ("Yeşil", "Çiçeksi", 1),
        ("Yeşil", "Baharatlı", -1),
        ("Yeşil", "Aromatik", 2),
        ("Yeşil", "Odunsu", 1),
        ("Yeşil", "Reçineli", -2),
        ("Yeşil", "Gurme", -2),
        ("Yeşil", "Misk", 1),
        ("Çiçeksi", "Çiçeksi", 1),
        ("Çiçeksi", "Baharatlı", 1),
        ("Çiçeksi", "Aromatik", 0),
        ("Çiçeksi", "Odunsu", 1),
        ("Çiçeksi", "Reçineli", 1),
        ("Çiçeksi", "Gurme", 1),
        ("Çiçeksi", "Misk", 2),
        ("Baharatlı", "Baharatlı", 0),
        ("Baharatlı", "Aromatik", 1),
        ("Baharatlı", "Odunsu", 2),
        ("Baharatlı", "Reçineli", 2),
        ("Baharatlı", "Gurme", 1),
        ("Baharatlı", "Misk", 0),
        ("Aromatik", "Aromatik", 1),
        ("Aromatik", "Odunsu", 2),
        ("Aromatik", "Reçineli", 0),
        ("Aromatik", "Gurme", -1),
        ("Aromatik", "Misk", 1),
        ("Odunsu", "Odunsu", 1),
        ("Odunsu", "Reçineli", 2),
        ("Odunsu", "Gurme", 1),
        ("Odunsu", "Misk", 2),
        ("Reçineli", "Reçineli", 1),
        ("Reçineli", "Gurme", 2),
        ("Reçineli", "Misk", 1),
        ("Gurme", "Gurme", 1),
        ("Gurme", "Misk", 1),
        ("Misk", "Misk", 0)
    ];

    private static readonly Dictionary<(string, string), int> AileUyumu = AileSozluguOlustur();

    private static Dictionary<(string, string), int> AileSozluguOlustur()
    {
        var sozluk = new Dictionary<(string, string), int>();
        foreach (var (a, b, puan) in AileTablosu)
        {
            sozluk[(a, b)] = puan;
            sozluk[(b, a)] = puan;
        }
        return sozluk;
    }

    private static readonly (string Katman, string Uyari)[] KatmanUyarilari =
    [
        ("Üst", "Üst nota seçmedin: koku açılışta düz kalabilir."),
        ("Kalp", "Kalp notası seçmedin: kokunun karakteri zayıf kalır."),
        ("Alt", "Alt nota seçmedin: koku tende uzun süre kalmaz."),
    ];

    private static readonly Dictionary<string, string> AileSifatlari = new()
    {
        ["Narenciye"] = "narenciyeli",
        ["Meyveli"] = "meyveli",
        ["Yeşil"] = "yeşil ve ferah",
        ["Çiçeksi"] = "çiçeksi",
        ["Baharatlı"] = "baharatlı",
        ["Aromatik"] = "aromatik",
        ["Odunsu"] = "odunsu",
        ["Reçineli"] = "reçineli ve sıcak",
        ["Gurme"] = "tatlı",
        ["Misk"] = "yumuşak, misk kokulu",
    };

    private static readonly Dictionary<int, decimal> HacimTabanFiyati = new()
    {
        [30] = 1200m,
        [50] = 1800m,
        [100] = 3000m,
    };

    private static readonly Dictionary<string, decimal> KonsantrasyonCarpani = new()
    {
        ["Eau de Toilette"] = 0.85m,
        ["Eau de Parfum"] = 1.0m,
        ["Extrait de Parfum"] = 1.3m,
    };

    private readonly AppDbContext _db;

    public KokuAtolyesiServisi(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<EsansDto>> EsanslariGetir()
    {
        return await _db.Esanslar
            .OrderBy(e => e.Id)
            .Select(e => new EsansDto(e.Id, e.Ad, e.Katman, e.Aile, e.Aciklama, e.Renk, e.EkFiyat))
            .ToListAsync();
    }

    public async Task<(DegerlendirmeSonucu? Sonuc, string? Hata)> Degerlendir(DegerlendirmeIstegi istek)
    {
        // Tablolar küçük (30 esans), hepsini bir kere çekip hesabı bellekte yapıyoruz
        var tumEsanslar = await _db.Esanslar.ToListAsync();
        var ozelUyumlar = await _db.EsansUyumlari.ToListAsync();

        var secilenIdler = istek.EsansIdleri.Distinct().ToList();
        var secilenler = tumEsanslar.Where(e => secilenIdler.Contains(e.Id)).ToList();

        if (secilenler.Count != secilenIdler.Count)
            return (null, "Geçersiz esans seçimi.");

        if (secilenler.GroupBy(e => e.Katman).Any(g => g.Count() > KatmanBasinaEnFazla))
            return (null, $"Her katmandan en fazla {KatmanBasinaEnFazla} esans seçebilirsin.");

        // İki esansın uyumu: önce özel çift tablosuna, yoksa aile tablosuna bakılır
        (int Puan, string Aciklama) CiftPuani(Esans a, Esans b)
        {
            var kucuk = Math.Min(a.Id, b.Id);
            var buyuk = Math.Max(a.Id, b.Id);
            var ozel = ozelUyumlar.FirstOrDefault(u => u.EsansAId == kucuk && u.EsansBId == buyuk);
            if (ozel is not null)
                return (ozel.Puan, ozel.Aciklama);

            var puan = AileUyumu.GetValueOrDefault((a.Aile, b.Aile), 0);
            return (puan, VarsayilanAciklama(puan, a.Aile, b.Aile));
        }

        var ciftler = new List<CiftUyumu>();
        for (var i = 0; i < secilenler.Count; i++)
        {
            for (var j = i + 1; j < secilenler.Count; j++)
            {
                var (puan, aciklama) = CiftPuani(secilenler[i], secilenler[j]);
                ciftler.Add(new CiftUyumu(secilenler[i].Ad, secilenler[j].Ad, puan, aciklama));
            }
        }

        // Çiftlerin ortalaması (-2..2) 0-100 arasına çevrilir, sonra yapı kuralları uygulanır
        double toplamPuan = ciftler.Count == 0 ? 50 : (ciftler.Average(c => c.Puan) + 2) / 4 * 100;
        var uyarilar = new List<string>();

        if (secilenler.Count > 0)
        {
            foreach (var (katman, uyari) in KatmanUyarilari)
            {
                if (!secilenler.Any(e => e.Katman == katman))
                {
                    uyarilar.Add(uyari);
                    toplamPuan -= 10;
                }
            }
        }

        var aileSayisi = secilenler.Select(e => e.Aile).Distinct().Count();
        if (aileSayisi > 4)
        {
            uyarilar.Add($"{aileSayisi} farklı koku ailesi var; koku dağınık hissedilebilir.");
            toplamPuan -= 5 * (aileSayisi - 4);
        }

        foreach (var cift in ciftler.Where(c => c.Puan <= -2))
            uyarilar.Add($"{cift.EsansA} ile {cift.EsansB} çatışıyor: {cift.Aciklama}");

        var sonPuan = secilenler.Count == 0 ? 0 : (int)Math.Round(Math.Clamp(toplamPuan, 0, 100));

        // Henüz seçilmemiş her esansın mevcut seçimle ortalama uyumu: arayüz bununla öneri gösterir
        var adayPuanlari = new Dictionary<int, double>();
        if (secilenler.Count > 0)
        {
            foreach (var aday in tumEsanslar.Where(e => !secilenIdler.Contains(e.Id)))
                adayPuanlari[aday.Id] = Math.Round(secilenler.Average(s => CiftPuani(aday, s).Puan), 1);
        }

        var sonuc = new DegerlendirmeSonucu(
            sonPuan,
            Seviye(sonPuan, secilenler.Count),
            Ozet(secilenler),
            ciftler.OrderByDescending(c => c.Puan).ToList(),
            uyarilar,
            adayPuanlari,
            FiyatHesapla(secilenler, istek.Konsantrasyon, istek.HacimMl));

        return (sonuc, null);
    }

    private static string VarsayilanAciklama(int puan, string aileA, string aileB)
    {
        var aileler = aileA == aileB ? $"İki {aileA.ToLower()} nota" : $"{aileA} ve {aileB.ToLower()}";
        return puan switch
        {
            >= 2 => $"{aileler} birbirini tamamlar.",
            1 => $"{aileler} uyumlu çalışır.",
            0 => $"{aileler} birbirini pek etkilemez.",
            -1 => $"{aileler} dikkatli dengelenmeli.",
            _ => $"{aileler} genellikle çatışır.",
        };
    }

    private static string Seviye(int puan, int esansSayisi)
    {
        if (esansSayisi == 0) return "Esans seçmeye başla";
        if (esansSayisi == 1) return "Bir esans daha ekle";
        return puan switch
        {
            >= 80 => "Mükemmel uyum",
            >= 65 => "Uyumlu",
            >= 45 => "Cesur bir karışım",
            _ => "Çatışan notalar",
        };
    }

    // Her katmanda en çok tekrar eden aileye göre kısa bir tarif cümlesi kurar
    private static string Ozet(List<Esans> secilenler)
    {
        string? Sifat(string katman) => secilenler
            .Where(e => e.Katman == katman)
            .GroupBy(e => e.Aile)
            .OrderByDescending(g => g.Count())
            .Select(g => AileSifatlari.GetValueOrDefault(g.Key, g.Key.ToLower()))
            .FirstOrDefault();

        var parcalar = new List<string>();
        if (Sifat("Üst") is { } ust) parcalar.Add($"{ust} bir açılış");
        if (Sifat("Kalp") is { } kalp) parcalar.Add($"{kalp} bir kalp");
        if (Sifat("Alt") is { } alt) parcalar.Add($"{alt} bir iz");

        if (parcalar.Count == 0) return "";

        var cumle = parcalar.Count == 1
            ? parcalar[0]
            : string.Join(", ", parcalar.Take(parcalar.Count - 1)) + " ve " + parcalar[^1];

        return char.ToUpperInvariant(cumle[0]) + cumle[1..] + ".";
    }

    private static decimal FiyatHesapla(List<Esans> secilenler, string konsantrasyon, int hacimMl)
    {
        if (secilenler.Count == 0) return 0m;

        var taban = HacimTabanFiyati.GetValueOrDefault(hacimMl, 1800m);
        var carpan = KonsantrasyonCarpani.GetValueOrDefault(konsantrasyon, 1m);
        var esansFiyati = secilenler.Sum(e => e.EkFiyat) * hacimMl / 50m;

        // 10 TL'ye yuvarla
        return Math.Round((taban + esansFiyati) * carpan / 10m) * 10m;
    }
}
