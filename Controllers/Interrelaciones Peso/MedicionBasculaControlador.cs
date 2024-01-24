using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class MedicionMedidorController : Controller
{
    private readonly MedicionMedidorServicio _medicionMedidorServicio;

    public MedicionMedidorController(MedicionMedidorServicio medicionMedidorServicio)
    {
        _medicionMedidorServicio = medicionMedidorServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(MedicionMedidor medicionMedidor)
    {
        return Ok(await  _medicionMedidorServicio.Create(medicionMedidor));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int MedidorId,int VehiculoId,DateTime FechaBId)
    {
        MedicionMedidor medicionMedidor=await _medicionMedidorServicio.Get(MedidorId, VehiculoId, FechaBId);
        if(medicionMedidor == null){
            return NotFound();
        }
        return Ok(medicionMedidor);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<MedicionMedidor>> GetAll() => await _medicionMedidorServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int MedidorId,int VehiculoId,DateTime FechaBId,MedicionMedidor medicionMedidor)
    {
        if (medicionMedidor == null)
        {
            return BadRequest();
        }

        MedicionMedidor medicionMedidorModificada = await _medicionMedidorServicio.Update(MedidorId,VehiculoId, FechaBId,medicionMedidor);

        if (medicionMedidorModificada == null)
        {
            return NotFound();
        }

        return Ok(medicionMedidorModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int MedidorId,int VehiculoId,DateTime FechaBId)
    {
        await _medicionMedidorServicio.Delete( MedidorId,VehiculoId,FechaBId);

        return NoContent();
    }

    
}

