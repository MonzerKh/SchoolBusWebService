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
    public class BusCompanyFluent : IEntityTypeConfiguration<BusCompany>
    {
        public void Configure(EntityTypeBuilder<BusCompany> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Address).IsRequired();
            builder.Property(r => r.Company).IsRequired().HasMaxLength(250);
            
            builder.Property(r => r.LogoPath).HasMaxLength(250);
            builder.Property(r => r.WebSiteUrl).HasMaxLength(250);

            builder.Property(r => r.CreatedBy).IsRequired();
            builder.Property(r => r.Logo).HasColumnType("image");

            #region Model Relations
            builder.HasOne(t => t.SystemUser).WithMany(r => r.BusCompanies).HasForeignKey(c => c.SystemUser_Id);
            builder.Property(r => r.SystemUser_Id).IsRequired(required:false);
            #endregion

        }
    }
}
