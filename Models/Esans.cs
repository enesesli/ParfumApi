namespace ParfumApi.Models;

// Koku atölyesinde kullanıcının seçebildiği tek bir esans (nota)
public class Esans
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";

    // "Üst", "Kalp" veya "Alt": parfümün hangi katmanında yer aldığı
    public string Katman { get; set; } = "";

    // Uyum hesabında kullanılan aile: Narenciye, Meyveli, Yeşil, Çiçeksi, Baharatlı,
    // Aromatik, Odunsu, Reçineli, Gurme, Misk
    public string Aile { get; set; } = "";

    public string Aciklama { get; set; } = "";
    public string Renk { get; set; } = "#c9a77c";

    // 50 ml'lik bir parfüme bu esansın eklediği fiyat
    public decimal EkFiyat { get; set; }
}
