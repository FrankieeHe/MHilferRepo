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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMHilfer.model;
using WpfMHilfer.view;

namespace WpfMHilfer.GUI
{
    /// <summary>
    /// Interaktionslogik für SearchResult.xaml
    /// </summary>
    public partial class SearchResultWindow : Window
    {
        public string SearchText { get; set; }
        public ListViewViewModel searchResultsListView { get; set; }
        public MasterController masterController { get; set; }

        public SearchResultWindow()
        {
            InitializeComponent();
        }
        public SearchResultWindow(MasterController masterController,string searchText):this()
        {
            this.masterController = masterController;
            this.SearchText = searchText;
            SearchItemLabel.Content = SearchText;
            Dictionary<Element, int> searchResults = masterController.searchController.searchProcedure(SearchText, masterController.hilfer.elements);
        }

        
    }
}
