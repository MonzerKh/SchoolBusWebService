using ModelsLayer.DataLayer.Core;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Guardian : PersonalCard
    {
        public byte[] PersonalImage { get; set; }
        public string ImagePath { get; set; }
        public int? SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }

        public ICollection<Student> Students { get; set; }

        public int School_Id { get; set; }
        public School School { get; set; }
    }
}
