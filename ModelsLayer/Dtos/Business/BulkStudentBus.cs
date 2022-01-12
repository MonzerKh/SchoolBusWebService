using ModelsLayer.Dtos.DropList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class BulkStudentBus
    {
        public List<StudentListDto> students { get; set; }
        public BusDto bus  { get; set; }
    }
}
