using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECOCEMProyect.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSede = table.Column<int>(type: "integer", nullable: false),
                    IdFabrica = table.Column<int>(type: "integer", nullable: false),
                    IdFecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
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
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.SedeId);
                });

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    SiloId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.SiloId);
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
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSede = table.Column<int>(type: "integer", nullable: false),
                    IdEntidadCompradora = table.Column<int>(type: "integer", nullable: false),
                    IdFecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descarga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoCemento = table.Column<int>(type: "integer", nullable: false),
                    IdSilo = table.Column<int>(type: "integer", nullable: false),
                    IdVehiculo = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    compraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descarga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descarga_Compras_compraId",
                        column: x => x.compraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoCemento = table.Column<int>(type: "integer", nullable: false),
                    IdSilo = table.Column<int>(type: "integer", nullable: false),
                    IdVehiculo = table.Column<int>(type: "integer", nullable: false),
                    IdFecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VentaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargas_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionBascula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVehiculo = table.Column<int>(type: "integer", nullable: false),
                    IdBascula = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    CargaId = table.Column<int>(type: "integer", nullable: true),
                    DescargaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionBascula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionBascula_Cargas_CargaId",
                        column: x => x.CargaId,
                        principalTable: "Cargas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionBascula_Descarga_DescargaId",
                        column: x => x.DescargaId,
                        principalTable: "Descarga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicionSilo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSilo = table.Column<int>(type: "integer", nullable: false),
                    IdMedidor = table.Column<int>(type: "integer", nullable: false),
                    IdFecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    Volumen = table.Column<int>(type: "integer", nullable: false),
                    CargaId = table.Column<int>(type: "integer", nullable: true),
                    DescargaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionSilo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionSilo_Cargas_CargaId",
                        column: x => x.CargaId,
                        principalTable: "Cargas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionSilo_Descarga_DescargaId",
                        column: x => x.DescargaId,
                        principalTable: "Descarga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargas_VentaId",
                table: "Cargas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Descarga_compraId",
                table: "Descarga",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionBascula_CargaId",
                table: "MedicionBascula",
                column: "CargaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionBascula_DescargaId",
                table: "MedicionBascula",
                column: "DescargaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionSilo_CargaId",
                table: "MedicionSilo",
                column: "CargaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionSilo_DescargaId",
                table: "MedicionSilo",
                column: "DescargaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basculas");

            migrationBuilder.DropTable(
                name: "EntidadCompradoras");

            migrationBuilder.DropTable(
                name: "Fabricas");

            migrationBuilder.DropTable(
                name: "MedicionBascula");

            migrationBuilder.DropTable(
                name: "MedicionSilo");

            migrationBuilder.DropTable(
                name: "Medidores");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "TipoCementos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Cargas");

            migrationBuilder.DropTable(
                name: "Descarga");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
