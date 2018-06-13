using MHilfer;
using MHilfer.controller;
using MHilfer.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMHilfer.view;
using WpfMHilfer.viewmodel;

namespace WpfMHilfer.GUI
{
    ///<summary>
    /// Interaktionslogik für MainWindow.xaml
    ///</summary>
    public partial class MainWindow : Window
    {
        public ViewController viewController { get; set; }
        public SearchViewController searchViewController { get; set; }
        public MasterController masterController { get; set; }
        public MainWindow()
        {
            masterController = new MasterController();
            viewController = masterController.viewController;
            searchViewController = masterController.searchViewController;
            InitializeComponent();
            MainPanel.DataContext = viewController;
            SearchGrid.DataContext = searchViewController;

        }


        public void addNewElement(object sender, RoutedEventArgs e)
        {
            Window addElementWindow = new AddElementWindow(GetMasterController());
            addElementWindow.Show();
        }

        private MasterController GetMasterController()
        {
            return masterController;
        }

        private void LocalLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                masterController.ioController.loadAll();
                viewController.generateListViewNames(null);
            }
            catch (Exception E)
            {
                MessageBox.Show("File Loading Error: \n"+E.Message);
            }
        }

        private void LocalSave(object sender, RoutedEventArgs e)
        {
            masterController.ioController.allSave();
        }

    }
}
