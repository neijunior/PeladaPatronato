using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AcertosBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posicao",
                schema: "PeladaPatronato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicao", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "PeladaPatronato",
                table: "Posicao",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Goleiro" },
                    { 2, "Fixo" },
                    { 3, "Ala" },
                    { 4, "Pivo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participante_IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante",
                column: "IdPosicaoPreferida");

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_Posicao_IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante",
                column: "IdPosicaoPreferida",
                principalSchema: "PeladaPatronato",
                principalTable: "Posicao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participante_Posicao_IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.DropTable(
                name: "Posicao",
                schema: "PeladaPatronato");

            migrationBuilder.DropIndex(
                name: "IX_Participante_IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "IdPosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosicaoPreferida",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
