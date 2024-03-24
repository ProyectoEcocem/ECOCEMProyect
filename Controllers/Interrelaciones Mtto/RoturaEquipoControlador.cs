using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class RoturaEquipoData
{
    public int EquipoId {get; set;}
    public int RoturaId {get; set;}
    public DateTime FechaId {get; set;}

}


[ApiController]
[Route("api/[controller]")]
public class RoturaEquipoController : Controller
{
    private readonly RoturaEquipoServicio _roturaEquipoServicio;
    private readonly UserManager<User>  _userManager;

    public RoturaEquipoController(RoturaEquipoServicio roturaEquipoServicio, UserManager<User> userManager)
    {
        _roturaEquipoServicio =roturaEquipoServicio;
        _userManager = userManager;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(RoturaEquipoData roturaE)
    {
        if (roturaE == null)
        {
            return BadRequest();
        }
        RoturaEquipo RECreada = await _roturaEquipoServicio.Create(roturaE);
        return Ok(RECreada);
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int RoturaId,int EquipoId,DateTime FechaId)
    {
        RoturaEquipo roturaE=await _roturaEquipoServicio.Get(RoturaId,EquipoId,FechaId);
        if(roturaE == null){
            return NotFound();
        }
        return Ok(roturaE);
    }
    
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<RoturaEquipo>> GetAll() 
    {
        List<RoturaEquipo>re = new();
        
        if (User.IsInRole("admin"))
        {
            return await _roturaEquipoServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _roturaEquipoServicio.GetAll(currentUser.NoSede);
            }

        }
        return re;

    }

    [HttpPut]
    public async Task<IActionResult> Put(int RoturaId,int EquipoId,DateTime FechaId,RoturaEquipo roturaEquipo)
    {
        if (roturaEquipo == null)
        {
            return BadRequest();
        }

        RoturaEquipo roturaEquipoModificada = await _roturaEquipoServicio.Update(RoturaId,EquipoId,FechaId,roturaEquipo);

        if (roturaEquipoModificada == null)
        {
            return NotFound();
        }

        return Ok(roturaEquipoModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int RoturaId,int EquipoId,DateTime FechaId)
    {
        await _roturaEquipoServicio.Delete( RoturaId,EquipoId,FechaId);

        return NoContent();
    }

    
}

