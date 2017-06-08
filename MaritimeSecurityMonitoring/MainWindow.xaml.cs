using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

using dataAnadll;
using System.Net;
using MaritimeSecurityMonitoring.MainInterfacePage;
namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SetConfig sc = new SetConfig();
        private int userCount;//本地记录的用户名数量
        private int maxCount = 10;//本地记录的用户名数量上限
        private ObservableCollection<User> ul = new ObservableCollection<User>();

        public static string dbIP;//数据库ip
        public static string dbUser;//数据库用户名
        public static string dbPassword;//数据库密码
        public static string dbName;//数据库名

        private LoginManager loginData;     //= new LoginManager();//数据库登录实例
        public static OperationLogWriter OperationLogData;//= new OperationLogWriter();//数据库操作日志实例
        public static OperationLog opeation;//= new OperationLog();//操作日志对象实例

        public static dataAnadll.User userInfor;//用户信息类
        public static string deviceIP = "";//设备ip

        private string[] str = { "管理员", "工程师", "操作员", "观察员" };//0：管理员，1：工程师，2：操作员，3：观察员
        public static string roleContrl = "管理员";//角色权限（用于权限控制）
        public static bool doubleScreen = false;//双屏显示
        public static DoubleScreen doubles;//创建一个双屏实例

        private SetConfig config = new SetConfig();//配置文件实例
        //管理员，工程师，操作员，观察员

        public MainWindow()
        {
            InitializeComponent();

            dbIP = config.read_string("dbsetting", "dbip");
            dbUser = config.read_string("dbsetting", "dbuser");
            dbPassword = config.read_string("dbsetting", "dbpassword");
            dbName = config.read_string("dbsetting", "dbname");

            WinProgressBar dialog = new WinProgressBar() { MaxRespTime = 2, BgWork = dataConnect, BarTitle = "正在加载系统" };//主界面进度条
            dialog.ShowDialog();
            deviceIP = getDeviceIP();
            try
            {
                //MessageBoxX("Info", GetProcess.ProcessManager.IsRunning("MaritimeSecurityMonitoring") == true)
                if (ProcessManager.IsRunning("MaritimeSecurityMonitoring") == true)
                {
                    MessageBoxX.Show("启动警告", "检测到软件已运行,请关闭后重启");
                    System.Windows.Application.Current.Shutdown();

                    Environment.Exit(0);//强制退出
                    GC.Collect();
                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                loginData = new LoginManager();
                OperationLogData = new OperationLogWriter();
                opeation = new OperationLog();

            }
            catch (Exception ee)
            {

            }

        }
        private void dataConnect()//建立短连接
        {
            MysqlDBAccess.SetConnectionStr(dbIP, dbUser, dbPassword, dbName);
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//按住鼠标左键，拖动窗口
        }

        private void MinimumClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;//窗口最小化
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭窗口
        }

        private void PullDownClick(object sender, RoutedEventArgs e)//弹出用户名list列表
        {
            userListPopup.IsOpen = true;
        }

        private void LoginClick(object sender, RoutedEventArgs e)//登录按钮
        {
            //userName.Text = "1";
            //password.Password = "1";
            try
            {
                userInfor = loginData.Login(userName.Text.Trim(), password.Password.Trim());
            }
            catch
            {
                MessageBoxX.Show("警告", "数据库连接失败！");
                System.Windows.Application.Current.Shutdown();

                Environment.Exit(0);//强制退出
                GC.Collect();
            }
            //roleContrl需要数据库查询赋值
            if (userInfor != null)
            {
                roleContrl = str[userInfor.RoleID];//用以权限赋值
                opeation.UserID = userInfor.ID;
                opeation.OptionName = "登录";
                opeation.LogType = 1;
                opeation.Result = "成功";
                opeation.UserName = userInfor.Name;
                opeation.IP = deviceIP;
                opeation.OptionTime = GetTime(GetTimeStamp().ToString());
                OperationLogData.WriteOperationLog(opeation);

                if (!String.IsNullOrWhiteSpace(userName.Text) && IsUserNameNew(userName.Text))//更新用户名的配置文件
                {
                    if (userCount < maxCount)
                    {
                        sc.write_string("userName", "count" + userCount.ToString(), userName.Text);
                        userCount += 1;
                        sc.write_double("userCount", "max", userCount);
                    }
                    else
                    {
                        for (int i = 0; i < maxCount - 1; i++)
                            sc.write_string("userName", "count" + i.ToString(), sc.read_string("userName", "count" + (i + 1).ToString()));
                        sc.write_string("userName", "count" + (userCount - 1).ToString(), userName.Text);
                    }
                }

                if ((bool)rememberPassword.IsChecked && !String.IsNullOrWhiteSpace(password.Password))//更新密码的配置文件
                {
                    sc.write_string("password", "user_" + userName.Text, password.Password);
                }

                sc.write_bool("isRememberPassword", "value", (bool)rememberPassword.IsChecked);//更新是否记住密码


                    if (extendScrean.IsChecked == true)//判断是否启动扩展屏
                    {
                        MonitoringInterface q = new MonitoringInterface();
                        System.Windows.Application.Current.MainWindow = q;
                        this.Close();
                        q.Show();

                        try
                        {
                            MainWindow.opeation.OptionName = "双屏显示";//日志入库
                            MainWindow.opeation.LogType = 2;
                            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                            if (!MainWindow.doubleScreen)
                            {
                                MainWindow.doubles = new DoubleScreen();
                                MainWindow.doubles.Closed += doubleScreenClosed;
                                System.Windows.Application.Current.MainWindow = MainWindow.doubles;
                                MainWindow.doubles.Show();

                                MainWindow.doubleScreen = true;
                                MonitoringX.MonitoringXObj.doubleScreen();//修改主界面
                                

                        }
                        }
                        catch (Exception eex)
                        {
                            MessageBoxX.Show("异常信息", "未检测到扩展屏。");//显示异常信息
                            MainWindow.doubleScreen = false;
                        }
                    }
                    else
                    {
                        MonitoringInterface q = new MonitoringInterface();
                        System.Windows.Application.Current.MainWindow = q;
                        this.Close();
                        q.Show();
                    };
                
            }
            else
            {
                if (String.IsNullOrWhiteSpace(userName.Text) || String.IsNullOrWhiteSpace(password.Password))
                {
                    MessageBoxX.Show("警告", "登录名或者密码为空。");
                }
                else
                {
                    MessageBoxX.Show("警告", "登录名或者密码有误.。");
                }
            };
        }

        private void doubleScreenClosed(object sender, EventArgs e)
        //双屏显示的关闭
        {
            MainWindow.doubleScreen = false;
            MonitoringX.MonitoringXObj.doubleScreen();//修改主界面
            if (MainWindow.doubles != null)
            {
                MainWindow.doubles.close();
            }
            MainWindow.doubles = null;
        }

        private void KeyboardClick(object sender, RoutedEventArgs e)//键盘按钮
        {
            keyboardPopup.IsOpen = true;
        }
        private void ChooseUserNumClick(object sender, SelectionChangedEventArgs e)//用户选择用户名
        {
            userName.Text = ul[userListView.SelectedIndex].UserNumber;
            password.Password = sc.read_string("password", "user_" + userName.Text);
            userListPopup.IsOpen = false;
        }

        bool input = true;

        private void keyboardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input)
            {
                string value = password.Password;
                Button b = sender as Button;
                if (b.Name == "btnDelete")
                {
                    if (value != null && value.Length > 0)
                        value = value.Substring(0, value.Length - 1);
                }
                else
                    value += b.Content.ToString();
                password.Password = value;
                input = false;
            }
            else
            {
                //nothing
                input = true;
            }
        }
        public static int GetTimeStamp()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
        public static DateTime GetTime(string timeStamp)//时间戳转datatime
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userCount = (int)sc.read_double("userCount", "max");//读取本地用户名数量
            rememberPassword.IsChecked = sc.read_bool("isRememberPassword", "value");//读取是否记住密码
            if (userCount > 0)//动态读取用户名密码
            {
                userName.Text = sc.read_string("userName", "count" + (userCount - 1).ToString());
                password.Password = sc.read_string("password", "user_" + userName.Text);
                for (int i = userCount - 1; i >= 0; i--)
                {
                    User u = new User();
                    u.UserNumber = sc.read_string("userName", "count" + i.ToString());
                    ul.Add(u);
                }
                userListView.DataContext = ul;
            }
        }

        private bool IsUserNameNew(string uN)//判断用户名是否为新，即本地是否没有记录
        {
            for (int i = 0; i < userCount; i++)
            {
                if (uN == sc.read_string("userName", "count" + i.ToString()))
                {
                    for (int n = i; n < maxCount - 1; n++)
                        sc.write_string("userName", "count" + n.ToString(), sc.read_string("userName", "count" + (n + 1).ToString()));
                    sc.write_string("userName", "count" + (userCount - 1).ToString(), uN);
                    return false;
                }
            }
            return true;
        }

        public static string getDeviceIP()
        {
            string ip = "";
            foreach (IPAddress _IPAddress in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = _IPAddress.ToString();
                }
            }
            return ip;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LoginClick(sender, e);
        }
        public static int GetTimeStampS()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
    }
}
