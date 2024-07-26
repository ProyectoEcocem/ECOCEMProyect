using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCEMProject.Migrations
{
    /// <inheritdoc />
    public partial class changedreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerdidaIndisponibilidad",
                table: "Reportes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PerdidaIndisponibilidad",
                table: "Reportes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
