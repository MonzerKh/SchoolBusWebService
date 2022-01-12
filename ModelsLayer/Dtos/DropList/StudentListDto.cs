using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.DropList
{
    public class StudentListDto
    {
        public int Id { get; set; }
        public int School_Id { get; set; }
        public string School_Name { get; set; }
        public string Full_Name { get; set; }
        public string Full_Address { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public int? Bus_Id { get; set; }
        public string Bus_Name { get; set; }
        public string Company { get; set; }

       
    }
}
