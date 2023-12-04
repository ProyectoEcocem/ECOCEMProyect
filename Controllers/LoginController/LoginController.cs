
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;


namespace ECOCEMProject;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
         private readonly UserService _userService;
        // private readonly RoleService _roleService;
        // private readonly UserRoleServicio _userRoleService;

        private readonly IAutorizacionService _autorizacionService;

        public LoginController(
            IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }

        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel autorizacion) {
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);
            if(resultado_autorizacion == null)
                return Unauthorized();

            return Ok(resultado_autorizacion);
        
        }

        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(
                login.Name!,
                login.Password!,
                isPersistent: false,
                lockoutOnFailure: false);
            if (!result.Succeeded)
                return BadRequest("Wrong name or password");

            var user = await _userService.GetByName(login.Name!);
            var roles =  await _filtro.GetRoles(user.Id);
            
            // Crea una lista de claims.
            var claims = new List<Claim>
            {
                new(ClaimTypes.Sid, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName!)
            };

            // Agrega un claim por cada rol del usuario.
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name!));
            }

            return Ok(roles);
        }*/
    }
