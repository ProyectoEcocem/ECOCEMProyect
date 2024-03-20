using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;
public class AccionMantenimientoData
{
    public int AMId { get; set; }

    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}
}

[ApiController]
[Route("api/[controller]")]

public class AccionMantenimientoController : Controller
{
    private readonly AccionMantenimientoService _accionMantenimientoService;

    public AccionMantenimientoController(AccionMantenimientoService accionMantenimientoService)
    {
        _accionMantenimientoService = accionMantenimientoService;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(AccionMantenimientoData accionMantenimiento)
    {
        AccionMantenimiento am = await _accionMantenimientoService.Create(accionMantenimiento);
        return Ok(am);
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        AccionMantenimiento accionMantenimiento=await _accionMantenimientoService.Get(id);
        if(accionMantenimiento == null){
            return NotFound();
        }
        return Ok(accionMantenimiento);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<AccionMantenimiento>> GetAll() => await _accionMantenimientoService.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put( int id, AccionMantenimiento accionMantenimiento)
    {
        if (accionMantenimiento == null)
        {
            return BadRequest();
        }

        AccionMantenimiento updatedAccionMantenimiento = await _accionMantenimientoService.Update(id,accionMantenimiento);

        if (updatedAccionMantenimiento == null)
        {
            return NotFound();
        }

        return Ok(updatedAccionMantenimiento);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _accionMantenimientoService.Delete(id);

        return NoContent();
    }

    
}

