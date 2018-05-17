﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHilfer
{
    //[ComplexType]
    [JsonObject(MemberSerialization.OptIn)]
    public class Element
    {
 

        public Element(string n, string d)
        {
            this.name = n;
            this.desc = d;
        }

        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string desc { get; set; }
        //[JsonProperty]
        //public Panel cPanel { get; set; }

        public override bool Equals(object obj)
        {
            return this.name==((Element)obj).name && this.desc== ((Element)obj).desc;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "\n name: "+this.name+" & desc: "+this.desc;
        }
    }
}
