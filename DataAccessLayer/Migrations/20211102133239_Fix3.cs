using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses");

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses",
                column: "Driver_Id",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses");

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Buses_Bus_Id",
                table: "Dirver_Buses",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dirver_Buses_Drivers_Driver_Id",
                table: "Dirver_Buses",
                column: "Driver_Id",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
