using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;

namespace MaritimeSecurityMonitoring
{
    class NullToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "")
                return "对应子项";
            else
                return value;
        }

        /*  
         * 数据从Targe到Source时，ConvertBack被调用 
         * 目前不会被调用 
         */
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
