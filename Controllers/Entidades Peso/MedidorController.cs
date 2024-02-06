using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class MedidorData
{
    public int MedidorId { get; set; }
    public string NoSerie { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class MedidorController : Controller
{
     private readonly MedidorService _medidorService;

    public MedidorController(MedidorService medidorService)
    {
        _medidorService = medidorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Medidor medidor = await _medidorService.Get(id);

        if (medidor == null)
        {
            return NotFound();
        }

        return Ok(medidor);
    }

    [HttpGet]
    public async Task<IEnumerable<Medidor>> GetAll() => await _medidorService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MedidorData medidor)
    {
        if (medidor == null)
        {
            return BadRequest();
        }

        Medidor createdMedidor = await _medidorService.Create(medidor);

        return Ok(createdMedidor);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Medidor medidor)
    {
        if (medidor == null)
        {
            throw new InvalidOperationException("Entidad null");
        }

        Medidor updatedMedidor = await _medidorService.Update(id,medidor);

        if (updatedMedidor == null)
        {
            throw new InvalidOperationException("Entidad no modificada");;
        }

        return Ok(updatedMedidor);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _medidorService.Delete(id);

        return NoContent();
    }
}


   

