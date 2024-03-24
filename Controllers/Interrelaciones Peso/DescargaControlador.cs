using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<User>  _userManager;

    public DescargaController(DescargaServicio descargaServicio, UserManager<User> userManager)
    {
        _descargaServicio =descargaServicio;
        _userManager = userManager;
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
    [Authorize(Roles="admin, jefe")]
     [HttpGet]
    public async Task<IEnumerable<Descarga>> GetAll() 
    {
        List<Descarga>d = new();
        
        if (User.IsInRole("admin"))
        {
            return await _descargaServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _descargaServicio.GetAll(currentUser.NoSede);
            }

        }
        return d;
    }

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

