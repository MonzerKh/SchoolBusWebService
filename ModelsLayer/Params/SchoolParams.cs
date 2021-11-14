﻿using ModelsLayer.Params.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Params
{
    public class SchoolParams : PaginationParams
    {
        public string School_Name { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
    }
}
