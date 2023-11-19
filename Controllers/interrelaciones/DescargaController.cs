using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class DescargaController : Controller
{
    private readonly DescargaServicio _descargaServicio;

    public DescargaController(DescargaServicio descargaServicio)
    {
        _descargaServicio =descargaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Descarga descarga)
    {
        return Ok(await  _descargaServicio.Create(descarga));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId)
    {
        Descarga descarga=await _descargaServicio.Get(TipoCementoId, SiloId, VehiculoId, FechaId);
        if(descarga == null){
            return NotFound();
        }
        return Ok(descarga);
    }
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<Descarga>> GetAll() => await _descargaServicio.GetAll();

    [HttpPut]
    public async Task<IActionResult> Put(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId,Descarga descarga)
    {
        if (descarga == null)
        {
            return BadRequest();
        }

        Descarga descargaModificada = await _descargaServicio.Update(TipoCementoId,SiloId,VehiculoId, FechaId,descarga);

        if (descargaModificada == null)
        {
            return NotFound();
        }

        return Ok(descargaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId)
    {
        await _descargaServicio.Delete( TipoCementoId,SiloId,VehiculoId,FechaId);

        return NoContent();
    }

    
}

