using System.Globalization;
using System.Windows.Data;

namespace WPF.Services;

public class ArrayToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string[] array)
        {
            // Convertit le tableau en une seule chaîne
            return string.Join(", ", array);
        }
        return null!;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
