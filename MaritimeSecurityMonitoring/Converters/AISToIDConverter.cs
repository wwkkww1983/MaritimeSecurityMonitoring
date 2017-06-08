using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaritimeSecurityMonitoring
{
    class AISToIDConverter:IMultiValueConverter
    {
        public object Convert(object[] values,Type targetType,object parameter,System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[0].ToString() == "AIS")
                return values[1].ToString();
            if (values[0] != null && values[0].ToString() == "融合" && values[1] != null && values[1].ToString() != "0")
                return values[1].ToString();
            return null;
        }

        public object[] ConvertBack(object value,Type[] targetTypes,object parameter,System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
