using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    public class NumberValidationRuleForInt : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int Inumber;
            if (value.ToString().Length <= 0)
            {
                return ValidationResult.ValidResult;
            }
            else if (!int.TryParse((string)value, out Inumber))
            {
                return new ValidationResult(false, "应为整数");
            }
            else if (Inumber > Max || Inumber < Min)
            {
                return new ValidationResult(false, "超过范围");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}