using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;


[Route("api/[controller]")]
[ApiController]
public class RoleController : Controller
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }
    
    /*[HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        Role role = await _roleService.GetByName(name);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }*/
    [HttpGet]
    public async Task<IEnumerable<Role>> GetAll() => await _roleService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post(RoleModel new_entity)
    {
        try
        {
            await _roleService.Create(new_entity);

            return Ok(new_entity);

        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id,string? name, RoleModel edited_entity)
    {
        try
        {
            await _roleService.Update(id,name, edited_entity);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _roleService.Delete(id);
        return NoContent();
    }

    /*[HttpDelete("Nombre")]
    public async Task<IActionResult> DeleteByName(string name)
    {
        await _roleService.DeleteByName(name);
        return NoContent();
    }*/
}
