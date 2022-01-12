using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Student_Bus : BaseTable
    {
        public int Bus_Id { get; set; }
        public Bus Bus { get; set; }
        public int Student_Id { get; set; }
        public Student Student { get; set; }
        public bool IsActive { get; set; }
    }
}
