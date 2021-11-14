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
    public class BusFluent : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Number).IsRequired().HasMaxLength(250);

            builder.Property(r => r.Marka).HasMaxLength(250);

            #region Model Relations
            builder.HasOne(t => t.BusCompany).WithMany(r => r.Buses).HasForeignKey(c => c.BusCompany_Id);
            #endregion

        }
    }
}
