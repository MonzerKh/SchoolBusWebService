using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables.Permissions
{
    public class Sys_Role_Function :Tracking
    {
        public int SysRole_Id { get; set; }
        public SysRole SysRole { get; set; }
        public int SysFunction_Id { get; set; }
        public SysFunction SysFunction { get; set; }
        public int Orders { get; set; }

    }
}
