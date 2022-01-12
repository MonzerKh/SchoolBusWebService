using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.DropList
{
    public class StudentBusListDto
    {
        public int Id { get; set; }
        public string Student_Full_Name { get; set; }
        public int Student_Id { get; set; }
        public int Bus_Id { get; set; }
        public string Bus_Marka_Number { get; set; }
    }
}
