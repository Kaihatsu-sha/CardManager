using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaihatsu.CardManager.DAL.MSSQL.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSessions_Accounts_AccountId1",
                table: "AccountSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountSessions",
                table: "AccountSessions");

            migrationBuilder.DropIndex(
                name: "IX_AccountSessions_AccountId1",
                table: "AccountSessions");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountSessions");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "AccountSessions");

            migrationBuilder.RenameTable(
                name: "AccountSessions",
                newName: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Accounts",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "TimeLastRequest",
                table: "Sessions",
                newName: "LastRequest");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Sessions",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "TimeClosed",
                table: "Sessions",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "SessionToken",
                table: "Sessions",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Sessions");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "AccountSessions");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Accounts",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "AccountSessions",
                newName: "SessionToken");

            migrationBuilder.RenameColumn(
                name: "LastRequest",
                table: "AccountSessions",
                newName: "TimeLastRequest");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "AccountSessions",
                newName: "TimeCreated");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "AccountSessions",
                newName: "TimeClosed");

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AccountSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId1",
                table: "AccountSessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountSessions",
                table: "AccountSessions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSessions_AccountId1",
                table: "AccountSessions",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSessions_Accounts_AccountId1",
                table: "AccountSessions",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
