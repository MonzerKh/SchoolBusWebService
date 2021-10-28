using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class OneToManySchoolFluent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemUser_Id",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SystemUser_Id",
                table: "Schools",
                column: "SystemUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools",
                column: "SystemUser_Id",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_SystemUser_Id",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SystemUser_Id",
                table: "Schools");
        }
    }
}
