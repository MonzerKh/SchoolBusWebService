using ModelsLayer.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Tables
{
    public class Driver_Bus :Tracking
    {
        public int Bus_Id { get; set; }
        public Bus Bus { get; set; }
        public int Driver_Id { get; set; }
        public Driver Driver { get; set; }

    }
}
