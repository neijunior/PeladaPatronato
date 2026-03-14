using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_RodadaTimeParticipantes_13032026_2359 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaTimeId",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_RodadaId_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTimeParticipante_RodadaTimeId",
                table: "RodadaTimeParticipante");

            migrationBuilder.RenameTable(
                name: "RodadaTimeParticipante",
                newName: "RodadaTimeParticipante",
                newSchema: "PeladaPatronato");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "RodadaId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaParticipante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaParticipanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaParticipante_Participante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante",
                column: "ParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "Participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaParticipanteId",
                principalSchema: "PeladaPatronato",
                principalTable: "RodadaTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaParticipante_Participante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante");

            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropIndex(
                name: "IX_RodadaParticipante_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.RenameTable(
                name: "RodadaTimeParticipante",
                schema: "PeladaPatronato",
                newName: "RodadaTimeParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_RodadaId_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                columns: new[] { "RodadaId", "TimeBaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaTimeId",
                table: "RodadaTimeParticipante",
                column: "RodadaTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaTimeId",
                table: "RodadaTimeParticipante",
                column: "RodadaTimeId",
                principalSchema: "PeladaPatronato",
                principalTable: "RodadaTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
