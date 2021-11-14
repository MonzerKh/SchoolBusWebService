using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsLayer.Params.Core;

namespace ModelsLayer.Params
{
    public class BusCompanyParams : PaginationParams
    {
        public string Company { get; set; }
        public string Address { get; set; }
    }
}
