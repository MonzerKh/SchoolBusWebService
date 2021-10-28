using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class DeleteRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "User_School_Id",
                table: "Schools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "Schools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_School_Id",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
