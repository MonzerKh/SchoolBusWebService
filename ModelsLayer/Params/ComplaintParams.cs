using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Params.Core;

namespace ModelsLayer.Params
{
    public class ComplaintParams : PaginationParams
    {
        public int Id { get; set; }
        public ComplaintType ComplaintType { get; set; }
        public string ComplaintInfo { get; set; }
        public string Contact_Phone { get; set; }
        public int School_Id { get; set; }
        public string School_Name { get; set; }
        public int BusCompany_Id { get; set; }
        public string Company { get; set; }
    }
}
