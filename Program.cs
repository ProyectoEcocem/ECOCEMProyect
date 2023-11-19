using Microsoft.EntityFrameworkCore;
using ECOCEMProject;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//agregar el contexto de la base de datos como servicios
builder.Services.AddDbContext<MyContext>(opciones=>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Servicios de entidades
builder.Services.AddScoped<BasculaService>();
builder.Services.AddScoped<AccionMantenimientoService>();
builder.Services.AddScoped<SedeService>();
builder.Services.AddScoped<MedidorService>();
builder.Services.AddScoped<EntidadCompradoraService>();
builder.Services.AddScoped<Vehiculo>();
builder.Services.AddScoped<TipoCementoService>();
builder.Services.AddScoped<RoturaService>();
builder.Services.AddScoped<FabricaService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<HerramientaService>();
builder.Services.AddScoped<EquipoServicio>();
builder.Services.AddScoped<OperadorServicio>();
builder.Services.AddScoped<TrabajadorServicio>();
builder.Services.AddScoped<SiloServicio>();
builder.Services.AddScoped<BrigadaServicio>();
builder.Services.AddScoped<JefeMantenimientoServicio>();
// Servicios de interrelaciones
builder.Services.AddScoped<CargaServicio>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuracion  HTTP .
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
