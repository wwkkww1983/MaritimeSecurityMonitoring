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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// TargetWakeSetting.xaml 的交互逻辑
    /// </summary>
    public partial class TargetWakeSetting : Window
    {
        public TargetWakeSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WakeData wd = new WakeData();
            DataContext = wd;
        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
    }

    class WakeData
    {
        public string width { get; set; }
        public string radius { get; set; }
    }
}
