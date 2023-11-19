using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class JefeManteniminetoController : Controller
{
    private readonly JefeMantenimientoServicio _jefeMantenimientoServicio;

    public JefeManteniminetoController(JefeMantenimientoServicio jefeMantenimientoServicio)
    {
        _jefeMantenimientoServicio = jefeMantenimientoServicio;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        JefeMantenimiento jefeMantenimiento = await _jefeMantenimientoServicio.Get(id);
        if (jefeMantenimiento == null)
        {
            return NotFound();
        }
        return Ok(jefeMantenimiento);
    }

    [HttpGet]
    public async Task<IEnumerable<JefeMantenimiento>> GetAll() => await _jefeMantenimientoServicio.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] JefeMantenimiento jefeMantenimiento)
    {
        if (jefeMantenimiento == null)
        {
            return BadRequest();
        }
        JefeMantenimiento jefeMCreado = await _jefeMantenimientoServicio.Create(jefeMantenimiento);
        return CreatedAtRoute("Get", new { id = jefeMCreado.TrabajadorId}, jefeMCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, JefeMantenimiento jefeMantenimiento)
    {
        if (jefeMantenimiento == null)
        {
            return BadRequest();
        }
        JefeMantenimiento jefeMModificado = await _jefeMantenimientoServicio.Update(id, jefeMantenimiento);
        if (jefeMModificado == null)
        {
            return NotFound();
        }
        return Ok(jefeMModificado);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _jefeMantenimientoServicio.Delete(id);
        return NoContent();
    }
}