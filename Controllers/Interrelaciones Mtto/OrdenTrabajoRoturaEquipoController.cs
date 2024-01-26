using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrdenTrabajoRoturaEquipoController : Controller
{
    private readonly OrdenTrabajoRoturaEquipoServicio _ordenTrabajoRoturaEquipoServicio;

    public OrdenTrabajoRoturaEquipoController(OrdenTrabajoRoturaEquipoServicio ordenTrabajoRoturaEquipoServicio)
    {
        _ordenTrabajoRoturaEquipoServicio = ordenTrabajoRoturaEquipoServicio;
    }

    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipo)
    {
        return Ok(await  _ordenTrabajoRoturaEquipoServicio.Create(ordenTrabajoRoturaEquipo));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId)
    {
        OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipo=await _ordenTrabajoRoturaEquipoServicio.Get(EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId);
        if(ordenTrabajoRoturaEquipo == null){
            return NotFound();
        }
        return Ok(ordenTrabajoRoturaEquipo);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<OrdenTrabajoRoturaEquipo>> GetAll() => await _ordenTrabajoRoturaEquipoServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId,OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipo)
    {
        if (ordenTrabajoRoturaEquipo == null)
        {
            return BadRequest();
        }

        OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipoModificada = await _ordenTrabajoRoturaEquipoServicio.Update(EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId,ordenTrabajoRoturaEquipo);

        if (ordenTrabajoRoturaEquipoModificada == null)
        {
            return NotFound();
        }

        return Ok(ordenTrabajoRoturaEquipoModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId)
    {
        await _ordenTrabajoRoturaEquipoServicio.Delete( EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId);

        return NoContent();
    }

    
}

