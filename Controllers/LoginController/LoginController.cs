
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using NuGet.Packaging;
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
            
            // Creación e inicialización de un diccionario con pares clave-valor
            Dictionary<string, string> response = new Dictionary<string, string>();
            string user_name = user.UserName;
            List<Role> rol = roles.ToList();
            string role_name = rol[0].Name;
            // Añadiendo un valor al diccionario
            response.Add("uario",user_name);
            response.Add("role", role_name);

            
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


            return Ok(response);
        }
        [HttpGet]
        public async Task<List<Object>> GetAll() {
            // Completame esto
            IEnumerable<User> users = await _userService.GetAllUsers();

            List<Object> user = new List<Object>();

            foreach(User i in users)
            {
                Dictionary<string, string> response = new Dictionary<string, string>();
                response.Add("Name", i.Nombre);
                response.Add("Sede", i.NoSede.ToString());
                response.Add("Email", i.Email);
                user.Add(response);
            }

            return user;
        }
    }
