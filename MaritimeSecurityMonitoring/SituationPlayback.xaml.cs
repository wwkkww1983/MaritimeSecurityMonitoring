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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// SituationPlayback.xaml 的交互逻辑
    /// </summary>
    public partial class SituationPlayback : Window
    {
        public static long startTime;
        public static long endTime;
        public SituationPlayback()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startTimeText.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).ToString();
            endTimeText.Text = DateTime.Now.ToString();
        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void confirmClick(object sender, RoutedEventArgs e)//确定
        {
            System.DateTime time = Convert.ToDateTime(startTimeText.Text);//string转datatime（star）
            startTime = (long)GetTimeStamp(time);//datatime时间戳（star）

            System.DateTime timer = Convert.ToDateTime(endTimeText.Text);//string转datatime（end） 
            endTime = (long)GetTimeStamp(timer);//datatime时间戳（end）


            if ((endTime - startTime) > 3 * 60 * 60)
            {
                MessageBoxX.Show("提示", "回放时间不应超过3小时！");
                return;
            }
            if (startTime > endTime)
            {
                  MessageBoxX.Show("提示","开始时间不能大于结束时间！");
                return;
            }
            if (startTime <= endTime  )
            {
                
                monitoringIn sp = new monitoringIn();
                Application.Current.MainWindow = sp;
                sp.ShowDialog();
                this.Close();
            }
            
        }
        private int GetTimeStamp(DateTime dt)//datatime转时间戳
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 0, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }
        private void cancelClick(object sender, RoutedEventArgs e)//取消
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