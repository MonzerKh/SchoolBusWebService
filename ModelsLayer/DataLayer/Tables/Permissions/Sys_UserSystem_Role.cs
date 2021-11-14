using ModelsLayer.DataLayer.Core;

namespace ModelsLayer.DataLayer.Tables.Permissions
{
    public class Sys_UserSystem_Role : Tracking
    {
        public int SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }
        public int SysRole_Id { get; set; }
        public SysRole SysRole { get; set; }

    }
}
