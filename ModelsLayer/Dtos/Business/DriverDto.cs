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
        public int Id { get; set; }
        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public int BusCompany_Id { get; set; }
        public string Company { get; set; }
    }
}
