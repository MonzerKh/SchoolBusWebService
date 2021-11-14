using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class SupervisorDto : PersonalCard
    {
        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public int School_Id { get; set; }
        public string School_Name { get; set; }
    }
}
