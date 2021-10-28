using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class MakeRelationOneToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "Schools",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SystemUserId",
                table: "Schools",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SystemUsers_SystemUserId",
                table: "Schools",
                column: "SystemUserId",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SystemUsers_SystemUserId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_SystemUserId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Schools");
        }
    }
}
