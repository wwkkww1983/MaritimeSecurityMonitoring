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

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// PlatformPositionSetting.xaml 的交互逻辑
    /// </summary>
    public partial class PlatformPositionSetting : Window
    {
        private PlatformManager plate = new PlatformManager();//平台实例
        public static double dlongtitude;
        public static double dlatitude;
        public PlatformPositionSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PlatformPosition pp = new PlatformPosition();

            MonitoringX.platform.GetPlatform(out dlongtitude, out dlatitude);//查询平台中心
                                                                             //longitude.Text =dlongtitude.ToString();
                                                                             // latitude.Text = dlatitude.ToString();
            pp.longitude = dlongtitude.ToString();
            pp.latitude = dlatitude.ToString();
            DataContext = pp;
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static int GetTimeStampS()//当前时间转换时间戳
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
        private void saveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (float.Parse(longitude.Text) > rule1.Max || float.Parse(longitude.Text) < rule1.Min || float.Parse(latitude.Text) > rule2.Max || float.Parse(latitude.Text) < rule2.Min)
                    MessageBoxX.Show("提示", "经纬度超过范围！");
                else
                {
                    double longitudeValue = double.Parse(longitude.Text);
                    double latitudeValue = double.Parse(latitude.Text);
                    MonitoringX.center[0] = double.Parse(longitude.Text);
                    MonitoringX.center[1] = double.Parse(latitude.Text);
                    App app = (App)App.Current;

                    plate.SavePlatform(MonitoringX.center[0], MonitoringX.center[1]);//平台中心入库

                    app.chartCtrl.SetPlatform(longitudeValue, latitudeValue);
                    app.chartCtrl.CenterMap(longitudeValue, latitudeValue);

                    MainWindow.opeation.OptionName = "设置平台中心";//日志入库
                    MainWindow.opeation.LogType = 2;
                    MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                    MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                    MessageBoxX.Show("提示", "经纬度设置成功！");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBoxX.Show("警告", "经纬度数据非法或为空！");
            }
        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            longitude.Text = "";
            latitude.Text = "";
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

    class PlatformPosition
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
