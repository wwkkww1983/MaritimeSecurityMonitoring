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
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.Text.RegularExpressions;

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// NetParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class NetParameterSetting : Page
    {
        public static ObservableCollection<NetDevice> deviceList = new ObservableCollection<NetDevice>();
        //private int addID;

        private DeviceInfoManager device=new DeviceInfoManager();//网络参数数据库实例

        public NetParameterSetting()
        {
            InitializeComponent();
            deviceList.Clear();
            List<DeviceInfo> list=device.GetAllDeviceInfo();//网络参数设置
            for (int i = 0; i < list.Count; i++)
            {
                NetDevice nd = new NetDevice
                {
                    ID = i,
                    IP = list[i].IP,
                    Name = list[i].Name,
                    Port1 = list[i].Port1.ToString(),
                    Port2 = list[i].Port2.ToString(),
                    Port3 = list[i].Port3.ToString(),
                    Port4 = list[i].Port4.ToString(),
                    ReadOnly = true,
                };
                deviceList.Add(nd);
            }
            DeviceListView.DataContext = deviceList;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)//编辑修改
        {
            ToggleButton b = sender as ToggleButton;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = DeviceListView.Items.Count - 1; i >= 0; i--)
            {
                if (deviceList[i].ID == id)
                {
                    if (!deviceList[i].ReadOnly)
                    {
                        ListViewItem lvi = this.DeviceListView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                        TextBox tb = FindVisualChild<TextBox>(lvi);
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;

                    }
                    else
                    {
                        if(String.IsNullOrWhiteSpace(deviceList[i].IP) || String.IsNullOrWhiteSpace(deviceList[i].Name))
                        {
                            MessageBoxX.Show("提示", "IP与设备名不能为空！");
                            deviceList[i].ReadOnly = !deviceList[i].ReadOnly;
                        }
                        else
                        {
                            Regex re = new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
                            if (!re.IsMatch(deviceList[i].IP))
                            {
                                MessageBoxX.Show("警告", "设备IP非法");
                                deviceList[i].ReadOnly = !deviceList[i].ReadOnly;
                            }
                            else
                            {
                                try
                                {
                                    DeviceInfo dev = new DeviceInfo();//实例化一个参数结构体
                                    dev.IP = deviceList[i].IP;
                                    dev.Name = deviceList[i].Name;
                                    if (String.IsNullOrWhiteSpace(deviceList[i].Port1))
                                        deviceList[i].Port1 = "0";
                                    dev.Port1 = int.Parse(deviceList[i].Port1);
                                    if (String.IsNullOrWhiteSpace(deviceList[i].Port2))
                                        deviceList[i].Port2 = "0";
                                    dev.Port2 = int.Parse(deviceList[i].Port2);
                                    if (String.IsNullOrWhiteSpace(deviceList[i].Port3))
                                        deviceList[i].Port3 = "0";
                                    dev.Port3 = int.Parse(deviceList[i].Port3);
                                    if (String.IsNullOrWhiteSpace(deviceList[i].Port4))
                                        deviceList[i].Port4 = "0";
                                    dev.Port4 = int.Parse(deviceList[i].Port4);

                                    if ((dev.Port1==0 || (dev.Port1 > 1024 && dev.Port1 <= 65536))
                                        && (dev.Port2==0 || (dev.Port2 > 1024 && dev.Port2 <= 65536))
                                        && (dev.Port3==0 || (dev.Port3 > 1024 && dev.Port3 <= 65536))
                                        && (dev.Port4==0 || (dev.Port4 > 1024 && dev.Port4 <= 65536)))
                                        device.UpdateDeviceInfo(dev);//更新网络参数
                                    else
                                    {
                                        MessageBoxX.Show("提示", "端口号超出范围！");
                                        deviceList[i].ReadOnly = !deviceList[i].ReadOnly;
                                    }
                                }
                                catch(Exception ex)
                                {
                                    MessageBoxX.Show("警告", "端口号应为整数！");
                                    deviceList[i].ReadOnly = !deviceList[i].ReadOnly;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//删除本行
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.CommandParameter);
            ConfirmBox cb = new ConfirmBox()
            {
                pageName = "NetParameterSetting",
                id = id,
                Title = "提示",
                Message = "确定删除这条数据吗？"
            };
            cb.ShowDialog();
        }

        private void AddTargetClick(object sender, RoutedEventArgs e)//添加串口
        {
            Net_Add na = new Net_Add();
            na.ShowDialog();
        }

        /*private void ConfirmClick(object sender, RoutedEventArgs e)//确定添加串口
        {
            //网络参数入库
            device.AddDeviceInfo(deviceList[addID].Name, deviceList[addID].IP, (int)double.Parse(deviceList[addID].Port1), (int)double.Parse(deviceList[addID].Port2), (int)double.Parse(deviceList[addID].Port3), (int)double.Parse(deviceList[addID].Port4));//
            for (int i = DeviceListView.Items.Count - 1; i >= 0; i--)
            {
                deviceList[i].IsConfirm = true;
                deviceList[i].ReadOnly = true;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)//取消删除添加串口
        {
            for (int i = DeviceListView.Items.Count - 1; i >= 0; i--)
            {
                if (deviceList[i].IsConfirm == false)
                {
                    deviceList.RemoveAt(i);
                    break;
                }
            }
        }*/

        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if (childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Focus();
        }
    }
}
