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
    public class StudentFluent : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Country).IsRequired().HasMaxLength(250);
            builder.Property(r => r.City).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Town).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Street).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Address).IsRequired();
            builder.Property(r => r.CreatedBy).IsRequired();

            builder.Property(r => r.Full_Name).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Phone).IsRequired().HasMaxLength(250);

            builder.Property(r => r.Father).HasMaxLength(250);
            builder.Property(r => r.Mother).HasMaxLength(250);
            builder.Property(r => r.Email).HasMaxLength(250);
            builder.Property(r => r.BoxNumber).HasMaxLength(250);
            builder.Property(r => r.ImagePath).HasMaxLength(250);

            builder.Property(r => r.PersonalImage).HasColumnType("image");
            #region Model Relations
            builder.HasOne(t => t.SystemUser).WithMany(r => r.Students).HasForeignKey(c => c.SystemUser_Id);
            builder.Property(r => r.SystemUser_Id).IsRequired(required:false);
            
            builder.HasOne(t => t.School).WithMany(r => r.Students).HasForeignKey(c => c.School_Id);
            
            builder.HasOne(t => t.Guardian).WithMany(r => r.Students).HasForeignKey(c => c.Guardian_Id);
            builder.Property(r => r.Guardian_Id).IsRequired(required: false);
            #endregion

        }
    }
}
