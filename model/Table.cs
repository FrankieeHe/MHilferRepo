using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHilfer.model
{
    //[ComplexType]
    [JsonObject(MemberSerialization.OptIn)]
    public class Table    {
        //public Table() {
        //    elements = new HashSet<Element>();
        //}
        [JsonProperty]
        public string name { set; get; }
        [JsonProperty]
        public int stufe { set; get; }
        //[JsonProperty]
        //public Collection<Element> elements { set; get; }
        public Table(string n, int s)
        {
            name = n;
            stufe = s;
        }
        public override bool Equals(object obj)
        {
            return this.name==((Table)obj).name&&this.stufe== ((Table)obj).stufe;
        }
        public override string ToString()
        {
            return "\n name:" + this.name + "; stufe: " + this.stufe.ToString();
        }
    }
}
