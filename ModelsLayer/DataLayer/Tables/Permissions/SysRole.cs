using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables.Permissions
{
    public enum RoleType
    {
        School,
        Bus_Company,
        Admin
    }
    public class SysRole :BaseTable
    {
        public string Role { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }

        public ICollection<Sys_UserSystem_Role> Sys_UserSystem_Roles { get; set; }
        public ICollection<Sys_Role_Function> Sys_Role_Function { get; set; }
    }
}
