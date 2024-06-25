using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
namespace ECOCEMProject;

public class BasculaData
{
    public int BasculaId {get; set;}
    public string NoSerie { get; set; }
    public int SedeId {get; set;}
    public string Descripcion { get; set; }

}

[Route("api/[controller]")]
[ApiController]
public class BasculaController : Controller
{
    private readonly BasculaService _basculaService;
    private readonly UserManager<User>  _userManager;

    public BasculaController(BasculaService basculaService, UserManager<User> userManager)
    {
        _basculaService = basculaService;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get( int id)
    {
        Bascula bascula = await _basculaService.Get(id);

        if (bascula == null)
        {
            return NotFound();
        }

        return Ok(bascula);
    }
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<BasculaDto>> GetAll()
    {
        List<BasculaDto>basculas = new();
        
        if (User.IsInRole("admin"))
        {
            return await _basculaService.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _basculaService.GetAll(currentUser.NoSede);
            }

        }
        return basculas;
    } 

    // [Authorize(Roles="admin, jefe")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bascula bascula)
    {

        if (bascula == null)
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
                Bascula createdBascula1 = await _basculaService.Create(bascula,NoSede);
                return Ok(createdBascula1);
            }
        }

        Bascula createdBascula = await _basculaService.Create(bascula,bascula.NoSede);
        return Ok(createdBascula);
    }

    [HttpPut]
    public async Task<IActionResult> Put( int id, Bascula bascula)
    {
        if (bascula == null)
        {
            return BadRequest();
        }

        Bascula updatedBascula = await _basculaService.Update(id,bascula);

        if (updatedBascula == null)
        {
            return NotFound();
        }

        return Ok(updatedBascula);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _basculaService.Delete(id);

        return NoContent();
    }
}





