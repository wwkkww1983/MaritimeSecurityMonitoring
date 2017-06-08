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
    /// MapMessage.xaml 的交互逻辑
    /// </summary>
    public partial class MapMessage : Window
    {
        public MapMessage()
        {
            InitializeComponent();
            if (MapManage.opeartion == "删除")
            {
                lblMsg.Text = "是否确认删除？";
            }
            else if (MapManage.opeartion == "预览")
            {

                lblMsg.Text = "是否确认切换？";
            }
        }
        private void YES_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            if (MapManage.opeartion == "删除")
            {
                app.chartCtrl.DeleteMap(MapManage.target);
                MessageBoxX.Show("提示", "海图文件删除成功!");
            }
            else if (MapManage.opeartion == "预览")
            {
                app.chartCtrl.OverViewMap(MapManage.target);
            }
            this.Close();
        }
        private void NO_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
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
}
