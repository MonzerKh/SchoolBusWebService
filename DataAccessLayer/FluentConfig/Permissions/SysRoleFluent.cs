using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables.Permissions;

namespace DataAccessLayer.FluentConfig.Permissions
{
    class SysRoleFluent : IEntityTypeConfiguration<SysRole>
    {
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoleType).IsRequired();
            builder.Property(r => r.Role).IsRequired();

            builder.Property(r => r.Role).HasMaxLength(250);

            #region Model Relations
          
            #endregion

        }
        
    }
}
