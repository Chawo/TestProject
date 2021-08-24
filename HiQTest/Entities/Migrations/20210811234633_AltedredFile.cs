using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AltedredFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "file");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "file",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "file");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "file",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
