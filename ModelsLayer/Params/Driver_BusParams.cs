using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelsLayer.Params.Core;

namespace ModelsLayer.Params
{
    public class Driver_BusParams : PaginationParams
    {
        public int Bus_Id { get; set; }
        public string Number { get; set; }
        public string Marka { get; set; }
        public int Capacity { get; set; }
        public int Driver_Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
    }
}
