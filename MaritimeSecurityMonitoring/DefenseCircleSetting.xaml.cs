﻿using System;
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
using System.Drawing;
using System.Windows.Forms;

using dataAnadll;
using MaritimeSecurityMonitoring.MainInterfacePage;
using YimaWF.data;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DefenseCircleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class DefenseCircleSetting : Window
    {
        public static float fHeight;
        public static float fAlarmR;
        public static byte ucAlarmLevel;
        public static int rankNumber;
        public static byte ucCycleAlarmNum;
        public static string color;
        public static string name;

        public static CircleProtectAreaManager circleData = new CircleProtectAreaManager();//圈层数据库实例
        public DefenseCircleSetting()
        {
            InitializeComponent();
 			try
			{
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            App app = (App)App.Current;
            List<ProtectZone> list0 = circleData.GetAllCircleProtectArea(app.chartCtrl.GetGeoMultiFactor());//圈层数据初始化

            DefenseCircle dc = new DefenseCircle()
            {
                r1 = (list0[0].Radius / 1000).ToString(),
                r2 = (list0[1].Radius / 1000).ToString(),
                r3 = (list0[2].Radius / 1000).ToString(),
            };
            DataContext = dc;
                System.Windows.Media.Color _color1= new System.Windows.Media.Color();
                System.Windows.Media.Color _color2= new System.Windows.Media.Color();
                System.Windows.Media.Color _color3= new System.Windows.Media.Color();
                _color1.A = 0xFF;
                _color1.R = list0[0].ContentColor.R;
                _color1.G = list0[0].ContentColor.G;
                _color1.B = list0[0].ContentColor.B;

                _color2.A = 0xFF;
                _color2.R = list0[1].ContentColor.R;
                _color2.G = list0[1].ContentColor.G;
                _color2.B = list0[1].ContentColor.B;

                _color3.A = 0xFF;
                _color3.R = list0[2].ContentColor.R;
                _color3.G = list0[2].ContentColor.G;
                _color3.B = list0[2].ContentColor.B;
            color1.SelectedColor = _color1;
            color2.SelectedColor = _color2;
            color3.SelectedColor = _color3;
         }
            catch (Exception ee)
            {
                
            }
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭窗口
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void sureClick(object sender, RoutedEventArgs e)//三次循环存储圈层
        {
            try
            {
                float a = (float)double.Parse(alarm1.Text);
                float b = (float)double.Parse(alarm2.Text);
                float c = (float)double.Parse(alarm3.Text);
                if (a > rule1.Max || a < rule1.Min || b > rule2.Max || b < rule2.Min || c > rule3.Max || c < rule3.Min)
                    MessageBoxX.Show("提示", "数据超出范围！");
                else if (a < b && b < c)
                {
                    //color.
                    MonitoringX.updataProtectZoneBack("201", "驱逐区", alarm1.Text, color1.SelectedColorText);
                    MonitoringX.updataProtectZoneBack("202", "警戒区", alarm2.Text, color2.SelectedColorText);
                    MonitoringX.updataProtectZoneBack("203", "预警区", alarm3.Text, color3.SelectedColorText);

                    MainWindow.opeation.OptionName = "圈层信息修改";
                    MainWindow.opeation.LogType = 2;
                    MainWindow.opeation.OptionTime = GetTime(GetTimeStamp().ToString());
                    MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);//操作日志
                    this.Close();//关闭窗口       
                }
                else
                {
                    MessageBoxX.Show("提示", "半径值需要递增！");
                }
            }
            catch(Exception ex)
            {
                MessageBoxX.Show("警告", "输入数据有误！请重新输入！");
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭窗口
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

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }

    class DefenseCircle
    {
        public string r1 { get; set; }
        public string r2 { get; set; }
        public string r3 { get; set; }
    }
}