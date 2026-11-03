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
    private readonly AppDbContext _db;

    public ParfumlerController(AppDbContext db)
    {
        _db = db;
    }

    // GET api/parfumler
    [HttpGet]
    public async Task<ActionResult<List<ParfumDto>>> Listele()
    {
        return await DtoyaCevir(_db.Parfumler).ToListAsync();
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
    public async Task<ActionResult<ParfumDto>> Ekle(ParfumKaydetDto dto)
    {
        if (!await _db.Markalar.AnyAsync(m => m.Id == dto.MarkaId))
            return BadRequest($"{dto.MarkaId} numaralı marka bulunamadı.");

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
    public async Task<IActionResult> Guncelle(int id, ParfumKaydetDto dto)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        if (!await _db.Markalar.AnyAsync(m => m.Id == dto.MarkaId))
            return BadRequest($"{dto.MarkaId} numaralı marka bulunamadı.");

        Aktar(dto, parfum);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // DELETE api/parfumler/3
    [HttpDelete("{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var parfum = await _db.Parfumler.FindAsync(id);
        if (parfum is null)
            return NotFound($"{id} numaralı parfüm bulunamadı.");

        _db.Parfumler.Remove(parfum);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // --- Yardımcı metotlar ---

    private static IQueryable<ParfumDto> DtoyaCevir(IQueryable<Parfum> sorgu) =>
        sorgu.Select(p => new ParfumDto(
            p.Id, p.Ad, p.Aciklama, p.Fiyat, p.HacimMl,
            p.Cinsiyet, p.Stok, p.MarkaId, p.Marka!.Ad));

    private static void Aktar(ParfumKaydetDto dto, Parfum parfum)
    {
        parfum.Ad = dto.Ad;
        parfum.Aciklama = dto.Aciklama;
        parfum.Fiyat = dto.Fiyat;
        parfum.HacimMl = dto.HacimMl;
        parfum.Cinsiyet = dto.Cinsiyet;
        parfum.Stok = dto.Stok;
        parfum.MarkaId = dto.MarkaId;
    }
}