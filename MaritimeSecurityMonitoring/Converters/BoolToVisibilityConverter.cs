using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace MaritimeSecurityMonitoring.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {

        public Visibility TrueVisibility { set; get; }

        public Visibility FalseVisibility { set; get; }

        public BoolToVisibilityConverter()
        {
            TrueVisibility = Visibility.Visible;
            FalseVisibility = Visibility.Hidden;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = (bool)value;
            if (isChecked)
                return TrueVisibility;
            else
                return FalseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
