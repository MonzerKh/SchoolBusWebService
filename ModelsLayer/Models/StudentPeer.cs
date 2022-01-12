﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class StudentPeer
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is StudentPeer))
                return false;
            return (this.lat == (obj as StudentPeer).lat && this.lng == (obj as StudentPeer).lng);

        }

        public override int GetHashCode() => this.lat.GetHashCode() ^ this.lng.GetHashCode();
    }
}
