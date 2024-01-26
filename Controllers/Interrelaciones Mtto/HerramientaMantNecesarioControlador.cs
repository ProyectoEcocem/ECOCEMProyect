using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class HerramientaMantNecesarioController : Controller
{
    private readonly HerramientaMantNecesarioServicio _herramientaMantNecesarioServicio;

    public HerramientaMantNecesarioController(HerramientaMantNecesarioServicio herramientaMantNecesarioServicio)
    {
        _herramientaMantNecesarioServicio =herramientaMantNecesarioServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(HerramientaMantNecesario herramientaMantNecesario)
    {
        return Ok(await  _herramientaMantNecesarioServicio.Create(herramientaMantNecesario));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int HerramientasId,int TipoEquipoId,double HorasExpId)
    {
        HerramientaMantNecesario herramientaMantNecesario=await _herramientaMantNecesarioServicio.Get(HerramientasId,TipoEquipoId,HorasExpId);
        if(herramientaMantNecesario == null){
            return NotFound();
        }
        return Ok(herramientaMantNecesario);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<HerramientaMantNecesario>> GetAll() => await _herramientaMantNecesarioServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int HerramientasId,int TipoEquipoId,double HorasExpId,HerramientaMantNecesario herramientaMantNecesario)
    {
        if (herramientaMantNecesario == null)
        {
            return BadRequest();
        }

        HerramientaMantNecesario herramientaMantNecesarioModificada = await _herramientaMantNecesarioServicio.Update(HerramientasId,TipoEquipoId,HorasExpId,herramientaMantNecesario);

        if (herramientaMantNecesarioModificada == null)
        {
            return NotFound();
        }

        return Ok(herramientaMantNecesarioModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int HerramientasId,int TipoEquipoId,double HorasExpId)
    {
        await _herramientaMantNecesarioServicio.Delete( HerramientasId,TipoEquipoId,HorasExpId);

        return NoContent();
    }

    
}

