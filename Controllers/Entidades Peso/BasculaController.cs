using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]")]
[ApiController]
public class BasculaController : Controller
{
    private readonly BasculaService _medidorService;

    public BasculaController(BasculaService medidorService)
    {
        _medidorService = medidorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Bascula medidor = await _medidorService.Get(id);

        if (medidor == null)
        {
            return NotFound();
        }

        return Ok(medidor);
    }

    [HttpGet]
    public async Task<IEnumerable<Bascula>> GetAll() => await _medidorService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bascula medidor)
    {
        if (medidor == null)
        {
            return BadRequest();
        }

        Bascula createdBascula = await _medidorService.Create(medidor);

        return CreatedAtRoute("Get", new { id = createdBascula.BasculaId }, createdBascula);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Bascula medidor)
    {
        if (medidor == null)
        {
            return BadRequest();
        }

        Bascula updatedBascula = await _medidorService.Update(id,medidor);

        if (updatedBascula == null)
        {
            return NotFound();
        }

        return Ok(updatedBascula);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _medidorService.Delete(id);

        return NoContent();
    }
}





