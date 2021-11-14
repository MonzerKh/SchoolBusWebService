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
    public class Dirver_BusFluent : IEntityTypeConfiguration<Driver_Bus>
    {
        public void Configure(EntityTypeBuilder<Driver_Bus> builder)
        {
            builder.HasKey(r => new { r.Driver_Id, r.Bus_Id });

            builder.Property(r => r.CreatedBy).IsRequired();


            #region Model Relations
            builder.HasOne(ts => ts.Driver).WithMany(tr => tr.Driver_Buses).HasForeignKey(c => c.Driver_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ts => ts.Bus).WithMany(tr => tr.Driver_Buses).HasForeignKey(c => c.Bus_Id).OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
