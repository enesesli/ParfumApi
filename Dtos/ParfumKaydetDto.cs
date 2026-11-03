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

    [Range(1, 500, ErrorMessage = "Hacim 1 ile 500 ml arasında olmalı.")]
    public int HacimMl { get; set; }

    [Required]
    [RegularExpression("^(Kadın|Erkek|Unisex)$", ErrorMessage = "Cinsiyet Kadın, Erkek veya Unisex olmalı.")]
    public string Cinsiyet { get; set; } = "";

    [Range(0, 10000)]
    public int Stok { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir marka seçilmeli.")]
    public int MarkaId { get; set; }
}