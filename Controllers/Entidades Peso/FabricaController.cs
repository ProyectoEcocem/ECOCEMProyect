using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class FabricaData
{
    public int FabricaId { get; set; }
    public string? Nombre { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class FabricaController : Controller
{
    private readonly FabricaService _fabricaService;

    public FabricaController(FabricaService fabricaService)
    {
        _fabricaService = fabricaService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Fabrica fabrica = await _fabricaService.Get(id);
        if (fabrica == null)
        {
            return NotFound();
        }
        return Ok(fabrica);
    }

    [HttpGet]
    public async Task<IEnumerable<Fabrica>> GetAll() => await _fabricaService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FabricaData fabrica)
    {
        if (fabrica == null)
        {
            return BadRequest();
        }
        Fabrica createdFabrica = await _fabricaService.Create(fabrica);
        return Ok(createdFabrica);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Fabrica fabrica)
    {
        if (fabrica == null)
        {
            return BadRequest();
        }
        Fabrica updatedFabrica = await _fabricaService.Update(id, fabrica);
        if (updatedFabrica == null)
        {
            return NotFound();
        }
        return Ok(updatedFabrica);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _fabricaService.Delete(id);
        return NoContent();
    }
}