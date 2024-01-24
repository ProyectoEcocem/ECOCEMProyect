using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

    public class SedeData
    {
        public int sedeid { get; set; }
        public string? nombreSede { get; set; }
        public string? ubicacionSede { get; set; }
        public int empresaId { get; set; }
    }

[Route("api/[controller]")]
[ApiController]
public class SedeController:Controller
{
    private readonly SedeService _sedeService;

    public SedeController(SedeService sedeService)
    {
        _sedeService = sedeService;
    }

    [HttpGet("id")]
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


    [HttpGet("Equipos")]
    public async Task<IEnumerable<Equipo>> GetEquipos(int id) => await _sedeService.GetEquipos(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SedeData sede)
    {
        if (sede == null)
        {
            return BadRequest();
        }

        Sede sedeCreada = await _sedeService.Create(sede);
        return Ok(sedeCreada);
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
