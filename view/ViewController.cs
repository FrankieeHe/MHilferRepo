using MHilfer;
using MHilfer.controller;
using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

//TODO: the circle button and columns width to set and test function
namespace WpfMHilfer.view
{
    public class ViewController : ObservableObject
    {
        private MasterController masterController { get; set; }
        private Element _parentElement;
        private TableSteps _TableStep;
        private ListViewViewModel _ListView;
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged("Description"); } }
        public ICommand OneClickCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand ReturenButtonCommand
        {
            get { return new RelayCommand<object>(ReturenButtonAction); }
        }
        public ICommand EditButtonCommand
        {
            get { return new RelayCommand<string>(EditButtonAction); }
        }

        public ICommand LeftClickCommand
        {
            get { return new RelayCommand<object>(LeftClickAction); }
        }
        public ICommand DeleteCommand
        {
            get { return new RelayCommand<object>(DeleteCommandAction); }
        }
        internal TableSteps TableStep
        {
            get { return this._TableStep; }
            set { this._TableStep = value;
                OnPropertyChanged("TableStep");
            }
        }
 
        public Element ParentElement
        {
            get
            {
                if (_parentElement is null)
                {
                    return new Element("Wellcome!", null);
                }
                return _parentElement;
            }
            set
            {
                _parentElement = value;
                OnPropertyChanged("ParentElement");
            }
        }
        public ListViewViewModel ListView
        {
            get
            {
                return _ListView;
            }
            set
            {
                _ListView = value;
                OnPropertyChanged("ListView");
            }
        }

        public ViewController()
        {
            OneClickCommand = new RelayCommand<string>(ClickForDesc);
            DoubleClickCommand = new RelayCommand<string>(EntityUnfold);

        }

        public ViewController(MasterController mc) : this()
        {
            this.masterController = mc;
            this.TableStep = new TableSteps();
            this.TableStep.actTable = masterController.hilfer.tables.Find(t => t.stufe == 0);
        }


        private void ClickForDesc(string obj)
        {
            ParentElement = masterController.elementController.findElement(obj);
            Description = ParentElement.desc;
        }

        private void EntityUnfold(string obj)
        {

            ParentElement = masterController.elementController.findElement(obj);
            Table thistable = masterController.elementController.subTable(ParentElement);
            generateListViewNames(thistable);
            TableSteps ts = new TableSteps();
            ts.previousStep = TableStep;
            ts.actTable = thistable;
            TableStep.nextStep = ts;
            this.TableStep = ts;
            //due to the main table is changed to tablestep, this could be cryclus

        }

        private void ReturenButtonAction(object sender)
        {
            if(TableStep.previousStep is null) { generateListViewNames(null);return; }
            generateListViewNames(TableStep.previousStep.actTable);
            this.TableStep = TableStep.previousStep;

            //if (TableStep.previousStep == null)
            //{
            //    Button button = (Button)sender;
            //    button.IsEnabled = false;
            //    button.Background = Brushes.DimGray;
            //}
        }

        private void EditButtonAction(string obj)
        {
            AddElementWindow editWindow = new AddElementWindow(masterController, ParentElement);
            editWindow.Show();
        }

        private void LeftClickAction(object sender)
        {
            Button button = (Button)sender;
            string nam = (string)(button.Content);
            Element ele = masterController.elementController.findElement(nam);
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            button.ContextMenu.IsOpen = true;


        }

        private void DeleteCommandAction(object obj)
        {
            try
            {
                Button button = (Button)obj;
                string nam = (string)(button.Content);
                Element ele = masterController.elementController.findElement(nam);
                Table t = masterController.elementController.preRelation(ele).table;
                ParentElement = masterController.elementController.findElement(t.name);

                masterController.elementController.removeElement(ele);
                generateListViewNames(t);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void generateListViewNames(Table table)
        {
            if (table == null)
            {
                table = masterController.hilfer.tables.Where(t => t.stufe == 0).First();
            }
            List<Element> rs = masterController.tableController.allSubElements(table);
            List<string> entitiesNames = new List<string>();
            foreach (Element r in rs)
            {
                entitiesNames.Add(r.name);
            }

            ListView = new ListViewViewModel(entitiesNames);

        }
    }
}
