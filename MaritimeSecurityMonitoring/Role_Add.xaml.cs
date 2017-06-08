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

using MaritimeSecurityMonitoring;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// Role_Add.xaml 的交互逻辑
    /// </summary>
    public partial class Role_Add : Window
    {
        private dataAnadll.UserManager userData = new dataAnadll.UserManager();//用户管理实例化
        public Role_Add()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }

        private void comfirmClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(right.Text))
            {
                MessageBoxX.Show("提示", "角色名称、权限不能为空！");
            }
            else
            {
                dataAnadll.User us = new dataAnadll.User();
                us.Name = name.Text;
                us.RoleID = int.Parse(right.Text);
                us.Department = description.Text;
                userData.AddUser(us);//用户数据添加

                List<dataAnadll.User> list = new List<dataAnadll.User>();
                list = userData.GetAllUsers();
                SystemRole sr = new SystemRole
                {
                    ID = RoleManagement.roleList.Count,
                    Code = list[list.Count - 1].ID.ToString(),
                    Name = list[list.Count - 1].Name,
                    Right = list[list.Count - 1].RoleID.ToString(),
                    Description = list[list.Count - 1].Department,
                    ReadOnly = true,
                };
                RoleManagement.roleList.Add(sr);
                this.Close();
            }
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
