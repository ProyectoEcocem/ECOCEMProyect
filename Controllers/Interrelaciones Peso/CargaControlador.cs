using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class CargaData
{
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    //public required Venta venta {get; set; }
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
public class CargaController : Controller
{
    private readonly CargaServicio _cargaServicio;

    public CargaController(CargaServicio cargaServicio)
    {
        _cargaServicio = cargaServicio;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CargaData carga)
    {
        return Ok(await  _cargaServicio.Create(carga));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        Carga carga = await _cargaServicio.Get(TipoCementoId, SiloId, VehiculoId, FechaCargaId);
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

