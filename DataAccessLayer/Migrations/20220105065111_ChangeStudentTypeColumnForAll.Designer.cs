﻿// <auto-generated />
using System;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220105065111_ChangeStudentTypeColumnForAll")]
    partial class ChangeStudentTypeColumnForAll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusCompany_Id")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("Large")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Minimum")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusCompany_Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.BusCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("image");

                    b.Property<string>("LogoPath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebSiteUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("BusCompanies");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusCompany_Id")
                        .HasColumnType("int");

                    b.Property<string>("ComplaintInfo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ComplaintType")
                        .HasColumnType("int");

                    b.Property<string>("Contact_Phone")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("School_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusCompany_Id");

                    b.HasIndex("School_Id");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusCompany_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("National_Number")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PersonalImage")
                        .HasColumnType("image");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusCompany_Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Driver_Bus", b =>
                {
                    b.Property<int>("Driver_Id")
                        .HasColumnType("int");

                    b.Property<int>("Bus_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Driver_Id", "Bus_Id");

                    b.HasIndex("Bus_Id");

                    b.ToTable("Driver_Buses");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoxNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("National_Number")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PersonalImage")
                        .HasColumnType("image");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("School_Id")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lat")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("lng")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("School_Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SysFunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FunctionName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("image");

                    b.Property<string>("IconPath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LinkRote")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Orders")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SysFunctions");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SysRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SysRoles");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.Sys_Role_Function", b =>
                {
                    b.Property<int>("SysRole_Id")
                        .HasColumnType("int");

                    b.Property<int>("SysFunction_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("Orders")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SysRole_Id", "SysFunction_Id");

                    b.HasIndex("SysFunction_Id");

                    b.ToTable("Sys_Role_Functions");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.Sys_UserSystem_Role", b =>
                {
                    b.Property<int>("SysRole_Id")
                        .HasColumnType("int");

                    b.Property<int>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SysRole_Id", "SystemUser_Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("Sys_UserSystem_Roles");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Full_Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("ImageIcon")
                        .HasColumnType("image");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateUser_Id")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Manager")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("School_Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lat")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("lng")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("CreateUser_Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BoxNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Father")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Guardian_Id")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Mother")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("National_Number")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PersonalImage")
                        .HasColumnType("image");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("School_Id")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lat")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("lng")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("Guardian_Id");

                    b.HasIndex("School_Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Supervisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoxNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("National_Number")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("School_Id")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("SystemUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lat")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("lng")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("School_Id");

                    b.HasIndex("SystemUser_Id");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Bus", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.BusCompany", "BusCompany")
                        .WithMany("Buses")
                        .HasForeignKey("BusCompany_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusCompany");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.BusCompany", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("BusCompanies")
                        .HasForeignKey("SystemUser_Id");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Complaint", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.BusCompany", "BusCompany")
                        .WithMany("Complaints")
                        .HasForeignKey("BusCompany_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.School", "School")
                        .WithMany("Complaints")
                        .HasForeignKey("School_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusCompany");

                    b.Navigation("School");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Driver", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.BusCompany", "BusCompany")
                        .WithMany("Drivers")
                        .HasForeignKey("BusCompany_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("Drivers")
                        .HasForeignKey("SystemUser_Id");

                    b.Navigation("BusCompany");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Driver_Bus", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Bus", "Bus")
                        .WithMany("Driver_Buses")
                        .HasForeignKey("Bus_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Driver", "Driver")
                        .WithMany("Driver_Buses")
                        .HasForeignKey("Driver_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Guardian", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.School", "School")
                        .WithMany("Guardians")
                        .HasForeignKey("School_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("Guardians")
                        .HasForeignKey("SystemUser_Id");

                    b.Navigation("School");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.Sys_Role_Function", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SysFunction", "SysFunction")
                        .WithMany("Sys_Role_Function")
                        .HasForeignKey("SysFunction_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SysRole", "SysRole")
                        .WithMany("Sys_Role_Function")
                        .HasForeignKey("SysRole_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SysFunction");

                    b.Navigation("SysRole");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.Sys_UserSystem_Role", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SysRole", "SysRole")
                        .WithMany("Sys_UserSystem_Roles")
                        .HasForeignKey("SysRole_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("Sys_UserSystem_Roles")
                        .HasForeignKey("SystemUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SysRole");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.School", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "CreateUser")
                        .WithMany("Schools")
                        .HasForeignKey("CreateUser_Id");

                    b.Navigation("CreateUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Student", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.Guardian", "Guardian")
                        .WithMany("Students")
                        .HasForeignKey("Guardian_Id");

                    b.HasOne("ModelsLayer.DataLayer.Tables.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("School_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("Students")
                        .HasForeignKey("SystemUser_Id");

                    b.Navigation("Guardian");

                    b.Navigation("School");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Supervisor", b =>
                {
                    b.HasOne("ModelsLayer.DataLayer.Tables.School", "School")
                        .WithMany("Supervisors")
                        .HasForeignKey("School_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", "SystemUser")
                        .WithMany("Supervisors")
                        .HasForeignKey("SystemUser_Id");

                    b.Navigation("School");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Bus", b =>
                {
                    b.Navigation("Driver_Buses");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.BusCompany", b =>
                {
                    b.Navigation("Buses");

                    b.Navigation("Complaints");

                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Driver", b =>
                {
                    b.Navigation("Driver_Buses");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Guardian", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SysFunction", b =>
                {
                    b.Navigation("Sys_Role_Function");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SysRole", b =>
                {
                    b.Navigation("Sys_Role_Function");

                    b.Navigation("Sys_UserSystem_Roles");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.Permissions.SystemUser", b =>
                {
                    b.Navigation("BusCompanies");

                    b.Navigation("Drivers");

                    b.Navigation("Guardians");

                    b.Navigation("Schools");

                    b.Navigation("Students");

                    b.Navigation("Supervisors");

                    b.Navigation("Sys_UserSystem_Roles");
                });

            modelBuilder.Entity("ModelsLayer.DataLayer.Tables.School", b =>
                {
                    b.Navigation("Complaints");

                    b.Navigation("Guardians");

                    b.Navigation("Students");

                    b.Navigation("Supervisors");
                });
#pragma warning restore 612, 618
        }
    }
}
