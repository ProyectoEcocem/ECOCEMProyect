using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCEMProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingIdToRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargas_Ventas_VentaSedeId_VentaEntidadCompradoraId_VentaFec~",
                table: "Cargas");

            migrationBuilder.DropForeignKey(
                name: "FK_Descargas_Compras_CompraSedeId_CompraFabricaId_CompraFechaId",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "Volumen",
                table: "MedicionesSilos");

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Vehiculos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "TipoE",
                table: "TiposEquipos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NombreTipoCemento",
                table: "TipoCementos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NoSilo",
                table: "Silos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NombreRotura",
                table: "Roturas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Roturas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "OrdenTrabajoId",
                table: "OrdenTrabajos",
                type: "integer",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Medidores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "AlturaCinta",
                table: "MedicionesSilos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadioMayorConoInf",
                table: "MedicionesSilos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadioMayorConoSuperior",
                table: "MedicionesSilos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadioMenorConoInferior",
                table: "MedicionesSilos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadioMenorConoSuperior",
                table: "MedicionesSilos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCargaId",
                table: "MedicionesBasculas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SiloId",
                table: "MedicionesBasculas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCementoId",
                table: "MedicionesBasculas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Herramientas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Herramientas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Fabricas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEntidadCompradora",
                table: "EntidadCompradoras",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Empresas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CompraSedeId",
                table: "Descargas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompraFechaId",
                table: "Descargas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "CompraFabricaId",
                table: "Descargas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Corriente",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DescargaId",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PesoBruto",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tara",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Temperatura",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoAsentamiento",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VentaSedeId",
                table: "Cargas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VentaFechaVentaId",
                table: "Cargas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "VentaEntidadCompradoraId",
                table: "Cargas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CargaId",
                table: "Cargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PesoBruto",
                table: "Cargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tara",
                table: "Cargas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Brigadas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Basculas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Basculas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AccionesMantenimientos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargas_Ventas_VentaSedeId_VentaEntidadCompradoraId_VentaFec~",
                table: "Cargas",
                columns: new[] { "VentaSedeId", "VentaEntidadCompradoraId", "VentaFechaVentaId" },
                principalTable: "Ventas",
                principalColumns: new[] { "SedeId", "EntidadCompradoraId", "FechaVentaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Descargas_Compras_CompraSedeId_CompraFabricaId_CompraFechaId",
                table: "Descargas",
                columns: new[] { "CompraSedeId", "CompraFabricaId", "CompraFechaId" },
                principalTable: "Compras",
                principalColumns: new[] { "SedeId", "FabricaId", "FechaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargas_Ventas_VentaSedeId_VentaEntidadCompradoraId_VentaFec~",
                table: "Cargas");

            migrationBuilder.DropForeignKey(
                name: "FK_Descargas_Compras_CompraSedeId_CompraFabricaId_CompraFechaId",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "OrdenTrabajoId",
                table: "OrdenTrabajos");

            migrationBuilder.DropColumn(
                name: "AlturaCinta",
                table: "MedicionesSilos");

            migrationBuilder.DropColumn(
                name: "RadioMayorConoInf",
                table: "MedicionesSilos");

            migrationBuilder.DropColumn(
                name: "RadioMayorConoSuperior",
                table: "MedicionesSilos");

            migrationBuilder.DropColumn(
                name: "RadioMenorConoInferior",
                table: "MedicionesSilos");

            migrationBuilder.DropColumn(
                name: "RadioMenorConoSuperior",
                table: "MedicionesSilos");

            migrationBuilder.DropColumn(
                name: "FechaCargaId",
                table: "MedicionesBasculas");

            migrationBuilder.DropColumn(
                name: "SiloId",
                table: "MedicionesBasculas");

            migrationBuilder.DropColumn(
                name: "TipoCementoId",
                table: "MedicionesBasculas");

            migrationBuilder.DropColumn(
                name: "Corriente",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "DescargaId",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "PesoBruto",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "Tara",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "TipoAsentamiento",
                table: "Descargas");

            migrationBuilder.DropColumn(
                name: "CargaId",
                table: "Cargas");

            migrationBuilder.DropColumn(
                name: "PesoBruto",
                table: "Cargas");

            migrationBuilder.DropColumn(
                name: "Tara",
                table: "Cargas");

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Vehiculos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoE",
                table: "TiposEquipos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreTipoCemento",
                table: "TipoCementos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoSilo",
                table: "Silos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreRotura",
                table: "Roturas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Roturas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Medidores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Volumen",
                table: "MedicionesSilos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Herramientas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Herramientas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Fabricas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEntidadCompradora",
                table: "EntidadCompradoras",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Empresas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompraSedeId",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompraFechaId",
                table: "Descargas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompraFabricaId",
                table: "Descargas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VentaSedeId",
                table: "Cargas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VentaFechaVentaId",
                table: "Cargas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VentaEntidadCompradoraId",
                table: "Cargas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Brigadas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoSerie",
                table: "Basculas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Basculas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AccionesMantenimientos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargas_Ventas_VentaSedeId_VentaEntidadCompradoraId_VentaFec~",
                table: "Cargas",
                columns: new[] { "VentaSedeId", "VentaEntidadCompradoraId", "VentaFechaVentaId" },
                principalTable: "Ventas",
                principalColumns: new[] { "SedeId", "EntidadCompradoraId", "FechaVentaId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descargas_Compras_CompraSedeId_CompraFabricaId_CompraFechaId",
                table: "Descargas",
                columns: new[] { "CompraSedeId", "CompraFabricaId", "CompraFechaId" },
                principalTable: "Compras",
                principalColumns: new[] { "SedeId", "FabricaId", "FechaId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
