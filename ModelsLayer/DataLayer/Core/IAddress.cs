using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Core
{
    public class IAddress : BaseTable
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string BoxNumber { get; set; }
    }
}
