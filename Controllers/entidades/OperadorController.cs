using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class OperadorController : Controller
{
    private readonly OperadorServicio _operadorServicio;

    public OperadorController(OperadorServicio operadorServicio)
    {
        _operadorServicio = operadorServicio;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Operador operador = await _operadorServicio.Get(id);
        if (operador == null)
        {
            return NotFound();
        }
        return Ok(operador);
    }

    [HttpGet]
    public async Task<IEnumerable<Operador>> GetAll() => await _operadorServicio.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Operador operador)
    {
        if (operador == null)
        {
            return BadRequest();
        }
        Operador operadorCreado = await _operadorServicio.Create(operador);
        return CreatedAtRoute("Get", new { id = operadorCreado.TrabajadorId }, operadorCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Operador operador)
    {
        if (operador == null)
        {
            return BadRequest();
        }
        Operador operadorModificado = await _operadorServicio.Update(id, operador);
        if (operadorModificado == null)
        {
            return NotFound();
        }
        return Ok(operadorModificado);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _operadorServicio.Delete(id);
        return NoContent();
    }
}
