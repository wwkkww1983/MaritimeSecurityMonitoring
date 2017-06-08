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
    class AlarmTypeToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlarmAction aa = (AlarmAction)value;
            switch (aa)
            {
                case AlarmAction.Into:
                    return "驶入";
                case AlarmAction.Out:
                    return "驶出";
                case AlarmAction.Resident:
                    return "驻留";
                case AlarmAction.None:
                    return "无告警";
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
