using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

using MaritimeSecurityMonitoring;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// ConfirmBox.xaml 的交互逻辑
    /// </summary>
    public partial class ConfirmBox : Window
    {
        public string pageName { get; set; }
        public int id { get; set; }

        private WhiteShipListManage white = new WhiteShipListManage();//白名单数据库实例
        private dataAnadll.UserManager userData = new dataAnadll.UserManager();//用户管理实例化
        private DeviceInfoManager device = new DeviceInfoManager();//网络参数数据库实例

        public ConfirmBox()
        {
            InitializeComponent();
        }

        public new string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }  
        }

        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }

        private void YES_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (pageName == "WhiteListSetting")
            {
                for (int i = WhiteListSetting.whiteList.Count - 1; i >= 0; i--)
                {
                    if (WhiteListSetting.whiteList[i].ID == id)
                    {
                        white.DeleteWhiteShip((int)double.Parse(WhiteListSetting.whiteList[i].MMSI));//数据库删除
                        MainWindow.opeation.OptionName = "删除白名单";//日志入库
                        MainWindow.opeation.LogType = 2;
                        MainWindow.opeation.OptionTime = WhiteListSetting.GetTime(WhiteListSetting.GetTimeStampS().ToString());
                        MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                        WhiteListSetting.whiteList.RemoveAt(i);//列表删除
                    }
                }
                for (int i = WhiteListSetting.whiteList.Count - 1; i >= 0; i--)
                    WhiteListSetting.whiteList[i].ID = i;
                dataAna.WhiteListSync();//白名单同步
            }
            else if (pageName == "UserManagement")
            {
                for (int i = UserManagement.userList.Count - 1; i >= 0; i--)
                {
                    if (UserManagement.userList[i].ID == id)
                    {
                        userData.DeleteUser(int.Parse(UserManagement.userList[i].UserID));//数据库删除用户
                        UserManagement.userList.RemoveAt(i);
                    }
                }
                for (int i = UserManagement.userList.Count - 1; i >= 0; i--)
                    UserManagement.userList[i].ID = i;
            }
            else if (pageName == "NetParameterSetting")
            {
                for (int i = NetParameterSetting.deviceList.Count - 1; i >= 0; i--)
                {
                    if (NetParameterSetting.deviceList[i].ID == id)
                    {
                        device.DeleteDeviceInfo(NetParameterSetting.deviceList[i].Name);//数据库删除
                        NetParameterSetting.deviceList.RemoveAt(i);
                    }
                }
                for (int i = NetParameterSetting.deviceList.Count - 1; i >= 0; i--)
                    NetParameterSetting.deviceList[i].ID = i;
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
