using System.Globalization;

namespace LolRankedData.Converters;

/// <summary>
/// Converts an object to a boolean (true if not null).
/// </summary>
public class ObjectToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
