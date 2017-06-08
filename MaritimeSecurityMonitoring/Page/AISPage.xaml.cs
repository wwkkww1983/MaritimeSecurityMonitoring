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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// AISPage.xaml 的交互逻辑
    /// </summary>
    public partial class AISPage : Page
    {
		private bool Freshing = false;
        //Freshing : true当时有线程正在刷新
        public AISPage()
        {
            InitializeComponent();
			//while (!Fresh())
   //         //刷新不成功,等待100毫秒,重新刷新,直到重新刷新一次
  	//		{
   //             Thread.Sleep(100);
   //         }
        }
		public bool Fresh()
        {
            if (Freshing == true)
            //有另外一个进程在刷新,则不刷新
            {
                return false;
            }
            else
            {
                Freshing = true;
                if (MonitoringX.Machine == 0)
                {
                    AISStr.Text = "正常";
                }
                else if (MonitoringX.Machine == 1)
                {
                    AISStr.Text = "故障";
                }
                else if (MonitoringX.Machine == 2)
                {
                    AISStr.Text = " --";
                }

                if (MonitoringX.channe == 0)
                {
                    channeStr.Text = "正常";
                }
                else if (MonitoringX.channe == 1)
                {
                    channeStr.Text = "故障";
                }
                else if (MonitoringX.channe == 2)
                {
                    channeStr.Text = " --";
                }

                if (MonitoringX.genaral == 0)
                {
                    genaralStr.Text = "正常";
                }
                else if (MonitoringX.genaral == 1)
                {
                    genaralStr.Text = "故障";
                }
                else if (MonitoringX.genaral == 2)
                {
                    genaralStr.Text = " --";
                }

                if (MonitoringX.clock == 0)
                {
                    clockStr.Text = "正常";
                }
                else if (MonitoringX.clock == 1)
                {
                    clockStr.Text = "故障";
                }
                else if (MonitoringX.clock == 2)
                {
                    clockStr.Text = " --";
                }

                if (MonitoringX.MKD == 0)
                {
                    MKDStr.Text = "正常";
                }
                else if (MonitoringX.MKD == 1)
                {
                    MKDStr.Text = "故障";
                }
                else if (MonitoringX.MKD == 2)
                {
                    MKDStr.Text = " --";
                }

                if (MonitoringX.EPFS == 0)
                {
                    EPFSStr.Text = "正常";
                }
                else if (MonitoringX.EPFS == 1)
                {
                    EPFSStr.Text = "故障";
                }
                else if (MonitoringX.EPFS == 2)
                {
                    EPFSStr.Text = " --";
                }

                if (MonitoringX.sensor == 0)
                {
                    sensorStr.Text = "正常";
                }
                else if (MonitoringX.sensor == 1)
                {
                    sensorStr.Text = "故障";
                }
                else if (MonitoringX.sensor == 2)
                {
                    sensorStr.Text = " --";
                }

                if (MonitoringX.information == 0)
                {
                    informationStr.Text = "正常";
                }
                else if (MonitoringX.information == 1)
                {
                    informationStr.Text = "故障";
                }
                else if (MonitoringX.information == 2)
                {
                    informationStr.Text = " --";
                }
                Freshing = false;
                return true;
           }
		}
    }
}