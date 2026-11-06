using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;
using ParfumApi.Dtos;
using ParfumApi.Models;
using ParfumApi.Services;
using ParfumApi.Services.Odeme;

namespace ParfumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiparislerController : ControllerBase
{
    private const decimal UcretsizKargoSiniri = 2000m;
    private const decimal StandartKargoUcreti = 150m;
    private const string SiparisNoKarakterleri = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // 0/O, 1/I karışmasın

    private readonly AppDbContext _db;
    private readonly IKokuAtolyesiServisi _atolye;
    private readonly IKartOdemeServisi _kartOdeme;
    private readonly IKriptoOdemeServisi _kriptoOdeme;
    private readonly ILogger<SiparislerController> _log;

    public SiparislerController(
        AppDbContext db,
        IKokuAtolyesiServisi atolye,
        IKartOdemeServisi kartOdeme,
        IKriptoOdemeServisi kriptoOdeme,
        ILogger<SiparislerController> log)
    {
        _db = db;
        _atolye = atolye;
        _kartOdeme = kartOdeme;
        _kriptoOdeme = kriptoOdeme;
        _log = log;
    }

    // ================= Müşteri tarafı =================

    // POST api/siparisler
    // Sepetteki ürünlerden sipariş oluşturur. Ödeme ayrı bir adımda alınır.
    [HttpPost]
    public async Task<ActionResult<SiparisDto>> Olustur(SiparisOlusturIstegi istek)
    {
        var siparis = new Siparis
        {
            SiparisNo = "ES" + RandomNumberGenerator.GetString(SiparisNoKarakterleri, 8),
            OlusturmaTarihi = DateTime.UtcNow,
            AdSoyad = istek.Teslimat.AdSoyad.Trim(),
            Eposta = istek.Teslimat.Eposta.Trim().ToLowerInvariant(),
            Telefon = istek.Teslimat.Telefon.Trim(),
            Adres = istek.Teslimat.Adres.Trim(),
            Sehir = istek.Teslimat.Sehir.Trim(),
        };

        // 1) Katalog ürünleri: fiyat ve stok veritabanından okunur
        var istenenAdetler = istek.Kalemler
            .Where(k => k.ParfumId.HasValue)
            .GroupBy(k => k.ParfumId!.Value)
            .ToDictionary(g => g.Key, g => g.Sum(k => k.Adet));

        var idler = istenenAdetler.Keys.ToList();
        var parfumler = await _db.Parfumler
            .Include(p => p.Marka)
            .Where(p => idler.Contains(p.Id))
            .ToListAsync();

        foreach (var (parfumId, adet) in istenenAdetler)
        {
            var parfum = parfumler.FirstOrDefault(p => p.Id == parfumId);
            if (parfum is null)
                return BadRequest($"{parfumId} numaralı parfüm artık satışta değil.");

            if (parfum.Stok < adet)
                return BadRequest(parfum.Stok == 0
                    ? $"\"{parfum.Ad}\" tükendi."
                    : $"\"{parfum.Ad}\" için yeterli stok yok (kalan: {parfum.Stok}).");

            siparis.Kalemler.Add(new SiparisKalemi
            {
                ParfumId = parfum.Id,
                Ad = parfum.Ad,
                Marka = parfum.Marka!.Ad,
                Aciklama = $"{parfum.Konsantrasyon} · {parfum.HacimMl} ml",
                BirimFiyat = parfum.Fiyat,
                Adet = adet,
                Tutar = parfum.Fiyat * adet,
            });
        }

        // 2) Atölyede tasarlanan özel parfümler: fiyat, atölye servisiyle yeniden hesaplanır
        foreach (var kalem in istek.Kalemler.Where(k => !k.ParfumId.HasValue))
        {
            if (kalem.Ozel is null)
                return BadRequest("Her kalemde bir parfüm ya da özel parfüm bilgisi olmalı.");

            if (kalem.Ozel.HacimMl is not (30 or 50 or 100) ||
                kalem.Ozel.Konsantrasyon is not ("Eau de Toilette" or "Eau de Parfum" or "Extrait de Parfum"))
                return BadRequest($"\"{kalem.Ozel.Ad}\" için hacim ya da konsantrasyon geçersiz.");

            var esansIdleri = kalem.Ozel.EsansIdleri.Distinct().ToList();
            if (esansIdleri.Count < 2)
                return BadRequest($"\"{kalem.Ozel.Ad}\" için en az 2 esans seçilmeli.");

            var (degerlendirme, hata) = await _atolye.Degerlendir(new DegerlendirmeIstegi
            {
                EsansIdleri = esansIdleri,
                Konsantrasyon = kalem.Ozel.Konsantrasyon,
                HacimMl = kalem.Ozel.HacimMl,
            });
            if (hata is not null)
                return BadRequest(hata);

            var esansAdlari = await _db.Esanslar
                .Where(e => esansIdleri.Contains(e.Id))
                .OrderBy(e => e.Id)
                .Select(e => e.Ad)
                .ToListAsync();

            siparis.Kalemler.Add(new SiparisKalemi
            {
                Ad = kalem.Ozel.Ad.Trim(),
                Marka = "Esans Atölye",
                Aciklama = $"{kalem.Ozel.Konsantrasyon} · {kalem.Ozel.HacimMl} ml · {string.Join(", ", esansAdlari)}",
                BirimFiyat = degerlendirme!.Fiyat,
                Adet = kalem.Adet,
                Tutar = degerlendirme.Fiyat * kalem.Adet,
            });
        }

        // 3) Tutarlar
        siparis.AraToplam = siparis.Kalemler.Sum(k => k.Tutar);
        siparis.KargoUcreti = siparis.AraToplam >= UcretsizKargoSiniri ? 0m : StandartKargoUcreti;
        siparis.Toplam = siparis.AraToplam + siparis.KargoUcreti;

        _db.Siparisler.Add(siparis);
        await _db.SaveChangesAsync();

        _log.LogInformation("Sipariş oluşturuldu: {SiparisNo}, toplam {Toplam} TL", siparis.SiparisNo, siparis.Toplam);

        return CreatedAtAction(nameof(Getir),
            new { siparisNo = siparis.SiparisNo, eposta = siparis.Eposta },
            DtoyaCevir(siparis));
    }

