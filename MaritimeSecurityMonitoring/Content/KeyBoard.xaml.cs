using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaritimeSecurityMonitoring.Content
{
    /// <summary>
    /// KeyBoard.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoard : UserControl
    {
        private enum CharacterStatus
        {
            Upper,
            Lower,
        };

        CharacterStatus currentStatus = CharacterStatus.Lower;

        public KeyBoard()
        {
            InitializeComponent();
        }

        private void btnShift_Click(object sender, RoutedEventArgs e)
        {
            UpperLowerConverter();
            if (btnShift.IsChecked == true)
            {
                btnNum2.Content = "@";
                btnNum3.Content = "#";
                btnNum4.Content = "$";
                btnNum5.Content = "%";
                btnNum6.Content = "^";
                btnNum7.Content = "&";
                btnNum8.Content = "*";
                btnNum9.Content = "(";
                btnNum0.Content = ")";
                btnDot.Content = "~";
                btnNum1.Content = "!";

                btnBackslant.Content = "|";
                btnLParenthesis.Content = "{";
                btnRParenthesis.Content = "}";
                btnSemicolon.Content = ":";
                btnSQuotes.Content="\"";
                btnComma.Content = "<";
                btnPeriod.Content = ">";
                btnSlant.Content = "?";
                btnSub.Content = "_";
                btnEquip.Content = "+";
            }
            else
            {
                btnNum2.Content = "2";
                btnNum3.Content = "3";
                btnNum4.Content = "4";
                btnNum5.Content = "5";
                btnNum6.Content = "6";
                btnNum7.Content = "7";
                btnNum8.Content = "8";
                btnNum9.Content = "9";
                btnNum0.Content = "0";
                btnDot.Content = "`";
                btnNum1.Content = "1";
                
                btnBackslant.Content = "\\";
                btnLParenthesis.Content = "[";
                btnRParenthesis.Content = "]";
                btnSemicolon.Content = ";";
                btnSQuotes.Content = "'";
                btnComma.Content = ",";
                btnPeriod.Content = ".";
                btnSlant.Content = "/";
                btnSub.Content = "-";
                btnEquip.Content = "=";
            }
        }

        private void btnCapsLock_Click(object sender, RoutedEventArgs e)
        {
            UpperLowerConverter();
        }

        private void btn_Down(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.LeftShift || e.Key == Key.RightShift) && btnShift.IsChecked == false)
            {
                btnShift.IsChecked = true;
                btnShift_Click(this, null);
            }
            if (e.Key == Key.CapsLock)
            {
                btnCapsLock.IsChecked = !btnCapsLock.IsChecked;
                btnCapsLock_Click(this, null);
            }
        }

        private void btn_Up(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.LeftShift || e.Key == Key.RightShift) && btnShift.IsChecked == true)
            {
                btnShift.IsChecked = false;
                btnShift_Click(this, null);
            }
        }

        public delegate void ClickEventArgs(object sender, RoutedEventArgs e);

        public event ClickEventArgs Click;

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }
        }

        private void UpperLowerConverter()
        {
            switch (currentStatus)
            {
                case CharacterStatus.Lower:
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        Button btn = FindName("btn" + ch) as Button;
                        btn.Content = ch.ToString().ToUpper();
                    }
                    currentStatus = CharacterStatus.Upper;
                    break;
                case CharacterStatus.Upper:
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        Button btn = FindName("btn" + ch) as Button;
                        btn.Content = ch;
                    }
                    currentStatus = CharacterStatus.Lower;
                    break;
                default:
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
 MessageBoxX.Show("ERROR", "发生未知错误！");
                    }
));
                   
                    break;
            }
        }
    }
}
