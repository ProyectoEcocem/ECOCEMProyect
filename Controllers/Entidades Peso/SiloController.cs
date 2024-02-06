using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class SiloData
{
    public int SiloId {get; set;}
    public string NoSilo {get; set;}
    public int EquipoId {get; set;}
}

[Route("api/[controller]")]
[ApiController]

public class SiloController:Controller
{
    private readonly SiloServicio _siloServicio;

    public SiloController(SiloServicio siloServicio)
    {
        _siloServicio = siloServicio;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Silo silo = await _siloServicio.Get(id);

        if (silo == null)
        {
            return NotFound();
        }

        return Ok(silo);
    }

    [HttpGet]
    public async Task<IEnumerable<Silo>> GetAll() => await _siloServicio.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post( SiloData silo)
    {
        if (silo == null)
        {
            return BadRequest();
        }

        Silo siloCreado= await _siloServicio.Create(silo);

        return Ok(siloCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Silo silo)
    {
        if (silo == null)
        {
            return BadRequest();
        }

        Silo SiloModificada = await _siloServicio.Update(id,silo);

        if (SiloModificada== null)
        {
            return NotFound();
        }

        return Ok(SiloModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _siloServicio.Delete(id);

        return NoContent();
    }
    
}
