using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class GenerateCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    LinkRote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Icon = table.Column<byte[]>(type: "image", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImageIcon = table.Column<byte[]>(type: "image", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role_Functions",
                columns: table => new
                {
                    SysRole_Id = table.Column<int>(type: "int", nullable: false),
                    SysFunction_Id = table.Column<int>(type: "int", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role_Functions", x => new { x.SysRole_Id, x.SysFunction_Id });
                    table.ForeignKey(
                        name: "FK_Sys_Role_Functions_SysFunctions_SysFunction_Id",
                        column: x => x.SysFunction_Id,
                        principalTable: "SysFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_Role_Functions_SysRoles_SysRole_Id",
                        column: x => x.SysRole_Id,
                        principalTable: "SysRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "image", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SystemUser_Id = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusCompanies_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "image", nullable: true),
                    SchoolUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateUser_Id = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_SystemUsers_CreateUser_Id",
                        column: x => x.CreateUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserSystem_Roles",
                columns: table => new
                {
                    SystemUser_Id = table.Column<int>(type: "int", nullable: false),
                    SysRole_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserSystem_Roles", x => new { x.SysRole_Id, x.SystemUser_Id });
                    table.ForeignKey(
                        name: "FK_Sys_UserSystem_Roles_SysRoles_SysRole_Id",
                        column: x => x.SysRole_Id,
                        principalTable: "SysRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_UserSystem_Roles_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Minimum = table.Column<int>(type: "int", nullable: true),
                    Large = table.Column<int>(type: "int", nullable: true),
                    BusCompany_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_BusCompanies_BusCompany_Id",
                        column: x => x.BusCompany_Id,
                        principalTable: "BusCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUser_Id = table.Column<int>(type: "int", nullable: true),
                    BusCompany_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PersonalImage = table.Column<byte[]>(type: "image", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_BusCompanies_BusCompany_Id",
                        column: x => x.BusCompany_Id,
                        principalTable: "BusCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintType = table.Column<int>(type: "int", nullable: false),
                    ComplaintInfo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Contact_Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    School_Id = table.Column<int>(type: "int", nullable: false),
                    BusCompany_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_BusCompanies_BusCompany_Id",
                        column: x => x.BusCompany_Id,
                        principalTable: "BusCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_Schools_School_Id",
                        column: x => x.School_Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalImage = table.Column<byte[]>(type: "image", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SystemUser_Id = table.Column<int>(type: "int", nullable: true),
                    School_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Schools_School_Id",
                        column: x => x.School_Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guardians_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUser_Id = table.Column<int>(type: "int", nullable: true),
                    School_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supervisors_Schools_School_Id",
                        column: x => x.School_Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supervisors_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dirver_Buses",
                columns: table => new
                {
                    Bus_Id = table.Column<int>(type: "int", nullable: false),
                    Driver_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirver_Buses", x => new { x.Driver_Id, x.Bus_Id });
                    table.ForeignKey(
                        name: "FK_Dirver_Buses_Buses_Bus_Id",
                        column: x => x.Bus_Id,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete:ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dirver_Buses_Drivers_Driver_Id",
                        column: x => x.Driver_Id,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Father = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Mother = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalImage = table.Column<byte[]>(type: "image", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SystemUser_Id = table.Column<int>(type: "int", nullable: true),
                    Guardian_Id = table.Column<int>(type: "int", nullable: true),
                    School_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Guardians_Guardian_Id",
                        column: x => x.Guardian_Id,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Schools_School_Id",
                        column: x => x.School_Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SystemUsers_SystemUser_Id",
                        column: x => x.SystemUser_Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusCompanies_SystemUser_Id",
                table: "BusCompanies",
                column: "SystemUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusCompany_Id",
                table: "Buses",
                column: "BusCompany_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_BusCompany_Id",
                table: "Complaints",
                column: "BusCompany_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_School_Id",
                table: "Complaints",
                column: "School_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dirver_Buses_Bus_Id",
                table: "Dirver_Buses",
                column: "Bus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_BusCompany_Id",
                table: "Drivers",
                column: "BusCompany_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_SystemUser_Id",
                table: "Drivers",
                column: "SystemUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_School_Id",
                table: "Guardians",
                column: "School_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_SystemUser_Id",
                table: "Guardians",
                column: "SystemUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CreateUser_Id",
                table: "Schools",
                column: "CreateUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Guardian_Id",
                table: "Students",
                column: "Guardian_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_School_Id",
                table: "Students",
                column: "School_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SystemUser_Id",
                table: "Students",
                column: "SystemUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_School_Id",
                table: "Supervisors",
                column: "School_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_SystemUser_Id",
                table: "Supervisors",
                column: "SystemUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Role_Functions_SysFunction_Id",
                table: "Sys_Role_Functions",
                column: "SysFunction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserSystem_Roles_SystemUser_Id",
                table: "Sys_UserSystem_Roles",
                column: "SystemUser_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Dirver_Buses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "Sys_Role_Functions");

            migrationBuilder.DropTable(
                name: "Sys_UserSystem_Roles");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "SysFunctions");

            migrationBuilder.DropTable(
                name: "SysRoles");

            migrationBuilder.DropTable(
                name: "BusCompanies");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "SystemUsers");
        }
    }
}
