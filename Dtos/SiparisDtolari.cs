using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

// ----- İstekler -----

public class TeslimatBilgisi
{
    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    [StringLength(100)]
    public string AdSoyad { get; set; } = "";

    [Required(ErrorMessage = "E-posta zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi gir.")]
    public string Eposta { get; set; } = "";

    [Required(ErrorMessage = "Telefon zorunludur.")]
    [RegularExpression(@"^[0-9 +()\-]{10,20}$", ErrorMessage = "Geçerli bir telefon numarası gir.")]
    public string Telefon { get; set; } = "";

    [Required(ErrorMessage = "Adres zorunludur.")]
    [StringLength(300, MinimumLength = 10, ErrorMessage = "Adres 10 ile 300 karakter arasında olmalı.")]
    public string Adres { get; set; } = "";

    [Required(ErrorMessage = "Şehir zorunludur.")]
    [StringLength(50)]
    public string Sehir { get; set; } = "";
}

public class OzelParfumIstegi
{
    [Required]
    [StringLength(40)]
    public string Ad { get; set; } = "";

    public List<int> EsansIdleri { get; set; } = new();
    public string Konsantrasyon { get; set; } = "Eau de Parfum";
    public int HacimMl { get; set; } = 50;
}

public class SepetKalemiIstegi
{
    // Ya katalogdan bir parfüm ya da atölyede tasarlanmış özel parfüm
    public int? ParfumId { get; set; }
    public OzelParfumIstegi? Ozel { get; set; }

    [Range(1, 10, ErrorMessage = "Bir üründen en fazla 10 adet alınabilir.")]
    public int Adet { get; set; } = 1;
}

public class SiparisOlusturIstegi
{
    [Required]
    public TeslimatBilgisi Teslimat { get; set; } = new();

    [MinLength(1, ErrorMessage = "Sepet boş.")]
    [MaxLength(30)]
    public List<SepetKalemiIstegi> Kalemler { get; set; } = new();
}

public class KartOdemeIstegi
{
    [Required] public string Eposta { get; set; } = "";

    [Required(ErrorMessage = "Kart üzerindeki isim zorunludur.")]
    public string KartSahibi { get; set; } = "";

    [Required(ErrorMessage = "Kart numarası zorunludur.")]
    public string KartNo { get; set; } = "";

    [RegularExpression(@"^(0[1-9]|1[0-2])/\d{2}$", ErrorMessage = "Son kullanma tarihi AA/YY biçiminde olmalı.")]
    public string SonKullanma { get; set; } = "";

    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVC 3 ya da 4 haneli olmalı.")]
    public string Cvc { get; set; } = "";
}

public class KriptoOdemeIstegi
{
    [Required] public string Eposta { get; set; } = "";

    [RegularExpression("^(USDT|BTC|ETH)$", ErrorMessage = "Para birimi USDT, BTC ya da ETH olmalı.")]
    public string Para { get; set; } = "USDT";
}

public class EpostaIstegi
{
    [Required] public string Eposta { get; set; } = "";
}

public class DurumGuncelleIstegi
{
    [Required] public string Durum { get; set; } = "";
}

// ----- Cevaplar -----

public record SiparisKalemiDto(
    int? ParfumId,
    string Ad,
    string Marka,
    string Aciklama,
    decimal BirimFiyat,
    int Adet,
    decimal Tutar);

public record KriptoFaturaDto(
    string Para,
    decimal Tutar,
    decimal Kur,
    string Adres,
    DateTime SonTarih,
    bool Simulasyon);

public record SiparisDto(
    int Id,
    string SiparisNo,
    DateTime OlusturmaTarihi,
    string Durum,
    string AdSoyad,
    string Eposta,
    string Telefon,
    string Adres,
    string Sehir,
    decimal AraToplam,
    decimal KargoUcreti,
    decimal Toplam,
    string? OdemeYontemi,
    string? KartSonDortHane,
    DateTime? OdemeTarihi,
    KriptoFaturaDto? Kripto,
    string[] SonrakiDurumlar,
    List<SiparisKalemiDto> Kalemler);
