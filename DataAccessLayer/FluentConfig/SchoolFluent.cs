using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer;
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
            builder.Property(r => r.School_Name).IsRequired();
            builder.Property(r => r.CreatedBy).IsRequired();

            builder.Property(r => r.School_Name).HasMaxLength(250);

            #region Model Relations
            builder.HasOne(t => t.SystemUser).WithMany(r => r.Schools).HasForeignKey(c => c.SystemUser_Id);
            builder.Property(r => r.SystemUser_Id).IsRequired(required:false);
            #endregion

        }
    }
}
