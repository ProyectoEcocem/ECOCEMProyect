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


    [HttpGet("Roturas")]
    public async Task<IActionResult> GetRoturas( int? dia, int? mes, int? anno)
    {
        var result = await _filtroMantenimientoService.GetRoturas(dia,mes,anno);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("Reporte")]
    public async Task<IActionResult> GetReportes( int? dia, int? mes, int? anno)
    {
        var result = await _filtroMantenimientoService.GetReportes(dia,mes,anno);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
