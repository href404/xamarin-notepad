using System;
using System.Globalization;
using Xamarin.Forms;

namespace Notepad.Converters
{
    public class DateTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
                return string.Empty;

            DateTime date = (DateTime) value;
            return date.ToString("f");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
