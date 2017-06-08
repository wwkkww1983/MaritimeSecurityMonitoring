using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YimaWF.data;
using YimaEncCtrl;

namespace MaritimeSecurityMonitoring
{
    class SourceToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TargetSource source = (TargetSource)value;
            switch (source)
            {
                case TargetSource.AIS:
                    return "AIS";
                case TargetSource.Merge:
                    return "融合";
                case TargetSource.Radar:
                    return "雷达";
                default:
                    break;
            }

            return null;
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
