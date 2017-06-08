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
    /// UserManagement.xaml 的交互逻辑
    /// </summary>
    public partial class UserManagement : Page
    {
        public static ObservableCollection<SystemUser> userList = new ObservableCollection<SystemUser>();
        //private int editID;

        private dataAnadll.UserManager userData = new dataAnadll.UserManager();//用户管理实例化
        public UserManagement()
        {
            InitializeComponent();
            userList.Clear();

            List<dataAnadll.User> list = new List<dataAnadll.User>();
            list = userData.GetAllUsers();
             
            for (int i = 0; i < list.Count; i++)
            {
                SystemUser user = new SystemUser
                {
                    ID = i,
                    UserID=list[i].ID.ToString(),
                    UserName = list[i].Name,
                    Password = list[i].Password,
                    Role = list[i].RoleID.ToString(),
                    Position = list[i].Level,
                    Department = list[i].Department,
                    Phone = list[i].Phone,
                    Mail = list[i].Email,
                    ReadOnly = true
                };
                userList.Add(user);
            }
            UserListView.DataContext = userList;
            
        }
        private void searchclick(object sender, RoutedEventArgs e)//搜索
        {
            //string[] str=MainWindow.data.查询用户函数名(searchBox.Text);
            /*string[] str = null;
            for (var i = 0; i < userList.Count; i++)//清空列表
            {
                userList.RemoveAt(0);
            }
            SystemUser user = new SystemUser
            {
                ID = 1,
                UserID = str[0],
                UserName = str[1],
                Password = str[3],
                Role = str[2],
                Position = str[4],
                Department = str[5],
                Phone = str[7],
                Mail = str[6],
                IsConfirm = true,
                ReadOnly = true
            };
            userList.Add(user);
            UserListView.DataContext = userList;
            */
        }
        private void Edit_Click(object sender, RoutedEventArgs e)//列表右侧按钮-编辑
        {
            ToggleButton b = sender as ToggleButton;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = UserListView.Items.Count - 1; i >= 0; i--)
            {
                if (userList[i].ID == id)
                {
                    if (!userList[i].ReadOnly)
                    {
                        ListViewItem lvi = this.UserListView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                        TextBox tb = FindVisualChild<TextBox>(lvi);
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(userList[i].UserName) || String.IsNullOrWhiteSpace(userList[i].Password) || String.IsNullOrWhiteSpace(userList[i].Role))
                        {
                            MessageBoxX.Show("提示", "用户名、密码、角色类型不能为空！");
                            userList[i].ReadOnly = !userList[i].ReadOnly;
                        }
                        else
                        {
                            try
                            {
                                dataAnadll.User us = new dataAnadll.User();
                                us.ID = int.Parse(userList[i].UserID);
                                us.Name = userList[i].UserName;
                                us.Password = userList[i].Password;
                                us.RoleID = int.Parse(userList[i].Role);
                                us.Department = userList[i].Department;
                                us.Level = userList[i].Position;
                                us.Email = userList[i].Mail;
                                us.Phone = userList[i].Phone;
                                userData.UpdateUser(us);//用户数据更新
                            }
                            catch(Exception ex)
                            {
                                MessageBoxX.Show("警告", "存在非法的数据！");
                                userList[i].ReadOnly = !userList[i].ReadOnly;
                            }
                        }
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//列表右侧按钮-删除
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.CommandParameter);
            ConfirmBox cb = new ConfirmBox()
            {
                pageName = "UserManagement",
                id = id,
                Title = "提示",
                Message = "确定删除这条数据吗？"
            };
            cb.ShowDialog();
        }

        private void AddTargetClick(object sender, RoutedEventArgs e)//新增
        {
            User_Add ua = new User_Add();
            ua.ShowDialog();
        }

        /*private void ConfirmClick(object sender, RoutedEventArgs e)//确定
        {
            if(userList[editID].UserName!=null&& userList[editID].UserName!=null&& userList[editID].Role!=null&& userList[editID].Password != null) { 
                string[] user = { userList[editID].UserID, userList[editID].UserName, userList[editID].Role, userList[editID].Password, userList[editID].Position, userList[editID].Department, userList[editID].Mail, "", userList[editID].Phone };
                dataAnadll.User us = new dataAnadll.User();
                us.Name = userList[editID].UserName;
                us.Password = userList[editID].Password;
                us.RoleID = (int)double.Parse(userList[editID].Role);
                us.Department = userList[editID].Department;
                us.Level = userList[editID].Position;
                us.Email = userList[editID].Mail;
                us.Phone = userList[editID].Phone;
                userData.AddUser(us);//用户数据添加
            }
            else
            {
                MessageBoxX.Show("提示","输入不能为空!");
            }
            for (int i = UserListView.Items.Count - 1; i >= 0; i--)
            {
                userList[i].IsConfirm = true;
                userList[i].ReadOnly = true;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)//取消
        {
            for (int i = UserListView.Items.Count - 1; i >= 0; i--)
            {
                if (userList[i].IsConfirm == false)
                {
                    userList.RemoveAt(i);
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
