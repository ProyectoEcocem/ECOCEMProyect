using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class OrdenTrabajoAMRealizadaController : Controller
{
    private readonly OrdenTrabajoAMRealizadaServicio _ordenTrabajoAMRealizadaServicio;

    public OrdenTrabajoAMRealizadaController(OrdenTrabajoAMRealizadaServicio ordenTrabajoAMRealizadaServicio)
    {
        _ordenTrabajoAMRealizadaServicio = ordenTrabajoAMRealizadaServicio;
    }

    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajoAMRealizada ordenTrabajoAMRealizada)
    {
        return Ok(await  _ordenTrabajoAMRealizadaServicio.Create(ordenTrabajoAMRealizada));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        OrdenTrabajoAMRealizada ordenTrabajoAMRealizada=await _ordenTrabajoAMRealizadaServicio.Get(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId);
        if(ordenTrabajoAMRealizada == null){
            return NotFound();
        }
        return Ok(ordenTrabajoAMRealizada);
    }

    [HttpGet]
    public async Task<IEnumerable<OrdenTrabajoAMRealizada>> GetAll() => await _ordenTrabajoAMRealizadaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,string resultado,OrdenTrabajoAMRealizada ordenTrabajoAMRealizada)
    {
        if (ordenTrabajoAMRealizada == null)
        {
            return BadRequest();
        }

        OrdenTrabajoAMRealizada ordenTrabajoAMRealizadaModificada = await _ordenTrabajoAMRealizadaServicio.Update(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId,resultado,ordenTrabajoAMRealizada);

        if (ordenTrabajoAMRealizadaModificada == null)
        {
            return NotFound();
        }

        return Ok(ordenTrabajoAMRealizadaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        await _ordenTrabajoAMRealizadaServicio.Delete(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        return NoContent();
    }

    
}

