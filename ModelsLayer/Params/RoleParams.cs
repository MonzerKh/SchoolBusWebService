using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Params.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Params
{
    public class RoleParams : PaginationParams
    {
        public string Role { get; set; }
        public RoleType? RoleType { get; set; }
    }
}
