using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using MaritimeSecurityMonitoring.MainInterfacePage;
using YimaEncCtrl;
using MaritimeSecurityMonitoring.Video;

using YimaWF.data;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// monitoringIn.xaml 的交互逻辑
    /// </summary>
    public partial class monitoringIn : Window
    {
        private bool isInShowingTrackMode = false;
        private bool isInShowingTrack = true;
        private bool isHandRoam = false;

        private bool areaZoom = true;//区域放大状态位
        private bool measureDistance = true;//测距状态位
        public static bool pageState = true;

        //蒋 04 16 添加

        public static FullNetStatus fullNetStatus;
        public static ContentControl CurrentContent;//保存当前的页面

        public static monitoringIn Inmon;
        public monitoringIn()
        {
            InitializeComponent();
            this.Closing += closeSoftware;
            monitoringIn.Inmon = this;


        }
        private void closeSoftware(object o, System.ComponentModel.CancelEventArgs e)//关闭主界面时界面完全关闭
        {
            pageState = false;
        }
        //***********************************************************************************
        //*******************************主菜单事件******************************************
        //***********************************************************************************
        private void AISSituationClick(object sender, RoutedEventArgs e)//态势显示->AIS态势
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;//收起菜单

            bool state = app.returnBack.showAISTarget;
            if (state)
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.AIS, false);
            }
            else
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.AIS, true);
            }
        }

        private void radarSituationClick(object sender, RoutedEventArgs e)//态势显示->雷达态势
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;//收起菜单
            bool state = app.returnBack.showRadarTarget;
            if (state)
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.READER, false);
            }
            else
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.READER, true);
            }
        }
        private void mixSituationClick(object sender, RoutedEventArgs e)//态势显示->融合态势
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;//收起菜单
            bool state = app.returnBack.showMergeTarget;
            if (state)
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.MERGER, false);
            }
            else
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.MERGER, true);
            }
        }

        private void radarScanningLineClick(object sender, RoutedEventArgs e)//态势显示->雷达扫描线
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;//收起菜单
            bool state = app.returnBack.showRadar;
            if (state)
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.RADARLINE, false);
            }
            else
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.RADARLINE, true);
            }
        }

        private void optoelectronicRangeClick(object sender, RoutedEventArgs e)//态势显示->光电扫描范围
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;//收起菜单
            bool state = app.returnBack.showOpt;
            if (state)
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.OPTLINE, false);
            }
            else
            {
                app.returnBack.SetDisplayMode(TARGET_TYPE.OPTLINE, true);
            }
        }

        private void ShowSignageClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->标牌显示
        {

        }

        private void ShowTrackLineClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->目标航迹线显示
        {

        }

        private void ShowTrackHeaderClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->目标航首线显示
        {

        }

        private void ShowTargetPropertyClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->目标属性显示
        {
            ShowTargetProperty stp = new ShowTargetProperty();
            Application.Current.MainWindow = stp;
            stp.ShowDialog();
        }

        private void ShowAISTargetPropertyClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->AIS目标属性显示
        {
            ShowAISTargetProperty satp = new ShowAISTargetProperty();
            Application.Current.MainWindow = satp;
            satp.ShowDialog();
        }

        private void ShowRadarTargetPropertyClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->雷达目标属性显示
        {
            ShowRadarTargetProperty srtp = new ShowRadarTargetProperty();
            Application.Current.MainWindow = srtp;
            srtp.ShowDialog();
        }

        private void ShowMixTargetPropertyClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->融合目标属性显示
        {
            ShowMixTargetProperty smtp = new ShowMixTargetProperty();
            Application.Current.MainWindow = smtp;
            smtp.ShowDialog();
        }

        private void targetDisplayMethodsClick(object sender, RoutedEventArgs e)//态势显示->目标显示方式设置   //已移除？
        {
            TargetDisplayMethods w = new TargetDisplayMethods();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void PlatformCenterSettingClick(object sender, RoutedEventArgs e)//报警管理->平台中心设置
        {
            PlatformPositionSetting w = new PlatformPositionSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void defenseSpheresSettingClick(object sender, RoutedEventArgs e)//报警管理->防护圈层设置
        {
            DefenseCircleSetting w = new DefenseCircleSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void areaLabelClick(object sender, RoutedEventArgs e)//报警管理->多边形防护区设置
        {
            PolygonDialog pgd = new PolygonDialog();
            Application.Current.MainWindow = pgd;
            pgd.ShowDialog();
            //Monitoring.AddedForbiddenZoneBack();
        }

        private void pipelineClick(object sender, RoutedEventArgs e)//报警管理->管道防护区设置
        {
            PipelineDialog pld = new PipelineDialog();
            Application.Current.MainWindow = pld;
            pld.ShowDialog();
            //Monitoring.AddedPipelineBack();
        }

        private void warnAreaSettingClick(object sender, RoutedEventArgs e)//报警管理->防护区管理
        {
            WarnAreaSetting was = new WarnAreaSetting();
            Application.Current.MainWindow = was;
            was.ShowDialog();
        }

        private void whiteListSettingClick(object sender, RoutedEventArgs e)//报警管理->船舶白名单管理
        {
            popup2.IsOpen = false;
            WhiteListSetting p = new WhiteListSetting();
            content.Content = p;
			CurrentContent = content;
        }

        private void listWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->列表报警
        {
            popup2.IsOpen = false;

        }

        private void imageWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->图像报警
        {
            popup2.IsOpen = false;

        }

        private void voiceWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->声音报警
        {
            popup2.IsOpen = false;

        }

        private void captureImagesClick(object sender, RoutedEventArgs e)//视频管理->图片抓取
        {
            CaptureImages w = new CaptureImages();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void trackVideoClick(object sender, RoutedEventArgs e)//视频管理->视频跟踪
        {
            popup3.IsOpen = false;

        }

        private void trackVideoPlaybackClick(object sender, RoutedEventArgs e)//视频管理->跟踪视频回放
        {
            popup3.IsOpen = false;
            TrackVideoPlayback p = new TrackVideoPlayback();
            content.Content = p;
			CurrentContent = content;
        }

        private void automaticLinkageClick(object sender, RoutedEventArgs e)//光电联动控制->联动控制->自动控制
        {
            AutomaticLinkage w = new AutomaticLinkage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void manualControlClick(object sender, RoutedEventArgs e)//光电联动控制->联动控制->手动控制
        {
            popup4.IsOpen = false;

        }
        private void PhotoelectricMaintenanceClick(object sender, RoutedEventArgs e)//光电联动控制->光电维护
        {
            PhotoelectricMaintenance pm = new PhotoelectricMaintenance();
            Application.Current.MainWindow = pm;
            pm.ShowDialog();
        }
        /*
        private void TrackAlgorithmSelectionClick(object sender, RoutedEventArgs e)//光电联动控制->伺服控制->跟踪算法选择
        {
            TrackAlgorithmSelection tas = new TrackAlgorithmSelection();
            Application.Current.MainWindow = tas;
            tas.ShowDialog();
        }

        private void TrackVideoSelectionClick(object sender, RoutedEventArgs e)//光电联动控制->伺服控制->跟踪视频选择
        {
            TrackVideoSelection tvs = new TrackVideoSelection();
            Application.Current.MainWindow = tvs;
            tvs.ShowDialog();
        }

        private void SoftwareLimitSettingClick(object sender, RoutedEventArgs e)//光电联动控制->伺服控制->软件限位设置
        {
            SoftwareLimitSetting sls = new SoftwareLimitSetting();
            Application.Current.MainWindow = sls;
            sls.ShowDialog();
        }

        private void DriftCompensationClick(object sender, RoutedEventArgs e)//光电联动控制->伺服控制->漂移补偿
        {
            DriftCompensation dc = new DriftCompensation();
            Application.Current.MainWindow = dc;
            dc.ShowDialog();
        }

        private void InfraredLensSettingClick(object sender, RoutedEventArgs e)//光电联动控制->伺服控制->红外镜头设置
        {
            InfraredLensSetting ils = new InfraredLensSetting();
            Application.Current.MainWindow = ils;
            ils.ShowDialog();
        }
*/
        private void fusionParameterSettingClick(object sender, RoutedEventArgs e)//融合参数
        {
            FusionParameterSetting w = new FusionParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void showBasisDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->基础显示
        {
            popup5.IsOpen = false;

        }

        private void showStandardDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->标准显示
        {
            popup5.IsOpen = false;

        }

        private void showAllDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->全部显示
        {
            popup5.IsOpen = false;

        }

        private void toBiggerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->放大
        {
            App app = (App)App.Current;
            app.returnBack.ZoomIn();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)//绑定快捷键
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed1(object sender, ExecutedRoutedEventArgs e)
        {
            toBiggerClick(this, null);
        }

        private void toSmallerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->缩小
        {
            App app = (App)App.Current;
            app.returnBack.ZoomOut();
        }

        private void CommandBinding_Executed2(object sender, ExecutedRoutedEventArgs e)
        {
            toSmallerClick(this, null);
        }

        private void partToBiggerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->区域放大
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            if (areaZoom)
            {
                app.returnBack.StartAreaZoom();
                areaZoom = false;

                move.IsEnabled = false;
                measure.IsEnabled = false;
            }
            else
            {
                app.returnBack.EndAreaZoom();
                areaZoom = true;

                move.IsEnabled = true;
                measure.IsEnabled = true;
            }

        }

        private void settingMeasuringScaleClick(object sender, RoutedEventArgs e)//海图管理->海图操作->指定比例尺
        {
            SetMeasuringScale w = new SetMeasuringScale();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void moveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->漫游
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            if (isHandRoam == false)
            {
                app.returnBack.StartHandRoam();
                isHandRoam = true;

                measure.IsEnabled = false;
                area.IsEnabled = false;
                MonitoringReturn.Return.hand();
            }
            else
            {
                app.returnBack.EndHandRoam();
                isHandRoam = false;

                measure.IsEnabled = true;
                area.IsEnabled = true;
                MonitoringReturn.Return.point();
            }

        }

        private void topMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->上移
        {
            App app = (App)App.Current;
            app.returnBack.MoveMap(MovingDirection.Up);
        }

        private void CommandBinding_Executed3(object sender, ExecutedRoutedEventArgs e)
        {
            topMoveClick(this, null);
        }

        private void bottomMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->下移
        {
            App app = (App)App.Current;
            app.returnBack.MoveMap(MovingDirection.Down);
        }

        private void CommandBinding_Executed4(object sender, ExecutedRoutedEventArgs e)
        {
            bottomMoveClick(this, null);
        }

        private void leftMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->左移
        {
            App app = (App)App.Current;
            app.returnBack.MoveMap(MovingDirection.Left);
        }

        private void CommandBinding_Executed5(object sender, ExecutedRoutedEventArgs e)
        {
            leftMoveClick(this, null);
        }

        private void rightMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->右移
        {
            App app = (App)App.Current;
            app.returnBack.MoveMap(MovingDirection.Right);
        }

        private void CommandBinding_Executed6(object sender, ExecutedRoutedEventArgs e)
        {
            rightMoveClick(this, null);
        }

        private void convertClick(object sender, RoutedEventArgs e)//海图管理->海图操作->平台归心
        {
            MainWindow.opeation.OptionName = "海图归心";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup5.IsOpen = false;
            App app = (App)App.Current;
            app.returnBack.CenterMap();
        }

        private void targetConvertClick(object sender, RoutedEventArgs e)//海图管理->海图操作->目标归心
        {
            popup5.IsOpen = false;
            if (MonitoringReturn.nowTarget == null)
            {
                System.Windows.MessageBox.Show("未选中目标！");
            }
            else
            {
                App app = (App)App.Current;
                MainWindow.opeation.OptionName = "目标归心";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                app.returnBack.CenterMap(MonitoringReturn.nowTarget.Longitude, MonitoringReturn.nowTarget.Latitude);
            }
        }

        private void measureDistanceClick(object sender, RoutedEventArgs e)//海图管理->海图操作->测距
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            if (measureDistance)
            {
                app.returnBack.StartRanging();
                measureDistance = false;

                move.IsEnabled = false;
                area.IsEnabled = false;
            }
            else
            {
                app.returnBack.EndRanging();
                measureDistance = true;

                move.IsEnabled = true;
                area.IsEnabled = true;
            }
        }

        private void mapManageClick(object sender, RoutedEventArgs e)//海图管理->图库管理
        {
            MapManage w = new MapManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void linkageEventQueryClick(object sender, RoutedEventArgs e)//数据管理->联动事件查询
        {
            popup6.IsOpen = false;
            LinkageEventQuery p = new LinkageEventQuery();
            content.Content = p;
			CurrentContent = content;
        }

        private void queryTrackClick(object sender, RoutedEventArgs e)//数据管理->航迹查询
        {
            if (!isInShowingTrackMode)
            {
                QueryTrack wqt = new QueryTrack();
                System.Windows.Application.Current.MainWindow = wqt;
                wqt.ShowDialog();
            }
            queryTrack(sender, e);
        }

        private void queryTrack(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            if (isInShowingTrack == false)
            {
                app.returnBack.SetShowTrackOrNot(true);
                isInShowingTrack = true;
            }
            else
            {
                app.returnBack.SetShowTrackOrNot(false);
                isInShowingTrack = false;
            }
        }

        private void situationPlaybackClick(object sender, RoutedEventArgs e)//数据管理->态势回放
        {
            SituationPlayback sp = new SituationPlayback();
            Application.Current.MainWindow = sp;
            sp.ShowDialog();
        }

        private void dataQueryClick(object sender, RoutedEventArgs e)//数据管理->数据查询
        {
            popup6.IsOpen = false;
            DataQuery p = new DataQuery();
            content.Content = p;
			CurrentContent = content;
        }

        private void dateStatisticsClick(object sender, RoutedEventArgs e)//数据管理->数据统计
        {
            popup6.IsOpen = false;
            DataStatistics p = new DataStatistics();
            content.Content = p;
 			CurrentContent = content;
        }

        private void dateExportClick(object sender, RoutedEventArgs e)//数据管理->数据导出
        {
            popup6.IsOpen = false;
            DataExport p = new DataExport();
            content.Content = p;
			CurrentContent = content;
        }

        private void shipNumberImportClick(object sender, RoutedEventArgs e)//数据管理->船舷号导入
        {
            ShipNumberImport sni = new ShipNumberImport();
            Application.Current.MainWindow = sni;
            sni.ShowDialog();
        }

        private void deviceOperationStatusClick(object sender, RoutedEventArgs e)//设备管理->设备工作状态 
        {
            popup7.IsOpen = false;
            DeviceOperationStatus p = DeviceOperationStatus.GetInstance();
            content.Content = p;
            CurrentContent = content;
        }

        private void deviceNetworkStatuisClick(object sender, RoutedEventArgs e)//设备管理->设备网络状态
        {
            popup7.IsOpen = false;
            if (fullNetStatus == null)
            {
                FullNetStatus p = new FullNetStatus();
                fullNetStatus = p;
            }
            content.Content = fullNetStatus;
            CurrentContent = content;
        }

        private void userManagementClick(object sender, RoutedEventArgs e)//系统管理->用户管理
        {
            popup8.IsOpen = false;
            UserManagement p = new UserManagement();
            content.Content = p;
 			CurrentContent = content;
        }

        private void roleManageClick(object sender, RoutedEventArgs e)//系统管理->权限管理->角色管理
        {
            popup8.IsOpen = false;
            RoleManagement p = new RoleManagement();
            content.Content = p;
			CurrentContent = content;
        }

        /*private void rolePermissionManageClick(object sender, RoutedEventArgs e)//系统管理->权限管理->角色权限管理 //移除？
        {
            RolePermisionManage w = new RolePermisionManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }*/

        private void networkParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->网络参数设置
        {
            popup8.IsOpen = false;
            NetParameterSetting p = new NetParameterSetting();
            content.Content = p;
			CurrentContent = content;
        }

        private void gorgeParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->串口参数设置
        {
            GorgeParameterSetting w = new GorgeParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void helpClick(object sender, RoutedEventArgs e)
        {

        }

        //***********************************************************************************
        //*******************************工具栏事件******************************************
        //***********************************************************************************
        private void doubleScreenShowClick(object sender, RoutedEventArgs e)//双屏显示
        {
  

        }

        private void returnClick(object sender, RoutedEventArgs e)//返回主界面
        {
            content.Content = MonitoringX.MonitoringXObj;
			CurrentContent = content;
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

        private void MenuPopupClick(object sender, RoutedEventArgs e)//菜单展开事件
        {
            Button b = sender as Button;
            Popup p = FindName(b.Tag.ToString()) as Popup;
            p.IsOpen = true;
            if (p.Name == "popup51")
                popup52.IsOpen = false;
            else if (p.Name == "popup52")
                popup51.IsOpen = false;

            App app = (App)App.Current;
            ais.IsChecked = app.returnBack.showAISTarget;
            radar.IsChecked = app.returnBack.showRadarTarget;
            mix.IsChecked = app.returnBack.showMergeTarget;
            radarLine.IsChecked = app.returnBack.showRadar;
            opt.IsChecked = app.returnBack.showOpt;
        }
    }
}
