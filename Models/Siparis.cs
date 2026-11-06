namespace ParfumApi.Models;

// Sipariş durumları ve aralarındaki izinli geçişler tek yerde
public static class SiparisDurumlari
{
    public const string OdemeBekliyor = "Ödeme bekliyor";
    public const string Odendi = "Ödendi";
    public const string Hazirlaniyor = "Hazırlanıyor";
    public const string Kargoda = "Kargoda";
    public const string TeslimEdildi = "Teslim edildi";
    public const string IptalEdildi = "İptal edildi";

    // Yönetici bir siparişi hangi durumdan hangisine taşıyabilir?
    public static readonly Dictionary<string, string[]> IzinliGecisler = new()
    {
        [OdemeBekliyor] = [IptalEdildi],
        [Odendi] = [Hazirlaniyor, IptalEdildi],
        [Hazirlaniyor] = [Kargoda, IptalEdildi],
        [Kargoda] = [TeslimEdildi],
        [TeslimEdildi] = [],
        [IptalEdildi] = [],
    };

    // Bu durumlardayken iptal edilirse düşülen stok geri eklenir
    public static readonly string[] StokDusulmusDurumlar = [Odendi, Hazirlaniyor];
}

public class Siparis
{
    public int Id { get; set; }

    // Müşteriye gösterilen, tahmin edilmesi zor numara (ör. "ES7K2M9QXA")
    public string SiparisNo { get; set; } = "";

    public DateTime OlusturmaTarihi { get; set; }
    public string Durum { get; set; } = SiparisDurumlari.OdemeBekliyor;

    // Teslimat bilgileri
    public string AdSoyad { get; set; } = "";
    public string Eposta { get; set; } = "";
    public string Telefon { get; set; } = "";
    public string Adres { get; set; } = "";
    public string Sehir { get; set; } = "";

    // Tutarlar: hepsi sunucuda hesaplanır, tarayıcıdan gelen fiyata güvenilmez
    public decimal AraToplam { get; set; }
    public decimal KargoUcreti { get; set; }
    public decimal Toplam { get; set; }

    // Ödeme
    public string? OdemeYontemi { get; set; }      // "Kart" ya da "Kripto"
    public string? OdemeReferansi { get; set; }    // ödeme kuruluşunun işlem numarası
    public DateTime? OdemeTarihi { get; set; }
    public string? KartSonDortHane { get; set; }   // kartın tamamı asla saklanmaz

    // Kripto ödeme (simülasyon)
    public string? KriptoPara { get; set; }
    public decimal? KriptoTutar { get; set; }
    public decimal? KriptoKur { get; set; }        // fatura anında sabitlenen kur (1 birim = ? TL)
    public string? KriptoAdres { get; set; }
    public DateTime? KriptoSonTarih { get; set; }

    public List<SiparisKalemi> Kalemler { get; set; } = new();
}

public class SiparisKalemi
{
    public int Id { get; set; }
    public int SiparisId { get; set; }

    // Katalog ürünüyse parfümün numarası; atölyede tasarlanan özel parfümde boş
    public int? ParfumId { get; set; }

    // Sipariş anındaki bilgilerin kopyası: ürün sonradan değişse de sipariş aynı kalır
    public string Ad { get; set; } = "";
    public string Marka { get; set; } = "";
    public string Aciklama { get; set; } = "";
    public decimal BirimFiyat { get; set; }
    public int Adet { get; set; }
    public decimal Tutar { get; set; }
}
