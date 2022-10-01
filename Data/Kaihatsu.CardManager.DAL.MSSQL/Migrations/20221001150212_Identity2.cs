using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaihatsu.CardManager.DAL.MSSQL.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccounttId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AccountId",
                table: "Sessions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Accounts_AccountId",
                table: "Sessions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Accounts_AccountId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AccountId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AccounttId",
                table: "Sessions");
        }
    }
}
