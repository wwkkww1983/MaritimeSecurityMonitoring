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

using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// FullNetStatus.xaml 的交互逻辑
    /// </summary>
    public partial class FullNetStatus : Page
    {
        private bool Freshing = false;
        //Freshing : true当时有线程正在刷新
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
                if (MonitoringX.SlpingstateValue == 1)
                {
                    angleNetwork.IsBroken = true;//卫星罗盘状态
                }
                else if (MonitoringX.SlpingstateValue == 0)
                {
                    angleNetwork.IsBroken = false;//卫星罗盘状态
                }

                if (MonitoringX.AISpingstateValue == 1)
                {
                    AISNetwork.IsBroken = true;//AIS网络状态
                }
                else if (MonitoringX.AISpingstateValue == 0)
                {
                    AISNetwork.IsBroken = false;//AIS网络状态
                }

                if (MonitoringX.RaderpingstateValue == 1)
                {
                    radar1.IsBroken = true;//雷达1状态
                    radar2.IsBroken = true;//雷达2状态
                }
                else if (MonitoringX.RaderpingstateValue == 0)
                {
                    radar1.IsBroken = false;//雷达1状态
                    radar2.IsBroken = false;//雷达2状态
                }

                if (MonitoringX.lightpingstateValue == 1)
                {
                    photoNetwork.IsBroken = true;//光电设备状态
                }
                else if (MonitoringX.lightpingstateValue == 0)
                {
                    photoNetwork.IsBroken = false;//光电设备状态
                }

                if (MonitoringX.lightpingstateValue == 1)
                {
                    photoNetwork.IsBroken = true;//光电设备状态
                }
                else if (MonitoringX.lightpingstateValue == 0)
                {
                    photoNetwork.IsBroken = false;//光电设备状态
                }

                if (MonitoringX.DBPingValue == 1)
                {
                    dbNetwork.IsBroken = true;//数据服务器状态
                }
                else if (MonitoringX.DBPingValue == 0)
                {
                    dbNetwork.IsBroken = false;//数据服务器状态
                }

                if (MonitoringX.clientApingValue == 1)
                {
                    clientNetwork1.IsBroken = true;//显控1状态
                }
                else if (MonitoringX.clientApingValue == 0)
                {
                    clientNetwork1.IsBroken = false;//显控1状态
                }

                if (MonitoringX.clientBpingValue == 1)
                {
                    clientNetwork2.IsBroken = true;//显控1状态
                }
                else if (MonitoringX.clientBpingValue == 0)
                {
                    clientNetwork2.IsBroken = false;//显控1状态
                }
                if (MonitoringX.FusionPingValue == 1)
                {
                    fuseNetwork.IsBroken = true;
                }
                else if (MonitoringX.FusionPingValue == 0)
                {
                    fuseNetwork.IsBroken = false;//融合服务器状态
                }
               

                Freshing = false;
                return true;
            }
        }
		public FullNetStatus()
        {  
         	InitializeComponent();
            while (!Fresh())
            {
                Fresh();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
