using MHilfer.controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfMHilfer.GUI;

namespace WpfMHilfer.view
{
    public class SearchController : ObservableObject
    {
        public SearchController() { }
        public TextBox SearchBox { get; set; }
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
        public ICommand SearchTextBoxEnterCommand{
            get { return new RelayCommand<object>(SearchTextBoxEnterAction); }
        }

        private void SearchTextBoxEnterAction(object obj)
        {
            OnSearchEvent();
            
        }

        public string SearchItem { get; set; }
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

        public string SearchText
        {
            get { return (string)SearchBox.GetValue(SearchTextProperty); }
            set { SearchBox.SetValue(SearchTextProperty, value); }
        }
        public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent("Search",RoutingStrategy.Bubble,typeof(RoutedEventHandler),typeof(TextBox));

        private void OnSearchEvent()
        {
            SearchText = SearchBox.Text;
            //var newEventArgs = new RoutedEventArgs(SearchController.SearchEvent);
            //SearchBox.RaiseEvent(newEventArgs);
            Window searchPage = new SearchResultWindow(masterController,SearchText);
            searchPage.Show();

        }

        // Allows add and remove of event handlers to handle the custom event
        public event RoutedEventHandler Search
        {
            add { SearchBox.AddHandler(SearchEvent, value); }
            remove { SearchBox.RemoveHandler(SearchEvent, value); }
        }


    }
}