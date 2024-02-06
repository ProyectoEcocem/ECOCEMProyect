using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class OrdenTrabajoHerramientaController : Controller
{
    private readonly OrdenTrabajoHerramientaServicio _ordenTrabajoHerramientaServicio;

    public OrdenTrabajoHerramientaController(OrdenTrabajoHerramientaServicio ordenTrabajoHerramientaServicio)
    {
        _ordenTrabajoHerramientaServicio =ordenTrabajoHerramientaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajoHerramienta ordenTrabajoHerramienta)
    {
        return Ok(await  _ordenTrabajoHerramientaServicio.Create(ordenTrabajoHerramienta));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        OrdenTrabajoHerramienta ordenTrabajoHerramienta=await _ordenTrabajoHerramientaServicio.Get(HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId);
        if(ordenTrabajoHerramienta == null){
            return NotFound();
        }
        return Ok(ordenTrabajoHerramienta);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<OrdenTrabajoHerramienta>> GetAll() => await _ordenTrabajoHerramientaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,OrdenTrabajoHerramienta ordenTrabajoHerramienta)
    {
        if (ordenTrabajoHerramienta == null)
        {
            return BadRequest();
        }

        OrdenTrabajoHerramienta ordenTrabajoHerramientaModificada = await _ordenTrabajoHerramientaServicio.Update(HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId,ordenTrabajoHerramienta);

        if (ordenTrabajoHerramientaModificada == null)
        {
            return NotFound();
        }

        return Ok(ordenTrabajoHerramientaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        await _ordenTrabajoHerramientaServicio.Delete( HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        return NoContent();
    }

    
}

