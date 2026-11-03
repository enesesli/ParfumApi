namespace ParfumApi.Models;

public class Parfum
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";
    public string Aciklama { get; set; } = "";
    public decimal Fiyat { get; set; }
    public int HacimMl { get; set; }
    public string Cinsiyet { get; set; } = "";   // "Kadın", "Erkek", "Unisex"
    public int Stok { get; set; }

    public int MarkaId { get; set; }
    public Marka? Marka { get; set; }
}