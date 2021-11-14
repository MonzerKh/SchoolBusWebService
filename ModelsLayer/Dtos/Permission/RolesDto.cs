using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Permission
{
    public class RolesDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
    }
}
