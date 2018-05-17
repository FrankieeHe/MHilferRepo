using System.ComponentModel;

namespace WpfMHilfer.view
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public ObservableObject()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(args));
            }
        }
    }

}