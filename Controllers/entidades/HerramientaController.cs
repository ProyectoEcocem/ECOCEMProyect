using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class HerramientaController : Controller
{
    private readonly HerramientaService _herramientaService;

    public HerramientaController(HerramientaService herramientaService)
    {
        _herramientaService = herramientaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Herramienta herramienta = await _herramientaService.Get(id);

        if (herramienta == null)
        {
            return NotFound();
        }

        return Ok(herramienta);
    }

    [HttpGet]
    public async Task<IEnumerable<Herramienta>> GetAll() => await _herramientaService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Herramienta herramienta)
    {
        if (herramienta == null)
        {
            return BadRequest();
        }

        Herramienta herramientaCreada = await _herramientaService.Create(herramienta);

        return CreatedAtRoute("Get", new { id = herramientaCreada.HerramientaId }, herramientaCreada);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Herramienta herramienta)
    {
        if (herramienta == null)
        {
            return BadRequest();
        }

        Herramienta herramientaModificada = await _herramientaService.Update(id,herramienta);

        if (herramientaModificada == null)
        {
            return NotFound();
        }

        return Ok(herramientaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _herramientaService.Delete(id);

        return NoContent();
    }
}

