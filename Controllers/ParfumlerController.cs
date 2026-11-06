using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;
using ParfumApi.Dtos;
using ParfumApi.Models;

namespace ParfumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParfumlerController : ControllerBase
{
    private const long EnBuyukGorselBoyutu = 5 * 1024 * 1024; // 5 MB
    private static readonly string[] IzinliUzantilar = [".jpg", ".jpeg", ".png", ".webp"];

    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _ortam;

    public ParfumlerController(AppDbContext db, IWebHostEnvironment ortam)
    {
        _db = db;
        _ortam = ortam;
    }

    // GET api/parfumler?ara=...&markaId=...&cinsiyet=...&kokuAilesi=...&konsantrasyon=...
    //                  &minFiyat=...&maxFiyat=...&yeni=true&indirimli=true&sirala=...&sayfa=...&boyut=...
    [HttpGet]
    public async Task<ActionResult<SayfaliSonuc<ParfumDto>>> Listele([FromQuery] ParfumSorgu s)
    {
        var sorgu = _db.Parfumler.AsQueryable();

        // 1) Filtreler
        if (!string.IsNullOrWhiteSpace(s.Ara))
        {
            var ara = s.Ara.Trim().ToLower();
            sorgu = sorgu.Where(p =>
                p.Ad.ToLower().Contains(ara) ||
                p.Marka!.Ad.ToLower().Contains(ara) ||
                p.UstNotalar.ToLower().Contains(ara) ||
                p.KalpNotalar.ToLower().Contains(ara) ||
                p.AltNotalar.ToLower().Contains(ara));
        }

        if (s.MarkaId.HasValue)
            sorgu = sorgu.Where(p => p.MarkaId == s.MarkaId);

        if (!string.IsNullOrWhiteSpace(s.Cinsiyet))
            sorgu = sorgu.Where(p => p.Cinsiyet == s.Cinsiyet);

        if (!string.IsNullOrWhiteSpace(s.KokuAilesi))
            sorgu = sorgu.Where(p => p.KokuAilesi == s.KokuAilesi);

        if (!string.IsNullOrWhiteSpace(s.Konsantrasyon))
            sorgu = sorgu.Where(p => p.Konsantrasyon == s.Konsantrasyon);

        if (s.MinFiyat.HasValue)
            sorgu = sorgu.Where(p => p.Fiyat >= s.MinFiyat);

        if (s.MaxFiyat.HasValue)
            sorgu = sorgu.Where(p => p.Fiyat <= s.MaxFiyat);

        if (s.Yeni == true)
            sorgu = sorgu.Where(p => p.Yeni);

        if (s.Indirimli == true)
            sorgu = sorgu.Where(p => p.EskiFiyat != null);

        // 2) Sıralama
        sorgu = s.Sirala switch
        {
            "fiyat" => sorgu.OrderBy(p => p.Fiyat),
            "fiyat_azalan" => sorgu.OrderByDescending(p => p.Fiyat),
            "ad" => sorgu.OrderBy(p => p.Ad),
            "yeni" => sorgu.OrderByDescending(p => p.Id),
            _ => sorgu.OrderBy(p => p.Id)
        };

        // 3) Sayfalama
        var toplam = await sorgu.CountAsync();

        var veriler = await DtoyaCevir(sorgu
                .Skip((s.Sayfa - 1) * s.Boyut)
                .Take(s.Boyut))
            .ToListAsync();

        var toplamSayfa = (int)Math.Ceiling(toplam / (double)s.Boyut);

        return new SayfaliSonuc<ParfumDto>(veriler, toplam, s.Sayfa, s.Boyut, toplamSayfa);
    }

    // GET api/parfumler/3
    [HttpGet("{id}")]
    public async Task<ActionResult<ParfumDto>> Getir(int id)
    {
        var parfum = await DtoyaCevir(_db.Parfumler.Where(p => p.Id == id))
            .FirstOrDefaultAsync();

        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        return parfum;
    }

    // POST api/parfumler
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ParfumDto>> Ekle(ParfumKaydetDto dto)
    {
        var hata = await KurallariKontrolEt(dto);
        if (hata is not null)
            return BadRequest(hata);

        var parfum = new Parfum();
        Aktar(dto, parfum);

        _db.Parfumler.Add(parfum);
        await _db.SaveChangesAsync();

        var sonuc = await DtoyaCevir(_db.Parfumler.Where(p => p.Id == parfum.Id))
            .FirstAsync();

        return CreatedAtAction(nameof(Getir), new { id = parfum.Id }, sonuc);
    }

    // PUT api/parfumler/3
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Guncelle(int id, ParfumKaydetDto dto)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        var hata = await KurallariKontrolEt(dto);
        if (hata is not null)
            return BadRequest(hata);

