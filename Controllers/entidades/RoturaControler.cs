using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]")]
[ApiController]
public class RoturaController : Controller
{
    private readonly RoturaService _roturaService;

    public RoturaController(RoturaService roturaService)
    {
        _roturaService = roturaService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Rotura rotura = await _roturaService.Get(id);
        if (rotura == null)
        {
            return NotFound();
        }
        return Ok(rotura);
    }

    [HttpGet]
    public async Task<IEnumerable<Rotura>> GetAll() => await _roturaService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Rotura rotura)
    {
        if (rotura == null)
        {
            return BadRequest();
        }
        Rotura createdRotura = await _roturaService.Create(rotura);
        return CreatedAtRoute("Get", new { id = createdRotura.RoturaId }, createdRotura);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Rotura rotura)
    {
        if (rotura == null)
        {
            return BadRequest();
        }
        Rotura updatedRotura = await _roturaService.Update(id, rotura);
        if (updatedRotura == null)
        {
            return NotFound();
        }
        return Ok(updatedRotura);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _roturaService.Delete(id);
        return NoContent();
    }
}
