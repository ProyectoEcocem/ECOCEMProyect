using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace ECOCEMProject;

public class SiloData
{
    public int SiloId {get; set;}
    public string? NoSilo {get; set;}
    public int NoSede {get; set;}
    public int radio{get; set;}
    public int altura{get; set;}
}

[Route("api/[controller]")]
[ApiController]

public class SiloController:Controller
{
    private readonly SiloServicio _siloServicio;
    private readonly UserManager<User>  _userManager;

    public SiloController(SiloServicio siloServicio, UserManager<User> userManager)
    {
        _siloServicio = siloServicio;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Silo silo = await _siloServicio.Get(id);

        if (silo == null)
        {
            return NotFound();
        }

        return Ok(silo);
    }

    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<SiloDto>> GetAll()
    {
        List<SiloDto>silos = new();
        
        if (User.IsInRole("admin"))
        {
            return await _siloServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _siloServicio.GetAll(currentUser.NoSede);
            }

        }
        return silos; 
    } 

    [HttpPost]
    public async Task<IActionResult> Post( SiloData silo)
    {
        if (silo == null)
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
                Silo siloCreado1= await _siloServicio.Create(silo,NoSede);
                return Ok(siloCreado1);
            }
        }

        Silo siloCreado= await _siloServicio.Create(silo,silo.NoSede);

        return Ok(siloCreado);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Silo silo)
    {
        if (silo == null)
        {
            return BadRequest();
        }

        Silo SiloModificada = await _siloServicio.Update(id,silo);

        if (SiloModificada== null)
        {
            return NotFound();
        }

        return Ok(SiloModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _siloServicio.Delete(id);

        return NoContent();
    }
    
}
