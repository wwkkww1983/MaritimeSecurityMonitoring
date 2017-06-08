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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Windows.Interop;
using PhotoelectricModule;
using System.Threading;
using System.Windows.Controls.Primitives;

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;
using YimaWF.data;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MonitoringReturn.xaml 的交互逻辑
    /// </summary>
    public partial class MonitoringReturn : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public bool focusDownClickbool = false;
        public bool focusUpClickbool = false;
        public bool focusDownMoreClickbool = false;
        public bool focusUpMoreClickbool = false;
        public int directionValue = 0;
        public int pitchValue = 0;
        public bool hfocusDownClickbool = false;
        public bool hfocusUpClickbool = false;
        public bool hfocusDownMoreClickbool = false;
        public bool hfocusUpMoreClickbool = false;
        public int horizontalLeft = 0;
        public int horizontalRight = 0;
        public int pitchingUp = 0;
        public int pitchingDown = 0;

        public int driveSwitch = 1;
        public int infraredSwitch = 0;
        public int trackingAlgorithm = 0;
        public int trackImage = 0;
        public int leftLimitAngle = 45;
        public int rightLimitAngle = 45;
        public int sweepSpeed = 30;

        public int targetId = 0;//目标id
        public int radarId = 0;//雷达id
        public static Target nowTarget=null;//当前目标
        private string listViewState = "allListView";//当前选中列表标识位

        public static CircleProtectAreaManager circleData = new CircleProtectAreaManager();//圈层数据库实例
        public static PolygonAreaManager polygonDate = new PolygonAreaManager();//多边形数据库实例
        public static PipeLineProtectAreaManager pipeLine = new PipeLineProtectAreaManager();//管道数据库实例

        public static int linkageContral = 0;//联动状态（0是不联动，1是手动联动，2是自动联动）
        private SituPlayBack situ;

        public static MonitoringReturn Return;

        private ObservableCollection<Target> alarmList = new ObservableCollection<Target>();//报警list

        public MonitoringReturn()
        {
            InitializeComponent();

            App app = (App)App.Current;
            app.returnBack = yimaEncCtrl;

            MonitoringX.page = "回放";

            app.returnBack.TargetSelect += YimaEncCtrl_SelectTarget;//海图选中目标回调
            app.returnBack.ShowTargetDetail += YimaEncCtrl_ShowTargetDetail;//海图大标牌显示回调
            app.returnBack.GetAlarm += YimaEncCtrl_getAlarm;//海图报警回调

            allListView.ItemsSource = app.returnBack.AllTargetList;//所有目标列表数据绑定
            AISListView.ItemsSource = app.returnBack.AISTargetList;//AIS目标列表数据绑定
            mixListView.ItemsSource = app.returnBack.MergeTargetList;//融合目标列表数据绑定
            radarListView.ItemsSource = app.returnBack.RadarTargetList;//雷达目标列表数据绑定
            //warnListView.ItemsSource = app.returnBack.AlarmTargetList;//报警目标列表数据绑定
            warnListView.ItemsSource = alarmList;//报警目标列表数据绑定

            MonitoringReturn.Return=this;
            situ = new SituPlayBack(playBackdele, PlayFinish, GetTime(SituationPlayback.startTime.ToString()), GetTime(SituationPlayback.endTime.ToString()));//态势回放接口
            bool a=situ.StartPlayBack();//开始回放


            List<ProtectZone> list0 = circleData.GetAllCircleProtectArea(app.returnBack.GetGeoMultiFactor());//圈层数据初始化
            for (int i = 0; i < list0.Count; i++)
            {
                app.returnBack.AddProtectZone(list0[i]);//初始化圈层
            }

            List<ForbiddenZone> list1 = polygonDate.GetAllPolygonArea(app.returnBack.GetGeoMultiFactor());//多边形所有目标      
            for (int i = 0; i < list1.Count; i++)
            {
                app.returnBack.AddForbiddenZone(list1[i]);//初始化多边形
            }

            List<Pipeline> list2 = pipeLine.GetAllPipeLineProtectArea(app.returnBack.GetGeoMultiFactor());//管道所有目标
            for (int i = 0; i < list2.Count; i++)
            {
                app.returnBack.AddPipeline(list2[i]);//初始化管道
            }


            double lati, longitude;
            MonitoringX.platform.GetPlatform(out longitude, out lati);//查询平台中心
            app.returnBack.SetPlatform(longitude, lati);//初始化平台中心坐标
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            app.returnBack.CenterMap();//初始化视角中心坐标
        }

        private void YimaEncCtrl_getAlarm(int tip, Target t)//告警list回调
        {
            if (tip == 1)
            {
                Target t1 = new Target(t.ID, t.Course, t.Speed, t.Source);
                t1.AlarmTime = t.AlarmTime;
                t1.DataType = t.DataType;
                t1.MIMSI = t.MIMSI;
                t1.Alarm = t.Alarm;
                t1.Nationality = t.Nationality;
                t1.Type = t.Type;
                t1.Action = t.Action;
                t1.AlarmCheck = false;
                add(t1);
            }
            else if (tip == 2)
            {
                for (int i = 0; i < alarmList.Count; i++)
                    if (alarmList[i].ID == t.ID)
                        alarmList[i].AlarmCheck = true;
                Target t2 = new Target(t.ID, t.Course, t.Speed, t.Source);
                t2.AlarmTime = t.AlarmTime;
                t2.DataType = t.DataType;
                t2.MIMSI = t.MIMSI;
                t2.Alarm = t.Alarm;
                t2.Nationality = t.Nationality;
                t2.Type = t.Type;
                t2.Action = AlarmAction.Out;
                t2.AlarmCheck = false;
                add(t2);
            }
        }

        private void add(Target t)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                alarmList.Insert(0, t);
                if (alarmList.Count > 100)
                    alarmList.RemoveAt(100);
            }));
        }

        public void YimaEncCtrl_SelectTarget(Target t)//海图选中目标回调
        {
            nowTarget = t;
            for (int i = 0; i < alarmList.Count; i++)
            {
                if (nowTarget.ID == alarmList[i].ID)
                {
                    alarmList[i].IsSelected = nowTarget.IsSelected;
                    break;
                }
            }
        }

        public void hand()//鼠标小手
        {
            formshost.Cursor = System.Windows.Input.Cursors.Hand;
        }
        public void point()//鼠标指针
        {
            formshost.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        //大标牌
        public void YimaEncCtrl_ShowTargetDetail(Target target)
        {
            nowTarget = target;
            if (target.Source == TargetSource.AIS)
            {
                ShowAISTargetProperty w = new ShowAISTargetProperty();//AIS弹窗
                System.Windows.Application.Current.MainWindow = w;
                w.ShowDialog();
            }
            else if (target.Source == TargetSource.Radar)
            {
                ShowRadarTargetProperty w = new ShowRadarTargetProperty();//雷达弹窗
                System.Windows.Application.Current.MainWindow = w;
                w.ShowDialog();
            }
            else if (target.Source == TargetSource.Merge)
            {
                ShowMixTargetProperty w = new ShowMixTargetProperty();//融合弹窗
                System.Windows.Application.Current.MainWindow = w;
                w.ShowDialog();
            };
        }

        /*列表数据显示模块（start）******************************************************************************/
        private void allTargetClick(object sender, RoutedEventArgs e)//所有目标列表置顶
        {
            allbtn.IsEnabled = false;
            aisbtn.IsEnabled = true;
            radarbtn.IsEnabled = true;
            mixbtn.IsEnabled = true;
            allListView.Visibility = Visibility.Visible;
            AISListView.Visibility = Visibility.Collapsed;
            radarListView.Visibility = Visibility.Collapsed;
            mixListView.Visibility = Visibility.Collapsed;
            listViewState = "allListView";
        }
        private void AISTargetClick(object sender, RoutedEventArgs e)//AIS目标列表置顶
        {
            allbtn.IsEnabled = true;
            aisbtn.IsEnabled = false;
            radarbtn.IsEnabled = true;
            mixbtn.IsEnabled = true;
            allListView.Visibility = Visibility.Collapsed;
            AISListView.Visibility = Visibility.Visible;
            radarListView.Visibility = Visibility.Collapsed;
            mixListView.Visibility = Visibility.Collapsed;
            listViewState = "AISListView";
        }
        private void radarTargetClick(object sender, RoutedEventArgs e)//雷达目标列表置顶
        {
            allbtn.IsEnabled = true;
            aisbtn.IsEnabled = true;
            radarbtn.IsEnabled = false;
            mixbtn.IsEnabled = true;
            allListView.Visibility = Visibility.Collapsed;
            AISListView.Visibility = Visibility.Collapsed;
            radarListView.Visibility = Visibility.Visible;
            mixListView.Visibility = Visibility.Collapsed;
            listViewState = "radarListView";
        }
        private void mixTargetClick(object sender, RoutedEventArgs e)//融合目标列表置顶
        {
            allbtn.IsEnabled = true;
            aisbtn.IsEnabled = true;
            radarbtn.IsEnabled = true;
            mixbtn.IsEnabled = false;
            allListView.Visibility = Visibility.Collapsed;
            AISListView.Visibility = Visibility.Collapsed;
            radarListView.Visibility = Visibility.Collapsed;
            mixListView.Visibility = Visibility.Visible;
            listViewState = "mixListView";
        }
        public void playBackdele(int tip, object data)//航船目标AIS，雷达，融合数据接收回调函数
        {
            App app = (App)App.Current;
            Target mapTarget = (Target)data;//通信object强制转换为target
            this.Dispatcher.Invoke(new Action(() =>//必须在UI线程中进行后台操作，否则后台操作是无法实现并且报错的。
            {
                if (tip == 0)
                {
                    if (mapTarget.Source == TargetSource.AIS)
                    {//ais数据
                        app.returnBack.AddAISTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加AIS目标
                    }
                    else if (mapTarget.Source == TargetSource.Radar)
                    {//雷达数据
                        app.returnBack.AddRadarTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加雷达目标
                    }
                    else if (mapTarget.Source == TargetSource.Merge)
                    {//融合数据
                        app.returnBack.AddMergeTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加融合目标
                    };
                }
                else if (tip == 1)
                {
                    if (mapTarget.Source == TargetSource.AIS)
                    {//ais数据
                        app.returnBack.UpdateAISTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新AIS目标
                    }
                    else if (mapTarget.Source == TargetSource.Radar)
                    {//雷达数据
                        app.returnBack.UpdateRadarTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新雷达目标
                    }
                    else if (mapTarget.Source == TargetSource.Merge)
                    {//融合数据
                        app.returnBack.UpdateMergeTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新融合目标
                    };
                }
                else if (tip == 2)
                {
                    if (mapTarget.Source == TargetSource.AIS)
                    {//ais数据
                        app.returnBack.DeleteAISTarget(mapTarget.ID);//删除AIS目标
                    }
                    else if (mapTarget.Source == TargetSource.Radar)
                    {//雷达数据
                        app.returnBack.DeleteRadarTarget(mapTarget.ID, mapTarget.RadarID);//删除雷达目标
                    }
                    else if (mapTarget.Source == TargetSource.Merge)
                    {//融合数据
                        app.returnBack.DeleteMergeTarget(mapTarget.ID);//删除融合目标
                    };
                }
            }));
        }
        private void PlayFinish() {
            this.Dispatcher.Invoke(new Action(() =>//必须在UI线程中进行后台操作，否则后台操作是无法实现并且报错的。
            {
                if(monitoringIn.pageState)
                MessageBoxX.Show("提示", "回放结束!");
            }));
        }
        private void isConfirmed_Click(object sender, RoutedEventArgs e)//报警确认按钮
        {
            App app = (App)App.Current;
            System.Windows.Controls.Button b = sender as System.Windows.Controls.Button;
            int id = Convert.ToInt32(b.CommandParameter);
            for (int i = warnListView.Items.Count - 1; i >= 0; i--)
            {
                if (alarmList[i].ID == id)
                    alarmList[i].AlarmCheck = true;
            }
            warnListView.Items.Refresh();
        }
        private void ListView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//列表联动事件(所有)
        {
            App app = (App)App.Current;

            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;
            lv.ScrollIntoView(lv.SelectedItem);

            if (lv.Name == listViewState && listViewState == "allListView")
            {
                //"allListView"
                if (allListView.SelectedIndex < 0)
                {
                    return;
                }

                Target targetAll = app.returnBack.AllTargetList[allListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetAll;
                app.returnBack.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
            }
            else if (lv.Name == listViewState && listViewState == "AISListView")
            {
                if (AISListView.SelectedIndex < 0)
                {
                    return;
                }

                Target targetAis = app.returnBack.AISTargetList[AISListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetAis;
                app.returnBack.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
            }
            else if (lv.Name == listViewState && listViewState == "radarListView")
            {
                if (radarListView.SelectedIndex < 0)
                {
                    return;
                }
                Target targetRadar = app.returnBack.RadarTargetList[radarListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetRadar;
                app.returnBack.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
            }
            else if (lv.Name == listViewState && listViewState == "mixListView")
            {

                if (mixListView.SelectedIndex < 0)
                {
                    return;
                }
                Target targetMix = app.returnBack.MergeTargetList[mixListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetMix;
                app.returnBack.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
            }
        }
        private void ListView2_SelectionChanged(object sender, SelectionChangedEventArgs e)//列表联动事件(所有)
        {
            if (warnListView.SelectedIndex >= 0)
            {
                int index = 0;
                for (int i = 0; i < warnListView.Items.Count; i++)
                {
                    if (warnListView.SelectedItems[warnListView.SelectedItems.Count - 1] == warnListView.Items[i])
                        index = i;
                }
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (alarmList[index].ID == alarmList[i].ID)
                        alarmList[i].IsSelected = true;
                    else
                        alarmList[i].IsSelected = false;
                }
                App app = (App)App.Current;
                for (int i = 0; i < app.returnBack.AlarmTargetList.Count; i++)
                    if (app.returnBack.AlarmTargetList[i].ID == alarmList[warnListView.SelectedIndex].ID)
                    {
                        app.returnBack.SetSelectedTarget(app.returnBack.AlarmTargetList[i]);
                        nowTarget = app.returnBack.AlarmTargetList[i];
                        break;
                    }
                warnListView.ScrollIntoView(warnListView.SelectedItem);
            }
        }

        private void TargetConvertClick(object sender, System.Windows.Input.MouseButtonEventArgs e)//列表双击事件
        {
            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;
            if (lv.SelectedIndex < 0) return;
            App app = (App)App.Current;
            Target t;
            switch (lv.Name)
            {
                case "allListView":
                    t = app.returnBack.AllTargetList[lv.SelectedIndex];
                    app.returnBack.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "AISListView":
                    t = app.returnBack.AISTargetList[lv.SelectedIndex];
                    app.returnBack.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "radarListView":
                    t = app.returnBack.RadarTargetList[lv.SelectedIndex];
                    app.returnBack.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "mixListView":
                    t = app.returnBack.MergeTargetList[lv.SelectedIndex];
                    app.returnBack.CenterMap(t.Longitude, t.Latitude);
                    break;
            }
        }

        private void TargetConvertClick_2(object sender, System.Windows.Input.MouseButtonEventArgs e)//告警列表双击事件
        {
            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;
            if (lv.SelectedIndex < 0) return;
            App app = (App)App.Current;
            for (int i = 0; i < app.returnBack.AlarmTargetList.Count; i++)
                if (app.returnBack.AlarmTargetList[i].ID == alarmList[lv.SelectedIndex].ID)
                {
                    app.returnBack.CenterMap(app.returnBack.AlarmTargetList[i].Longitude, app.returnBack.AlarmTargetList[i].Latitude);
                    break;
                }
        }

        private void SortClick(object sender, RoutedEventArgs e)//列表排序
        {
            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;
            App app = (App)App.Current;
            if (e.OriginalSource is GridViewColumnHeader)
            {
                GridViewColumn clickedColumn = (e.OriginalSource as GridViewColumnHeader).Column;
                if (clickedColumn != null)
                {
                    if (lv.Name == "allListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.returnBack.AllTargetList.Count; i++)
                            tempList.Add(app.returnBack.AllTargetList[i]);
                        tempList.Sort(delegate (Target x, Target y)
                        {
                            switch (clickedColumn.Header.ToString())
                            {
                                case "融合批号":
                                    try { return x.ID.CompareTo(y.ID); }
                                    catch (Exception ex) { return 0; }
                                case "雷达1批号":
                                    try { return x.RadarBatchNum.CompareTo(y.RadarBatchNum); }
                                    catch (Exception ex) { return 0; }
                                case "雷达2批号":
                                    try { return x.RadarBatchNum2.CompareTo(y.RadarBatchNum2); }
                                    catch (Exception ex) { return 0; }
                                case "MMSI":
                                    try { return x.MIMSI.CompareTo(y.MIMSI); }
                                    catch (Exception ex) { return 0; }
                                case "发现时间":
                                    try { return x.UpdateTime.CompareTo(y.UpdateTime); }
                                    catch (Exception ex) { return 0; }
                                default:
                                    break;
                            }
                            return 0;
                        });
                        app.returnBack.AllTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.returnBack.AllTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "AISListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.returnBack.AISTargetList.Count; i++)
                            tempList.Add(app.returnBack.AISTargetList[i]);
                        tempList.Sort(delegate (Target x, Target y)
                        {
                            switch (clickedColumn.Header.ToString())
                            {
                                case "MMSI":
                                    try { return x.MIMSI.CompareTo(y.MIMSI); }
                                    catch (Exception ex) { return 0; }
                                case "发现时间":
                                    try { return x.UpdateTime.CompareTo(y.UpdateTime); }
                                    catch (Exception ex) { return 0; }
                                default:
                                    break;
                            }
                            return 0;
                        });
                        app.returnBack.AISTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.returnBack.AISTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "radarListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.returnBack.RadarTargetList.Count; i++)
                            tempList.Add(app.returnBack.RadarTargetList[i]);
                        tempList.Sort(delegate (Target x, Target y)
                        {
                            switch (clickedColumn.Header.ToString())
                            {
                                case "雷达1批号":
                                    try { return x.RadarBatchNum.CompareTo(y.RadarBatchNum); }
                                    catch (Exception ex) { return 0; }
                                case "雷达2批号":
                                    try { return x.RadarBatchNum2.CompareTo(y.RadarBatchNum2); }
                                    catch (Exception ex) { return 0; }
                                case "发现时间":
                                    try { return x.UpdateTime.CompareTo(y.UpdateTime); }
                                    catch (Exception ex) { return 0; }
                                default:
                                    break;
                            }
                            return 0;
                        });
                        app.returnBack.RadarTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.returnBack.RadarTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "mixListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.returnBack.MergeTargetList.Count; i++)
                            tempList.Add(app.returnBack.MergeTargetList[i]);
                        tempList.Sort(delegate (Target x, Target y)
                        {
                            switch (clickedColumn.Header.ToString())
                            {
                                case "融合批号":
                                    try { return x.ID.CompareTo(y.ID); }
                                    catch (Exception ex) { return 0; }
                                case "雷达1批号":
                                    try { return x.RadarBatchNum.CompareTo(y.RadarBatchNum); }
                                    catch (Exception ex) { return 0; }
                                case "雷达2批号":
                                    try { return x.RadarBatchNum2.CompareTo(y.RadarBatchNum2); }
                                    catch (Exception ex) { return 0; }
                                case "MMSI":
                                    try { return x.MIMSI.CompareTo(y.MIMSI); }
                                    catch (Exception ex) { return 0; }
                                case "发现时间":
                                    try { return x.UpdateTime.CompareTo(y.UpdateTime); }
                                    catch (Exception ex) { return 0; }
                                default:
                                    break;
                            }
                            return 0;
                        });
                        app.returnBack.MergeTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.returnBack.MergeTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "warnListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < alarmList.Count; i++)
                            tempList.Add(alarmList[i]);
                        tempList.Sort(delegate (Target x, Target y)
                        {
                            switch (clickedColumn.Header.ToString())
                            {
                                case "告警时间":
                                    try { return x.AlarmTime.CompareTo(y.AlarmTime); }
                                    catch (Exception ex) { return 0; }
                                case "MMSI":
                                    try { return x.MIMSI.CompareTo(y.MIMSI); }
                                    catch (Exception ex) { return 0; }
                                default:
                                    break;
                            }
                            return 0;
                        });
                        alarmList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            alarmList.Add(tempList[i]);
                    }
                }
            }
        }

        public static DateTime GetTime(string timeStamp)//时间戳转datatime
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}
