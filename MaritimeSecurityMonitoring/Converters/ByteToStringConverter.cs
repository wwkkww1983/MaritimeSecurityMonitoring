using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaritimeSecurityMonitoring
{
    class ByteToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte dataType = (byte)value;
            switch (dataType)
            {
                case 2:
                    return "AIS";
                case 3:
                    return "雷达";
                case 100:
                    return "融合";
                default:
                    return "其他";
            }
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
