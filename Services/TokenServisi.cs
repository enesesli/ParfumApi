using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ParfumApi.Models;

namespace ParfumApi.Services;

public class TokenServisi
{
    private readonly IConfiguration _ayarlar;

    public TokenServisi(IConfiguration ayarlar)
    {
        _ayarlar = ayarlar;
    }

    public (string Token, DateTime Bitis) Uret(Kullanici kullanici)
    {
        var bitis = DateTime.UtcNow.AddHours(2);

        var anahtar = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_ayarlar["Jwt:Key"]!));

        var tanim = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
                new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                new Claim(ClaimTypes.Role, kullanici.Rol),
            }),
            Expires = bitis,
            Issuer = _ayarlar["Jwt:Issuer"],
            Audience = _ayarlar["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(anahtar, SecurityAlgorithms.HmacSha256),
        };

        var token = new JsonWebTokenHandler().CreateToken(tanim);
        return (token, bitis);
    }
}