    // GET api/siparisler/ES7K2M9QXA?eposta=...
    // Sipariş takibi: numara ve e-posta birlikte doğruysa gösterilir
    [HttpGet("{siparisNo}")]
    public async Task<ActionResult<SiparisDto>> Getir(string siparisNo, [FromQuery] string eposta)
    {
        var siparis = await SiparisBul(siparisNo, eposta);
        if (siparis is null)
            return NotFound("Bu numara ve e-postayla eşleşen bir sipariş bulunamadı.");

        return DtoyaCevir(siparis);
    }

    // POST api/siparisler/ES7K2M9QXA/odeme/kart
    [HttpPost("{siparisNo}/odeme/kart")]
    public async Task<ActionResult<SiparisDto>> KartIleOde(string siparisNo, KartOdemeIstegi istek)
    {
        var siparis = await SiparisBul(siparisNo, istek.Eposta);
        if (siparis is null)
            return NotFound("Sipariş bulunamadı.");

        if (siparis.Durum != SiparisDurumlari.OdemeBekliyor)
            return Conflict("Bu siparişin ödemesi zaten alınmış ya da sipariş iptal edilmiş.");

        var tarihHatasi = SonKullanmaKontrol(istek.SonKullanma);
        if (tarihHatasi is not null)
            return BadRequest(tarihHatasi);

        // Para çekmeden önce stok hâlâ yeterli mi? (Çektikten sonra stok yoksa iade gerekir)
        var stokHatasi = await StokKontrol(siparis);
        if (stokHatasi is not null)
            return Conflict(stokHatasi);

        var sonuc = await _kartOdeme.Ode(siparis,
            new KartBilgisi(istek.KartSahibi, istek.KartNo, istek.SonKullanma, istek.Cvc));

        if (!sonuc.Basarili)
        {
            _log.LogInformation("Kart ödemesi başarısız: {SiparisNo}", siparis.SiparisNo);
            return StatusCode(StatusCodes.Status402PaymentRequired, sonuc.HataMesaji);
        }

        var numara = new string(istek.KartNo.Where(char.IsDigit).ToArray());
        var hata = await OdemeyiTamamla(siparis, "Kart", sonuc.Referans!, numara[^4..]);
        if (hata is not null)
        {
            // Gerçek bir sistemde burada çekilen para iade edilir
            _log.LogWarning("Ödeme alındı ama stok yetmedi, iade gerekir: {SiparisNo}", siparis.SiparisNo);
            return Conflict(hata);
        }

        return DtoyaCevir(siparis);
    }

    // POST api/siparisler/ES7K2M9QXA/odeme/kripto
    // Kripto ödeme faturası oluşturur (simülasyon)
    [HttpPost("{siparisNo}/odeme/kripto")]
    public async Task<ActionResult<SiparisDto>> KriptoFaturaOlustur(string siparisNo, KriptoOdemeIstegi istek)
    {
        var siparis = await SiparisBul(siparisNo, istek.Eposta);
        if (siparis is null)
            return NotFound("Sipariş bulunamadı.");

        if (siparis.Durum != SiparisDurumlari.OdemeBekliyor)
            return Conflict("Bu siparişin ödemesi zaten alınmış ya da sipariş iptal edilmiş.");

        var fatura = _kriptoOdeme.FaturaOlustur(siparis, istek.Para);

        siparis.OdemeYontemi = "Kripto";
        siparis.KriptoPara = fatura.Para;
        siparis.KriptoTutar = fatura.Tutar;
        siparis.KriptoAdres = fatura.Adres;
        siparis.KriptoSonTarih = fatura.SonTarih;
        await _db.SaveChangesAsync();

        return DtoyaCevir(siparis);
    }

