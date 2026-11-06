using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

public class ParfumSorgu
{
    public string? Ara { get; set; }
    public int? MarkaId { get; set; }
    public string? Cinsiyet { get; set; }
    public string? KokuAilesi { get; set; }
    public string? Konsantrasyon { get; set; }
    public decimal? MinFiyat { get; set; }
    public decimal? MaxFiyat { get; set; }

    // true: sadece yeni gelenler / sadece indirimdekiler
    public bool? Yeni { get; set; }
    public bool? Indirimli { get; set; }

    // "fiyat", "fiyat_azalan", "ad", "yeni"
    public string? Sirala { get; set; }

    [Range(1, int.MaxValue)]
    public int Sayfa { get; set; } = 1;

    [Range(1, 50)]
    public int Boyut { get; set; } = 12;
}
