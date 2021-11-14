using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables.Permissions
{
    public class SysFunction
    {
        public int Id { get; set; }
        public string FunctionName { get; set; }
        public int Orders { get; set; }
        public string LinkRote { get; set; }
        public byte[] Icon { get; set; }
        public string IconPath { get; set; }

        public ICollection<Sys_Role_Function> Sys_Role_Function { get; set; }
    }
}
