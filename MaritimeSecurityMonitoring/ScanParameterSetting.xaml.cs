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
using System.Windows.Shapes;

using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// ScanParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class ScanParameterSetting : Window
    {
        /*public static int left=45;
        public static int right=45;
        public static int speed=40;*/
        public static bool rst = true;
        public static ScanParameter sp = new ScanParameter()
        {
            angle1 = "45",
            angle2 = "45",
            percent = "40",
        };

        public ScanParameterSetting()
        {
            InitializeComponent();
            rst = false;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = sp;
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            rst = false;
            this.Close();//关闭界面
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }

        int min, max;
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Tag.ToString() == "Percent")
            {
                min = 20;
                max = 100;
            }
            else
            {
                min = -179;
                max = 180;
            }

            TextBox tb = FindName(b.Tag.ToString()) as TextBox;
            int itry;
            if (!int.TryParse(tb.Text, out itry)) return;
            else if (itry <= max && itry >= min)
                tb.Text = ((itry + 1    +179)%(180+179+1)-179).ToString();
            else
                tb.Text = min.ToString();
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Tag.ToString() == "Percent")
            {
                min = 20;
                max = 100;
            }
            else
            {
                min = -179;
                max = 180;
            }

            TextBox tb = FindName(b.Tag.ToString()) as TextBox;
            int itry;
            if (!int.TryParse(tb.Text, out itry)) return;
            else if (itry > max || itry <= min)
                tb.Text = max.ToString();
            else
                tb.Text = ((itry - 1 + 179) % (180 + 179 + 1) - 179).ToString();
        }

        private void comfirmClick(object sender, RoutedEventArgs e)//确定
        {
            try
            {
                if (int.Parse(Angle1.Text) > rule1.Max || int.Parse(Angle1.Text) < rule1.Min || int.Parse(Angle2.Text) > rule2.Max || int.Parse(Angle2.Text) < rule2.Min || int.Parse(Percent.Text) > rule3.Max || int.Parse(Percent.Text) < rule3.Min)
                    MessageBoxX.Show("提示", "数据超出范围！");
                else
                {
                    sp.angle1 = Angle1.Text;
                    sp.angle2 = Angle2.Text;
                    sp.percent = Percent.Text;
                   
                    this.Close();
                    rst = true;
                }
            }
            catch(Exception ex)
            {
                MessageBoxX.Show("警告", "数据非法或为空！");
                rst = false;
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)//取消
        {
            //  sp.angle1 = "45";
            //  sp.angle2 = "45";
            //  sp.percent = "40";
            rst = false;
             this.Close();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ScanParameter
    {
        public string angle1 { get; set; }
        public string angle2 { get; set; }
        public string percent { get; set; }
    }
}

