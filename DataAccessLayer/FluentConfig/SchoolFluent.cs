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
    public class SchoolFluent : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Address).IsRequired();
            builder.Property(r => r.School_Name).IsRequired().HasMaxLength(250);
            builder.Property(r => r.CreatedBy).IsRequired();

            builder.Property(r => r.Manager).HasMaxLength(250);
            builder.Property(r => r.SchoolUrl).HasMaxLength(250);

            builder.Property(r => r.SchoolImage).IsRequired(required: false);

            #region Model Relations
            builder.HasOne(t => t.CreateUser).WithMany(r => r.Schools).HasForeignKey(c => c.CreateUser_Id);
            builder.Property(r => r.CreateUser_Id).IsRequired(required:false);
            #endregion

        }
    }
}
