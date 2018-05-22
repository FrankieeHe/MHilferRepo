using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MHilfer;
using MHilfer.controller;
using WpfMHilfer.model;

namespace WpfMHilfer.view
{
    public class AddElementViewModel:ObservableObject
    {
        private ListViewViewModel _RelevEleListView;
        private ListViewViewModel _SelectedRelevEleListView;
        private MasterController masterController;

        public ICommand addCommand { get
            {
                return new RelayCommand<object>(addAction); 
            } }

        public ICommand removeCommand
        {
            get { return new RelayCommand<object>(removeAction); }
        }


        public void setMasterController(MasterController masterController)
        {
            this.masterController = masterController;
        }

        public AddElementViewModel(){}

        public void init_ElevElementList()
        {
            List<string> elementsListView = new List<string>();
            foreach( Element e in masterController.hilfer.elements){
                elementsListView.Add(e.name);
            }
            this.RelevEleListView = new ListViewViewModel(elementsListView);
        }

        public ListViewViewModel RelevEleListView
        {
            get { return _RelevEleListView; }
            set { this._RelevEleListView = value;
                OnPropertyChanged("RelevEleListView");
            }
        }

        public ListViewViewModel SelectedRelevEleListView
        {
            get { return _SelectedRelevEleListView; }
            set
            {
                this._SelectedRelevEleListView = value;
                OnPropertyChanged("SelectedRelevEleListView");
            }
        }

        private void removeAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void addAction(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
