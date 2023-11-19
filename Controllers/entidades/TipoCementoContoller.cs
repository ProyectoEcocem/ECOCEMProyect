using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class TipoCementoController : Controller
{
    private readonly TipoCementoService _tipoCementoService;

    public TipoCementoController(TipoCementoService tipoCementoService)
    {
        _tipoCementoService = tipoCementoService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        TipoCemento tipoCemento = await _tipoCementoService.Get(id);
        if (tipoCemento == null)
        {
            return NotFound();
        }
        return Ok(tipoCemento);
    }

    [HttpGet]
    public async Task<IEnumerable<TipoCemento>> GetAll() => await _tipoCementoService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TipoCemento tipoCemento)
    {
        if (tipoCemento == null)
        {
            return BadRequest();
        }
        TipoCemento createdTipoCemento = await _tipoCementoService.Create(tipoCemento);
        return CreatedAtRoute("Get", new { id = createdTipoCemento.TipoCementoId }, createdTipoCemento);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, TipoCemento tipoCemento)
    {
        if (tipoCemento == null)
        {
            return BadRequest();
        }
        TipoCemento updatedTipoCemento = await _tipoCementoService.Update(id, tipoCemento);
        if (updatedTipoCemento == null)
        {
            return NotFound();
        }
        return Ok(updatedTipoCemento);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _tipoCementoService.Delete(id);
        return NoContent();
    }
}
