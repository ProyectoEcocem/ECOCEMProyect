using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECOCEMProject.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccionesMantenimientos",
                columns: table => new
                {
                    AMId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesMantenimientos", x => x.AMId);
                });

            migrationBuilder.CreateTable(
                name: "Basculas",
                columns: table => new
                {
                    BasculaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basculas", x => x.BasculaId);
                });

            migrationBuilder.CreateTable(
                name: "Brigadas",
                columns: table => new
                {
                    BrigadaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigadas", x => x.BrigadaId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "integer", nullable: false),
                    FabricaId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => new { x.SedeId, x.FabricaId, x.FechaId });
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreEmpresa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "EntidadCompradoras",
                columns: table => new
                {
                    EntidadCompradoraId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadCompradoras", x => x.EntidadCompradoraId);
                });

            migrationBuilder.CreateTable(
                name: "Fabricas",
                columns: table => new
                {
                    FabricaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricas", x => x.FabricaId);
                });

            migrationBuilder.CreateTable(
                name: "Herramientas",
                columns: table => new
                {
                    HerramientaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herramientas", x => x.HerramientaId);
                });

            migrationBuilder.CreateTable(
                name: "Medidores",
                columns: table => new
                {
                    MedidorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidores", x => x.MedidorId);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IndiceParoFalla = table.Column<double>(type: "double precision", nullable: false),
                    DisponibilidadRequerida = table.Column<double>(type: "double precision", nullable: false),
                    DisponibilidadReal = table.Column<double>(type: "double precision", nullable: false),
                    IndiceRotura = table.Column<double>(type: "double precision", nullable: false),
                    CostoTotalMantFact = table.Column<double>(type: "double precision", nullable: false),
                    CostoMantContratadoTotal = table.Column<double>(type: "double precision", nullable: false),
                    PerdidaIndisponibilidad = table.Column<double>(type: "double precision", nullable: false),
                    TiempoRealParoFalla = table.Column<double>(type: "double precision", nullable: false),
                    TiempoRealMant = table.Column<double>(type: "double precision", nullable: false),
                    TiempoOPeracionReal = table.Column<double>(type: "double precision", nullable: false),
                    TiempoParoTrabajosPlan = table.Column<double>(type: "double precision", nullable: false),
                    TiempoParoMant = table.Column<double>(type: "double precision", nullable: false),
                    TiempoOperacionRequerido = table.Column<double>(type: "double precision", nullable: false),
                    TiempoRequeridoAccProgramadas = table.Column<double>(type: "double precision", nullable: false),
                    CostoTotalMant = table.Column<double>(type: "double precision", nullable: false),
                    Facturacion = table.Column<double>(type: "double precision", nullable: false),
                    CostoMantContratado = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => new { x.EquipoId, x.FechaId });
                });

            migrationBuilder.CreateTable(
                name: "RoturaEquipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    RoturaId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoturaEquipo", x => new { x.EquipoId, x.RoturaId, x.FechaId });
                });

            migrationBuilder.CreateTable(
                name: "Roturas",
                columns: table => new
                {
                    RoturaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roturas", x => x.RoturaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoCementos",
                columns: table => new
                {
                    TipoCementoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCementos", x => x.TipoCementoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposEquipos",
                columns: table => new
                {
                    TipoEId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEquipos", x => x.TipoEId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "integer", nullable: false),
                    EntidadCompradoraId = table.Column<int>(type: "integer", nullable: false),
                    FechaVentaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => new { x.SedeId, x.EntidadCompradoraId, x.FechaVentaId });
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajo", x => new { x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId });
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Brigadas_BrigadaId",
                        column: x => x.BrigadaId,
                        principalTable: "Brigadas",
                        principalColumn: "BrigadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descargas",
                columns: table => new
                {
                    TipoCementoId = table.Column<int>(type: "integer", nullable: false),
                    SiloId = table.Column<int>(type: "integer", nullable: false),
                    VehiculoId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    compraSedeId = table.Column<int>(type: "integer", nullable: false),
                    compraFabricaId = table.Column<int>(type: "integer", nullable: false),
                    compraFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descargas", x => new { x.TipoCementoId, x.SiloId, x.VehiculoId, x.FechaId });
                    table.ForeignKey(
                        name: "FK_Descargas_Compras_compraSedeId_compraFabricaId_compraFechaId",
                        columns: x => new { x.compraSedeId, x.compraFabricaId, x.compraFechaId },
                        principalTable: "Compras",
                        principalColumns: new[] { "SedeId", "FabricaId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreSede = table.Column<string>(type: "text", nullable: true),
                    UbicacionSede = table.Column<string>(type: "text", nullable: true),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.SedeId);
                    table.ForeignKey(
                        name: "FK_Sedes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MantenimientosNecesarios",
                columns: table => new
                {
                    TipoEquipoId = table.Column<int>(type: "integer", nullable: false),
                    AMId = table.Column<int>(type: "integer", nullable: false),
                    HorasExpId = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MantenimientosNecesarios", x => new { x.TipoEquipoId, x.AMId, x.HorasExpId });
                    table.ForeignKey(
                        name: "FK_MantenimientosNecesarios_AccionesMantenimientos_AMId",
                        column: x => x.AMId,
                        principalTable: "AccionesMantenimientos",
                        principalColumn: "AMId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MantenimientosNecesarios_TiposEquipos_TipoEquipoId",
                        column: x => x.TipoEquipoId,
                        principalTable: "TiposEquipos",
                        principalColumn: "TipoEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolNombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cargas",
                columns: table => new
                {
                    TipoCementoId = table.Column<int>(type: "integer", nullable: false),
                    SiloId = table.Column<int>(type: "integer", nullable: false),
                    VehiculoId = table.Column<int>(type: "integer", nullable: false),
                    FechaCargaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SedeId = table.Column<int>(type: "integer", nullable: false),
                    EntidadCompradoraId = table.Column<int>(type: "integer", nullable: false),
                    FechaVentaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VentaSedeId = table.Column<int>(type: "integer", nullable: false),
                    VentaEntidadCompradoraId = table.Column<int>(type: "integer", nullable: false),
                    VentaFechaVentaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargas", x => new { x.TipoCementoId, x.SiloId, x.VehiculoId, x.FechaCargaId });
                    table.ForeignKey(
                        name: "FK_Cargas_Ventas_VentaSedeId_VentaEntidadCompradoraId_VentaFec~",
                        columns: x => new { x.VentaSedeId, x.VentaEntidadCompradoraId, x.VentaFechaVentaId },
                        principalTable: "Ventas",
                        principalColumns: new[] { "SedeId", "EntidadCompradoraId", "FechaVentaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionMantenimientoOrdenTrabajo",
                columns: table => new
                {
                    AccionesMantenimientoAMId = table.Column<int>(type: "integer", nullable: false),
                    OrdenesTrabajoEquipoId = table.Column<int>(type: "integer", nullable: false),
                    OrdenesTrabajoBrigadaId = table.Column<int>(type: "integer", nullable: false),
                    OrdenesTrabajoTrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    OrdenesTrabajoFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionMantenimientoOrdenTrabajo", x => new { x.AccionesMantenimientoAMId, x.OrdenesTrabajoEquipoId, x.OrdenesTrabajoBrigadaId, x.OrdenesTrabajoTrabajadorId, x.OrdenesTrabajoFechaId });
                    table.ForeignKey(
                        name: "FK_AccionMantenimientoOrdenTrabajo_AccionesMantenimientos_Acci~",
                        column: x => x.AccionesMantenimientoAMId,
                        principalTable: "AccionesMantenimientos",
                        principalColumn: "AMId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionMantenimientoOrdenTrabajo_OrdenTrabajo_OrdenesTrabajo~",
                        columns: x => new { x.OrdenesTrabajoEquipoId, x.OrdenesTrabajoBrigadaId, x.OrdenesTrabajoTrabajadorId, x.OrdenesTrabajoFechaId },
                        principalTable: "OrdenTrabajo",
                        principalColumns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajoAMRealizada",
                columns: table => new
                {
                    AMId = table.Column<int>(type: "integer", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Resultado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajoAMRealizada", x => new { x.AMId, x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId });
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoAMRealizada_AccionesMantenimientos_AMId",
                        column: x => x.AMId,
                        principalTable: "AccionesMantenimientos",
                        principalColumn: "AMId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoAMRealizada_OrdenTrabajo_EquipoId_BrigadaId_Tra~",
                        columns: x => new { x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId },
                        principalTable: "OrdenTrabajo",
                        principalColumns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajoHerramienta",
                columns: table => new
                {
                    HerramientasId = table.Column<int>(type: "integer", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnidadMedidaU = table.Column<string>(type: "text", nullable: true),
                    CantidadU = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    ValeAlmacen = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajoHerramienta", x => new { x.HerramientasId, x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId });
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoHerramienta_Herramientas_HerramientasId",
                        column: x => x.HerramientasId,
                        principalTable: "Herramientas",
                        principalColumn: "HerramientaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoHerramienta_OrdenTrabajo_EquipoId_BrigadaId_Tra~",
                        columns: x => new { x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId },
                        principalTable: "OrdenTrabajo",
                        principalColumns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajoRoturaEquipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoturaId = table.Column<int>(type: "integer", nullable: false),
                    RoturaEquipoEquipoId = table.Column<int>(type: "integer", nullable: false),
                    RoturaEquipoRoturaId = table.Column<int>(type: "integer", nullable: false),
                    RoturaEquipoFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrdenTrabajoEquipoId = table.Column<int>(type: "integer", nullable: false),
                    OrdenTrabajoBrigadaId = table.Column<int>(type: "integer", nullable: false),
                    OrdenTrabajoTrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    OrdenTrabajoFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajoRoturaEquipo", x => new { x.EquipoId, x.BrigadaId, x.TrabajadorId, x.FechaId });
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoRoturaEquipo_OrdenTrabajo_OrdenTrabajoEquipoId_~",
                        columns: x => new { x.OrdenTrabajoEquipoId, x.OrdenTrabajoBrigadaId, x.OrdenTrabajoTrabajadorId, x.OrdenTrabajoFechaId },
                        principalTable: "OrdenTrabajo",
                        principalColumns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoRoturaEquipo_RoturaEquipo_RoturaEquipoEquipoId_~",
                        columns: x => new { x.RoturaEquipoEquipoId, x.RoturaEquipoRoturaId, x.RoturaEquipoFechaId },
                        principalTable: "RoturaEquipo",
                        principalColumns: new[] { "EquipoId", "RoturaId", "FechaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoEId = table.Column<int>(type: "integer", nullable: false),
                    SedeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoId);
                    table.ForeignKey(
                        name: "FK_Equipos_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_TiposEquipos_TipoEId",
                        column: x => x.TipoEId,
                        principalTable: "TiposEquipos",
                        principalColumn: "TipoEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreTrabajador = table.Column<string>(type: "text", nullable: true),
                    SedeId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.TrabajadorId);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HerramientaMantNecesario",
                columns: table => new
                {
                    HerramientasId = table.Column<int>(type: "integer", nullable: false),
                    TipoEquipoId = table.Column<int>(type: "integer", nullable: false),
                    AMId = table.Column<int>(type: "integer", nullable: false),
                    HorasExpId = table.Column<double>(type: "double precision", nullable: false),
                    HerramientaId = table.Column<int>(type: "integer", nullable: true),
                    MantenimientoNecesarioTipoEquipoId = table.Column<int>(type: "integer", nullable: true),
                    MantenimientoNecesarioAMId = table.Column<int>(type: "integer", nullable: true),
                    MantenimientoNecesarioHorasExpId = table.Column<double>(type: "double precision", nullable: true),
                    UnidadMedidaR = table.Column<string>(type: "text", nullable: false),
                    CantidadR = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerramientaMantNecesario", x => new { x.HerramientasId, x.TipoEquipoId, x.AMId, x.HorasExpId });
                    table.ForeignKey(
                        name: "FK_HerramientaMantNecesario_Herramientas_HerramientaId",
                        column: x => x.HerramientaId,
                        principalTable: "Herramientas",
                        principalColumn: "HerramientaId");
                    table.ForeignKey(
                        name: "FK_HerramientaMantNecesario_MantenimientosNecesarios_Mantenimi~",
                        columns: x => new { x.MantenimientoNecesarioTipoEquipoId, x.MantenimientoNecesarioAMId, x.MantenimientoNecesarioHorasExpId },
                        principalTable: "MantenimientosNecesarios",
                        principalColumns: new[] { "TipoEquipoId", "AMId", "HorasExpId" });
                });

            migrationBuilder.CreateTable(
                name: "MedicionesBasculas",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "integer", nullable: false),
                    BasculaId = table.Column<int>(type: "integer", nullable: false),
                    FechaBId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PesoB = table.Column<int>(type: "integer", nullable: false),
                    TipoCementoId = table.Column<int>(type: "integer", nullable: false),
                    SiloId = table.Column<int>(type: "integer", nullable: false),
                    FechaCargaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CargaTipoCementoId = table.Column<int>(type: "integer", nullable: true),
                    CargaSiloId = table.Column<int>(type: "integer", nullable: true),
                    CargaVehiculoId = table.Column<int>(type: "integer", nullable: true),
                    CargaFechaCargaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DescargaTipoCementoId = table.Column<int>(type: "integer", nullable: true),
                    DescargaSiloId = table.Column<int>(type: "integer", nullable: true),
                    DescargaVehiculoId = table.Column<int>(type: "integer", nullable: true),
                    DescargaFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesBasculas", x => new { x.VehiculoId, x.BasculaId, x.FechaBId });
                    table.ForeignKey(
                        name: "FK_MedicionesBasculas_Cargas_CargaTipoCementoId_CargaSiloId_Ca~",
                        columns: x => new { x.CargaTipoCementoId, x.CargaSiloId, x.CargaVehiculoId, x.CargaFechaCargaId },
                        principalTable: "Cargas",
                        principalColumns: new[] { "TipoCementoId", "SiloId", "VehiculoId", "FechaCargaId" });
                    table.ForeignKey(
                        name: "FK_MedicionesBasculas_Descargas_DescargaTipoCementoId_Descarga~",
                        columns: x => new { x.DescargaTipoCementoId, x.DescargaSiloId, x.DescargaVehiculoId, x.DescargaFechaId },
                        principalTable: "Descargas",
                        principalColumns: new[] { "TipoCementoId", "SiloId", "VehiculoId", "FechaId" });
                });

            migrationBuilder.CreateTable(
                name: "MedicionesSilos",
                columns: table => new
                {
                    SiloId = table.Column<int>(type: "integer", nullable: false),
                    MedidorId = table.Column<int>(type: "integer", nullable: false),
                    FechaMId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    PesoM = table.Column<int>(type: "integer", nullable: false),
                    Volumen = table.Column<int>(type: "integer", nullable: false),
                    TipoCementoId = table.Column<int>(type: "integer", nullable: false),
                    VehiculoId = table.Column<int>(type: "integer", nullable: false),
                    FechaCargaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CargaTipoCementoId = table.Column<int>(type: "integer", nullable: true),
                    CargaSiloId = table.Column<int>(type: "integer", nullable: true),
                    CargaVehiculoId = table.Column<int>(type: "integer", nullable: true),
                    CargaFechaCargaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DescargaTipoCementoId = table.Column<int>(type: "integer", nullable: true),
                    DescargaSiloId = table.Column<int>(type: "integer", nullable: true),
                    DescargaVehiculoId = table.Column<int>(type: "integer", nullable: true),
                    DescargaFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesSilos", x => new { x.SiloId, x.MedidorId, x.FechaMId });
                    table.ForeignKey(
                        name: "FK_MedicionesSilos_Cargas_CargaTipoCementoId_CargaSiloId_Carga~",
                        columns: x => new { x.CargaTipoCementoId, x.CargaSiloId, x.CargaVehiculoId, x.CargaFechaCargaId },
                        principalTable: "Cargas",
                        principalColumns: new[] { "TipoCementoId", "SiloId", "VehiculoId", "FechaCargaId" });
                    table.ForeignKey(
                        name: "FK_MedicionesSilos_Descargas_DescargaTipoCementoId_DescargaSil~",
                        columns: x => new { x.DescargaTipoCementoId, x.DescargaSiloId, x.DescargaVehiculoId, x.DescargaFechaId },
                        principalTable: "Descargas",
                        principalColumns: new[] { "TipoCementoId", "SiloId", "VehiculoId", "FechaId" });
                });

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    SiloId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.SiloId);
                    table.ForeignKey(
                        name: "FK_Silos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesTrabajoAtendidas",
                columns: table => new
                {
                    TrabajadorId = table.Column<int>(type: "integer", nullable: false),
                    DiaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EquipoId = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    FechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrdenTrabajoEquipoId = table.Column<int>(type: "integer", nullable: true),
                    OrdenTrabajoBrigadaId = table.Column<int>(type: "integer", nullable: true),
                    OrdenTrabajoTrabajadorId = table.Column<int>(type: "integer", nullable: true),
                    OrdenTrabajoFechaId = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PrecioPorHora = table.Column<double>(type: "double precision", nullable: false),
                    NoHoras = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesTrabajoAtendidas", x => new { x.TrabajadorId, x.DiaId });
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajoAtendidas_OrdenTrabajo_OrdenTrabajoEquipoId_O~",
                        columns: x => new { x.OrdenTrabajoEquipoId, x.OrdenTrabajoBrigadaId, x.OrdenTrabajoTrabajadorId, x.OrdenTrabajoFechaId },
                        principalTable: "OrdenTrabajo",
                        principalColumns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" });
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajoAtendidas_Trabajadores_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajadores",
                        principalColumn: "TrabajadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionMantenimientoOrdenTrabajo_OrdenesTrabajoEquipoId_Orde~",
                table: "AccionMantenimientoOrdenTrabajo",
                columns: new[] { "OrdenesTrabajoEquipoId", "OrdenesTrabajoBrigadaId", "OrdenesTrabajoTrabajadorId", "OrdenesTrabajoFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Cargas_VentaSedeId_VentaEntidadCompradoraId_VentaFechaVenta~",
                table: "Cargas",
                columns: new[] { "VentaSedeId", "VentaEntidadCompradoraId", "VentaFechaVentaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Descargas_compraSedeId_compraFabricaId_compraFechaId",
                table: "Descargas",
                columns: new[] { "compraSedeId", "compraFabricaId", "compraFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_SedeId",
                table: "Equipos",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TipoEId",
                table: "Equipos",
                column: "TipoEId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HerramientaMantNecesario_HerramientaId",
                table: "HerramientaMantNecesario",
                column: "HerramientaId");

            migrationBuilder.CreateIndex(
                name: "IX_HerramientaMantNecesario_MantenimientoNecesarioTipoEquipoId~",
                table: "HerramientaMantNecesario",
                columns: new[] { "MantenimientoNecesarioTipoEquipoId", "MantenimientoNecesarioAMId", "MantenimientoNecesarioHorasExpId" });

            migrationBuilder.CreateIndex(
                name: "IX_MantenimientosNecesarios_AMId",
                table: "MantenimientosNecesarios",
                column: "AMId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesBasculas_CargaTipoCementoId_CargaSiloId_CargaVehi~",
                table: "MedicionesBasculas",
                columns: new[] { "CargaTipoCementoId", "CargaSiloId", "CargaVehiculoId", "CargaFechaCargaId" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesBasculas_DescargaTipoCementoId_DescargaSiloId_Des~",
                table: "MedicionesBasculas",
                columns: new[] { "DescargaTipoCementoId", "DescargaSiloId", "DescargaVehiculoId", "DescargaFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesSilos_CargaTipoCementoId_CargaSiloId_CargaVehicul~",
                table: "MedicionesSilos",
                columns: new[] { "CargaTipoCementoId", "CargaSiloId", "CargaVehiculoId", "CargaFechaCargaId" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesSilos_DescargaTipoCementoId_DescargaSiloId_Descar~",
                table: "MedicionesSilos",
                columns: new[] { "DescargaTipoCementoId", "DescargaSiloId", "DescargaVehiculoId", "DescargaFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajoAtendidas_OrdenTrabajoEquipoId_OrdenTrabajoBr~",
                table: "OrdenesTrabajoAtendidas",
                columns: new[] { "OrdenTrabajoEquipoId", "OrdenTrabajoBrigadaId", "OrdenTrabajoTrabajadorId", "OrdenTrabajoFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_BrigadaId",
                table: "OrdenTrabajo",
                column: "BrigadaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoAMRealizada_EquipoId_BrigadaId_TrabajadorId_Fec~",
                table: "OrdenTrabajoAMRealizada",
                columns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoHerramienta_EquipoId_BrigadaId_TrabajadorId_Fec~",
                table: "OrdenTrabajoHerramienta",
                columns: new[] { "EquipoId", "BrigadaId", "TrabajadorId", "FechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoRoturaEquipo_OrdenTrabajoEquipoId_OrdenTrabajoB~",
                table: "OrdenTrabajoRoturaEquipo",
                columns: new[] { "OrdenTrabajoEquipoId", "OrdenTrabajoBrigadaId", "OrdenTrabajoTrabajadorId", "OrdenTrabajoFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoRoturaEquipo_RoturaEquipoEquipoId_RoturaEquipoR~",
                table: "OrdenTrabajoRoturaEquipo",
                columns: new[] { "RoturaEquipoEquipoId", "RoturaEquipoRoturaId", "RoturaEquipoFechaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_EmpresaId",
                table: "Sedes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_EquipoId",
                table: "Silos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_SedeId",
                table: "Trabajadores",
                column: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionMantenimientoOrdenTrabajo");

            migrationBuilder.DropTable(
                name: "Basculas");

            migrationBuilder.DropTable(
                name: "EntidadCompradoras");

            migrationBuilder.DropTable(
                name: "Fabricas");

            migrationBuilder.DropTable(
                name: "HerramientaMantNecesario");

            migrationBuilder.DropTable(
                name: "MedicionesBasculas");

            migrationBuilder.DropTable(
                name: "MedicionesSilos");

            migrationBuilder.DropTable(
                name: "Medidores");

            migrationBuilder.DropTable(
                name: "OrdenesTrabajoAtendidas");

            migrationBuilder.DropTable(
                name: "OrdenTrabajoAMRealizada");

            migrationBuilder.DropTable(
                name: "OrdenTrabajoHerramienta");

            migrationBuilder.DropTable(
                name: "OrdenTrabajoRoturaEquipo");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Roturas");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "TipoCementos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "MantenimientosNecesarios");

            migrationBuilder.DropTable(
                name: "Cargas");

            migrationBuilder.DropTable(
                name: "Descargas");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Herramientas");

            migrationBuilder.DropTable(
                name: "OrdenTrabajo");

            migrationBuilder.DropTable(
                name: "RoturaEquipo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "AccionesMantenimientos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Brigadas");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "TiposEquipos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
