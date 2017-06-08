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
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// RoleManagement.xaml 的交互逻辑
    /// </summary>
    public partial class RoleManagement : Page
    {
        public static ObservableCollection<SystemRole> roleList = new ObservableCollection<SystemRole>();
        //private int editID;

        private UserManager user = new UserManager();//用户管理实例化

        public RoleManagement()
        {
            InitializeComponent();
            roleList.Clear();
            List<dataAnadll.User> list = new List<dataAnadll.User>();
            list = user.GetAllUsers();

            for (int i = 0; i < list.Count; i++)
            {
                SystemRole sr = new SystemRole
                {
                    ID = i,
                    Code = list[i].ID.ToString(),
                    Name =list[i].Name,
                    Right = list[i].RoleID.ToString(),
                    Description = list[i].Department,
                    ReadOnly = true,
                };
                roleList.Add(sr);
            }
            RoleListView.DataContext = roleList;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)//列表编辑
        {
            ToggleButton b = sender as ToggleButton;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = RoleListView.Items.Count - 1; i >= 0; i--)
            {
                if (roleList[i].ID == id)
                {
                    if (!roleList[i].ReadOnly)
                    {
                        ListViewItem lvi = this.RoleListView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                        TextBox tb = FindVisualChild<TextBox>(lvi);
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(roleList[i].Name) || String.IsNullOrWhiteSpace(roleList[i].Right))
                        {
                            MessageBoxX.Show("提示", "角色名称、权限不能为空！");
                            roleList[i].ReadOnly = !roleList[i].ReadOnly;
                        }
                        else
                        {
                            dataAnadll.User us = new dataAnadll.User();
                            us.ID = int.Parse(roleList[i].Code);
                            us.Name = roleList[i].Name;
                            us.RoleID = int.Parse(roleList[i].Right);
                            us.Department = roleList[i].Description;

                            user.UpdateUser(us);//用户数据更新
                        }
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//列表删除
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = RoleListView.Items.Count - 1; i >= 0; i--)
            {
                if (roleList[i].ID == id)
                {
                    user.DeleteUser((int)double.Parse(roleList[i].Code));//数据库删除用户
                    roleList.RemoveAt(i);            
                }
            }
            for (int i = RoleListView.Items.Count - 1; i >= 0; i--)
                roleList[i].ID = i;
        }

        private void AddTargetClick(object sender, RoutedEventArgs e)//新增
        {
            Role_Add ra = new Role_Add();
            ra.ShowDialog();        
        }

        /*private void ConfirmClick(object sender, RoutedEventArgs e)//确定（更新新添加数据到数据库）
        {
            dataAnadll.User us = new dataAnadll.User();
            us.Name = roleList[editID].Name;
            us.RoleID = (int)double.Parse(roleList[editID].Right);
            us.Department = roleList[editID].Description;

            user.AddUser(us);//添加新用户
            for (int i = RoleListView.Items.Count - 1; i >= 0; i--)
            {
                roleList[i].ReadOnly = true;
                roleList[i].IsConfirm = true;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)//取消（删除新增的那一行）
        {
            for (int i = RoleListView.Items.Count - 1; i >= 0; i--)
            {
                if (roleList[i].IsConfirm == false)
                {
                    roleList.RemoveAt(i);
                    break;
                }
            }
        }*/

        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if (childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Focus();
        }
    }
}
