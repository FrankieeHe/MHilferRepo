using MHilfer.model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfMHilfer.view
{
    public class ListViewViewModel
    {
        public ObservableCollection<string> Names { get; set; }

        public ListViewViewModel(List<string> tablesEntitiesNames)
        {
            Names = new ObservableCollection<string>(tablesEntitiesNames);
        }
    }
}