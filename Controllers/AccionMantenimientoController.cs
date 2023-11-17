using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("API/[controller]/[action]")]
public class AccionMantenimientoController : ControllerBase
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
        return Ok(await _accionMantenimientoService.CreateAccionMantenimientoAsync(accionMantenimiento));
    }

    // GET by ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AccionMantenimiento>> GetById(int id)
    {
        return await _accionMantenimientoService.GetAccionMantenimientoAsync(id);
    }

    // PUT
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(AccionMantenimiento accionMantenimiento)
    {
        return Ok(await _accionMantenimientoService.UpdateAccionMantenimientoAsync(accionMantenimiento));
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _accionMantenimientoService.DeleteAccionMantenimientoAsync(id));
    }
}

