using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfMHilfer.converter
{
    internal class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int stufe = System.Convert.ToInt16(value);
            bool r =  stufe==0?true:false;
            return r;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}