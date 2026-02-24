using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_23022026_2228 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Legado");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LegadoEstatistica",
                schema: "Legado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPartidas = table.Column<int>(type: "int", nullable: false),
                    TotalGols = table.Column<int>(type: "int", nullable: false),
                    TotalAssistencias = table.Column<int>(type: "int", nullable: false),
                    MediaGols = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    MediaAssistencias = table.Column<decimal>(type: "decimal(6,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegadoEstatistica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegadoEstatistica_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalSchema: "PeladaPatronato",
                        principalTable: "Participante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegadoEstatistica_ParticipanteId",
                schema: "Legado",
                table: "LegadoEstatistica",
                column: "ParticipanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegadoEstatistica",
                schema: "Legado");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                schema: "PeladaPatronato",
                table: "Participante");
        }
    }
}
