using MHilfer;
using MHilfer.controller;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WpfMHilfer.view;

namespace WpfMHilfer.viewmodel
{
    public class SearchResultViewModel : ObservableObject
    {
        private string _searchItem;
        private MasterController masterController;
        public string searchItem { get { return _searchItem; } set { this._searchItem = value; this.OnPropertyChanged("searchItem"); } }

        public SearchResultViewModel(string sitem, Dictionary<Element, int> keyValuePairs)
        {
            searchItem = sitem;
            this.searchDict = keyValuePairs;
        }

        public void setMasterController( MasterController masterController)
        {
            this.masterController = masterController;
        }

        public ICommand LeftClickCommand { get { return new RelayCommand<string>(LeftClickCommandAction); }}

        public void LeftClickCommandAction(string obj)
        {
            masterController.viewController.SeeAlsoJumpAction(obj);

        }

        private DoppelListView _seachResultsListView;
        public DoppelListView searchResultsListView
        {
            get { return _seachResultsListView; }
            set
            {
                this._seachResultsListView = value;
                this.OnPropertyChanged("searchResultsListView");
            }
        }
        private Dictionary<Element, int> _searchDict;
        public Dictionary<Element, int> searchDict
        {
            get { return _searchDict; }
            set
            {
                this._searchDict = value;
                setDicttoViewModel();
                this.OnPropertyChanged("searchDict");
            }
        }

        public void setDicttoViewModel()
        {
            List<KeyValuePair<string, string>> doppelList = new List<KeyValuePair<string, string>>();
            foreach (KeyValuePair<Element, int> pair in searchDict)
            {
                string desc = getShortDescPreview(pair);
                doppelList.Add(new KeyValuePair<string, string>(pair.Key.name, desc));
            }
            this.searchResultsListView = new DoppelListView(doppelList);
            
        }


        public string getShortDescPreview(KeyValuePair<Element, int> pair)
        {
            int start;
            if (pair.Value == 0)
            {
                start = 0;
            }
            else if (pair.Key.desc is null || pair.Key.desc.Length == 0)
            {
                return "";
            }
            else
            {
                string fristPart = pair.Key.desc.Substring(0, pair.Value);
                start = Math.Max(Math.Max(fristPart.LastIndexOf(','), fristPart.LastIndexOf("\n")), fristPart.LastIndexOf("."));
            }

            string lastPart = pair.Key.desc.Substring(pair.Value);
            int end = Math.Min(Math.Min(lastPart.IndexOf(","), lastPart.IndexOf(".")), lastPart.IndexOf("\n"));
            if(end<0 || start < 0) { return pair.Key.desc; }
            return pair.Key.desc.Substring(start, end);
        }

    }
}