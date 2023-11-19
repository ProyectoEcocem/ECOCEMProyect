using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class TrabajadorController : Controller
{
    private readonly TrabajadorServicio _trabajadorServicio;

    public TrabajadorController(TrabajadorServicio trabajadorServicio)
    {
       _trabajadorServicio = trabajadorServicio;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Trabajador trabajador = await _trabajadorServicio.Get(id);
        if (trabajador == null)
        {
            return NotFound();
        }
        return Ok(trabajador);
    }

    [HttpGet]
    public async Task<IEnumerable<Trabajador>> GetAll() => await _trabajadorServicio.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Trabajador trabajador)
    {
        if (trabajador == null)
        {
            return BadRequest();
        }
        Trabajador trabajadorCreado = await _trabajadorServicio.Create(trabajador);
        return CreatedAtRoute("Get", new { id = trabajadorCreado.TrabajadorId }, trabajadorCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Trabajador trabajador)
    {
        if (trabajador == null)
        {
            return BadRequest();
        }
        Trabajador trabajadorModificado = await _trabajadorServicio.Update(id, trabajador);
        if (trabajadorModificado == null)
        {
            return NotFound();
        }
        return Ok(trabajadorModificado);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _trabajadorServicio.Delete(id);
        return NoContent();
    }
}
