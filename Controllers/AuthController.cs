using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;
using ParfumApi.Dtos;
using ParfumApi.Models;
using ParfumApi.Services;

namespace ParfumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly TokenServisi _tokenServisi;

    public AuthController(AppDbContext db, TokenServisi tokenServisi)
    {
        _db = db;
        _tokenServisi = tokenServisi;
    }

    // POST api/auth/giris
    [HttpPost("giris")]
    public async Task<ActionResult<GirisSonucDto>> Giris(GirisDto dto)
    {
        var kullanici = await _db.Kullanicilar
            .FirstOrDefaultAsync(k => k.KullaniciAdi == dto.KullaniciAdi);

        // Kullanıcı yoksa da, şifre yanlışsa da aynı mesaj: hangisinin yanlış olduğunu belli etmiyoruz
        if (kullanici is null)
            return Unauthorized("Kullanıcı adı veya şifre hatalı.");

        var sonuc = new PasswordHasher<Kullanici>()
            .VerifyHashedPassword(kullanici, kullanici.SifreHash, dto.Sifre);

        if (sonuc == PasswordVerificationResult.Failed)
            return Unauthorized("Kullanıcı adı veya şifre hatalı.");

        var (token, bitis) = _tokenServisi.Uret(kullanici);
        return new GirisSonucDto(token, kullanici.KullaniciAdi, bitis);
    }
}
