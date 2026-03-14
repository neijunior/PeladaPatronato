using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_RodadaTimeParticipantes_13032026_0019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaTimeId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaTimeId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaTimeId",
                principalSchema: "PeladaPatronato",
                principalTable: "RodadaTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaTime_RodadaTimeId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTimeParticipante_RodadaTimeId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaParticipanteId");

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
    }
}
