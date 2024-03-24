using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace ECOCEMProject;
public class EquipoData
{
    public int EquipoId {get; set;}
    public int TipoEId { get; set; }
    public int SedeId {get; set;}

}

[Route("api/[controller]")]
[ApiController]
public class EquipoController : Controller
{
    private readonly EquipoServicio _equipoServicio;
    private readonly UserManager<User>  _userManager;

    public EquipoController(EquipoServicio equipoServicio,  UserManager<User> userManager)
    {
        _equipoServicio = equipoServicio;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Equipo equipo = await _equipoServicio.Get(id);
        if (equipo == null)
        {
            return NotFound();
        }
        return Ok(equipo);
    }
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<Equipo>> GetAll()
    {
         List<Equipo>equipos = new();
        
        if (User.IsInRole("admin"))
        {
            return await _equipoServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _equipoServicio.GetAll(currentUser.NoSede);
            }

        }
        return equipos;

    } 

    [HttpPost]
    public async Task<IActionResult> Post(EquipoData equipo)
    {
        if (equipo == null)
        {
            return BadRequest();
        }

          if (User.IsInRole("jefe"))
        {
            int NoSede=0;
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                NoSede = currentUser.NoSede;
                Equipo equipoCreado1 = await _equipoServicio.Create(equipo,NoSede);
                return Ok(equipoCreado1);
            }
        }

        Equipo equipoCreado = await _equipoServicio.Create(equipo,equipo.SedeId);
        return Ok(equipoCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Equipo equipo)
    {
        if (equipo == null)
        {
            return BadRequest();
        }
        Equipo equipoModificado = await _equipoServicio.Update(id, equipo);
        if (equipoModificado == null)
        {
            return NotFound();
        }
        return Ok(equipoModificado);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _equipoServicio.Delete(id);
        return NoContent();
    }
}
