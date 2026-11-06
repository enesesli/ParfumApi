using Microsoft.AspNetCore.Mvc;
using ParfumApi.Dtos;
using ParfumApi.Services;

namespace ParfumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EsanslarController : ControllerBase
{
    // Controller iş mantığı bilmiyor; hesabı servise bırakıyor.
    // Servisi interface üzerinden alması, ileride test için sahte bir servis vermeyi kolaylaştırır.
    private readonly IKokuAtolyesiServisi _servis;

    public EsanslarController(IKokuAtolyesiServisi servis)
    {
        _servis = servis;
    }

    // GET api/esanslar
    [HttpGet]
    public async Task<ActionResult<List<EsansDto>>> Listele()
    {
        return await _servis.EsanslariGetir();
    }

    // POST api/esanslar/degerlendir
    [HttpPost("degerlendir")]
    public async Task<ActionResult<DegerlendirmeSonucu>> Degerlendir(DegerlendirmeIstegi istek)
    {
        var (sonuc, hata) = await _servis.Degerlendir(istek);
        if (hata is not null)
            return BadRequest(hata);

        return sonuc!;
    }
}
