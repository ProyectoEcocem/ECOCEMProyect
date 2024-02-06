using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;


[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        User user = await _userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet]
    public async Task<IEnumerable<User>> GetAll() => await _userService.GetAll();

    [HttpPost]
    public async Task<IActionResult> Post(RegistrationModel new_entity)
    {
        try
        {
            await _userService.Create(new_entity);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id,string? name, RegistrationModel edited_entity)
    {
        try
        {
            await _userService.Update(id, edited_entity);
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
        await _userService.Delete(id);
        return NoContent();
    }

    /*[HttpDelete("Nombre")]
    public async Task<IActionResult> DeleteByName(string name)
    {
        await _roleService.DeleteByName(name);
        return NoContent();
    }*/
}
