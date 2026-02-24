using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_23022026_2232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegadoEstatistica_Participante_ParticipanteId",
                schema: "Legado",
                table: "LegadoEstatistica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LegadoEstatistica",
                schema: "Legado",
                table: "LegadoEstatistica");

            migrationBuilder.RenameTable(
                name: "LegadoEstatistica",
                schema: "Legado",
                newName: "LegadoTotalEstatistica",
                newSchema: "Legado");

            migrationBuilder.RenameIndex(
                name: "IX_LegadoEstatistica_ParticipanteId",
                schema: "Legado",
                table: "LegadoTotalEstatistica",
                newName: "IX_LegadoTotalEstatistica_ParticipanteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LegadoTotalEstatistica",
                schema: "Legado",
                table: "LegadoTotalEstatistica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegadoTotalEstatistica_Participante_ParticipanteId",
                schema: "Legado",
                table: "LegadoTotalEstatistica",
                column: "ParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "Participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegadoTotalEstatistica_Participante_ParticipanteId",
                schema: "Legado",
                table: "LegadoTotalEstatistica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LegadoTotalEstatistica",
                schema: "Legado",
                table: "LegadoTotalEstatistica");

            migrationBuilder.RenameTable(
                name: "LegadoTotalEstatistica",
                schema: "Legado",
                newName: "LegadoEstatistica",
                newSchema: "Legado");

            migrationBuilder.RenameIndex(
                name: "IX_LegadoTotalEstatistica_ParticipanteId",
                schema: "Legado",
                table: "LegadoEstatistica",
                newName: "IX_LegadoEstatistica_ParticipanteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LegadoEstatistica",
                schema: "Legado",
                table: "LegadoEstatistica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegadoEstatistica_Participante_ParticipanteId",
                schema: "Legado",
                table: "LegadoEstatistica",
                column: "ParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "Participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
