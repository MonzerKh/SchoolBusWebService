using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FluentConfig.Permissions
{
    public class SysFunctionFluent : IEntityTypeConfiguration<SysFunction>
    {
        public void Configure(EntityTypeBuilder<SysFunction> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.FunctionName).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Icon).HasColumnType("image");
            builder.Property(r => r.IconPath).HasMaxLength(250);
            builder.Property(r => r.LinkRote).HasMaxLength(250);
        }
    }
}
