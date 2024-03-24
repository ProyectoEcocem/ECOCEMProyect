using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace ECOCEMProject;


public class OrdenTrabajoData
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}
}

[ApiController]
[Route("api/[controller]")]
public class OrdenTrabajoController : Controller
{
    private readonly OrdenTrabajoServicio _ordenTrabajoServicio;
    private readonly UserManager<User>  _userManager;

    public OrdenTrabajoController(OrdenTrabajoServicio ordenTrabajoServicio, UserManager<User> userManager)
    {
        _ordenTrabajoServicio = ordenTrabajoServicio;
        _userManager = userManager;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(OrdenTrabajoData OT)
    {
        if (OT == null)
        {
            return BadRequest();
        }
        OrdenTrabajo OTCrada = await  _ordenTrabajoServicio.Create(OT);
        return Ok(OTCrada);
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        OrdenTrabajo OT = await _ordenTrabajoServicio.Get(EquipoId,BrigadaId,TrabajadorId, FechaId);
        if(OT == null){
            return NotFound();
        }
        return Ok(OT);
    }
    
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<OrdenTrabajo>> GetAll() 
    {
         List<OrdenTrabajo>ot = new();
        
        if (User.IsInRole("admin"))
        {
            return await _ordenTrabajoServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _ordenTrabajoServicio.GetAll(currentUser.NoSede);
            }

        }
        return ot;

    }

    [HttpPut]
    public async Task<IActionResult> Put(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId, OrdenTrabajo OT)
    {
        if (OT == null)
        {
            return BadRequest();
        }

        OrdenTrabajo OTModificada = await _ordenTrabajoServicio.Update(EquipoId,BrigadaId,TrabajadorId, FechaId, OT);

        if (OTModificada == null)
        {
            return NotFound();
        }

        return Ok(OTModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        await _ordenTrabajoServicio.Delete(EquipoId,BrigadaId,TrabajadorId, FechaId);

        return NoContent();
    }

    
}
