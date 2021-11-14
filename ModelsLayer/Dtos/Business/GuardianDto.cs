using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class GuardianDto : BaseDtos
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string BoxNumber { get; set; }
        public string Full_Address
        {
            get { return string.Format("{0}-{1}-{2}-{3}-{4}", Country, City, Town, Street, Address); }
        }
        public int? SystemUser_Id { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public int School_Id { get; set; }

        public string School_Name { get; set; }


    }
}
