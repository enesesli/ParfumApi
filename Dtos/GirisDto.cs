using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

public class GirisDto
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    public string KullaniciAdi { get; set; } = "";

    [Required(ErrorMessage = "Şifre zorunludur.")]
    public string Sifre { get; set; } = "";
}

public record GirisSonucDto(string Token, string KullaniciAdi, DateTime Bitis);
