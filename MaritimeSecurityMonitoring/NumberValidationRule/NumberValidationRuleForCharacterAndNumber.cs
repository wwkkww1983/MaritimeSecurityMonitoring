using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    class NumberValidationRuleForCharacterAndNumber:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length > 0)
            {
                int i;
                string str = value.ToString();
                char[] ch = str.Substring(str.Length - 1).ToCharArray();
                if(!(ch[0]>='a'&&ch[0]<='z')&&!(ch[0]>='A'&&ch[0]<='Z')&&!int.TryParse(str.Substring(str.Length - 1),out i))
                    return new ValidationResult(false, "应输入字母或数字！");
                else
                    return ValidationResult.ValidResult;
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
