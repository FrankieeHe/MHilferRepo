using MHilfer;
using System;
using System.Collections.Generic;

namespace WpfMHilfer.view
{
    public class SearchResultViewModel : ObservableObject
    {
        private string _searchItem;
        private ListViewViewModel _searchResults;
        private ListViewViewModel _searchResultsDesc;
        public string searchItem { get { return _searchItem; } set { this._searchItem = value; this.OnPropertyChanged("searchItem"); } }
        public ListViewViewModel searchResults
        {
            get { return _searchResults; }
            set { this._searchResults = value; this.OnPropertyChanged("searchResults"); }
        }
        public ListViewViewModel searchResultsDesc
        {
            get { return _searchResultsDesc; }
            set { this._searchResultsDesc = value; this.OnPropertyChanged("searchResults"); }
        }
        private Dictionary<Element, int> _searchDict;
        public Dictionary<Element, int> searchDict
        {
            get { return _searchDict; }
            set
            {
                this._searchDict = value;
                setDicttoViewModel( );
                this.OnPropertyChanged("searchDict");
            }
        }

        private void setDicttoViewModel(  )
        {
            List<string> listview = new List<string>();
            List<string> listviewDesc = new List<string>();
            foreach (KeyValuePair<Element, int> pair in this.searchDict)
            {

                listview.Add(pair.Key.name);
                listviewDesc.Add(getShortDescPreview(pair));
            }
            searchResults = new ListViewViewModel(listview);
            searchResultsDesc = new ListViewViewModel(listviewDesc);
        }

        public string getShortDescPreview(KeyValuePair<Element, int> pair)
        {
            int start;
            if (pair.Value == 0) {
                start = 0;
            }
            else if (pair.Key.desc  is null || pair.Key.desc.Length == 0)
            {
                return "";
            }
            else{
                string fristPart = pair.Key.desc.Substring(0, pair.Value);
                start = Math.Max(Math.Max(fristPart.LastIndexOf(','), fristPart.LastIndexOf("\n")), fristPart.LastIndexOf("."));
            }

            string lastPart = pair.Key.desc.Substring(pair.Value);
            int end = Math.Min(Math.Min(lastPart.IndexOf(","), lastPart.IndexOf(".")), lastPart.IndexOf("\n"));

            return pair.Key.desc.Substring(start, end);
        }

    }
}