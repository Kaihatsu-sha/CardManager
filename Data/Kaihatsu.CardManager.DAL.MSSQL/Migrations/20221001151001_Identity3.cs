using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaihatsu.CardManager.DAL.MSSQL.Migrations
{
    public partial class Identity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccounttId",
                table: "Sessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccounttId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