        Aktar(dto, parfum);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // DELETE api/parfumler/3
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Sil(int id)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        GorselDosyasiniSil(parfum.GorselYolu);
        _db.Parfumler.Remove(parfum);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // POST api/parfumler/3/gorsel   (multipart/form-data, alan adı: "dosya")
    [HttpPost("{id}/gorsel")]
    [Authorize(Roles = "Admin")]
    [RequestSizeLimit(6 * 1024 * 1024)]
    public async Task<ActionResult<ParfumDto>> GorselYukle(int id, IFormFile dosya)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        if (dosya.Length == 0)
            return BadRequest("Dosya boş.");

        if (dosya.Length > EnBuyukGorselBoyutu)
            return BadRequest("Görsel en fazla 5 MB olabilir.");

        // Hem uzantıya hem içerik türüne bakıyoruz; adı ".jpg" olan bir program yüklenemesin
        var uzanti = Path.GetExtension(dosya.FileName).ToLowerInvariant();
        if (!IzinliUzantilar.Contains(uzanti) || !dosya.ContentType.StartsWith("image/"))
            return BadRequest("Sadece JPG, PNG veya WEBP görsel yüklenebilir.");

        // Kullanıcının verdiği dosya adını kullanmıyoruz: çakışmasın ve klasör dışına çıkılamasın diye
        // adı kendimiz üretiyoruz
        var klasor = GorselKlasoru();
        Directory.CreateDirectory(klasor);
        var dosyaAdi = $"parfum-{id}-{Guid.NewGuid():N}{uzanti}";

        await using (var akis = System.IO.File.Create(Path.Combine(klasor, dosyaAdi)))
        {
            await dosya.CopyToAsync(akis);
        }

        GorselDosyasiniSil(parfum.GorselYolu);
        parfum.GorselYolu = $"/gorseller/{dosyaAdi}";
        await _db.SaveChangesAsync();

        return await DtoyaCevir(_db.Parfumler.Where(p => p.Id == id)).FirstAsync();
    }

    // DELETE api/parfumler/3/gorsel
    [HttpDelete("{id}/gorsel")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GorselKaldir(int id)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        GorselDosyasiniSil(parfum.GorselYolu);
        parfum.GorselYolu = null;
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // --- Yardımcı metotlar ---

    private string GorselKlasoru() =>
        Path.Combine(_ortam.WebRootPath ?? Path.Combine(_ortam.ContentRootPath, "wwwroot"), "gorseller");

    private void GorselDosyasiniSil(string? gorselYolu)
    {
        if (string.IsNullOrEmpty(gorselYolu))
            return;

        // Sadece dosya adını alıyoruz; "../" gibi hilelerle başka klasöre ulaşılamaz
        var tamYol = Path.Combine(GorselKlasoru(), Path.GetFileName(gorselYolu));
        if (System.IO.File.Exists(tamYol))
            System.IO.File.Delete(tamYol);
    }

    // Etiketlerle (attribute) ifade edilemeyen kurallar
    private async Task<string?> KurallariKontrolEt(ParfumKaydetDto dto)
    {
        if (!await _db.Markalar.AnyAsync(m => m.Id == dto.MarkaId))
            return $"{dto.MarkaId} numaralı marka bulunamadı.";

        if (dto.EskiFiyat.HasValue && dto.EskiFiyat <= dto.Fiyat)
            return "Eski fiyat, satış fiyatından yüksek olmalı.";

        return null;
    }

    private static IQueryable<ParfumDto> DtoyaCevir(IQueryable<Parfum> sorgu) =>
        sorgu.Select(p => new ParfumDto(
            p.Id, p.Ad, p.Aciklama, p.Fiyat, p.EskiFiyat, p.HacimMl,
            p.Cinsiyet, p.Stok, p.KokuAilesi, p.Konsantrasyon,
            p.UstNotalar, p.KalpNotalar, p.AltNotalar,
            p.Renk, p.SiseTipi, p.Yeni, p.MarkaId, p.Marka!.Ad, p.GorselYolu));

    private static void Aktar(ParfumKaydetDto dto, Parfum parfum)
    {
        parfum.Ad = dto.Ad;
        parfum.Aciklama = dto.Aciklama;
        parfum.Fiyat = dto.Fiyat;
        parfum.EskiFiyat = dto.EskiFiyat;
        parfum.HacimMl = dto.HacimMl;
        parfum.Cinsiyet = dto.Cinsiyet;
        parfum.Stok = dto.Stok;
        parfum.KokuAilesi = dto.KokuAilesi;
        parfum.Konsantrasyon = dto.Konsantrasyon;
        parfum.UstNotalar = dto.UstNotalar.Trim();
        parfum.KalpNotalar = dto.KalpNotalar.Trim();
        parfum.AltNotalar = dto.AltNotalar.Trim();
        parfum.Renk = dto.Renk;
        parfum.SiseTipi = dto.SiseTipi;
        parfum.Yeni = dto.Yeni;
        parfum.MarkaId = dto.MarkaId;
    }
}