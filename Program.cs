using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ECOCEMProject;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//agregar el contexto de la base de datos como servicios
builder.Services.AddDbContext<MyContext>(opciones=>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
