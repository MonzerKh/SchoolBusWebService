using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsLayer.DataLayer.Tables.Permissions;

namespace DataAccessLayer.FluentConfig.Permissions
{
    public class Sys_Role_FunctionFluent : IEntityTypeConfiguration<Sys_Role_Function>
    {
        public void Configure(EntityTypeBuilder<Sys_Role_Function> builder)
        {
            builder.HasKey(r => new { r.SysRole_Id, r.SysFunction_Id });

            builder.HasOne(ts => ts.SysFunction).WithMany(tr => tr.Sys_Role_Function).HasForeignKey(c => c.SysFunction_Id);
            builder.HasOne(ts => ts.SysRole).WithMany(tr => tr.Sys_Role_Function).HasForeignKey(c => c.SysRole_Id);
        }
    }
}
