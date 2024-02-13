using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class DescargaData
{
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    //public required Compra compra {get; set; }
    //public required ICollection<MedicionSilo> MedicionesSilo {get; set; }
    public int MedidorId { get; set; }

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    public int Volumen {get; set; }
    //public required ICollection<MedicionBascula> MedicionesBascula {get; set; }
    public int BasculaId { get; set; }
    public int PesoB {get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class DescargaController : Controller
{
    private readonly DescargaServicio _descargaServicio;

    public DescargaController(DescargaServicio descargaServicio)
    {
        _descargaServicio =descargaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(DescargaData descarga)
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

