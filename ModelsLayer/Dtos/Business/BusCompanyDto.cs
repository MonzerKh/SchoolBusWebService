using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class BusCompanyDto:BaseDtos
    {
        public string Company { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string LogoPath { get; set; }
        public string WebSiteUrl { get; set; }

        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public int? User_Id { get; set; }
    }
}
