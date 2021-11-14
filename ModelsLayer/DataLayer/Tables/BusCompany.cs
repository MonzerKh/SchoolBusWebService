using ModelsLayer.DataLayer.Core;
using ModelsLayer.DataLayer.Tables.Permissions;
using System.Collections.Generic;

namespace ModelsLayer.DataLayer.Tables
{
    public class BusCompany : BaseTable
    {
        public string Company { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Logo { get; set; }
        public string LogoPath { get; set; }
        public string WebSiteUrl { get; set; }

        public int? SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }

        public ICollection<Bus> Buses { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}