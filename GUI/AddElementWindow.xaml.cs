using MHilfer;
using MHilfer.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMHilfer.view;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using WpfMHilfer.viewmodel;

namespace WpfMHilfer.GUI
{
    /// <summary>
    /// Interaktionslogik für AddElementWindow.xaml
    /// </summary>
    public partial class AddElementWindow : Window
    {
        public ViewController viewController { get; set; }
        public AddElementViewModel addElementViewModel { get; set; }
        public ComboBoxViewModel comboBoxViewModel { get; set; }
        public MasterController masterController { get; set; }

        //Add Item entry
        public AddElementWindow(MasterController mc)
        {
            InitializeComponent();
            masterController = mc;
            viewController = masterController.viewController;
            masterController.addElementViewModel = new AddElementViewModel();
            masterController.addElementViewModel.setMasterController(masterController);
            addElementViewModel = masterController.addElementViewModel;
            comboBoxViewModel = new ComboBoxViewModel(new ObservableCollection<Element>(masterController.hilfer.elements));
            EntitiesComboBox.ItemsSource = comboBoxViewModel.elements;
            EntitiesComboBox.DisplayMemberPath = "name";
            EditSave.Visibility = Visibility.Collapsed;
            addElementViewModel.init_ElevElementList();
            this.DataContext = addElementViewModel;
        }



        //Edit Item entry
        public AddElementWindow(MasterController mc, Element parentElement) : this(mc)
        {
            NameTextBox.Text = parentElement.name;
            if(parentElement.url == true)
            {
                DescriptionTextBox.Text = "";
                addElementViewModel.ImportDescURLText = parentElement.desc;
            }
            else {
                addElementViewModel.ImportDescURLText = "";
                DescriptionTextBox.Text = parentElement.desc;
            }
            EntitiesComboBox.SelectedItem = masterController.elementController.getPreElement(parentElement);
            NameTextBox.IsReadOnly = true;
            EntitiesComboBox.IsReadOnly = true;
            EditSave.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Collapsed;

            addElementViewModel.init_SelectedElevElementList(parentElement);
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameTextBox = NameTextBox.Text;
                if (Regex.Match(nameTextBox, @"(^\s+)|(^$)").Success) { MessageBox.Show("name is required"); return; }
                Element parentEle = (Element)EntitiesComboBox.SelectedItem;
                string descTextBox = DescriptionTextBox.Text;
                Element childEle;
                childEle = new Element(nameTextBox, descTextBox);
                if (descTextBox.Length == 0)
                {
                    string urlTextBox = ImportDescURL.Text;
                    if (urlTextBox.Length != 0)
                    {
                        nameTextBox = nameTextBox + '.' + get_type(urlTextBox);
                        masterController.ioController.copyToLocal(urlTextBox, nameTextBox );
                        childEle = new Element(NameTextBox.Text, new Uri(masterController.ioController.mdFileDir , nameTextBox).AbsolutePath, true);
                    }
                }

                masterController.elementController.addNewElement(childEle);
                masterController.elementController.addElementToParent(childEle, parentEle);

                addElementViewModel.update_SelectedRelevs(childEle);
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            viewController.generateListViewNames(null);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string get_type(string url)
        {

            return url.Split('.').Last();
        }

        private void EditSave_Click(object sender, RoutedEventArgs e)
        {
            string nameTextBox = NameTextBox.Text;
            string descTextBox = DescriptionTextBox.Text;

            if (descTextBox.Length == 0)
            {
                string urlTextBox = ImportDescURL.Text;
                if (urlTextBox.Length != 0)
                {
                    nameTextBox = nameTextBox + '.' + get_type(urlTextBox);
                    masterController.ioController.copyToLocal(urlTextBox, nameTextBox);
                    descTextBox = new Uri(masterController.ioController.mdFileDir, nameTextBox).AbsolutePath;
                    masterController.elementController.findElement(NameTextBox.Text).url = true;
                }
            }

            masterController.elementController.overrideElement(NameTextBox.Text, descTextBox);
            //add reset and actuallization
            addElementViewModel.update_SelectedRelevs(masterController.elementController.findElement(NameTextBox.Text));
            viewController.Description = descTextBox;
            this.Close();
        }
    }
}
