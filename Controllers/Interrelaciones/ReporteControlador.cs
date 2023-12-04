using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReporteController : Controller
{
    private readonly ReporteServicio _reporteServicio;

    public ReporteController(ReporteServicio reporteServicio)
    {
        _reporteServicio =reporteServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Reporte reporte)
    {
        return Ok(await  _reporteServicio.Create(reporte));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int EquipoId,DateTime FechaId)
    {
        Reporte reporte=await _reporteServicio.Get(EquipoId,FechaId);
        if(reporte == null){
            return NotFound();
        }
        return Ok(reporte);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<Reporte>> GetAll() => await _reporteServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int EquipoId,DateTime FechaId,Reporte reporte)
    {
        if (reporte == null)
        {
            return BadRequest();
        }

        Reporte reporteModificada = await _reporteServicio.Update(EquipoId,FechaId,reporte);

        if (reporteModificada == null)
        {
            return NotFound();
        }

        return Ok(reporteModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int EquipoId,DateTime FechaId)
    {
        await _reporteServicio.Delete(EquipoId,FechaId);

        return NoContent();
    }

    
}

