using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Core
{
    public class Tracking
    {
        public int? CreatedBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
