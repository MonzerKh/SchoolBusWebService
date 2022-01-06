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
        public string Full_Name { get; set; }
        public string Full_Address { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
