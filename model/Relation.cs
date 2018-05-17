using Newtonsoft.Json;
using System;

namespace MHilfer.model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Relation
    {
        [JsonProperty]
        public Element element { get; set; }
        [JsonProperty]
        public Table table { get; set; }

        /*
        true when the element contrains the table 
        false when the table  contrains the element
        */
        [JsonProperty]
        public bool leftOwnRight { get; set; }

        public Relation(Element element, Table table, bool leftOwnRight)
        {
            
            this.element = element is null ? throw new Exception("new null relation from element"): element;
            this.table = table is null ? throw new Exception("new null relation from table") : table;
            this.leftOwnRight = leftOwnRight ;
        }
    }

}