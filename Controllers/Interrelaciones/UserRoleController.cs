/*using Microsoft.AspNetCore.Mvc;

namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserRoleController : Controller
{
    private readonly UserRoleServicio _userRoleServicio;

    public UserRoleController(UserRoleServicio userRoleServicio)
    {
        _userRoleServicio = userRoleServicio;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int id1, int id2)
    {
        return Ok(await  _userRoleServicio.Create(id1,id2));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int idUser, int idRole)
    {
        UserRole userRole = await _userRoleServicio.Get(idUser,idRole);
        if(userRole == null){
            return NotFound();
        }
        return Ok(userRole);
    }
    
     [HttpGet]
    public async Task<IEnumerable<UserRole>> GetAll() => await _userRoleServicio.GetAll();


    [HttpDelete]
    public async Task<IActionResult> Delete(int idUser, int idRole)
    {
        await _userRoleServicio.Delete(idUser,idRole);

        return NoContent();
    }
}*/