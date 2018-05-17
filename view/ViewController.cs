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
        private List<Panel> panels;
        private Element _parentElement;
        private Grid mainPanel;
        private int[] zindexs;
        private ListViewViewModel _ListView;
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; OnPropertyChanged("Description"); } }
        public ICommand OneClickCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand ReturenButtonCommand
        {
            get { return new RelayCommand<string>(ReturenButtonAction); }
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
        }


        private void ClickForDesc(string obj)
        {

            ParentElement = masterController.elementController.findElement(obj);
            Description = ParentElement.desc;
        }

        private void EntityUnfold(string obj)
        {

            ParentElement = masterController.elementController.findElement(obj);

            Table nexttable = masterController.elementController.subTable(ParentElement);
            if (nexttable is null) { return; }
            generateListViewNames(nexttable);
        }

        private void ReturenButtonAction(string nix)
        {
            Element preElement = masterController.elementController.getPreElement(ParentElement);
            this.ParentElement = preElement;
            if(preElement is null) { generateListViewNames(null); return; }
            generateListViewNames(masterController.tableController.getTablePerName(preElement.name));
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
            Button button = (Button)obj;
            string nam =(string)( button.Content);
            Element ele = masterController.elementController.findElement(nam);
            masterController.elementController.removeElement(ele);
            generateListViewNames(masterController.elementController.preRelation(ele).table);
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


        public List<Button> new_buttons(List<Element> es)
        {
            var bs = from e in es
                     select new_Button(e);
            List<Button> buttons = bs.ToList<Button>();
            return buttons;
        }



        /// <summary>
        /// Add all Panels to their Columns 
        /// the Columns is initialized according to the each Panel
        /// zindex is here initialized by the number of columns
        /// </summary>
        public void addPanelsToColumn()
        {
            int column_index = 0;
            bool more = true;
            while (more)
            {

                var pns = from p in this.panels
                          where p.FindName(column_index.ToString()) != null
                          select p;
                if (pns.Count() == 0) { more = false; break; }

                List<Panel> column_panels = pns.ToList<Panel>();
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Name = "column" + column_index.ToString();
                this.mainPanel.ColumnDefinitions.Add(columnDefinition);

                foreach (Panel p in column_panels)
                {
                    Grid.SetColumn(p, column_index);
                    this.mainPanel.Children.Add(p);
                }
                column_index += 1;
            }
            this.zindexs = new int[column_index];
        }

        public Button new_Button(Element ele)
        {
            string name = ele.name;
            string desc = ele.desc;
            Panel subPanel = new StackPanel();
            if (masterController.elementController.subRelation(ele).table != null)
            {
                var subp = from p in this.panels
                           where p.Name == masterController.elementController.subRelation(ele).table.name
                           select p;
                List<Panel> subPanels = subp.ToList<Panel>();
                if (subPanels.Count > 1) { throw new Exception("table name duplicated in GUI panels"); }
                subPanel = subPanels[0];
            };
            Button newBtn = new Button();
            newBtn.Name = name;
            newBtn.Content = name;
            newBtn.Margin = new Thickness(10, 5, 10, 5);
            newBtn.Background = Brushes.Blue;
            newBtn.Click += (s, e) => { toggle_panel(s, subPanel); };

            return newBtn;
        }

        /// <summary>
        /// When others is already in the panel's Column showed 
        /// this function firstly close the others and then show this one.
        /// </summary>
        /// <param name="parent">event dissolver button</param>
        /// <param name="panel">the corresponding Panel, which to show or hidden</param>
        public void toggle_panel(object parent, Panel panel)
        {
            Button btn = (Button)parent;
            if (panel.Name == null)
            {
                return;
            }
            panel.HorizontalAlignment = HorizontalAlignment.Left;
            if (panel.Visibility == Visibility.Visible)
            {
                panel.Visibility = Visibility.Collapsed;
            }
            else
            {
                Table table = masterController.tableController.getTablePerName(panel.Name);
                int column = table.stufe;
                Grid mgrid = (Grid)(FrameworkElement)(panel).Parent;//function probe
                if (mgrid != this.mainPanel) { throw new Exception("parent of the child panel is not MainPanel"); }
                List<UIElement> uies = (List<UIElement>)(mgrid.Children.Cast<UIElement>().Where(p => Grid.GetColumn(p) == column));
                foreach (UIElement u in uies)
                {
                    u.Visibility = Visibility.Collapsed;
                }
                panel.Visibility = Visibility.Visible;
            }

        }

        public void hang_Buttons(Panel panel, List<Button> buttons)
        {
            foreach (Button b in buttons)
            {
                panel.Children.Add(b);
            }
        }


    }
}
