using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;
using ParfumApi.Dtos;

namespace ParfumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarkalarController : ControllerBase
{
    private readonly AppDbContext _db;

    public MarkalarController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<MarkaDto>>> Listele()
    {
        return await _db.Markalar
            .OrderBy(m => m.Ad)
            .Select(m => new MarkaDto(m.Id, m.Ad, m.Ulke, m.Parfumler.Count))
            .ToListAsync();
    }
}