using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangeImageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "SchoolImage",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolImage",
                table: "Schools");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Schools",
                type: "image",
                nullable: true);
        }
    }
}
