﻿using System.Collections;
using System.Collections.Generic;


namespace MHilfer.model
{
    public class Hilfer
    {
        public List<Element> elements{ get; set; }
        public List<Table> tables { get; set; }
        public List<Relation> relations { get; set; }


        public Hilfer(List<Table> ps , List<Element> es, List<Relation> rs)
        {
            this.tables = ps;
            this.elements = es;
            this.relations= rs;
        }
    }
}
