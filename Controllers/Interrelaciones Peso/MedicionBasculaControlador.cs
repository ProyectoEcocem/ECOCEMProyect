using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class MedicionBasculaData
{
    public int VehiculoId { get; set; }
    public int BasculaId { get; set; }
    public DateTime FechaBId {get; set;}

    public int PesoB {get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class MedicionBasculaController : Controller
{
    private readonly MedicionBasculaServicio _medicionBasculaServicio;
    private readonly UserManager<User>  _userManager;

    public MedicionBasculaController(MedicionBasculaServicio medicionBasculaServicio, UserManager<User> userManager)
    {
        _medicionBasculaServicio = medicionBasculaServicio;
        _userManager = userManager;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(MedicionBasculaData medicionBascula)
    {
        return Ok(await  _medicionBasculaServicio.Create(medicionBascula));
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        MedicionBascula medicionBascula=await _medicionBasculaServicio.Get(BasculaId, VehiculoId, FechaBId);
        if(medicionBascula == null){
            return NotFound();
        }
        return Ok(medicionBascula);
    }
    
    [Authorize(Roles="admin, jefe")]
     [HttpGet]
    public async Task<IEnumerable<MedicionBascula>> GetAll() 
    {
        List<MedicionBascula>mb = new();
        
        if (User.IsInRole("admin"))
        {
            return await _medicionBasculaServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _medicionBasculaServicio.GetAll(currentUser.NoSede);
            }

        }
        return mb;
    }

    [HttpPut]
    public async Task<IActionResult> Put(int BasculaId,int VehiculoId,DateTime FechaBId,MedicionBascula medicionBascula)
    {
        if (medicionBascula == null)
        {
            return BadRequest();
        }

        MedicionBascula medicionBasculaModificada = await _medicionBasculaServicio.Update(BasculaId,VehiculoId, FechaBId,medicionBascula);

        if (medicionBasculaModificada == null)
        {
            return NotFound();
        }

        return Ok(medicionBasculaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        await _medicionBasculaServicio.Delete( BasculaId,VehiculoId,FechaBId);

        return NoContent();
    }

    
}

