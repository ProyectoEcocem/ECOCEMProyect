using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class BasculaController : Controller
{
    private readonly BasculaService _basculaService;

    public BasculaController(BasculaService basculaService)
    {
        _basculaService = basculaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Bascula bascula = await _basculaService.Get(id);

        if (bascula == null)
        {
            return NotFound();
        }

        return Ok(bascula);
    }

    [HttpGet]
    public async Task<IEnumerable<Bascula>> GetAll() => await _basculaService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bascula bascula)
    {
        if (bascula == null)
        {
            return BadRequest();
        }

        Bascula createdBascula = await _basculaService.Create(bascula);

        return CreatedAtRoute("Get", new { id = createdBascula.BasculaId }, createdBascula);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Bascula bascula)
    {
        if (bascula == null)
        {
            return BadRequest();
        }

        Bascula updatedBascula = await _basculaService.Update(id,bascula);

        if (updatedBascula == null)
        {
            return NotFound();
        }

        return Ok(updatedBascula);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _basculaService.Delete(id);

        return NoContent();
    }
}





