using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskTrackerApp.Converters
{
    public class PriorityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string priority = value as string;
            return priority switch
            {
                "High" => Brushes.LightCoral,
                "Medium" => Brushes.LightGoldenrodYellow,
                "Low" => Brushes.LightGreen,
                _ => Brushes.White
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
