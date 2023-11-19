using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ECOCEMProject;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public LoginController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return BadRequest("El usuario no existe.");
        }

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return BadRequest("La contraseña es incorrecta.");
        }

        var token = await _userManager.GenerateUserTokenAsync(user, "Email", "Authentication");;
        return Ok(new { token });
    }
}
