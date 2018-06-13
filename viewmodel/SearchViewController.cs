using MHilfer.controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfMHilfer.GUI;
using WpfMHilfer.view;

namespace WpfMHilfer.viewmodel
{
    public class SearchViewController : ObservableObject
    {
        public SearchViewController() { }
        public MasterController masterController { get; set; }
        internal void setMasterController(MasterController masterController)
        {
            this.masterController = masterController;
        }


        public ICommand SearchBox_GotFocus
        {
            get
            {
                return new RelayCommand<object>(SearchBox_GotFocusAction);
            }
        }
        public ICommand SearchTextBox_GotMouseCapture
        {
            get
            {
                return new RelayCommand<object>(SearchTextBox_GotMouseCaptureAction);
            }
        }
        public ICommand SearchButtonCommand
        {
            get { return new RelayCommand<object>(SearchButtonCommandAction); }
        }
        public ICommand SearchTextBoxEnterCommand
        {
            get { return new RelayCommand<object>(SearchTextBoxEnterAction); }
        }

        private void SearchTextBoxEnterAction(object obj)
        {
            var t = (TextBox)obj;
            SearchText = t.Text;
            OnSearchEvent();

        }

        private void SearchButtonCommandAction(object obj)
        {
            OnSearchEvent();
        }

        private void SearchTextBox_GotMouseCaptureAction(object obj)
        {
            var t = (TextBox)obj;
            t.SelectAll();
        }

        private void SearchBox_GotFocusAction(object obj)
        {
            var t = (TextBox)obj;
            t.SelectAll();
        }

        private static DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(TextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits));

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                this._searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        private void OnSearchEvent()
        {
            //var newEventArgs = new RoutedEventArgs(SearchController.SearchEvent);
            //SearchBox.RaiseEvent(newEventArgs);
            if (SearchText is null) { MessageBox.Show("empty string to search!"); return; }
            try
            {
                Window searchPage = new SearchResultWindow(masterController, SearchText);
                searchPage.Show();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }


    }
}