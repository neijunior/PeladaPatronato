using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTabs_2300_08022026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaPosicao",
                schema: "PeladaPatronato",
                table: "Posicao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rodada",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorDiarista = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RodadaTime",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vitorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    Empates = table.Column<int>(type: "int", nullable: false),
                    GolsPro = table.Column<int>(type: "int", nullable: false),
                    GolsContra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaTime_Rodada_RodadaId",
                        column: x => x.RodadaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "Rodada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaPosicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaParticipante_RodadaTime_RodadaTimeId",
                        column: x => x.RodadaTimeId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RodadaPartida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GolsTimeA = table.Column<int>(type: "int", nullable: false),
                    GolsTimeB = table.Column<int>(type: "int", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaPartida_RodadaTime_RodadaTimeId",
                        column: x => x.RodadaTimeId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaTime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RodadaEvento",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaEvento_RodadaParticipante_RodadaParticipanteId",
                        column: x => x.RodadaParticipanteId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaParticipante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "PeladaPatronato",
                table: "Posicao",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaPosicao",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "PeladaPatronato",
                table: "Posicao",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaPosicao",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "PeladaPatronato",
                table: "Posicao",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoriaPosicao",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "PeladaPatronato",
                table: "Posicao",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoriaPosicao",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_RodadaEvento_RodadaParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaEvento",
                column: "RodadaParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaParticipante_RodadaTimeId_ParticipanteId",
                schema: "PeladaPatronato",
                table: "RodadaParticipante",
                columns: new[] { "RodadaTimeId", "ParticipanteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RodadaPartida_RodadaTimeId",
                table: "RodadaPartida",
                column: "RodadaTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_RodadaId_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                columns: new[] { "RodadaId", "TimeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodadaEvento",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaPartida");

            migrationBuilder.DropTable(
                name: "Time",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaTime",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "Rodada",
                schema: "PeladaPatronato");

            migrationBuilder.DropColumn(
                name: "CategoriaPosicao",
                schema: "PeladaPatronato",
                table: "Posicao");
        }
    }
}
