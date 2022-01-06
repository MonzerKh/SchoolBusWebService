using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class DriverDto : BaseDtos
    {
        public string National_Number { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PersonalImage { get; set; }
        public string UserName { get; set; }
        public int BusCompany_Id { get; set; }
        public string Company { get; set; }
    }
}
