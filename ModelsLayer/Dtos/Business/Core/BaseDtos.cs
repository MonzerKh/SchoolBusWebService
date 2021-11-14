using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business.Core
{
    public class BaseDtos
    {

        public int Id { get; set; } = 0;
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
    }
}
