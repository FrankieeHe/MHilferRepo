using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfMHilfer.view
{
    public class WebBrowserHelper
    {
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.RegisterAttached("Body", typeof(string), typeof(WebBrowserHelper), new PropertyMetadata(OnBodyChanged));

        public static string GetBody(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(BodyProperty);
        }

        public static void SetBody(DependencyObject dependencyObject, string body)
        {
            dependencyObject.SetValue(BodyProperty, body);
        }

        private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser)d;
            if(((string)e.NewValue).Length ==0) { return; }
            string desc = (string)e.NewValue;
            webBrowser.NavigateToString(desc);
        }


        public static readonly DependencyProperty UrlProperty =
           DependencyProperty.RegisterAttached("Url", typeof(string), typeof(WebBrowserHelper), new PropertyMetadata(OnUrlChanged));

        public static string GetUrl(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(UrlProperty);
        }

        public static void SetUrl(DependencyObject dependencyObject, string Url)
        {
            dependencyObject.SetValue(UrlProperty, Url);
        }

        private static void OnUrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)d;

            string desc = (string)e.NewValue;
            webBrowser.Navigate(desc);
        }
    }
}
