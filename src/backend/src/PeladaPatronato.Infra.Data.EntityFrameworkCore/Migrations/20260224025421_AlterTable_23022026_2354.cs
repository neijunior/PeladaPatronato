using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_23022026_2354 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAssistencias",
                schema: "Legado",
                table: "LegadoTotalEstatistica");

            migrationBuilder.DropColumn(
                name: "MediaGols",
                schema: "Legado",
                table: "LegadoTotalEstatistica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MediaAssistencias",
                schema: "Legado",
                table: "LegadoTotalEstatistica",
                type: "decimal(6,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MediaGols",
                schema: "Legado",
                table: "LegadoTotalEstatistica",
                type: "decimal(6,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
