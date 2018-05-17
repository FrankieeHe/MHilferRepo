using MHilfer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMHilfer.view
{
    public class ComboBoxViewModel : ObservableObject
    {
        private ObservableCollection<Element> _elements;
        public ObservableCollection<Element> elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        private Element _selectedElement;
        public Element selectedElement
        {
            get { return _selectedElement; }
            set { _selectedElement = value; }
        }
        public ComboBoxViewModel(ObservableCollection<Element> eles)
        {
            elements = eles;
        }
    }
}
