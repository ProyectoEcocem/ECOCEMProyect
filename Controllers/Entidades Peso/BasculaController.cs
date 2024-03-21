using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IEnumerable<Bascula>> GetAll() => await _basculaService.GetAll();

    [Authorize(Roles="ADMIN,LiderSucursal")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bascula bascula)
    {
        if (User.IsInRole("role"))
        {
            Console.WriteLine("User belongs to the NetworkUser role.");
        }
        // Get the current user
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);

        if (currentUser != null)
        {
            int NoSede = currentUser.NoSede;
        }

        if (bascula == null)
        {
            return BadRequest();
        }

        Bascula createdBascula = await _basculaService.Create(bascula);
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





