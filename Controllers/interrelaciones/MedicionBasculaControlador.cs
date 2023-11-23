using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class MedicionBasculaController : Controller
{
    private readonly MedicionBasculaServicio _medicionBasculaServicio;

    public MedicionBasculaController(MedicionBasculaServicio medicionBasculaServicio)
    {
        _medicionBasculaServicio = medicionBasculaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(MedicionBascula medicionBascula)
    {
        return Ok(await  _medicionBasculaServicio.Create(medicionBascula));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        MedicionBascula medicionBascula=await _medicionBasculaServicio.Get(BasculaId, VehiculoId, FechaBId);
        if(medicionBascula == null){
            return NotFound();
        }
        return Ok(medicionBascula);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<MedicionBascula>> GetAll() => await _medicionBasculaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int BasculaId,int VehiculoId,DateTime FechaBId,MedicionBascula medicionBascula)
    {
        if (medicionBascula == null)
        {
            return BadRequest();
        }

        MedicionBascula medicionBasculaModificada = await _medicionBasculaServicio.Update(BasculaId,VehiculoId, FechaBId,medicionBascula);

        if (medicionBasculaModificada == null)
        {
            return NotFound();
        }

        return Ok(medicionBasculaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        await _medicionBasculaServicio.Delete( BasculaId,VehiculoId,FechaBId);

        return NoContent();
    }

    
}

