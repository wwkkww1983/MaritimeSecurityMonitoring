using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaritimeSecurityMonitoring
{
    class SailStatusToStringConverter : IMultiValueConverter
    {
        public static readonly Dictionary<byte, string> SailStatusMap = new Dictionary<byte, string>
        {
            {0,"发动机使用中" },
            {1,"锚泊" },
            {2, "未操纵" },
            {3, "有限适航性" },
            {4, "受船舶吃水限制" },
            {5, "系泊" },
            {6, "搁浅" },
            {7, "从事捕捞" },
            {8, "航行中" },
            {9, "留做将来修正导航状态" },
            {10, "留做将来修正导航状态" },
            {11, "留做将来用" },
            {12, "留做将来用" },
            {13, "留做将来用"},
            {14, "AIS-SART（现行的）"},
            {15, "未规定，默认值（也用于测试中的AIS-SART）" },
        };
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[0].ToString() == "雷达")
                return null;
            if (values[0] != null && values[0].ToString() == "融合" && values[1] != null && values[1].ToString() == "0")
                return null;
            try
            {
                return SailStatusMap[(byte)values[2]];
            }
            catch (Exception ex)
            {
                return "类型解析错误！";
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
