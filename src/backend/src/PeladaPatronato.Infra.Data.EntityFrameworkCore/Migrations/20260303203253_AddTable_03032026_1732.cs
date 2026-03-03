using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_03032026_1732 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.CreateTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Diarista = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaParticipante_Rodada_RodadaId",
                        column: x => x.RodadaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "Rodada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RodadaParticipante_RodadaId_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante",
                columns: new[] { "RodadaId", "ParticipanteId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                column: "RodadaId",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "RodadaId",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                column: "RodadaId",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "RodadaId",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
