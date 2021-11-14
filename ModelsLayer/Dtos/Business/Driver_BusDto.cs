using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class Driver_BusDto : BaseDtos
    {
        public int Bus_Id { get; set; }
        public string Number { get; set; }
        public string Marka { get; set; }
        public int Capacity { get; set; }
        
        public int Driver_Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }

    }
}
