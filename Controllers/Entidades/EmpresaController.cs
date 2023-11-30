using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmpresaController : Controller
{
    private readonly EmpresaService _empresaService;

    public EmpresaController(EmpresaService empresaService)
    {
        _empresaService = empresaService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Empresa empresa = await _empresaService.Get(id);
        if (empresa == null)
        {
            return NotFound();
        }
        return Ok(empresa);
    }

    [HttpGet]
    public async Task<IEnumerable<Empresa>> GetAll() => await _empresaService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Empresa empresa)
    {
        if (empresa == null)
        {
            return BadRequest();
        }
        Empresa creadaEmpresa = await _empresaService.Create(empresa);
        return CreatedAtRoute("Get", new { id = creadaEmpresa.EmpresaId }, creadaEmpresa);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Empresa empresa)
    {
        if (empresa == null)
        {
            return BadRequest();
        }
        Empresa modificadaEmpresa = await _empresaService.Update(id, empresa);
        if (modificadaEmpresa == null)
        {
            return NotFound();
        }
        return Ok(modificadaEmpresa);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _empresaService.Delete(id);
        return NoContent();
    }
}