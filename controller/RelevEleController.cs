using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHilfer;
using MHilfer.controller;
using WpfMHilfer.model;

namespace WpfMHilfer.controller
{
    public class RelevEleController
    {
        private MasterController masterController;

        public RelevEleController(MasterController masterController)
        {
            this.masterController = masterController;
        }

        public List<string> get_ElementList(Element element)
        {
            if(element is null) { throw new ArgumentNullException("the element is null"); }
            RelevEle relevEle = masterController.hilfer.relevEles.Find(r => r.element.Equals(element));
            if(relevEle is null) { return null; }
            return relevEle.relevantElements;
        }

        public void add_Rels(Element ele, List<string> relevEles, bool reset) {
            RelevEle relevEle = masterController.hilfer.relevEles.Find(r => r.element.Equals(ele));
            if (reset && relevEle != null) { masterController.hilfer.relevEles.Remove(relevEle); relevEle = null; }
            if (relevEle is null)
            {
                RelevEle rE = new RelevEle(ele, relevEles);
                masterController.hilfer.relevEles.Add(rE);
                return;
            }
            else
            {
                List<string> new_eles= relevEle.relevantElements.Concat(relevEles).ToList<string>();
                relevEle.relevantElements = new_eles.Distinct().ToList();
            }
        }

    }
}
