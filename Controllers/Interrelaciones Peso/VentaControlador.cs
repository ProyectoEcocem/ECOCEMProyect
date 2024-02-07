using Microsoft.AspNetCore.Http.HttpResults;
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

    public VentaController(VentaServicio ventaServicio)
    {
        _ventaServicio =ventaServicio;
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

