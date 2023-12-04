using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class VentaController : Controller
{
    private readonly VentaServicio _ventaServicio;

    public VentaController(VentaServicio ventaServicio)
    {
        _ventaServicio =ventaServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Venta venta)
    {
        return Ok(await  _ventaServicio.Create(venta));
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
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<Venta>> GetAll() => await _ventaServicio.GetAll();

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

