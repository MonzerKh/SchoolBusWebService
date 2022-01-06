using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.SystemUsers
{
    public class CreateUserDto: BaseDtos
    {
        public string Full_Name { get; set; }
        public string Phone_Number { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PersonalImage { get; set; }

        //private byte[] _PasswordHash;
        //private byte[] _PasswordSalt;

        //public byte[] PasswordHash { set { _PasswordHash = value; } }
        //public byte[] PasswordSalt { set { _PasswordSalt = value; } }


        public string UserActiveType { get; set; }
        public int UserType_Id { get; set; }

    }
}
