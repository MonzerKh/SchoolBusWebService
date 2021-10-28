using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer
{
    public class BaseTable
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
