using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsLayer.Params.Core;

namespace ModelsLayer.Params
{
    public class DriverParams : PaginationParams
    {
        public int Id { get; set; }
        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public int BusCompany_Id { get; set; }
        public string Company { get; set; }
    }
}
