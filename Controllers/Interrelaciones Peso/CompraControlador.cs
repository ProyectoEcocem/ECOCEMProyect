using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class CompraController : Controller
{
    private readonly CompraServicio _compraServicio;

    public CompraController(CompraServicio compraServicio)
    {
        _compraServicio =compraServicio;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Compra compra)
    {
        return Ok(await  _compraServicio.Create(compra));
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
    // GETALL
     [HttpGet]
    public async Task<IEnumerable<Compra>> GetAll() => await _compraServicio.GetAll();

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

