using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class OrdenTrabajoAController : Controller
{
    private readonly OrdenTrabajoAtendidaServicio _ordenTAtendidaServicio;

    public OrdenTrabajoAController(OrdenTrabajoAtendidaServicio ordenTAtendidaServicio)
    {
        _ordenTAtendidaServicio = ordenTAtendidaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajoAtendida ordenTA)
    {
        return Ok(await  _ordenTAtendidaServicio.Create(ordenTA));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int EquipoId , int BrigadaId, int TrabajadorId, DateTime FechaId, DateTime DiaId)
    {
        OrdenTrabajoAtendida ordenTA=await _ordenTAtendidaServicio.Get(EquipoId,BrigadaId,TrabajadorId,FechaId,DiaId);
        if(ordenTA == null){
            return NotFound();
        }
        return Ok(ordenTA);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<OrdenTrabajoAtendida>> GetAll() => await _ordenTAtendidaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put( int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,DateTime DiaId,OrdenTrabajoAtendida ordenTA)
    {
        if (ordenTA == null)
        {
            return BadRequest();
        }

        OrdenTrabajoAtendida ordenTAModificada = await _ordenTAtendidaServicio.Update(EquipoId,BrigadaId,TrabajadorId,FechaId,DiaId,ordenTA);

        if (ordenTAModificada == null)
        {
            return NotFound();
        }

        return Ok(ordenTAModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int EquipoId , int BrigadaId, int TrabajadorId, DateTime FechaId, DateTime DiaId)
    {
        await _ordenTAtendidaServicio.Delete( EquipoId , BrigadaId, TrabajadorId, FechaId, DiaId);

        return NoContent();
    }

    
}

