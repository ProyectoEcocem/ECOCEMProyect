using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class CargaData
{
    public int CargaId = 0;
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    public int PesoBruto {get; set;}
    public int Tara {get; set;}

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
    private readonly UserManager<User>  _userManager;

    public CargaController(CargaServicio cargaServicio, UserManager<User> userManager)
    {
        _cargaServicio = cargaServicio;
        _userManager = userManager;
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
    
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<CargaDto>> GetAll()
    {
         List<CargaDto>carga = new();
        
        if (User.IsInRole("admin"))
        {
            return await _cargaServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _cargaServicio.GetAll(currentUser.NoSede);
            }

        }
        return carga;

    }

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

