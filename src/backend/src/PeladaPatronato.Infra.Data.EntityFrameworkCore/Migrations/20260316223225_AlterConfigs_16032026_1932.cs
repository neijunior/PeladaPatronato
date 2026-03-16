using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterConfigs_16032026_1932 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.RenameColumn(
                name: "RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                newName: "ParticipanteId");

            migrationBuilder.RenameIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                newName: "IX_RodadaTimeParticipante_ParticipanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTimeParticipante_Participante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "ParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "Participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_Participante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.RenameColumn(
                name: "ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                newName: "RodadaParticipanteId");

            migrationBuilder.RenameIndex(
                name: "IX_RodadaTimeParticipante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                newName: "IX_RodadaTimeParticipante_RodadaParticipanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "RodadaParticipante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
