using MHilfer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMHilfer.model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RelevEle
    {
        [JsonProperty]
        public Element element { get; set; }
        [JsonProperty]
        public List<string> relevantElements { get; set; }

        public RelevEle(Element element, List<string> relevElems)
        {
            this.element = element;
            this.relevantElements = relevElems;
        }

    }
}
