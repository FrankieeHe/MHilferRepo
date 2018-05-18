using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfMHilfer.converter
{
    internal class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int f = System.Convert.ToInt16(value);
            SolidColorBrush brushes = f!=0 ? Brushes.LightBlue : Brushes.DimGray;
            return brushes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}