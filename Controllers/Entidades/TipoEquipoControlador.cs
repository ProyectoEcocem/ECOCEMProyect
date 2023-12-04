using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;
public class TipoEData{
    public int TipoEId { get; set; }
    public string? TipoE {get; set;} 
}

[Route("api/[controller]")]
[ApiController]
public class TipoEquipoController : Controller
{
    private readonly TipoEquipoServicio _tipoEServicio;

    public TipoEquipoController(TipoEquipoServicio tipoEServicio)
    {
        _tipoEServicio =tipoEServicio;
    }


    [HttpPost]

    public async Task<ActionResult> Post(TipoEData tipoE)
    {
        
        if (tipoE == null)
        {
            return BadRequest();
        }
        TipoEquipo TE = await _tipoEServicio.Create(tipoE);
        return Ok(TE);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoEId)
    {
        TipoEquipo tipoE=await _tipoEServicio.Get(TipoEId);
        if(tipoE == null){
            return NotFound();
        }
        return Ok(tipoE);
    }

    [HttpGet]
    public async Task<IEnumerable<TipoEquipo>> GetAll() => await _tipoEServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int TipoEId,TipoEquipo tipoE)
    {
        if (tipoE == null)
        {
            return BadRequest();
        }

        TipoEquipo tipoEModificada = await _tipoEServicio.Update(TipoEId,tipoE);

        if (tipoEModificada == null)
        {
            return NotFound();
        }

        return Ok(tipoEModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int TipoEId)
    {
        await _tipoEServicio.Delete(TipoEId);

        return NoContent();
    }

    
}