    // POST api/siparisler/ES7K2M9QXA/odeme/kripto/simule-et
    // Gerçekte blokzinciri izlenir; burada "para geldi" anını bir düğmeyle taklit ediyoruz
    [HttpPost("{siparisNo}/odeme/kripto/simule-et")]
    public async Task<ActionResult<SiparisDto>> KriptoOdemesiniSimuleEt(string siparisNo, EpostaIstegi istek)
    {
        if (!_kriptoOdeme.SimulasyonMu)
            return NotFound();

        var siparis = await SiparisBul(siparisNo, istek.Eposta);
        if (siparis is null)
            return NotFound("Sipariş bulunamadı.");

        if (siparis.Durum != SiparisDurumlari.OdemeBekliyor)
            return Conflict("Bu siparişin ödemesi zaten alınmış ya da sipariş iptal edilmiş.");

        if (siparis.KriptoAdres is null || siparis.KriptoSonTarih is null)
            return BadRequest("Önce bir kripto ödeme faturası oluşturulmalı.");

        if (siparis.KriptoSonTarih < DateTime.UtcNow)
            return BadRequest("Faturanın süresi doldu. Yeni bir fatura oluştur.");

        var referans = "DEMO-TX-" + RandomNumberGenerator.GetHexString(16, lowercase: true);
        var hata = await OdemeyiTamamla(siparis, "Kripto", referans, null);
        if (hata is not null)
            return Conflict(hata);

        return DtoyaCevir(siparis);
    }

    // ================= Yönetici tarafı =================

    // GET api/siparisler?sayfa=1&boyut=20&durum=Ödendi
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SayfaliSonuc<SiparisDto>>> Listele(
        [FromQuery] int sayfa = 1, [FromQuery] int boyut = 20, [FromQuery] string? durum = null)
    {
        sayfa = Math.Max(1, sayfa);
        boyut = Math.Clamp(boyut, 1, 50);

        var sorgu = _db.Siparisler.AsQueryable();
        if (!string.IsNullOrWhiteSpace(durum))
            sorgu = sorgu.Where(s => s.Durum == durum);

        var toplam = await sorgu.CountAsync();
        var siparisler = await sorgu
            .Include(s => s.Kalemler)
            .OrderByDescending(s => s.Id)
            .Skip((sayfa - 1) * boyut)
            .Take(boyut)
            .ToListAsync();

        return new SayfaliSonuc<SiparisDto>(
            siparisler.Select(DtoyaCevir).ToList(),
            toplam, sayfa, boyut, (int)Math.Ceiling(toplam / (double)boyut));
    }

