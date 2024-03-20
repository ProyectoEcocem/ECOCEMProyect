using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class MantenimientoNecesarioData
{
    public int TipoEId {get; set;}
    public int AMId {get; set;}
    public double HorasExpId {get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class MantenimientoNecesarioController : Controller
{
    private readonly MantenimientoNecesarioServicio _mantenimientoNecesarioServicio;

    public MantenimientoNecesarioController(MantenimientoNecesarioServicio mantenimientoNecesarioServicio)
    {
        _mantenimientoNecesarioServicio = mantenimientoNecesarioServicio;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(MantenimientoNecesarioData mn)
    {
        return Ok(await  _mantenimientoNecesarioServicio.Create(mn));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoEquipoId,int AMId,double HorasExpId)
    {
        MantenimientoNecesario mn=await _mantenimientoNecesarioServicio.Get(TipoEquipoId,AMId,HorasExpId);
        if(mn == null){
            return NotFound();
        }
        return Ok(mn);
    }
    [HttpGet]
    public async Task<IEnumerable<MantenimientoNecesario>> GetAll() => await _mantenimientoNecesarioServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int TipoEquipoId,int AMId,double HorasExpId,MantenimientoNecesario mn)
    {
        if (mn == null)
        {
            return BadRequest();
        }

        MantenimientoNecesario mnModificada = await _mantenimientoNecesarioServicio.Update(TipoEquipoId,AMId,HorasExpId,mn);

        if (mnModificada == null)
        {
            return NotFound();
        }

        return Ok(mnModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int TipoEquipoId,int AMId,double HorasExpId)
    {
        await _mantenimientoNecesarioServicio.Delete(TipoEquipoId,AMId,HorasExpId);

        return NoContent();
    }

    
}

