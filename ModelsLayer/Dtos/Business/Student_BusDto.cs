using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class Student_BusDto : BaseDtos
    {
        #region Bus
        public int Bus_Id { get; set; }
        public string Number { get; set; }
        public string Marka { get; set; }
        public int Capacity { get; set; } 
        #endregion
        #region Student
        public int Student_Id { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
        #endregion
        public bool IsActive { get; set; }
    }
}
