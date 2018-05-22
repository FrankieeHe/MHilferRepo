using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHilfer.controller;

namespace WpfMHilfer.view
{
    public class AddElementViewModel:ObservableObject
    {
        private ListViewViewModel _RelevEleListView;
        private MasterController masterController;

        public AddElementViewModel(MasterController masterController)
        {
            this.masterController = masterController;
        }

        public ListViewViewModel RelevEleListView
        {
            get { return _RelevEleListView; }
            set { this._RelevEleListView = value;
                OnPropertyChanged("SeeAlsoListView");
            }
        }

    }
}
