using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class TrabajadorData{
    public int TrabajadorId {get; set;}
    public string? NombreTrabajador {get; set;}
    public int SedeId {get; set;}
}

[Route("api/[controller]")]
[ApiController]
public class TrabajadorController : Controller
{
    private readonly TrabajadorServicio _trabajadorServicio;
    private readonly UserManager<User>  _userManager;

    public TrabajadorController(TrabajadorServicio trabajadorServicio,  UserManager<User> userManager)
    {
       _trabajadorServicio = trabajadorServicio;
       _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Trabajador trabajador = await _trabajadorServicio.Get(id);
        if (trabajador == null)
        {
            return NotFound();
        }
        return Ok(trabajador);
    }

    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<Trabajador>> GetAll() 
    {
         List<Trabajador>trab = new();
        
        if (User.IsInRole("admin"))
        {
            return await _trabajadorServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _trabajadorServicio.GetAll(currentUser.NoSede);
            }

        }
        return trab;

    }

    [Authorize(Roles="admin, jefe")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TrabajadorData trabajador)
    {
        if (trabajador == null)
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
                Trabajador trabajadorCreado1 = await _trabajadorServicio.Create(trabajador,NoSede);
                return Ok(trabajadorCreado1);
            }
        }

        Trabajador trabajadorCreado = await _trabajadorServicio.Create(trabajador, trabajador.SedeId);
        return Ok(trabajadorCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Trabajador trabajador)
    {
        if (trabajador == null)
        {
            return BadRequest();
        }
        Trabajador trabajadorModificado = await _trabajadorServicio.Update(id, trabajador);
        if (trabajadorModificado == null)
        {
            return NotFound();
        }
        return Ok(trabajadorModificado);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _trabajadorServicio.Delete(id);
        return NoContent();
    }
}
