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
    public class SystemUsersFluent : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.UserName).IsRequired();
            builder.Property(r => r.PasswordHash).IsRequired();
            builder.Property(r => r.PasswordSalt).IsRequired();
        }
    }
}
