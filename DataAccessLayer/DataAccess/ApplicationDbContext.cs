using DataAccessLayer.FluentConfig;
using DataAccessLayer.FluentConfig.Permissions;
using Microsoft.EntityFrameworkCore;

using ModelsLayer.DataLayer.Tables;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(string connectionString) :
           base(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region Permsion System
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysFunction> SysFunctions { get; set; }
        public DbSet<Sys_Role_Function> Sys_Role_Functions { get; set; }
        public DbSet<Sys_UserSystem_Role> Sys_UserSystem_Roles { get; set; }
        #endregion

        #region Functions
        public DbSet<School> Schools { get; set; }
        public DbSet<BusCompany> BusCompanies { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Driver_Bus> Driver_Buses { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Student_Bus> Student_Buses { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            #region Permsions System
            modelBuilder.ApplyConfiguration(new SystemUsersFluent());
            modelBuilder.ApplyConfiguration(new SysRoleFluent());
            modelBuilder.ApplyConfiguration(new SysFunctionFluent());
            modelBuilder.ApplyConfiguration(new Sys_Role_FunctionFluent());
            modelBuilder.ApplyConfiguration(new Sys_UserSystem_RoleFluent());
            #endregion

            #region Functions
            modelBuilder.ApplyConfiguration(new SchoolFluent());
            modelBuilder.ApplyConfiguration(new BusCompanyFluent());
            modelBuilder.ApplyConfiguration(new BusFluent());
            modelBuilder.ApplyConfiguration(new ComplaintFluent());
            modelBuilder.ApplyConfiguration(new DriverFluent());
            modelBuilder.ApplyConfiguration(new Dirver_BusFluent());
            modelBuilder.ApplyConfiguration(new GuardianFluent());
            modelBuilder.ApplyConfiguration(new StudentFluent());
            modelBuilder.ApplyConfiguration(new SupervisorFluent());
            modelBuilder.ApplyConfiguration(new Student_BusFluent());
            #endregion
        }
    }
}
