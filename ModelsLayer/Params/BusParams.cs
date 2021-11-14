using ModelsLayer.Params.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelsLayer.Params
{
    public class BusParams : PaginationParams
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Marka { get; set; }
        public int? Capacity { get; set; }
        public string Company { get; set; }
    }
}
