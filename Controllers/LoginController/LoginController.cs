
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.IdentityModel.Tokens;


namespace ECOCEMProject;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private readonly UserRoleServicio _userRoleService;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly FiltroMantenimientoService _filtro;

        public LoginController(
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

            // // Crear un ClaimsIdentity y un ClaimsPrincipal.
            // var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            // var principal = new ClaimsPrincipal(identity);

            // // Crear AuthenticationProperties.
            // var authProperties = new AuthenticationProperties
            // {
            //     // Configura la cookie para que expire después de 10 minutos.
            //     ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //     // Configura la cookie para que sea persistente.
            //     IsPersistent = true,
            //     // Configura la cookie para que solo se envíe a través de HTTPS.
            //     RedirectUri = Url.Action("Index", "Home"),
            // };

            // Inicia la sesión del usuario.
            // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);


            return Ok();
        }
    }
