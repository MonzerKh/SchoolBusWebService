﻿using ModelsLayer.Dtos.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Dtos.Business
{
    public class SchoolDto : BaseDtos
    {
        public int Id { get; set; }
        public string School_Name { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string SchoolImage { get; set; }
        public string SchoolUrl { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }

        public int? CreateUser_Id { get; set; }
        public string UserName { get; set; }
    }
}
