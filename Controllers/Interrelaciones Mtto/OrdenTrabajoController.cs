using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class OrdenTrabajoController : Controller
{
    private readonly OrdenTrabajoServicio _ordenTrabajoServicio;

    public OrdenTrabajoController(OrdenTrabajoServicio ordenTrabajoServicio)
    {
        _ordenTrabajoServicio = ordenTrabajoServicio;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajo OT)
    {
        return Ok(await  _ordenTrabajoServicio.Create(OT));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        OrdenTrabajo OT = await _ordenTrabajoServicio.Get(EquipoId,BrigadaId,TrabajadorId, FechaId);
        if(OT == null){
            return NotFound();
        }
        return Ok(OT);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<OrdenTrabajo>> GetAll() => await _ordenTrabajoServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId, OrdenTrabajo OT)
    {
        if (OT == null)
        {
            return BadRequest();
        }

        OrdenTrabajo OTModificada = await _ordenTrabajoServicio.Update(EquipoId,BrigadaId,TrabajadorId, FechaId, OT);

        if (OTModificada == null)
        {
            return NotFound();
        }

        return Ok(OTModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        await _ordenTrabajoServicio.Delete(EquipoId,BrigadaId,TrabajadorId, FechaId);

        return NoContent();
    }

    
}
