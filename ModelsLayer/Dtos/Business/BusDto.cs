using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class BusDto :BaseDtos
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public string Marka { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int? Minimum { get; set; }
        public int? Large { get; set; }
        [Required]
        public int BusCompany_Id { get; set; }
        public string Company { get; set; }
    }
}
