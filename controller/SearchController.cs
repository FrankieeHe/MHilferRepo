using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHilfer;
using MHilfer.controller;
using WpfMHilfer.model;

namespace WpfMHilfer.controller
{
    /***
     * Here is the PageRank implementation for search functionality, 
     * introduced from Google's Page Rank Algorithm
     * **/
    public class SearchController
    {
        MasterController masterController { get; set; }
        public SearchController() {
            setParamConfig(20,0.85,1);
        }
        public void setMasterController(MasterController masterController)
        {
            this.masterController = masterController;
        }
        public void setParamConfig(int iter,double offs, double init)
        {
            iterations = iter;
            this.offset = offs;
            initValue = init;
        }
        private int iterations;
        private double offset;
        private double initValue;
        private Dictionary<string, int> contributions;
        private Dictionary<string, double> PageRanks;

        public List<string> searchProcedure(string keywords, List<Element> elements)
        {
            contributions = contributionCalculation( elements, masterController.hilfer.relevEles);
            List<int> Similarities = new List<int>();
 
            return null;
        }

        private Dictionary<string, int> contributionCalculation(List<Element> elements, List<RelevEle> relevEles) {
            Dictionary<string, int> contribution = new Dictionary<string, int>();
            foreach (Element item in elements)
            {
                RelevEle rEle = relevEles.Find(r => r.element.name.Equals(item.name));
                int count = 0;
                if(rEle!= null) { count = rEle.relevantElements.Count; }
                contribution.Add( item.name,count );
            }
            return contribution;
        }

        public List<int> PageRankProcedure(List<RelevEle> relevEles)
        {
            if (contributions is null) { throw new Exception("contribution not be initialized"); }
            //TODO!
            return null;

        }
    }
}
