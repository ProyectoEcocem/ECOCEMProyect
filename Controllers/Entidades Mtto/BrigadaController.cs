using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;


public class BrigadaData
{
    public int BrigadaId { get; set; }
    public string? Descripcion { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class BrigadaController : Controller
{
    private readonly BrigadaServicio _brigadaServicio;

    public BrigadaController(BrigadaServicio brigadaServicio)
    {
        _brigadaServicio = brigadaServicio;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Brigada brigada = await _brigadaServicio.Get(id);
        if (brigada == null)
        {
            return NotFound();
        }
        return Ok(brigada);
    }

    [HttpGet]
    public async Task<IEnumerable<Brigada>> GetAll() => await _brigadaServicio.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BrigadaData brigada)
    {
        if (brigada == null)
        {
            return BadRequest();
        }
        Brigada brigadaCreada = await _brigadaServicio.Create(brigada);
        return Ok(brigadaCreada);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Brigada brigada)
    {
        if (brigada == null)
        {
            return BadRequest();
        }
        Brigada brigadaModificada = await _brigadaServicio.Update(id, brigada);
        if (brigadaModificada == null)
        {
            return NotFound();
        }
        return Ok(brigadaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _brigadaServicio.Delete(id);
        return NoContent();
    }
}