using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class MedicionSiloData
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    public int Volumen {get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class MedicionSiloController : Controller
{
    private readonly MedicionSiloServicio _medicionSiloServicio;
    private readonly UserManager<User>  _userManager;

    public MedicionSiloController(MedicionSiloServicio medicionSiloServicio, UserManager<User> userManager)
    {
        _medicionSiloServicio = medicionSiloServicio;
        _userManager = userManager;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(MedicionSiloData medicionSilo, UserManager<User> userManager)
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
    
    [Authorize(Roles="admin, jefe")]
     [HttpGet]
    public async Task<IEnumerable<MedicionSilo>> GetAll() 
    {
        List<MedicionSilo>ms = new();
        
        if (User.IsInRole("admin"))
        {
            return await _medicionSiloServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _medicionSiloServicio.GetAll(currentUser.NoSede);
            }

        }
        return ms;

    }

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

