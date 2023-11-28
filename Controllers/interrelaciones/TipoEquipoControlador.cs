using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class TipoEquipoController : Controller
{
    private readonly TipoEquipoServicio _tipoEServicio;

    public TipoEquipoController(TipoEquipoServicio tipoEServicio)
    {
        _tipoEServicio =tipoEServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(TipoEquipo tipoE)
    {
        return Ok(await  _tipoEServicio.Create(tipoE));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoEId)
    {
        TipoEquipo tipoE=await _tipoEServicio.Get(TipoEId);
        if(tipoE == null){
            return NotFound();
        }
        return Ok(tipoE);
    }
    // GETALL
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


