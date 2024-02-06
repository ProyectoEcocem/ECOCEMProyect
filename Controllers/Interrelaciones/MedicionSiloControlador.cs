using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class MedicionSiloController : Controller
{
    private readonly MedicionSiloServicio _medicionSiloServicio;

    public MedicionSiloController(MedicionSiloServicio medicionSiloServicio)
    {
        _medicionSiloServicio = medicionSiloServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(MedicionSilo medicionSilo)
    {
        return Ok(await  _medicionSiloServicio.Create(medicionSilo));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int SiloId,int MedidorId,DateTime FechaMId)
    {
        MedicionSilo medicionSilo=await _medicionSiloServicio.Get(SiloId,MedidorId, FechaMId);
        if( medicionSilo == null){
            return NotFound();
        }
        return Ok(medicionSilo);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<MedicionSilo>> GetAll() => await _medicionSiloServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int SiloId,int MedidorId,DateTime FechaMId,MedicionSilo medicionSilo)
    {
        if (medicionSilo == null)
        {
            return BadRequest();
        }

        MedicionSilo medicionSiloModificada = await _medicionSiloServicio.Update(SiloId,MedidorId, FechaMId,medicionSilo);

        if (medicionSiloModificada == null)
        {
            return NotFound();
        }

        return Ok(medicionSiloModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int SiloId,int MedidorId,DateTime FechaMId)
    {
        await _medicionSiloServicio.Delete(SiloId,MedidorId, FechaMId);

        return NoContent();
    }

    
}

