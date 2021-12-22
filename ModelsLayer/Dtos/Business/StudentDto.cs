using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class StudentDto : PersonalCard
    {
        public string Father { get; set; }
        public string Natoinal_Number { get; set; }
        public string Mother { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public int? Guardian_Id { get; set; }
        public string Guardian_Name { get; set; }
        public int School_Id { get; set; }
        public string School_Name { get; set; }
    }
}
