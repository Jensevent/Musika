using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audio.Microservice.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "track",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "track",
                table: "Songs",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
