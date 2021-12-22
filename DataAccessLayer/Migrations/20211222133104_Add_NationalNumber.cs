using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Add_NationalNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "National_Number",
                table: "Supervisors",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "National_Number",
                table: "Students",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "National_Number",
                table: "Guardians",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "National_Number",
                table: "Drivers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "National_Number",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "National_Number",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "National_Number",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "National_Number",
                table: "Drivers");
        }
    }
}
