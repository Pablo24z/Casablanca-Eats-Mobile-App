using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace assignment_2425
{
    // Converter checks if a string is not empty or whitespace.
    public class StringNotEmptyConverter : IValueConverter
    {
        // Converts a string to a boolean — returns true if the string is not null or whitespace.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            !string.IsNullOrWhiteSpace(value as string);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
