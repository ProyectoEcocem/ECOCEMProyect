using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

public class VentaData
{
    public int SedeId {get; set;}
    public int EntidadCompradoraId {get; set;}
    public DateTime FechaId {get; set;}

}

[ApiController]
[Route("api/[controller]")]
public class VentaController : Controller
{
    private readonly VentaServicio _ventaServicio;
    private readonly UserManager<User>  _userManager;

    public VentaController(VentaServicio ventaServicio, UserManager<User> userManager)
    {
        _ventaServicio =ventaServicio;
        _userManager = userManager;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(VentaData venta)
    {
        if (venta == null)
        {
            return BadRequest();
        }
        Venta createdVenta =  await  _ventaServicio.Create(venta);
        return Ok(createdVenta);
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId)
    {
        Venta venta=await _ventaServicio.Get(SedeId,EntidadCompradoraId,FechaVentaId);
        if(venta == null){
            return NotFound();
        }
        return Ok(venta);
    }
    [Authorize(Roles="admin, jefe")]
    [HttpGet]
    public async Task<IEnumerable<Venta>> GetAll() 
    {
        List<Venta>v = new();
        
        if (User.IsInRole("admin"))
        {
            return await _ventaServicio.GetAll();

        }
        else{

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                return await _ventaServicio.GetAll(currentUser.NoSede);
            }

        }
        return v;
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId,Venta venta)
    {
        if (venta == null)
        {
            return BadRequest();
        }

        Venta ventaModificada = await _ventaServicio.Update(SedeId,EntidadCompradoraId,FechaVentaId,venta);

        if (ventaModificada == null)
        {
            return NotFound();
        }

        return Ok(ventaModificada);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId)
    {
        await _ventaServicio.Delete( SedeId,EntidadCompradoraId,FechaVentaId);

        return NoContent();
    }

    
}

