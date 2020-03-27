using System;
using System.Globalization;
using Xamarin.Forms;

namespace Notepad.Convertisseurs
{
    public class DateTimeEnStringConvertisseur : IValueConverter
    {
        #region Constantes

        private const string FORMAT_DATE = "f";

        #endregion

        #region Implémentation IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
                return string.Empty;

            DateTime date = (DateTime) value;
            return date.ToString(FORMAT_DATE);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        #endregion

    }
}
