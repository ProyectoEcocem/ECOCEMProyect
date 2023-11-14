using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECOCEMProyect.migrations;


public class MyContext : DbContext//IdentityDbContext<Trabajador, Role, Guid>
{
    private readonly IConfiguration _configuration;

    public MyContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // public MyContext(DbContextOptions<MyContext> options) : base(options)
    // {
    // }

    // Definición de las entidades DbSet
    public DbSet<Bascula>Basculas {get; set;}
    public DbSet<EntidadCompradora> EntidadCompradoras {get; set;}
    public DbSet<Fabrica>Fabricas {get; set;}
    public DbSet<Medidor>Medidores {get; set;}
    public DbSet<Sede>Sedes {get; set;}
    public DbSet<Silo>Silos {get; set;}
    public DbSet<TipoCemento>TipoCementos {get; set;}
    public DbSet<Vehiculo>Vehiculos {get; set;}
    public DbSet<Carga>Cargas {get; set;}
    public DbSet<Compra>Compras {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {      
        var default_connection = _configuration.GetConnectionString("DefaultConnection");
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(default_connection);
    }

}
