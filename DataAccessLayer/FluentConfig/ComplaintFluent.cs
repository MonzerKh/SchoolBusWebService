
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
    public class ComplaintFluent : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.ComplaintInfo).IsRequired().HasMaxLength(250); 
            builder.Property(r => r.ComplaintType).IsRequired();
            builder.Property(r => r.CreatedBy).IsRequired();

            builder.Property(r => r.Contact_Phone).HasMaxLength(250);

            #region Model Relations
            builder.HasOne(t => t.School).WithMany(r => r.Complaints).HasForeignKey(c => c.School_Id);
            builder.HasOne(t => t.BusCompany).WithMany(r => r.Complaints).HasForeignKey(c => c.BusCompany_Id);
            #endregion

        }
    }
}