    // PUT api/siparisler/12/durum
    [HttpPut("{id:int}/durum")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SiparisDto>> DurumGuncelle(int id, DurumGuncelleIstegi istek)
    {
        var siparis = await _db.Siparisler.Include(s => s.Kalemler).FirstOrDefaultAsync(s => s.Id == id);
        if (siparis is null)
            return NotFound("Sipariş bulunamadı.");

        var izinli = SiparisDurumlari.IzinliGecisler.GetValueOrDefault(siparis.Durum, []);
        if (!izinli.Contains(istek.Durum))
            return BadRequest($"\"{siparis.Durum}\" durumundaki sipariş \"{istek.Durum}\" yapılamaz.");

        await using var islem = await _db.Database.BeginTransactionAsync();

        // Ödenmiş bir sipariş iptal edilirse ürünler stoğa geri döner
        if (istek.Durum == SiparisDurumlari.IptalEdildi &&
            SiparisDurumlari.StokDusulmusDurumlar.Contains(siparis.Durum))
        {
            foreach (var kalem in siparis.Kalemler.Where(k => k.ParfumId.HasValue))
            {
                await _db.Parfumler
                    .Where(p => p.Id == kalem.ParfumId)
                    .ExecuteUpdateAsync(s => s.SetProperty(p => p.Stok, p => p.Stok + kalem.Adet));
            }
        }

        siparis.Durum = istek.Durum;
        await _db.SaveChangesAsync();
        await islem.CommitAsync();

        return DtoyaCevir(siparis);
    }

    // ================= Yardımcılar =================

    private async Task<Siparis?> SiparisBul(string siparisNo, string? eposta)
    {
        if (string.IsNullOrWhiteSpace(eposta))
            return null;

        var temizEposta = eposta.Trim().ToLowerInvariant();
        return await _db.Siparisler
            .Include(s => s.Kalemler)
            .FirstOrDefaultAsync(s => s.SiparisNo == siparisNo.ToUpperInvariant() && s.Eposta == temizEposta);
    }

    private async Task<string?> StokKontrol(Siparis siparis)
    {
        foreach (var kalem in siparis.Kalemler.Where(k => k.ParfumId.HasValue))
        {
            var stok = await _db.Parfumler
                .Where(p => p.Id == kalem.ParfumId)
                .Select(p => (int?)p.Stok)
                .FirstOrDefaultAsync();

            if (stok is null || stok < kalem.Adet)
                return $"\"{kalem.Ad}\" için artık yeterli stok yok.";
        }
        return null;
    }

    // Ödeme alındıktan sonra stoğu düşer ve siparişi "Ödendi" yapar.
    // Hepsi tek bir transaction içinde: ya tamamı olur ya hiçbiri.
    private async Task<string?> OdemeyiTamamla(Siparis siparis, string yontem, string referans, string? kartSonDort)
    {
        await using var islem = await _db.Database.BeginTransactionAsync();

        foreach (var kalem in siparis.Kalemler.Where(k => k.ParfumId.HasValue))
        {
            // Koşullu güncelleme: "stok yeterliyse düş". Kontrol ve düşme tek SQL komutunda olduğu için
            // aynı anda gelen iki sipariş son ürünü birlikte satın alamaz.
            var etkilenen = await _db.Parfumler
                .Where(p => p.Id == kalem.ParfumId && p.Stok >= kalem.Adet)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.Stok, p => p.Stok - kalem.Adet));

            if (etkilenen == 0)
            {
                await islem.RollbackAsync();
                return $"\"{kalem.Ad}\" için stok tükendi.";
            }
        }

        siparis.Durum = SiparisDurumlari.Odendi;
        siparis.OdemeYontemi = yontem;
        siparis.OdemeReferansi = referans;
        siparis.OdemeTarihi = DateTime.UtcNow;
        siparis.KartSonDortHane = kartSonDort;

        await _db.SaveChangesAsync();
        await islem.CommitAsync();

        _log.LogInformation("Ödeme alındı: {SiparisNo} ({Yontem})", siparis.SiparisNo, yontem);
        return null;
    }

    private static string? SonKullanmaKontrol(string sonKullanma)
    {
        var parcalar = sonKullanma.Split('/');
        var ay = int.Parse(parcalar[0]);
        var yil = 2000 + int.Parse(parcalar[1]);

        // Kart, yazan ayın son gününe kadar geçerlidir
        var sonGun = new DateTime(yil, ay, 1).AddMonths(1);
        return sonGun <= DateTime.Today ? "Kartın son kullanma tarihi geçmiş." : null;
    }

    // SQLite tarihleri "türsüz" döndürür; hepsini UTC olarak işaretliyoruz ki tarayıcı doğru saate çevirsin
    private static DateTime Utc(DateTime tarih) => DateTime.SpecifyKind(tarih, DateTimeKind.Utc);

    private static SiparisDto DtoyaCevir(Siparis s)
    {
        KriptoFaturaDto? kripto = null;
        if (s.KriptoAdres is not null && s.KriptoPara is not null && s.KriptoTutar is not null && s.KriptoSonTarih is not null)
        {
            var kur = s.KriptoTutar.Value == 0 ? 0 : Math.Round(s.Toplam / s.KriptoTutar.Value, 2);
            kripto = new KriptoFaturaDto(s.KriptoPara, s.KriptoTutar.Value, kur, s.KriptoAdres, Utc(s.KriptoSonTarih.Value), true);
        }

        return new SiparisDto(
            s.Id,
            s.SiparisNo,
            Utc(s.OlusturmaTarihi),
            s.Durum,
            s.AdSoyad,
            s.Eposta,
            s.Telefon,
            s.Adres,
            s.Sehir,
            s.AraToplam,
            s.KargoUcreti,
            s.Toplam,
            s.OdemeYontemi,
            s.KartSonDortHane,
            s.OdemeTarihi is null ? null : Utc(s.OdemeTarihi.Value),
            kripto,
            SiparisDurumlari.IzinliGecisler.GetValueOrDefault(s.Durum, []),
            s.Kalemler
                .OrderBy(k => k.Id)
                .Select(k => new SiparisKalemiDto(k.ParfumId, k.Ad, k.Marka, k.Aciklama, k.BirimFiyat, k.Adet, k.Tutar))
                .ToList());
    }
}
