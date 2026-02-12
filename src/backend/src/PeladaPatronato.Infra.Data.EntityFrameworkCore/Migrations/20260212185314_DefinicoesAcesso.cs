using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class DefinicoesAcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PossuiAcesso",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                schema: "PeladaPatronato",
                table: "Participante",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "Perfil",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "PossuiAcesso",
                schema: "PeladaPatronato",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                schema: "PeladaPatronato",
                table: "Participante");
        }
    }
}
