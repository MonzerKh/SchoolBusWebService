using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public enum ComplaintType 
    {
        Driver,
        Supervisor
    }
    public class Complaint : BaseTable
    {
        public ComplaintType ComplaintType { get; set; }
        public string ComplaintInfo { get; set; }
        public string Contact_Phone { get; set; }
        public int School_Id { get; set; }
        public School School { get; set; }
        public int BusCompany_Id { get; set; }
        public BusCompany BusCompany { get; set; }

    }
}
