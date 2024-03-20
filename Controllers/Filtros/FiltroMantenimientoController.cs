using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;


[Route("api/[controller]/[action]")]
[ApiController]
public class FiltroMantenimientoController : Controller
{
    private readonly FiltroMantenimientoService _filtroMantenimientoService;

    public FiltroMantenimientoController(FiltroMantenimientoService filtroMantenimientoService)
    {
        _filtroMantenimientoService = filtroMantenimientoService;
    }


    [HttpGet]
    public async Task<IActionResult> GetRoturas( int? dia, int? mes, int? anno)
    {
        var result = await _filtroMantenimientoService.GetRoturas(dia,mes,anno);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetReportes( int? dia, int? mes, int? anno, int equipoId)
    {
        var result = await _filtroMantenimientoService.GetReportes(dia,mes,anno,equipoId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetHoras(int equipoId)
    {
        var result =  _filtroMantenimientoService.GetHoras(equipoId);

        // if (result == null)
        // {
        //     return NotFound();
        // }

        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetEquipos(string TipoE)
    {
        var result =  await _filtroMantenimientoService.GetEquipos(TipoE);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
