﻿using MHilfer;
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WpfMHilfer
{
    /// <summary>
    /// Interaktionslogik für AddElementWindow.xaml
    /// </summary>
    public partial class AddElementWindow : Window
    {
        public ViewController viewController { get; set; }
        public ComboBoxViewModel comboBoxViewModel { get; set; }
        public MasterController masterController { get; set; }
        public AddElementWindow(MasterController mc)
        {
            InitializeComponent();
            masterController = mc;
            viewController = masterController.viewController;
            AddElementGrid.DataContext = viewController;
            comboBoxViewModel = new ComboBoxViewModel(new ObservableCollection<Element>( masterController.hilfer.elements));
            EntitiesComboBox.ItemsSource = comboBoxViewModel.elements;
            EntitiesComboBox.DisplayMemberPath = "name";
            EditSave.Visibility = Visibility.Collapsed;
        }
        public AddElementWindow(MasterController mc, Element parentElement) : this(mc)
        {
            NameTextBox.Text = parentElement.name;
            DescriptionTextBox.Text = parentElement.desc;
            EntitiesComboBox.SelectedItem = masterController.elementController.getPreElement(parentElement);
            NameTextBox.IsReadOnly = true;
            EntitiesComboBox.IsReadOnly=true;
            EditSave.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Collapsed;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            string nameTextBox = NameTextBox.Text;
            Element parentEle= (Element)EntitiesComboBox.SelectedItem;
            string descTextBox = DescriptionTextBox.Text;
            if (Regex.Match(nameTextBox, @"(^\s+)|(^$)").Success) { MessageBox.Show("name is required"); return; }
            Element childEle = new Element(nameTextBox, descTextBox);
            masterController.elementController.addNewElement(childEle);
            masterController.elementController.addElementToParent(childEle, parentEle);
            this.Close();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            viewController.generateListViewNames(null);

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditSave_Click(object sender, RoutedEventArgs e)
        {
            string nameTextBox = NameTextBox.Text;
            string descTextBox = DescriptionTextBox.Text;
            masterController.elementController.overrideElement(nameTextBox, descTextBox);
            viewController.Description = descTextBox;
            this.Close();
        }
    }
}
