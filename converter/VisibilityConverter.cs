﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfMHilfer.converter
{
    internal class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = System.Convert.ToInt16(value);
            int par = System.Convert.ToInt16(parameter);
            if (par == 0) { return number == 0 ? Visibility.Visible:Visibility.Collapsed ; }
            return number == 0 ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
