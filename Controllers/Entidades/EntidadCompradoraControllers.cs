using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class EntidadCompradoraController : Controller
{
    private readonly EntidadCompradoraService _entidadCompradoraService;

    public EntidadCompradoraController(EntidadCompradoraService entidadCompradoraService)
    {
        _entidadCompradoraService = entidadCompradoraService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        EntidadCompradora entidadCompradora = await _entidadCompradoraService.Get(id);
        if (entidadCompradora == null)
        {
            return NotFound();
        }
        return Ok(entidadCompradora);
    }

    [HttpGet]
    public async Task<IEnumerable<EntidadCompradora>> GetAll() => await _entidadCompradoraService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EntidadCompradora entidadCompradora)
    {
        if (entidadCompradora == null)
        {
            return BadRequest();
        }
        EntidadCompradora createdEntidadCompradora = await _entidadCompradoraService.Create(entidadCompradora);
        return CreatedAtRoute("Get", new { id = createdEntidadCompradora.EntidadCompradoraId }, createdEntidadCompradora);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, EntidadCompradora entidadCompradora)
    {
        if (entidadCompradora == null)
        {
            return BadRequest();
        }
        EntidadCompradora updatedEntidadCompradora = await _entidadCompradoraService.Update(id, entidadCompradora);
        if (updatedEntidadCompradora == null)
        {
            return NotFound();
        }
        return Ok(updatedEntidadCompradora);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _entidadCompradoraService.Delete(id);
        return NoContent();
    }
}
