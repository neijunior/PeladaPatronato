using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTables_02032026_0127 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodadaEventoPartida",
                schema: "PeladaPatronato");

            migrationBuilder.CreateTable(
                name: "RodadaPartidaEvento",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaPartidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEvento = table.Column<int>(type: "int", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaPartidaParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaPartidaEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaPartidaEvento_RodadaPartida_RodadaPartidaId",
                        column: x => x.RodadaPartidaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RodadaPartidaParticipante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaPartidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaPartidaParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaPartidaParticipante_RodadaPartida_RodadaPartidaId",
                        column: x => x.RodadaPartidaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RodadaPartidaEvento_RodadaPartidaId",
                schema: "PeladaPatronato",
                table: "RodadaPartidaEvento",
                column: "RodadaPartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaPartidaParticipante_RodadaPartidaId",
                table: "RodadaPartidaParticipante",
                column: "RodadaPartidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodadaPartidaEvento",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaPartidaParticipante");

            migrationBuilder.CreateTable(
                name: "RodadaEventoPartida",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaPartidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaPartidaParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEvento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaEventoPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaEventoPartida_RodadaPartida_RodadaPartidaId",
                        column: x => x.RodadaPartidaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RodadaEventoPartida_RodadaPartidaId",
                schema: "PeladaPatronato",
                table: "RodadaEventoPartida",
                column: "RodadaPartidaId");
        }
    }
}
