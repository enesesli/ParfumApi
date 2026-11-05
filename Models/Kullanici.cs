namespace ParfumApi.Models;

public class Kullanici
{
    public int Id { get; set; }
    public string KullaniciAdi { get; set; } = "";

    // Şifre asla düz metin saklanmaz, sadece hash'i tutulur
    public string SifreHash { get; set; } = "";

    public string Rol { get; set; } = "Admin";
}
