using DataAccessLayer.FluentConfig;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer;
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

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SystemUsersFluent());
            modelBuilder.ApplyConfiguration(new SchoolFluent());
        }
    }
}
