using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;

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

    [HttpGet]
    public async Task<IActionResult> Listele()
    {
        var parfumler = await _db.Parfumler
            .Select(p => new
            {
                p.Id,
                p.Ad,
                Marka = p.Marka!.Ad,
                p.Fiyat,
                p.HacimMl,
                p.Cinsiyet
            })
            .ToListAsync();

        return Ok(parfumler);
    }
}