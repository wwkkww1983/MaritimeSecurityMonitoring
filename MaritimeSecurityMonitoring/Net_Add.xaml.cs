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
using System.Text.RegularExpressions;

using MaritimeSecurityMonitoring;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// Net_Add.xaml 的交互逻辑
    /// </summary>
    public partial class Net_Add : Window
    {
        private DeviceInfoManager device = new DeviceInfoManager();//网络参数数据库实例
        public Net_Add()
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
            if(String.IsNullOrWhiteSpace(ip.Text) || String.IsNullOrWhiteSpace(name.Text) )
            {
                MessageBoxX.Show("提示", "IP与设备名不能为空！");
            }
            else
            {
                Regex re = new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
                if (!re.IsMatch(ip.Text))
                    MessageBoxX.Show("警告", "设备IP非法");
                else
                {
                    try
                    {
                        if ((string.IsNullOrWhiteSpace(port1.Text)||( int.Parse(port1.Text) > 1024 && int.Parse(port1.Text) <= 65536)) 
                            &&(string.IsNullOrWhiteSpace(port2.Text)|| (int.Parse(port2.Text) > 1024 && int.Parse(port2.Text) <= 65536)) 
                            && (string.IsNullOrWhiteSpace(port3.Text)||( int.Parse(port3.Text) > 1024 && int.Parse(port3.Text) <= 65536 ))
                            &&(string.IsNullOrWhiteSpace(port4.Text)|| (int.Parse(port4.Text) > 1024 && int.Parse(port4.Text) <= 65536)))
                        {
                            int[] port = new int[4];
                            if (string.IsNullOrWhiteSpace(port1.Text))
                            {
                                port[0] = 0;
                            }
                            else
                            {
                                port[0] = int.Parse(port1.Text);
                            }

                            if (string.IsNullOrWhiteSpace(port2.Text))
                            {
                                port[1] = 0;
                            }
                            else
                            {
                                port[1] = int.Parse(port2.Text);
                            }

                            if (string.IsNullOrWhiteSpace(port3.Text))
                            {
                                port[2] = 0;
                            }
                            else
                            {
                                port[2] = int.Parse(port3.Text);
                            }
                            if (string.IsNullOrWhiteSpace(port4.Text))
                            {
                                port[3] = 0;
                            }
                            else
                            {
                                port[3] = int.Parse(port4.Text);
                            }
                            device.AddDeviceInfo(name.Text, ip.Text, port[0],port[1],port[2],port[3]);

                            List<DeviceInfo> list = device.GetAllDeviceInfo();//网络参数设置
                            NetDevice nd = new NetDevice()
                            {
                                ID = NetParameterSetting.deviceList.Count,
                                IP = list[list.Count - 1].IP,
                                Name = list[list.Count - 1].Name,
                                Port1 = list[list.Count - 1].Port1.ToString(),
                                Port2 = list[list.Count - 1].Port2.ToString(),
                                Port3 = list[list.Count - 1].Port3.ToString(),
                                Port4 = list[list.Count - 1].Port4.ToString(),
                                ReadOnly = true,
                            };
                            NetParameterSetting.deviceList.Add(nd);
                            this.Close();
                        }
                        else
                            MessageBoxX.Show("提示", "端口号超出范围！");
                    }
                    catch(Exception ex)
                    {
                        MessageBoxX.Show("警告", "端口号应为整数！");
                    }
                }
            }
        }

        private void cancelClick(object sender, RoutedEventArgs e)
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
