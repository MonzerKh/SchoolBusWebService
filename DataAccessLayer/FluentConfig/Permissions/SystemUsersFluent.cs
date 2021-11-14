using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables.Permissions;

namespace DataAccessLayer.FluentConfig.Permissions
{
    public class SystemUsersFluent : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.UserName).IsRequired().HasMaxLength(250);
            builder.Property(r => r.Full_Name).HasMaxLength(250);
            builder.Property(r => r.PasswordHash).IsRequired();
            builder.Property(r => r.PasswordSalt).IsRequired();
            builder.Property(r => r.ImageIcon).HasColumnType("image");
            builder.Property(r => r.ImagePath).HasMaxLength(250);
        }
    }
}
