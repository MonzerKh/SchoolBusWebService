using ModelsLayer.DataLayer.Core;
using ModelsLayer.DataLayer.Tables.Permissions;
using System.Collections.Generic;

namespace ModelsLayer.DataLayer.Tables
{
    public class School : BaseTable
    {
        public string School_Name { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }

        public string SchoolImage { get; set; }
        public string SchoolUrl { get; set; }

        public int? CreateUser_Id { get; set; }
        public SystemUser CreateUser { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
        public ICollection<Guardian> Guardians { get; set; }
        public ICollection<Complaint> Complaints { get; set; }

    }
}
