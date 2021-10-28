using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class OneToManySchoolFluent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools");

            migrationBuilder.AlterColumn<int>(
                name: "SystemUser_Id",
                table: "Schools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools",
                column: "SystemUser_Id",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools");

            migrationBuilder.AlterColumn<int>(
                name: "SystemUser_Id",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SystemUsers_SystemUser_Id",
                table: "Schools",
                column: "SystemUser_Id",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
