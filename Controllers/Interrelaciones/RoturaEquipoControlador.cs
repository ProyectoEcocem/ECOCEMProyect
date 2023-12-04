using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class RoturaEquipoController : Controller
{
    private readonly RoturaEquipoServicio _roturaEquipoServicio;

    public RoturaEquipoController(RoturaEquipoServicio roturaEquipoServicio)
    {
        _roturaEquipoServicio =roturaEquipoServicio;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(RoturaEquipo roturaE)
    {
        return Ok(await  _roturaEquipoServicio.Create(roturaE));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int RoturaId,int EquipoId,DateTime FechaId)
    {
        RoturaEquipo roturaE=await _roturaEquipoServicio.Get(RoturaId,EquipoId,FechaId);
        if(roturaE == null){
            return NotFound();
        }
        return Ok(roturaE);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<RoturaEquipo>> GetAll() => await _roturaEquipoServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int RoturaId,int EquipoId,DateTime FechaId,RoturaEquipo roturaEquipo)
    {
        if (roturaEquipo == null)
        {
            return BadRequest();
        }

        RoturaEquipo roturaEquipoModificada = await _roturaEquipoServicio.Update(RoturaId,EquipoId,FechaId,roturaEquipo);

        if (roturaEquipoModificada == null)
        {
            return NotFound();
        }

        return Ok(roturaEquipoModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int RoturaId,int EquipoId,DateTime FechaId)
    {
        await _roturaEquipoServicio.Delete( RoturaId,EquipoId,FechaId);

        return NoContent();
    }

    
}

