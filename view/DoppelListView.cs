using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMHilfer.view
{
    public class DoppelListView
    {
        public ObservableCollection<KeyValuePair<string, string>> NameAndDesc { get; set; }
        public DoppelListView(List<KeyValuePair<string, string>> pairs)
        {
            NameAndDesc = new ObservableCollection<KeyValuePair<string, string>>(pairs);
        }
    }
}
