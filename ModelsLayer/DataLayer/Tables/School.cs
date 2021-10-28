using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer
{
    public class School : BaseTable
    {
        public string School_Name { get; set; }
        public string Address { get; set; }

        public int? SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }


    }
}
