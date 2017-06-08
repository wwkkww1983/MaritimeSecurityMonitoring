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
    /// PolygonDialog.xaml 的交互逻辑
    /// </summary>
    
    public partial class PolygonDialog : Window
    {
        public static String polygonNameText;
        public static String aLarmRankText="4";
        public static String logText;
        
        public PolygonDialog()
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
            App app = (App)App.Current;
            int count = 0;
            for (int i = 0; i < app.chartCtrl.ForbiddenZoneList.Count; i++)
            {
                if (polygonName.Text == app.chartCtrl.ForbiddenZoneList[i].Name)
                {
                    count = 1;
                }
            }

            for (int j = 0; j < app.chartCtrl.PipelineList.Count; j++)
            {
                if (polygonName.Text == app.chartCtrl.PipelineList[j].Name)
                {
                    count = 1;
                }
            }

            if (count == 0)
            {
                polygonNameText = polygonName.Text;
                logText = polygonLog.Text;
                this.Close();
            }
            else if(count==1)
            {
                MessageBoxX.Show("提示", "名称已存在,请修改命名！");
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.comfirmClick(sender, e);
        }
    }
}


