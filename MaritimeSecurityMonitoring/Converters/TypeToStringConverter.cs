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
    class TypeToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[0].ToString() == "雷达")
                return null;
            TargetType type = (TargetType)values[1];
            switch (type)
            {
                case TargetType.Suspicious:
                    return "可疑船只";
                case TargetType.Normal:
                    return "正常船只";
                case TargetType.Unknow:
                    return "未知船只";
                default:
                    return "类型解析异常";
            }
        }

        /*  
         * 数据从Targe到Source时，ConvertBack被调用 
         * 目前不会被调用 
         */
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }  
    }
}
