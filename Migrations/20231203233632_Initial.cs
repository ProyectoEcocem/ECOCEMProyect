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
        }
    }
}
