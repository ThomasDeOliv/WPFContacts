using System;
using System.Globalization;
using System.Windows.Data;
using WPFContacts.Datas.Models;

namespace WPFContacts.Converters
{
    public class PresentationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Contact contact = value as Contact;
            return $"{contact.FirstName} {contact.Name}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
