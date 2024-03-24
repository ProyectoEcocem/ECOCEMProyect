using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace ECOCEMProject;

public class MantenimientoNecesarioData
{
    public int TipoEId {get; set;}
    public int AMId {get; set;}
    public double HorasExpId {get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class MantenimientoNecesarioController : Controller
{
    private readonly MantenimientoNecesarioServicio _mantenimientoNecesarioServicio;
    private readonly UserManager<User>  _userManager;

    public MantenimientoNecesarioController(MantenimientoNecesarioServicio mantenimientoNecesarioServicio, UserManager<User> userManager)
    {
        _mantenimientoNecesarioServicio = mantenimientoNecesarioServicio;
        _userManager = userManager;
    }

    
    [HttpPost]
    public async Task<ActionResult> Post(MantenimientoNecesarioData mn)
    {
        return Ok(await  _mantenimientoNecesarioServicio.Create(mn));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int TipoEquipoId,int AMId,double HorasExpId)
    {
        MantenimientoNecesario mn=await _mantenimientoNecesarioServicio.Get(TipoEquipoId,AMId,HorasExpId);
        if(mn == null){
            return NotFound();
        }
        return Ok(mn);
    }

    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<MantenimientoNecesario>> GetAll()
    {
        List<MantenimientoNecesario>mn = new();
        
        if (User.IsInRole("admin"))
        {
            return await _mantenimientoNecesarioServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _mantenimientoNecesarioServicio.GetAll(currentUser.NoSede);
            }

        }
        return mn;
    }

    [HttpPut]
    public async Task<IActionResult> Put(int TipoEquipoId,int AMId,double HorasExpId,MantenimientoNecesario mn)
    {
        if (mn == null)
        {
            return BadRequest();
        }

        MantenimientoNecesario mnModificada = await _mantenimientoNecesarioServicio.Update(TipoEquipoId,AMId,HorasExpId,mn);

        if (mnModificada == null)
        {
            return NotFound();
        }

        return Ok(mnModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int TipoEquipoId,int AMId,double HorasExpId)
    {
        await _mantenimientoNecesarioServicio.Delete(TipoEquipoId,AMId,HorasExpId);

        return NoContent();
    }

    
}

