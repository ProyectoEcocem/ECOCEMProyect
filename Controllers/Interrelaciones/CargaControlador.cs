using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class CargaController : Controller
{
    private readonly CargaServicio _cargaServicio;

    public CargaController(CargaServicio cargaServicio)
    {
        _cargaServicio =cargaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Carga carga)
    {
        return Ok(await  _cargaServicio.Create(carga));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        Carga carga=await _cargaServicio.Get(TipoCementoId, SiloId, VehiculoId, FechaCargaId);
        if(carga == null){
            return NotFound();
        }
        return Ok(carga);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<Carga>> GetAll() => await _cargaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId,Carga carga)
    {
        if (carga == null)
        {
            return BadRequest();
        }

        Carga cargaModificada = await _cargaServicio.Update(TipoCementoId,SiloId,VehiculoId, FechaCargaId,carga);

        if (cargaModificada == null)
        {
            return NotFound();
        }

        return Ok(cargaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        await _cargaServicio.Delete( TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        return NoContent();
    }

    
}

