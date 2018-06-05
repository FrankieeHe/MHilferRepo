using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        public SearchController()
        {
        }
        public void setMasterController(MasterController masterController)
        {
            this.masterController = masterController;
        }
        public void setParamConfig(List<Element> elements, int iter, double dampingFactor, double init)
        {
            this.nodeCount = this.masterController.hilfer.elements.Count;
            iterations = iter;
            this.offset = (1 - dampingFactor) / this.nodeCount;
            this.dampingFactor = dampingFactor;
            initValue = init;
            this.converged = false;
            PageRanks = new Dictionary<string, double>();
            foreach (Element item in elements)
            {
                PageRanks.Add(item.name, initValue);
            }
        }
        private int iterations;
        private double offset;
        private double dampingFactor;
        private double initValue;
        private int nodeCount;
        private bool converged;
        private Dictionary<string, int> contributions;
        private Dictionary<string, double> PageRanks;


        public Dictionary<Element, int> searchProcedure(string keywords, List<Element> elements)
        {

            Char[] delimiter = { ' ', ',', '.' };
            List<string> keywordArray = keywords.Split(delimiter).Where(s => s.Length > 0).ToList<string>();
            if (keywordArray.Count < 1) { throw new Exception("no valid keywords"); }

            List<string> pageRankResult = pagerankProcedure(elements);
            Dictionary<Element,int> searchResult = new Dictionary<Element, int>();

            int i, j;
            foreach (string eleName in pageRankResult)
            {
                Element element = masterController.elementController.findElement(eleName);
                CultureInfo culture = CultureInfo.CurrentCulture;
                foreach (string keyword in keywordArray)
                {
                    i = culture.CompareInfo.IndexOf(eleName, keyword, CompareOptions.IgnoreCase);
                    j = culture.CompareInfo.IndexOf(element.desc, keyword, CompareOptions.IgnoreCase);
                    if (i >= 0 ) {
                        searchResult.Add(element, 0);
                        break;
                    }
                    if (j >= 0)
                    {
                        searchResult.Add(element, j);
                        break;
                    }
                }
            }


            return searchResult;

        }
        public List<string> pagerankProcedure(List<Element> elements)
        {
            setParamConfig(elements, 50, 0.85, 1);
            List<RelevEle> relevEles = masterController.hilfer.relevEles;
            contributions = contributionCalculation(elements, masterController.hilfer.relevEles);
            List<string> pagerankResult = new List<string>();
            while (converged != true || iterations > 0)
            {

                PageRankProcedure(masterController.hilfer.relevEles);
                iterations--;
            }

            var pgR = from pair in PageRanks
                      orderby pair.Value ascending
                      select pair;
            foreach (KeyValuePair<string, double> pair in pgR)
            {
                pagerankResult.Add(pair.Key);
            }
            return pagerankResult;
        }

        private Dictionary<string, int> contributionCalculation(List<Element> elements, List<RelevEle> relevEles)
        {
            Dictionary<string, int> contribution = new Dictionary<string, int>();
            foreach (Element item in elements)
            {
                RelevEle rEle = relevEles.Find(r => r.element.name.Equals(item.name));
                int count = 0;
                if (rEle != null) { count = rEle.relevantElements.Count; }
                contribution.Add(item.name, count);
            }
            return contribution;
        }

        public Dictionary<string, double> PageRankProcedure(List<RelevEle> relevEles)
        {
            Dictionary<string, double> ranksResult = new Dictionary<string, double>();
            if (contributions is null) { throw new Exception("contribution not be initialized"); }
            if (contributions.Count != PageRanks.Count) { throw new Exception("Diction in diffierennt size"); }

            converged = true;

            foreach (KeyValuePair<string, double> pair in PageRanks)
            {
                double intermediateCalculation = 0;
                foreach (RelevEle rE in relevEles)
                {
                    if (rE.relevantElements.Contains(pair.Key))
                    {
                        intermediateCalculation += PageRanks[rE.element.name] / contributions[rE.element.name];
                    }
                }
                if (Math.Abs(pair.Value - offset - dampingFactor * intermediateCalculation) > 0.05) { converged = false; }
                ranksResult.Add(pair.Key, offset + dampingFactor * intermediateCalculation);
            }

            PageRanks = ranksResult;
            return PageRanks;

        }
    }
}
