using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]


public class SedeController:Controller
{
    private readonly SedeService _sedeService;

    public SedeController(SedeService sedeService)
    {
        _sedeService = sedeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Sede sede = await _sedeService.Get(id);

        if (sede == null)
        {
            return NotFound();
        }

        return Ok(sede);
    }

    [HttpGet]
    public async Task<IEnumerable<Sede>> GetAll() => await _sedeService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sede sede)
    {
        if (sede == null)
        {
            return BadRequest();
        }

        Sede sedeCreada = await _sedeService.Create(sede);

        return CreatedAtRoute("Get", new { id = sedeCreada.SedeId }, sedeCreada);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Sede sede)
    {
        if (sede == null)
        {
            return BadRequest();
        }

        Sede SedeModificada = await _sedeService.Update(id,sede);

        if (SedeModificada== null)
        {
            return NotFound();
        }

        return Ok(SedeModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _sedeService.Delete(id);

        return NoContent();
    }
    
}
