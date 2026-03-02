using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTables_02032026_0040 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaPartida_RodadaTime_RodadaTimeId",
                table: "RodadaPartida");

            migrationBuilder.DropTable(
                name: "RodadaEvento",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato");

            migrationBuilder.DropIndex(
                name: "IX_RodadaPartida_RodadaTimeId",
                table: "RodadaPartida");

            migrationBuilder.DropColumn(
                name: "GolsTimeA",
                table: "RodadaPartida");

            migrationBuilder.RenameTable(
                name: "RodadaPartida",
                newName: "RodadaPartida",
                newSchema: "PeladaPatronato");

            migrationBuilder.RenameColumn(
                name: "TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                newName: "TimeBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_RodadaTime_RodadaId_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                newName: "IX_RodadaTime_RodadaId_TimeBaseId");

            migrationBuilder.RenameColumn(
                name: "RodadaTimeId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                newName: "TimeComPosseInicialId");

            migrationBuilder.RenameColumn(
                name: "GolsTimeB",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                newName: "Ordem");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDiarista",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "decimal(15,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoPorPartida",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoTotal",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RodadaEventoPartida",
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
                    table.PrimaryKey("PK_RodadaEventoPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaEventoPartida_RodadaPartida_RodadaPartidaId",
                        column: x => x.RodadaPartidaId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RodadaTimeParticipante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodadaTimeParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodadaTimeParticipante_RodadaTime_RodadaTimeId",
                        column: x => x.RodadaTimeId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "RodadaTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RodadaPartida_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                column: "RodadaId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaEventoPartida_RodadaPartidaId",
                schema: "PeladaPatronato",
                table: "RodadaEventoPartida",
                column: "RodadaPartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTimeParticipante_RodadaTimeId",
                table: "RodadaTimeParticipante",
                column: "RodadaTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida",
                column: "RodadaId",
                principalSchema: "PeladaPatronato",
                principalTable: "Rodada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaPartida_Rodada_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.DropTable(
                name: "RodadaEventoPartida",
                schema: "PeladaPatronato");

            migrationBuilder.DropTable(
                name: "RodadaTimeParticipante");

            migrationBuilder.DropIndex(
                name: "IX_RodadaPartida_RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "PeladaPatronato",
                table: "Rodada");

            migrationBuilder.DropColumn(
                name: "TempoPorPartida",
                schema: "PeladaPatronato",
                table: "Rodada");

            migrationBuilder.DropColumn(
                name: "TempoTotal",
                schema: "PeladaPatronato",
                table: "Rodada");

            migrationBuilder.DropColumn(
                name: "DataHora",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.DropColumn(
                name: "RodadaId",
                schema: "PeladaPatronato",
                table: "RodadaPartida");

            migrationBuilder.RenameTable(
                name: "RodadaPartida",
                schema: "PeladaPatronato",
                newName: "RodadaPartida");

            migrationBuilder.RenameColumn(
                name: "TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                newName: "TimeId");

            migrationBuilder.RenameIndex(
                name: "IX_RodadaTime_RodadaId_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                newName: "IX_RodadaTime_RodadaId_TimeId");

            migrationBuilder.RenameColumn(
                name: "TimeComPosseInicialId",
                table: "RodadaPartida",
                newName: "RodadaTimeId");

            migrationBuilder.RenameColumn(
                name: "Ordem",
                table: "RodadaPartida",
                newName: "GolsTimeB");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDiarista",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                schema: "PeladaPatronato",
                table: "Rodada",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "GolsTimeA",
                table: "RodadaPartida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RodadaParticipante",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaPosicao = table.Column<int>(type: "int", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RodadaTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "RodadaEvento",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: true),
                    RodadaParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_RodadaPartida_RodadaTimeId",
                table: "RodadaPartida",
                column: "RodadaTimeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaPartida_RodadaTime_RodadaTimeId",
                table: "RodadaPartida",
                column: "RodadaTimeId",
                principalSchema: "PeladaPatronato",
                principalTable: "RodadaTime",
                principalColumn: "Id");
        }
    }
}
