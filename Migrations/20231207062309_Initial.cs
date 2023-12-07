using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCEMProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoMantContratadoTotal",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "CostoTotalMantFact",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "DisponibilidadReal",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "DisponibilidadRequerida",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "IndiceParoFalla",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "IndiceRotura",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "PerdidaIndisponibilidad",
                table: "Reportes");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Roturas",
                newName: "NombreRotura");

            migrationBuilder.AlterColumn<string>(
                name: "TipoE",
                table: "TiposEquipos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRotura",
                table: "Roturas",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "TipoE",
                table: "TiposEquipos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "CostoMantContratadoTotal",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CostoTotalMantFact",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DisponibilidadReal",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DisponibilidadRequerida",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IndiceParoFalla",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IndiceRotura",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PerdidaIndisponibilidad",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
