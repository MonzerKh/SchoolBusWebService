using ModelsLayer.Dtos.Business.Core;
using ModelsLayer.Permission.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.SystemUsers
{
    public class SystemUserDto :BaseDtos
    {   
        public string Full_Name { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string ImagePath { get; set; }
        public List<FunctionDto> FunctionList { get; set; }
    }
}
