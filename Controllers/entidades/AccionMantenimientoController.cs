using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccionMantenimientoController : Controller
{
    private readonly AccionMantenimientoService _accionMantenimientoService;

    public AccionMantenimientoController(AccionMantenimientoService accionMantenimientoService)
    {
        _accionMantenimientoService = accionMantenimientoService;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(AccionMantenimiento accionMantenimiento)
    {
        return Ok(await _accionMantenimientoService.Create(accionMantenimiento));
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

