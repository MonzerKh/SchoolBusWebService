using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables.Permissions;

namespace DataAccessLayer.FluentConfig.Permissions
{
    public class Sys_UserSystem_RoleFluent : IEntityTypeConfiguration<Sys_UserSystem_Role>
    {
        public void Configure(EntityTypeBuilder<Sys_UserSystem_Role> builder)
        {
            builder.HasKey(r => new {r.SysRole_Id,r.SystemUser_Id });

            builder.HasOne(ts => ts.SystemUser).WithMany(tr => tr.Sys_UserSystem_Roles).HasForeignKey(c => c.SystemUser_Id);
            builder.HasOne(ts => ts.SysRole).WithMany(tr => tr.Sys_UserSystem_Roles).HasForeignKey(c => c.SysRole_Id);

        }
    }
}
