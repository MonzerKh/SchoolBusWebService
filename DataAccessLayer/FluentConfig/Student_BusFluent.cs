using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FluentConfig
{
    public class Student_BusFluent : IEntityTypeConfiguration<Student_Bus>
    {
        public void Configure(EntityTypeBuilder<Student_Bus> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CreatedBy).IsRequired();
            builder.Property(r => r.IsActive).IsRequired().HasDefaultValueSql("1");

            #region Model Relations
            builder.HasOne(t => t.Student).WithMany(r => r.Student_Buses).HasForeignKey(c => c.Student_Id);
        //    builder.Property(r => r.Student_Id).IsRequired(required: true);

            builder.HasOne(t => t.Bus).WithMany(r => r.Bus_Students).HasForeignKey(c => c.Bus_Id);
         //   builder.Property(r => r.Student_Id).IsRequired(required: true);
            #endregion

        }
    }
}
