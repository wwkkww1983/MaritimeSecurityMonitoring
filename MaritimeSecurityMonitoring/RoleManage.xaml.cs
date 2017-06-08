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
    /// RoleManage.xaml 的交互逻辑
    /// </summary>
    public partial class RoleManage : Window
    {
        List<RoleDate> items = new List<RoleDate>();
        public RoleManage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            items.Add(new RoleDate() { Number = "1", Role = "管理员", });
            items.Add(new RoleDate() { Number = "2", Role = "工程师", });
            items.Add(new RoleDate() { Number = "3", Role = "操作员", });
            items.Add(new RoleDate() { Number = "4", Role = "观察员", });
            dataList.ItemsSource = items;
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void addingClick(object sender, RoutedEventArgs e)
        {
            dataList.ItemsSource = "";
            items.Add(new RoleDate() { Number = numberText.Text, Role = roleText.Text });
            dataList.ItemsSource = items;
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            //dataList.ItemsSource = items;
        }

    }
    public class RoleDate
    {
        public string Number { get; set; }
        public string Role { get; set; }
    }
}

