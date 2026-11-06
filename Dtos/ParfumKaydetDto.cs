using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

public class ParfumKaydetDto
{
    [Required(ErrorMessage = "Ad zorunludur.")]
    [StringLength(100)]
    public string Ad { get; set; } = "";

    [StringLength(500)]
    public string Aciklama { get; set; } = "";

    [Range(typeof(decimal), "1", "100000", ErrorMessage = "Fiyat 1 ile 100.000 arasında olmalı.")]
    public decimal Fiyat { get; set; }

    [Range(typeof(decimal), "1", "100000", ErrorMessage = "Eski fiyat 1 ile 100.000 arasında olmalı.")]
    public decimal? EskiFiyat { get; set; }

    [Range(1, 500, ErrorMessage = "Hacim 1 ile 500 ml arasında olmalı.")]
    public int HacimMl { get; set; }

    [Required]
    [RegularExpression("^(Kadın|Erkek|Unisex)$", ErrorMessage = "Cinsiyet Kadın, Erkek veya Unisex olmalı.")]
    public string Cinsiyet { get; set; } = "";

    [Range(0, 10000)]
    public int Stok { get; set; }

    [Required]
    [RegularExpression("^(Çiçeksi|Odunsu|Oryantal|Ferah|Gurme|Aromatik)$",
        ErrorMessage = "Koku ailesi Çiçeksi, Odunsu, Oryantal, Ferah, Gurme veya Aromatik olmalı.")]
    public string KokuAilesi { get; set; } = "";

    [Required]
    [RegularExpression("^(Eau de Toilette|Eau de Parfum|Extrait de Parfum)$",
        ErrorMessage = "Konsantrasyon Eau de Toilette, Eau de Parfum veya Extrait de Parfum olmalı.")]
    public string Konsantrasyon { get; set; } = "";

    [StringLength(200)]
    public string UstNotalar { get; set; } = "";

    [StringLength(200)]
    public string KalpNotalar { get; set; } = "";

    [StringLength(200)]
    public string AltNotalar { get; set; } = "";

    [RegularExpression("^#[0-9A-Fa-f]{6}$", ErrorMessage = "Renk #RRGGBB biçiminde olmalı.")]
    public string Renk { get; set; } = "#c9a77c";

    [Range(0, 4, ErrorMessage = "Şişe tipi 0 ile 4 arasında olmalı.")]
    public int SiseTipi { get; set; }

    public bool Yeni { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir marka seçilmeli.")]
    public int MarkaId { get; set; }
}
