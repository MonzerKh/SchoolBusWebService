using ModelsLayer.DataLayer.Core;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Student : PersonalCard
    {
        public string Father { get; set; }
        public string Mother { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalImage { get; set; }
        public string ImagePath { get; set; }

        public int? SystemUser_Id { get; set; }
        public SystemUser SystemUser { get; set; }

        public int? Guardian_Id { get; set; }
        public Guardian Guardian { get; set; }

        public int School_Id { get; set; }
        public School School { get; set; }
    }
}
