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
using System.Windows.Forms;
using YimaWF.data;

using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MapManage.xaml 的交互逻辑
    /// </summary>
    public partial class MapManage : Window
    {
        private string[] mapInformation = { "", "", "", "", "", "", "", "", "" };
        SetConfig sc = new SetConfig();
        List<string> list = new List<string>();
        private YimaWF.data.MapInfo mapInformations;
        public static int target=-1;//获取选中第几项
        public static string opeartion;//操作

        public MapManage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            App app = (App)App.Current;
            list=app.chartCtrl.GetMapList();//获取海图名数组

            for (int i = 0;i<list.Count;i++)//加载海图名列表
            {
                int flag = list[i].IndexOf('\0');
                if (flag > 0)
                    addMapsSelection.Items.Add(list[i].Substring(0, flag));
                else
                    addMapsSelection.Items.Add(list[i]);
            } 
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void chooseMaps(object sender, SelectionChangedEventArgs e)//选择
        {
            target = addMapsSelection.SelectedIndex;//选中第几项
        }
        private void showInfo_Click(object sender, RoutedEventArgs e)//概览
        {
            if (target != -1)
            {
                App app = (App)App.Current;
                mapInformations = app.chartCtrl.GetMapInfo(target);//获取海图信息类的数据

                mapInformation[0] = mapInformations.OriginalScale.ToString();
                mapInformation[1] = mapInformations.EditionNum.ToString();
                mapInformation[2] = mapInformations.UpdateEdtNum.ToString();
                mapInformation[3] = mapInformations.EditDate.ToString();
                mapInformation[4] = mapInformations.LeftStrBndry.ToString();
                mapInformation[5] = mapInformations.RightStrBndry.ToString();
                mapInformation[6] = mapInformations.UpStrBndry.ToString();
                mapInformation[7] = mapInformations.DownStrBndry.ToString();

                measuring.Text = mapInformation[0];
                edition.Text = mapInformation[1];
                upgradedVersion.Text = mapInformation[2];
                int flag = mapInformation[3].IndexOf('\0');
                if (flag > 0)
                    memory.Text = mapInformation[3].Substring(0, flag);
                else
                    memory.Text = mapInformation[3];
                rightBoundary.Text = mapInformation[4];
                leftBoundary.Text = mapInformation[5];
                topBoundary.Text = mapInformation[6];
                bottomBoundary.Text = mapInformation[7];
            }else
            {
                MessageBoxX.Show("提示","没有选取海图目标！");
            }
        }
        private void delete_Click(object sender, RoutedEventArgs e)//删除
        {
            if (target != -1)
            {
                App app = (App)App.Current;
                opeartion = "删除";

                MapMessage sp = new MapMessage();
                System.Windows.Application.Current.MainWindow = sp;
                sp.ShowDialog();

                
                MainWindow.opeation.OptionName = "海图删除";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                addMapsSelection.Items.Clear();

                list = app.chartCtrl.GetMapList();//获取海图名数组

                for (int i = 0; i < list.Count; i++)//加载海图名列表
                {
                    int flag = list[i].IndexOf('\0');
                    if (flag > 0)
                        addMapsSelection.Items.Add(list[i].Substring(0, flag));
                    else
                        addMapsSelection.Items.Add(list[i]);
                }
                addMapsSelection.Items.Refresh();
            }
            else
            {
                MessageBoxX.Show("提示", "没有选取海图目标！");
            }
        }
        private void addMap_Click(object sender, RoutedEventArgs e)//添加海图
        {
            string path = "";
            OpenFileDialog ofd = new OpenFileDialog();//选择打开的文件路径
            ofd.Title = "打开";
            ofd.Filter = "海图文件|*.ymc;*.tbl"; //这是设置扩展名。
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = ofd.FileName;
                App app = (App)App.Current;
                app.chartCtrl.AddMap(path);

                System.Windows.MessageBox.Show("海图文件上传成功");
                MainWindow.opeation.OptionName = "海图上传";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                for (int i = addMapsSelection.Items.Count; i > 0; i--)
                {
                    addMapsSelection.Items.Remove(0);
                }

                list = app.chartCtrl.GetMapList();//获取海图名数组

                for (int i = 0; i < list.Count; i++)//加载海图名列表
                {
                    int flag = list[i].IndexOf('\0');
                    if (flag > 0)
                        addMapsSelection.Items.Add(list[i].Substring(0, flag));
                    else
                        addMapsSelection.Items.Add(list[i]);
                }
            }
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
        private void Window_Loaded(object sender, RoutedEventArgs e)//不用写入配置文件
        {
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

