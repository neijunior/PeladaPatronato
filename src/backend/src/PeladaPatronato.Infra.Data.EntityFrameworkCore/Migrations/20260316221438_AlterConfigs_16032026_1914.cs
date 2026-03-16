using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterConfigs_16032026_1914 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante",
                column: "RodadaParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "RodadaId1");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "RodadaId1",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Time_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeId",
                principalSchema: "PeladaPatronato",
                principalTable: "Time",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Time_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTimeParticipante_RodadaParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTimeParticipante_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropColumn(
                name: "RodadaId1",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropColumn(
                name: "TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");
        }
    }
}
