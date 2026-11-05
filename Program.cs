using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParfumApi.Data;
using ParfumApi.Models;
using ParfumApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5180")
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

var app = builder.Build();

// İlk çalıştırmada admin kullanıcısını oluştur (bilgiler user secrets'tan gelir)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
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

// Sıra önemli: önce "kimsin?" (authentication), sonra "yetkin var mı?" (authorization)
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
