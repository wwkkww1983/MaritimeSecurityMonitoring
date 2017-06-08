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

using MaritimeSecurityMonitoring;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// White_Add.xaml 的交互逻辑
    /// </summary>
    public partial class White_Add : Window
    {
        private WhiteShipListManage white = new WhiteShipListManage();//白名单数据库实例
        public White_Add()
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
            if (String.IsNullOrWhiteSpace(mmsi.Text) || String.IsNullOrWhiteSpace(number.Text))
            {
                MessageBoxX.Show("提示", "MMSI、船舷号不能为空！");
            }
            else
            {
                WhiteListSetting.whiteList.Clear();

                List<WhiteShip> whiteListStr = new List<WhiteShip>();
                whiteListStr = white.GetAllWhiteShip();//初始化白名单列表

                for (int i = 0; i < whiteListStr.Count(); i++)
                {
                    WhiteTarget wt = new WhiteTarget
                    {
                        ID = i,
                        MMSI = whiteListStr[i].MMSI.ToString(),
                        Number = whiteListStr[i].ShipNumber,
                        IMO = whiteListStr[i].IMO.ToString(),
                        CallSign = whiteListStr[i].CallID,
                        Name = whiteListStr[i].ShipName,
                        Department = whiteListStr[i].ShipDepartment,
                        Usage = whiteListStr[i].ShipUsage,
                        ReadOnly = true,
                    };
                    WhiteListSetting.whiteList.Add(wt);
                }

                int count;
                for(count=0;count< WhiteListSetting.whiteList.Count; count++)
                {
                    if (WhiteListSetting.whiteList[count].MMSI == mmsi.Text)
                    {
                        MessageBoxX.Show("提示", "已存在具有相同MMSI的船只！");
                        break;
                    }
                }

                if(count== WhiteListSetting.whiteList.Count)
                {
                    try
                    {
                        WhiteShip ship = new WhiteShip();
                        ship.CallID = callSign.Text;
                        if (!String.IsNullOrWhiteSpace(imo.Text))
                            ship.IMO = uint.Parse(imo.Text);
                        ship.MMSI = int.Parse(mmsi.Text); ;
                        ship.ShipDepartment = department.Text;
                        ship.ShipName = name.Text;
                        ship.ShipUsage = usage.Text;
                        ship.ShipNumber = number.Text;
                        white.AddWhiteShip(ship);//添加白名单入库

                        dataAna.WhiteListSync();//白名单同步

                        MainWindow.opeation.OptionName = "添加白名单";//日志入库
                        MainWindow.opeation.LogType = 2;
                        MainWindow.opeation.OptionTime = WhiteListSetting.GetTime(WhiteListSetting.GetTimeStampS().ToString());
                        MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                        whiteListStr = white.GetAllWhiteShip();
                        WhiteTarget wt = new WhiteTarget
                        {
                            ID = WhiteListSetting.whiteList.Count,
                            MMSI = whiteListStr[whiteListStr.Count - 1].MMSI.ToString(),
                            Number = whiteListStr[whiteListStr.Count - 1].ShipNumber,
                            IMO = whiteListStr[whiteListStr.Count - 1].IMO.ToString(),
                            CallSign = whiteListStr[whiteListStr.Count - 1].CallID,
                            Name = whiteListStr[whiteListStr.Count - 1].ShipName,
                            Department = whiteListStr[whiteListStr.Count - 1].ShipDepartment,
                            Usage = whiteListStr[whiteListStr.Count - 1].ShipUsage,
                            ReadOnly = true,
                        };
                        WhiteListSetting.whiteList.Add(wt);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBoxX.Show("警告", "MMSI、IMO应为整数！");
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
