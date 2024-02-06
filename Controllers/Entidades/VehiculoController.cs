using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class VehiculoController : Controller
{
    private readonly VehiculoService _vehiculoService;

    public VehiculoController(VehiculoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Vehiculo vehiculo = await _vehiculoService.Get(id);
        if (vehiculo == null)
        {
            return NotFound();
        }
        return Ok(vehiculo);
    }

    [HttpGet]
    public async Task<IEnumerable<Vehiculo>> GetAll() => await _vehiculoService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Vehiculo vehiculo)
    {
        if (vehiculo == null)
        {
            return BadRequest();
        }
        Vehiculo createdVehiculo = await _vehiculoService.Create(vehiculo);
        return CreatedAtRoute("Get", new { id = createdVehiculo.VehiculoId }, createdVehiculo);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Vehiculo vehiculo)
    {
        if (vehiculo == null)
        {
            return BadRequest();
        }
        Vehiculo updatedVehiculo = await _vehiculoService.Update(id, vehiculo);
        if (updatedVehiculo == null)
        {
            return NotFound();
        }
        return Ok(updatedVehiculo);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _vehiculoService.Delete(id);
        return NoContent();
    }
}