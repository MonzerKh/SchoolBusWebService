using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Core
{
    public class PersonalCard : IAddress
    {
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
