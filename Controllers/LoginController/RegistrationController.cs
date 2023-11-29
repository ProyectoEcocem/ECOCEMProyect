
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;


namespace ECOCEMProject;


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private readonly UserRoleServicio _userRoleService;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly FiltroMantenimientoService _filtro;

        public RegistrationController(
            UserService userService,
            RoleService roleService,
            UserRoleServicio userRoleService,
            IConfiguration configuration,
            FiltroMantenimientoService filtro,
            
            
            
            SignInManager<User> signInManager)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _configuration = configuration;
            _signInManager = signInManager;
            _filtro = filtro;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel new_user)
        {
            User current_user;
            Role current_role;
            try
            {
                current_user = await _userService.Create(new_user.User!);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The user name is already in use");
            }
            catch (ArgumentException)
            {
                return BadRequest("The password must contain at least 8 characters, a lower-case alphanumeric character"
                    + ", an upper-case alphanumeric character and two unique characters");
            }
            catch
            {
                return BadRequest("Fatal error");
            }
            
            try
            {
                current_role = await _roleService.Create(new_user.Role!);
            }
            catch (InvalidOperationException)
            {
                current_role = await _roleService.GetByName(new_user.Role!.Name!);
            }
            catch
            {
                await _userService.DeleteByName(current_user.Nombre);
                return BadRequest("Fatal errwor");
            }
            await _userRoleService.Create(current_user.Id, current_role.Id);
            await _signInManager.SignInAsync(current_user, isPersistent: false);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
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

            return Ok();
        }
    }
