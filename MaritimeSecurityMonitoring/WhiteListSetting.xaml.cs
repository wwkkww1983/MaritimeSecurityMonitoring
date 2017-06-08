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

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{ 
    /// <summary>
    /// WhiteListSetting.xaml 的交互逻辑
    /// </summary>
    public partial class WhiteListSetting : Page
    {
        public static ObservableCollection<WhiteTarget> whiteList = new ObservableCollection<WhiteTarget>();
        //private int addId;

        private WhiteShipListManage white = new WhiteShipListManage();//白名单数据库实例
        public WhiteListSetting()
        {
            InitializeComponent();
            whiteList.Clear();
            
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
                whiteList.Add(wt);
            }
            WhiteListView.DataContext = whiteList;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton b = sender as ToggleButton;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = WhiteListView.Items.Count - 1; i >= 0; i--)
            {
                if (whiteList[i].ID == id)
                {
                    if (!whiteList[i].ReadOnly)
                    {
                        ListViewItem lvi = this.WhiteListView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                        TextBox tb = FindVisualChild<TextBox>(lvi);
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(whiteList[i].Number))
                        {
                            MessageBoxX.Show("提示", "船舷号不能为空！");
                            whiteList[i].ReadOnly = !whiteList[i].ReadOnly;
                        }
                        else
                        {
                            try
                            {
                                WhiteShip ship = new WhiteShip();
                                ship.CallID = whiteList[i].CallSign;
                                if (!String.IsNullOrWhiteSpace(whiteList[i].IMO))
                                    ship.IMO = uint.Parse(whiteList[i].IMO);
                                ship.MMSI = int.Parse(whiteList[i].MMSI);
                                ship.ShipDepartment = whiteList[i].Department;
                                ship.ShipName = whiteList[i].Name;
                                ship.ShipUsage = whiteList[i].Usage;
                                ship.ShipNumber = whiteList[i].Number;
                                white.UpdateWhiteShip(ship);
                                dataAna.WhiteListSync();
                            }
                            catch(Exception ex)
                            {
                                MessageBoxX.Show("警告", "存在非法的数据！");
                                whiteList[i].ReadOnly = !whiteList[i].ReadOnly;
                            }
                        }
                    }
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        { 
            Button b = sender as Button;
            int id = Convert.ToInt32(b.CommandParameter);
            ConfirmBox cb = new ConfirmBox()
            {
                pageName = "WhiteListSetting",
                id = id,
                Title = "提示",
                Message = "确定删除这条数据吗？"
            };
            cb.ShowDialog();
        }
        private void AddTargetClick(object sender, RoutedEventArgs e)//添加一行
        {
            White_Add wa = new White_Add();
            wa.ShowDialog();
        }

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

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Focus();
        }
    }
}
