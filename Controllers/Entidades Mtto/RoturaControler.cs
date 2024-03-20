using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class RoturaData
{
    public int RoturaId {get; set;}
    public string NombreRotura {get; set;}
    public string Descripcion {get; set;}
}


[Route("api/[controller]")]
[ApiController]
public class RoturaController : Controller
{
    private readonly RoturaService _roturaService;

    public RoturaController(RoturaService roturaService)
    {
        _roturaService = roturaService;
    }
    [HttpGet("(id)")]
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
    public async Task<IActionResult> Post([FromBody] RoturaData rotura)
    {
        if (rotura == null)
        {
            return BadRequest();
        }
        Rotura createdRotura = await _roturaService.Create(rotura);
        return Ok(createdRotura);

        
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
