using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

public class ParfumSorgu
{
    public string? Ara { get; set; }
    public int? MarkaId { get; set; }
    public string? Cinsiyet { get; set; }
    public decimal? MinFiyat { get; set; }
    public decimal? MaxFiyat { get; set; }

    // "fiyat", "fiyat_azalan", "ad"
    public string? Sirala { get; set; }

    [Range(1, int.MaxValue)]
    public int Sayfa { get; set; } = 1;

    [Range(1, 50)]
    public int Boyut { get; set; } = 6;
}
