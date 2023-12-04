using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using ECOCEMProject;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//agregar el contexto de la base de datos como servicios
builder.Services.AddDbContext<MyContext>(opciones=>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))

);



builder.Services.AddControllers();

//agregar el contexto de la base de datos como servicios
builder.Services.AddDbContext<MyContext>(opciones=>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Servicios de entidades
//builder.Services.AddScoped<UserService>();
//builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<BasculaService>();
builder.Services.AddScoped<AccionMantenimientoService>();
builder.Services.AddScoped<SedeService>();
builder.Services.AddScoped<MedidorService>();
builder.Services.AddScoped<EntidadCompradoraService>();
builder.Services.AddScoped<Vehiculo>();
builder.Services.AddScoped<TipoCementoService>();
builder.Services.AddScoped<FabricaService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<HerramientaService>();
builder.Services.AddScoped<EquipoServicio>();
builder.Services.AddScoped<OperadorServicio>();
builder.Services.AddScoped<TrabajadorServicio>();
builder.Services.AddScoped<SiloServicio>();
builder.Services.AddScoped<BrigadaServicio>();
builder.Services.AddScoped<JefeMantenimientoServicio>();
builder.Services.AddScoped<TipoEquipoServicio>();
builder.Services.AddScoped<RoturaService>();
// Servicios de interrelaciones
builder.Services.AddScoped<CargaServicio>();
builder.Services.AddScoped<DescargaServicio>();
builder.Services.AddScoped<MedicionBasculaServicio>();
builder.Services.AddScoped<MedicionSiloServicio>();
builder.Services.AddScoped<VentaServicio>();
builder.Services.AddScoped<CompraServicio>();
builder.Services.AddScoped<ReporteServicio>();
builder.Services.AddScoped<OrdenTrabajoAtendidaServicio>();
builder.Services.AddScoped<RoturaEquipoServicio>();
//builder.Services.AddScoped<UserRoleServicio>();
builder.Services.AddScoped<FiltroMantenimientoService>();
builder.Services.AddScoped<IAutorizacionService, AutorizacionService>();


// // Agregar las clases User y Role usando el paquete Identity de .Net Core
// builder.Services.AddIdentity<User, Role>(options =>
//     {
//         options.Password.RequiredLength = 8;
//         options.Password.RequireNonAlphanumeric = false;
//         options.Password.RequireLowercase = true;
//         options.Password.RequireUppercase = true;
//         options.Password.RequireDigit = false;
//         options.Password.RequiredUniqueChars = 2;
//     })
//     .AddEntityFrameworkStores<MyContext>()
//     .AddDefaultTokenProviders()
//     .AddUserStore<UserStore<User,Role,MyContext,int>>()
//     .AddRoleStore<RoleStore<Role, MyContext, int>>();



var key = builder.Configuration.GetValue<string>("JwtSettings:key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey= true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuracion  HTTP .
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


