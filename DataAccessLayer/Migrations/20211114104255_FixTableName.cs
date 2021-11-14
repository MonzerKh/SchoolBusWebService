using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FixTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dirver_Buses",
                table: "Dirver_Buses");

            migrationBuilder.RenameTable(
                name: "Dirver_Buses",
                newName: "Driver_Buses");

            migrationBuilder.RenameIndex(
                name: "IX_Dirver_Buses_Bus_Id",
                table: "Driver_Buses",
                newName: "IX_Driver_Buses_Bus_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver_Buses",
                table: "Driver_Buses",
                columns: new[] { "Driver_Id", "Bus_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Buses_Buses_Bus_Id",
                table: "Driver_Buses",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Buses_Drivers_Driver_Id",
                table: "Driver_Buses",
                column: "Driver_Id",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Buses_Buses_Bus_Id",
                table: "Driver_Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Buses_Drivers_Driver_Id",
                table: "Driver_Buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver_Buses",
                table: "Driver_Buses");

            migrationBuilder.RenameTable(
                name: "Driver_Buses",
                newName: "Dirver_Buses");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_Buses_Bus_Id",
                table: "Dirver_Buses",
                newName: "IX_Dirver_Buses_Bus_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dirver_Buses",
                table: "Dirver_Buses",
                columns: new[] { "Driver_Id", "Bus_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses",
                column: "Driver_Id",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
