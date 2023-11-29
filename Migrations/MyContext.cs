using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class MyContext: DbContext
{
    private readonly IConfiguration _configuration;

    public MyContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public DbSet<User>Users {get; set;}
    public DbSet<Role>Roles {get; set;}
    public DbSet<UserRole>UserRoles {get; set;}
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
    public DbSet<Brigada>Brigadas{get;set;}
    public DbSet<AccionMantenimiento>AccionesMantenimientos{get;set;}
    public DbSet<MantenimientoPlanificado>MantenimientosPlanificados{get;set;}
    public DbSet<Empresa>Empresas{get;set;}
    public DbSet<Equipo>Equipos{get;set;}
    public DbSet<Herramienta>Herramientas{get;set;}
    public DbSet<JefeMantenimiento>JefesMantenimientos{get;set;}
    public DbSet<Reporte>Reportes{get;set;}
    public DbSet<Rotura>Roturas{get;set;}
    public DbSet<TipoEquipo>TiposEquipos{get;set;}
    public DbSet<Trabajador>Trabajadores{get;set;}
    public DbSet<Operador>Operadores{get;set;}
    public DbSet<RoturaEquipo>RoturasEquipos{get;set;}
    public DbSet<Descarga>Descargas{get;set;}
    public DbSet<MantenimientoNecesario>MantenimientosNecesarios{get;set;} 
    public DbSet<MedicionBascula>MedicionesBasculas{get;set;}
    public DbSet<MedicionSilo>MedicionesSilos{get;set;}
    public DbSet<OrdenTrabajoAtendida>OrdenesTrabajoAtendidas{get;set;}
    public DbSet<Venta>Ventas{get;set;}
    public DbSet<IdentityUserClaim<int>> UserClaims { get; set; }


 
        protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        modelBuilder.Entity<Compra>()
            .HasKey(key => new { key.SedeId, key.FabricaId, key.FechaId });
        
        modelBuilder.Entity<Venta>()
            .HasKey(key => new { key.SedeId, key.EntidadCompradoraId, key.FechaVentaId });
        
        modelBuilder.Entity<Carga>()
            .HasKey(key => new { key.TipoCementoId, key.SiloId,key.VehiculoId, key.FechaCargaId });
        
        modelBuilder.Entity<Descarga>()
            .HasKey(key => new {key.TipoCementoId, key.SiloId, key.VehiculoId, key.FechaId});
        
        modelBuilder.Entity<MedicionBascula>()
            .HasKey(key => new { key.VehiculoId, key.BasculaId, key.FechaBId });
        
        modelBuilder.Entity<MedicionSilo>()
            .HasKey(key => new { key.SiloId, key.MedidorId, key.FechaMId });
        
        modelBuilder.Entity<MantenimientoNecesario>()
            .HasKey(key => new { key.TipoEquipoId, key.AMId, key.HorasExpId });
        
        modelBuilder.Entity<OrdenTrabajoAtendida>()
            .HasKey(key => new { key.TrabajadorId, key.DiaId });
        
        modelBuilder.Entity<Reporte>()
            .HasKey(key => new { key.EquipoId, key.FechaId });
        
        modelBuilder.Entity<AccionMantenimiento>()
            .HasKey(key => new { key.AMId });
        
        modelBuilder.Entity<HerramientaMantNecesario>()
            .HasKey(key => new { key.HerramientasId, key.TipoEquipoId,key.AMId, key.HorasExpId  });
        
        modelBuilder.Entity<OrdenTrabajoAMRealizada>()
            .HasKey(key => new { key.AMId, key.EquipoId,key.BrigadaId, key.TrabajadorId, key.FechaId  });
        
        modelBuilder.Entity<OrdenTrabajoHerramienta>()
            .HasKey(key => new { key.HerramientasId, key.EquipoId,key.BrigadaId, key.TrabajadorId, key.FechaId  });
        
        modelBuilder.Entity<TipoEquipo>()
            .HasKey(key => new { key.TipoEId });
        
        modelBuilder.Entity<RoturaEquipo>()
            .HasKey(key=> new {key.EquipoId, key.RoturaId, key.FechaId});
        
        modelBuilder.Entity<OrdenTrabajo>()
            .HasKey(key=> new {key.EquipoId, key.BrigadaId,key.TrabajadorId, key.FechaId});
        
        modelBuilder.Entity<Equipo>()
            .HasOne(equipo => equipo.TipoEquipo)
            .WithOne(tipoEquipo => tipoEquipo.Equipo)
            .HasForeignKey<Equipo>(equipo => equipo.TipoEId);

        modelBuilder.Entity<OrdenTrabajoRoturaEquipo>()
            .HasKey(key=> new {key.EquipoId, key.BrigadaId,key.TrabajadorId, key.FechaId});

        modelBuilder.Entity<IdentityUserRole<int>>()
            .HasKey(key => new { key.UserId, key.RoleId });


        /*modelBuilder.Entity<UserRole>()
            .HasKey(key => new { key.UserId, key.RoleId } );*/

        modelBuilder.Entity<User>()
            .HasMany(e => e.Roles)
            .WithMany(e => e.Users);


        modelBuilder.Entity<Empresa>()
            .HasMany(e => e.Sedes)
            .WithOne(e => e.Empresa)
            .HasForeignKey(e => e.EmpresaId)
            .IsRequired();

        modelBuilder.Entity<Sede>()
            .HasMany(e => e.Trabajadores)
            .WithOne(e => e.Sede)
            .HasForeignKey(e => e.SedeId)
            .IsRequired();
        modelBuilder.Entity<Sede>()
            .HasMany(e=>e.Equipos)
            .WithOne(e=>e.Sede)
            .HasForeignKey(e=>e.SedeId)
            .IsRequired();
                
        modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            entity.ToTable("IdentityRoleClaims");
            entity.HasKey(p => new { p.RoleId, p.ClaimType });
        });




    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {      
        var default_connection = _configuration.GetConnectionString("DefaultConnection");
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(default_connection);
    }
}
