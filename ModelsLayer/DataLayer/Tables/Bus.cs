using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Bus : BaseTable
    {
        public string Number { get; set; }
        public string Marka { get; set; }
        public int Capacity { get; set; }
        public int? Minimum{ get; set; }
        public int? Large { get; set; }

        public int BusCompany_Id { get; set; }
        public BusCompany BusCompany { get; set; }

        public ICollection<Driver_Bus> Driver_Buses { get; set; }
        public ICollection<Student_Bus> Bus_Students { get; set; }
    }
}
