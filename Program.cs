using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParfumApi.Data;
using ParfumApi.Models;
using ParfumApi.Services;
using ParfumApi.Services.Odeme;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// İzin verilen ön yüz adresleri ayardan okunur:
// yerelde appsettings.json'dan, canlıda sunucunun ortam değişkenlerinden
var izinliAdresler = builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(izinliAdresler)
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var jwtAnahtar = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key ayarı bulunamadı. 'dotnet user-secrets list' ile kontrol et.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAnahtar)),
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenServisi>();
builder.Services.AddScoped<IKokuAtolyesiServisi, KokuAtolyesiServisi>();

// Ödeme sağlayıcıları: hangisinin kullanılacağı appsettings.json'daki "Odeme" bölümünden okunur.
// Controller sadece interface'i bilir; sağlayıcı değişince başka hiçbir kod değişmez.
var kartSaglayici = builder.Configuration["Odeme:KartSaglayici"] ?? "Sahte";
switch (kartSaglayici)
{
    case "Sahte":
        builder.Services.AddScoped<IKartOdemeServisi, SahteKartOdemeServisi>();
        break;
    default:
        throw new InvalidOperationException($"Bilinmeyen kart ödeme sağlayıcısı: {kartSaglayici}");
}

// Türkiye'de kripto ile ödeme yasak olduğu için yalnızca simülasyon var
builder.Services.AddSingleton<IKriptoOdemeServisi, SimuleKriptoOdemeServisi>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Bekleyen migration'ları uygula. Canlı sunucuda veritabanı böylece kendiliğinden kurulur;
    // yerelde her şey güncelse hiçbir şey yapmaz.
    db.Database.Migrate();

    // İlk çalıştırmada admin kullanıcısını oluştur (bilgiler user secrets'tan / ortam değişkenlerinden gelir)
    var adminAdi = app.Configuration["Admin:KullaniciAdi"];
    var adminSifre = app.Configuration["Admin:Sifre"];

    if (!string.IsNullOrWhiteSpace(adminAdi) &&
        !string.IsNullOrWhiteSpace(adminSifre) &&
        !db.Kullanicilar.Any())
    {
        var admin = new Kullanici { KullaniciAdi = adminAdi, Rol = "Admin" };
        admin.SifreHash = new PasswordHasher<Kullanici>().HashPassword(admin, adminSifre);
        db.Kullanicilar.Add(admin);
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// wwwroot klasöründeki dosyaları (yüklenen ürün görselleri) doğrudan sunar: /gorseller/...
app.UseStaticFiles();

// Sıra önemli: önce "kimsin?" (authentication), sonra "yetkin var mı?" (authorization)
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Sunucunun ayakta olup olmadığını kontrol etmek için basit bir adres
app.MapGet("/saglik", () => Results.Ok(new { durum = "çalışıyor", zaman = DateTime.UtcNow }));

app.Run();

// Test projesindeki WebApplicationFactory<Program> bu sınıfa erişebilsin diye
public partial class Program { }
