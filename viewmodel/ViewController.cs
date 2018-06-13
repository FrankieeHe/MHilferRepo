using MarkdownDeep;
using MHilfer;
using MHilfer.controller;
using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfMHilfer.GUI;
using WpfMHilfer.model;
using WpfMHilfer.view;

namespace WpfMHilfer.viewmodel
{
    public class ViewController : ObservableObject
    {
        private MasterController masterController { get; set; }
        private Element _parentElement;
        private TableSteps _TableStep;
        private ListViewViewModel _ListView;
        private ListViewViewModel _seeAlsoListView;
        private Markdown markdown;
        private string _Description;
        public string Description
        {
            get
            {
                if (_Description == null)
                {
                    return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); ;
                }
                else
                { return _Description; }
            }
            set { _Description = value; OnPropertyChanged("Description"); }
        }
        public ICommand ShiftCommand
        {
            get { return new RelayCommand<object>(ShiftCommandAction); }
        }
        public ICommand OneClickCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand NextButtonCommand
        {
            get { return new RelayCommand<object>(NextButtonAction); }
        }
        public ICommand ReturenButtonCommand
        {
            get { return new RelayCommand<object>(ReturenButtonAction); }
        }
        public ICommand EditButtonCommand
        {
            get { return new RelayCommand<string>(EditButtonAction); }
        }
        public ICommand SeeAlsoJumpCommand
        {
            get { return new RelayCommand<string>(SeeAlsoJumpAction); }
        }

        public ICommand RightClickCommand
        {
            get { return new RelayCommand<object>(RightClickCommandAction); }
        }
        public ICommand DeleteCommand
        {
            get { return new RelayCommand<object>(DeleteCommandAction); }
        }
        public ICommand HomeButtonCommand
        {
            get { return new RelayCommand<object>(HomeButtonAction); }
        }


        internal TableSteps TableStep
        {
            get { return this._TableStep; }
            set
            {
                this._TableStep = value;
                OnPropertyChanged("TableStep");
            }
        }

        public ListViewViewModel SeeAlsoListView
        {
            get { return _seeAlsoListView; }
            set { _seeAlsoListView = value; OnPropertyChanged("SeeAlsoListView"); }
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
            markdown = new MarkdownDeep.Markdown();
            markdown.ExtraMode = true;
            markdown.SafeMode = false;
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

            if (ParentElement.url == true)
            {
                Description = ParentElement.desc;
            }
            else
            {
                Description = markdown.Transform(ParentElement.desc);
            }
            RelevEle relevEle = this.masterController.hilfer.relevEles.Find(rE => rE.element.Equals(ParentElement));
            List<string> caListView = new List<string>();
            if (relevEle != null)
            {
                caListView = relevEle.relevantElements;
            }
            SeeAlsoListView = new ListViewViewModel(caListView);

        }

        private void EntityUnfold(string obj)
        {

            ParentElement = masterController.elementController.findElement(obj);
            Table thistable = masterController.elementController.subTable(ParentElement);
            if (thistable is null)
            {
                thistable = masterController.elementController.preRelation(ParentElement).table;
                generateListViewNames(thistable);
                return;
            }
            generateListViewNames(thistable);

            TableSteps ts = new TableSteps();
            ts.actTable = thistable;
            ts.previousStep = TableStep;
            TableStep.nextStep = ts;

            next_step(TableStep);
            //due to the main table is changed to tablestep, this could be circle
        }
        public void SeeAlsoJumpAction(string obj)
        {
            ClickForDesc(obj);
            EntityUnfold(obj);
        }

        private void next_step(TableSteps ts)
        {
            if (ts.nextStep is null) { return; }
            this.TableStep = ts.nextStep;
        }
        private void prev_step()
        {
            if (TableStep.actTable.stufe == 0)
            {
                return;
            }
            TableSteps ts = this.TableStep;
            this.TableStep = this.TableStep.previousStep;
            this.TableStep.nextStep = ts;

        }
        private void ReturenButtonAction(object sender)
        {
            if (TableStep.previousStep is null) { generateListViewNames(null); return; }
            prev_step();
            Table table = TableStep.actTable;
            generateListViewNames(table);

        }

        private void EditButtonAction(string obj)
        {
            try
            {
                AddElementWindow editWindow = new AddElementWindow(masterController, ParentElement);
                editWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RightClickCommandAction(object sender)
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
                masterController.relevEleController.removeRelevance(ele);
                generateListViewNames(t);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void ShiftCommandAction(object obj)
        {

        }

        private void NextButtonAction(object obj)
        {
            next_step(this.TableStep);
            generateListViewNames(this.TableStep.actTable);
        }

        private void HomeButtonAction(object obj)
        {
            if (ParentElement.name.Equals("Wellcome!")) { return; }
            Table mainTable = masterController.hilfer.tables.Find(t => t.stufe == 0);
            TableSteps tableStep = new TableSteps();
            tableStep.previousStep = TableStep;
            tableStep.actTable = mainTable;
            TableStep.nextStep = tableStep;
            next_step(TableStep);
            ParentElement = null;
            generateListViewNames(mainTable);
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
