using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MHilfer;
using MHilfer.controller;
using WpfMHilfer.model;
using WpfMHilfer.view;

namespace WpfMHilfer.viewmodel
{
    public class AddElementViewModel : ObservableObject
    {
        private ListViewViewModel _RelevEleListView;
        private ListViewViewModel _SelectedRelevEleListView;
        private MasterController masterController;

        public ICommand addCommand
        {
            get { return new RelayCommand<object>(addAction); }
        }

        public ICommand removeCommand
        {
            get { return new RelayCommand<object>(removeAction); }
        }
        private string _SelectedName;

        public string SelectedName
        {
            get { return _SelectedName; }
            set { this._SelectedName = value; OnPropertyChanged("SelectedName"); }
        }
        private string _ToRemoveName;

        public string ToRemoveName
        {
            get { return _ToRemoveName; }
            set { this._ToRemoveName = value; OnPropertyChanged("ToRemoveName"); }
        }



        public void setMasterController(MasterController masterController)
        {
            this.masterController = masterController;
        }

        public AddElementViewModel() { }

        public void init_ElevElementList()
        {
            List<string> elementsListView = new List<string>();
            foreach (Element e in masterController.hilfer.elements)
            {
                elementsListView.Add(e.name);
            }
            this.RelevEleListView = new ListViewViewModel(elementsListView);

            this.SelectedRelevEleListView = new ListViewViewModel(new List<string>());
        }
        public void init_SelectedElevElementList(Element element)
        {
            List<string> elementsListView = masterController.relevEleController.get_ElementList(element);
            List<string> relEles = RelevEleListView.Names.ToList<string>();
            relEles.RemoveAll(s => elementsListView.Contains(s));
            this.RelevEleListView = new ListViewViewModel(relEles);

            this.SelectedRelevEleListView = new ListViewViewModel(elementsListView);
        }

        public ListViewViewModel RelevEleListView
        {
            get { return _RelevEleListView; }
            set
            {
                this._RelevEleListView = value;
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

        public void removeAction(object obj)
        {
            if (ToRemoveName is null) { MessageBox.Show(String.Format("To removed Item cannot be empty{0} {1}", "!", ToRemoveName)); return; }
            RelevEleListView.Names.Add(ToRemoveName);
            SelectedRelevEleListView.Names.Remove(ToRemoveName);
        }

        public void addAction(object obj)
        {

            if (SelectedName is null) { MessageBox.Show(String.Format("selected Item cannot be empty {0} {1}", "!", SelectedName)); return; }

            SelectedRelevEleListView.Names.Add(SelectedName);
            RelevEleListView.Names.Remove(SelectedName);

        }

        public void update_SelectedRelevs(Element element)
        {
            List<string> selectedRelevs = SelectedRelevEleListView.Names.ToList<string>();
            masterController.relevEleController.add_Rels(element, selectedRelevs);
            masterController.viewController.SeeAlsoListView = new ListViewViewModel(masterController.hilfer.relevEles.Find(rE => rE.element.name == element.name).relevantElements);
        }

    }



}

