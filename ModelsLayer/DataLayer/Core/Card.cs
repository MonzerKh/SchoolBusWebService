using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer.Core
{
    public class CardInfo : BaseTable
    {
        public string National_Number { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public byte[] PersonalImage { get; set; }
        public string ImagePath { get; set; }
    }
}
