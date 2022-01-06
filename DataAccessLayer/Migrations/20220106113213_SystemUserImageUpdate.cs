using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SystemUserImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageIcon",
                table: "SystemUsers");

            migrationBuilder.AddColumn<string>(
                name: "PersonalImage",
                table: "SystemUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalImage",
                table: "SystemUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageIcon",
                table: "SystemUsers",
                type: "image",
                nullable: true);
        }
    }
}
