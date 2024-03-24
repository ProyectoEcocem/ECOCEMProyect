using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class CompraData
{
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaId {get; set;}

}

[ApiController]
[Route("api/[controller]")]
public class CompraController : Controller
{
    private readonly CompraServicio _compraServicio;
    private readonly UserManager<User>  _userManager;

    public CompraController(CompraServicio compraServicio, UserManager<User> userManager)
    {
        _compraServicio =compraServicio;
        _userManager = userManager;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(CompraData compra)
    {
        if (compra == null)
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
                Compra createdCompra1 =  await  _compraServicio.Create(compra, NoSede);
                return Ok(createdCompra1);
            }
        }

        Compra createdCompra =  await  _compraServicio.Create(compra, compra.SedeId);
        return Ok(createdCompra);
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int SedeId,int FabricaId,DateTime FechaCompraId)
    {
        Compra compra=await _compraServicio.Get(SedeId,FabricaId,FechaCompraId);
        if(compra == null){
            return NotFound();
        }
        return Ok(compra);
    }
    [Authorize(Roles="admin, jefe")]
     [HttpGet]
    public async Task<IEnumerable<Compra>> GetAll()
    {
        List<Compra>c = new();
        
        if (User.IsInRole("admin"))
        {
            return await _compraServicio.GetAll();
        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _compraServicio.GetAll(currentUser.NoSede);
            }

        }
        return c;
    }

    [HttpPut]
    public async Task<IActionResult> Put(int SedeId,int FabricaId,DateTime FechaCompraId,Compra compra)
    {
        if (compra == null)
        {
            return BadRequest();
        }

       Compra compraModificada = await _compraServicio.Update(SedeId,FabricaId,FechaCompraId,compra);

        if (compraModificada == null)
        {
            return NotFound();
        }

        return Ok(compraModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int SedeId,int FabricaId,DateTime FechaCompraId)
    {
        await _compraServicio.Delete(SedeId,FabricaId,FechaCompraId);

        return NoContent();
    }

    
}

