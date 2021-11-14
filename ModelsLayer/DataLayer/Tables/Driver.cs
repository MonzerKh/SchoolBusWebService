using ModelsLayer.DataLayer.Core;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Driver : CardInfo
    {
        public int? SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }
        public int BusCompany_Id { get; set; }
        public BusCompany BusCompany { get; set; }
        public ICollection<Driver_Bus> Driver_Buses { get; set; }
    }
}
