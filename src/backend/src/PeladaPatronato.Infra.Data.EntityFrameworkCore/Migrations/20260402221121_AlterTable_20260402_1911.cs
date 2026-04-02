using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_20260402_1911 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Time_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropColumn(
                name: "TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Time_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeBaseId",
                principalSchema: "PeladaPatronato",
                principalTable: "Time",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodadaTime_Time_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.DropIndex(
                name: "IX_RodadaTime_TimeBaseId",
                schema: "PeladaPatronato",
                table: "RodadaTime");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RodadaTime_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RodadaTime_Time_TimeId",
                schema: "PeladaPatronato",
                table: "RodadaTime",
                column: "TimeId",
                principalSchema: "PeladaPatronato",
                principalTable: "Time",
                principalColumn: "Id");
        }
    }
}
