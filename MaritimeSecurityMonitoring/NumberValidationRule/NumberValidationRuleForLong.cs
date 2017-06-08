using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    public class NumberValidationRuleForLong : ValidationRule
    {
        public long Max { get; set; }
        public long Min { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long lnumber;
            if (value.ToString().Length <= 0)
            {
                return ValidationResult.ValidResult;
            }
            else if (!long.TryParse((string)value, out lnumber))
            {
                return new ValidationResult(false, "输入内容必须为整数！");
            }
            else if (lnumber > Max || lnumber < Min)
            {
                return new ValidationResult(false, "超过范围！");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}