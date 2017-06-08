using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    public class NumberValidationRuleForFloat : ValidationRule
    {
        public float Min { get; set; }
        public float Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            float fnumber;
            if (value.ToString().Length <= 0)
            {
                return ValidationResult.ValidResult;
            }
            else if (!float.TryParse((string)value, out fnumber))
            {
                return new ValidationResult(false, "输入内容必须为数值！");
            }
            else if (fnumber > Max || fnumber < Min)
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
