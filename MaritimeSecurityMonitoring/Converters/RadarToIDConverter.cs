﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaritimeSecurityMonitoring
{
    class RadarToIDConverter:IMultiValueConverter
    {
        public object Convert(object[] values,Type targetType,object parameter,System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[0].ToString() == "AIS")
                return null;
            if (values[1] != null && values[1].ToString() == "0")
                return null;
            return values[1].ToString();
        }

        public object[] ConvertBack(object value,Type[] targetTypes,object parameter,System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
