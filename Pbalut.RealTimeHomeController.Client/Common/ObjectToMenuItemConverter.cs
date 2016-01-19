using System;
using Windows.UI.Xaml.Data;

namespace Pbalut.RealTimeHomeController.Client.Common
{
    public class ObjectToMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (MenuItem) value;
        }
    }
}