using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsLayer.Params.Core;

namespace ModelsLayer.Params
{
    public class StudentParams : PaginationParams
    {
        public string Full_Name { get; set; }
        public string Address { get; set; }
        public string Guardian_Name { get; set; }
    }
}
