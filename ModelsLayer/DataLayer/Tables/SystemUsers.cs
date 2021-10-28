using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataLayer
{
    public class SystemUser : BaseTable
    {
        public string Full_Name { get; set; }
        public string Phone_Number { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<School> Schools { get; set; }


    }
}
