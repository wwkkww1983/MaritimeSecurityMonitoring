﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YimaWF.data;
using YimaEncCtrl;

namespace MaritimeSecurityMonitoring
{
    class AlarmTypeToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlarmType at = (AlarmType)value;
            switch (at)
            {
                case AlarmType.ForbiddenZone:
                    return "多边形区域";
                case AlarmType.None:
                    return "无告警";
                case AlarmType.Pipeline:
                    return "管道区域";
                case AlarmType.Contact:
                    return "平台碰撞";
                case AlarmType.ExpulsionArea:
                    return "驱逐区";
                case AlarmType.AlertArea:
                    return "警戒区";
                case AlarmType.EarlyWarningArea:
                    return "预警区";
                case AlarmType.Checked:
                    return "已确认";
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
