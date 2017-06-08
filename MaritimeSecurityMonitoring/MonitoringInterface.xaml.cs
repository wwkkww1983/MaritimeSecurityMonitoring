﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using MaritimeSecurityMonitoring.MainInterfacePage;
using YimaEncCtrl;
using MaritimeSecurityMonitoring.Video;
using System.Windows.Media.Imaging;
using PhotoelectricModule;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// Interface.xaml 的交互逻辑
    /// </summary>
    public partial class MonitoringInterface : Window
    {
        private bool isInShowingTrackMode = false;
        private bool isInShowingTrack = true;
        private bool isHandRoam = false;

        private bool isShowTrackLIine = true;//航迹线显示标示位
        private bool isShowTrackHeadLine = true;//航首线显示标示位

        private bool areaZoom = true;//区域放大状态位
        private bool measureDistance = true;//测距状态位

        //MonitoringX moni;//主界面的实例化
        // DoubleScreen doubles;//双屏实例化

        //蒋 0416 添加
        public static FullNetStatus fullNetStatus;//网络状态
        public static ContentControl CurrentContent;//保存当前的页面
        public static DeviceOperationStatus deviceOperationStatus;//设备状态

        public static MonitoringInterface moninterface;
        private BitmapImage AlarmRed;
        private BitmapImage AlarmGreen;
        public MonitoringInterface()
        {
            InitializeComponent();
            this.Closing += closeSoftware;

            App app = (App)App.Current;
            app.moninterface = this;

            CurrentContent = new ContentControl();
            CurrentContent.Content = null;
            if (MainWindow.roleContrl == "管理员")
            {
                //全部权限
            }
            else if (MainWindow.roleContrl == "工程师")
            {
                //不能操作”用户管理”和“角色管理”
                userManager.Visibility = Visibility.Collapsed;
                //roleManager.Visibility = Visibility.Collapsed;
            }
            else if (MainWindow.roleContrl == "操作员")
            {
                //不能操作“系统管理”下各项功能
                menu8.Visibility = Visibility.Collapsed;
            }
            else if (MainWindow.roleContrl == "观察员")
            {
                //不能操作“系统管理”下各项功能、所有参数设置(融合参数设置、圈层参数、平台中心、多边形区域设置、管道区域设置、白名单管理)、光电伺服控制、图库管理
                menu8.Visibility = Visibility.Collapsed;
                fuseSetting.Visibility = Visibility.Collapsed;
                defenseCircle.Visibility = Visibility.Collapsed;
                platformSsetting.Visibility = Visibility.Collapsed;
                //polygon.Visibility = Visibility.Collapsed;
                poly.Visibility = Visibility.Collapsed;
                //pipeline.Visibility = Visibility.Collapsed;
                pipe.Visibility = Visibility.Collapsed;
                whiteList.Visibility = Visibility.Collapsed;
                menu4.Visibility = Visibility.Collapsed;
                menu5.Visibility = Visibility.Collapsed;
            }
            MonitoringInterface.moninterface = this;
            BridgeBetweenX.fresh_device_lantern += FreshLantern_Device;
            BridgeBetweenX.fresh_Alarm_lantern += FreshLantern_Alarm;
            BridgeBetweenX.freshTips += freshTip;
            AlarmRed = new BitmapImage(new Uri(".\\Image\\AlarmRed.png", UriKind.Relative));
            AlarmGreen = new BitmapImage(new Uri(".\\Image\\AlarmGreen.png", UriKind.Relative));

            FreshLantern_Device(1, 1, 1, 1);
            FreshLantern_Alarm(0, 0, 0, 0, 0, 0);
        }
        private void closeSoftware(object o, System.ComponentModel.CancelEventArgs e)//关闭主界面时界面完全关闭
        {

            MonitoringX.photoControl.UpdatePhotoelectricControl(MainWindow.userInfor.ID);

            System.Windows.Application.Current.Shutdown();

            Environment.Exit(0);//强制退出
            GC.Collect();

        }
        //***********************************************************************************
        //*******************************主菜单事件******************************************
        //***********************************************************************************

        private void AISSituationClick(object sender, RoutedEventArgs e)//态势显示->AIS态势
        {
            App app = (App)App.Current;
            ToggleButton tb = sender as ToggleButton;
            bool state = app.chartCtrl.showAISTarget;

            popup1.IsOpen = false;//收起菜单

            if (state)
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.AIS, false);
                MainWindow.opeation.OptionName = "AIS态势开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
            else
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.AIS, true);
                MainWindow.opeation.OptionName = "AIS态势关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
        }
        private void radarSituationClick(object sender, RoutedEventArgs e)//态势显示->雷达态势
        {
            App app = (App)App.Current;
            ToggleButton tb = sender as ToggleButton;
            bool state = app.chartCtrl.showRadarTarget;
            popup1.IsOpen = false;//收起菜单

            if (state)
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.READER, false);
                MainWindow.opeation.OptionName = "雷达态势开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
            else
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.READER, true);
                MainWindow.opeation.OptionName = "雷达态势开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
        }
        private void mixSituationClick(object sender, RoutedEventArgs e)//态势显示->融合态势
        {
            App app = (App)App.Current;
            ToggleButton tb = sender as ToggleButton;
            bool state = app.chartCtrl.showMergeTarget;
            popup1.IsOpen = false;//收起菜单
            if (state)
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.MERGER, false);
                MainWindow.opeation.OptionName = "融合态势开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
            else
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.MERGER, true);
                MainWindow.opeation.OptionName = "融合态势开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
        }
        private void radarScanningLineClick(object sender, RoutedEventArgs e)//态势显示->雷达扫描线
        {
            App app = (App)App.Current;
            ToggleButton tb = sender as ToggleButton;
            bool state = app.chartCtrl.showRadar;
            popup1.IsOpen = false;
            if (state)
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.RADARLINE, false);
                MainWindow.opeation.OptionName = "雷达扫描线开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
            else
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.RADARLINE, true);
                MainWindow.opeation.OptionName = "雷达扫描线关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
        }
        private void optoelectronicRangeClick(object sender, RoutedEventArgs e)//态势显示->光电扫描范围
        {
            App app = (App)App.Current;
            ToggleButton tb = sender as ToggleButton;
            bool state = app.chartCtrl.showOpt;
            popup1.IsOpen = false;
            if (state)
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.OPTLINE, false);
                MainWindow.opeation.OptionName = "光电扫描范围开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
            else
            {
                app.chartCtrl.SetDisplayMode(TARGET_TYPE.OPTLINE, true);
                MainWindow.opeation.OptionName = "光电扫描范围关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            }
        }
        private void ShowTrackLineClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->目标航迹线显示
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;
            if (isShowTrackLIine)
            {
                app.chartCtrl.SetShowTrackOrNot(false);
                isShowTrackLIine = false;
            }
            else
            {
                app.chartCtrl.SetShowTrackOrNot(true);
                isShowTrackLIine = true;
            }
        }
        private void ShowTrackHeaderClick(object sender, RoutedEventArgs e)//态势显示->目标属性设置->目标航首线显示
        {
            App app = (App)App.Current;
            popup1.IsOpen = false;
            if (isShowTrackHeadLine)
            {
                app.chartCtrl.SetShowTargetSpeedLineOrNot(false);
                MainWindow.opeation.OptionName = "目标航首线开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                isShowTrackHeadLine = false;
            }
            else
            {
                app.chartCtrl.SetShowTargetSpeedLineOrNot(true);
                MainWindow.opeation.OptionName = "目标航首线关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                isShowTrackHeadLine = true;
            }
        }

        private void ShowTargetPropertyClick(object sender, RoutedEventArgs e)//态势显示->目标属性显示
        {

            MainWindow.opeation.OptionName = "目标属性显示";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            ShowTargetProperty stp = new ShowTargetProperty();
            Application.Current.MainWindow = stp;
            stp.ShowDialog();
        }
        private void PlatformCenterSettingClick(object sender, RoutedEventArgs e)//报警管理->平台中心设置
        {
            MainWindow.opeation.OptionName = "开启平台中心设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            PlatformPositionSetting w = new PlatformPositionSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void defenseSpheresSettingClick(object sender, RoutedEventArgs e)//报警管理->防护圈层设置
        {
            MainWindow.opeation.OptionName = "开启防护圈层设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            DefenseCircleSetting w = new DefenseCircleSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void areaLabelClick(object sender, RoutedEventArgs e)//报警管理->多边形防护区设置
        {
            MainWindow.opeation.OptionName = "多边形保护区设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

            if (MonitoringX.AddedForbiddenZoneBack())
            {
                move.IsEnabled = false;
                measure.IsEnabled = false;
                area.IsEnabled = false;
                pipe.IsEnabled = false;
                playback.IsEnabled = false;
                track.IsEnabled = false;
            }

        }
        private void pipelineClick(object sender, RoutedEventArgs e)//报警管理->管道防护区设置
        {
            MainWindow.opeation.OptionName = "管道保护区设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

            if (MonitoringX.AddedPipelineBack())
            {
                move.IsEnabled = false;
                measure.IsEnabled = false;
                area.IsEnabled = false;
                poly.IsEnabled = false;
                playback.IsEnabled = false;
                track.IsEnabled = false;
            }
        }
        private void warnAreaSettingClick(object sender, RoutedEventArgs e)//报警管理->防护区管理
        {
            MainWindow.opeation.OptionName = "防护区管理";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            WarnAreaSetting was = new WarnAreaSetting();
            Application.Current.MainWindow = was;
            was.ShowDialog();
        }
        private void whiteListSettingClick(object sender, RoutedEventArgs e)//报警管理->船舶白名单管理
        {
            MainWindow.opeation.OptionName = "船舶白名单管理";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup2.IsOpen = false;
            WhiteListSetting p = new WhiteListSetting();
            content.Content = p;
        }
        private void listWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->列表报警
        {
            MainWindow.opeation.OptionName = "开启列表报警";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup2.IsOpen = false;
        }
        private void imageWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->图像报警
        {
            MainWindow.opeation.OptionName = "开启图像列表报警";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup2.IsOpen = false;
        }
        private void voiceWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->声音报警
        {
            MainWindow.opeation.OptionName = "开启声音报警";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup2.IsOpen = false;
        }
        private void captureImagesClick(object sender, RoutedEventArgs e)//视频管理->图片抓取
        {
            MainWindow.opeation.OptionName = "抓取图片";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            MonitoringX.captureImages();//截取长焦视频，保留到指定路径

            CaptureImages w = new CaptureImages();//打开新窗口，展示图片
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void trackVideoPlaybackClick(object sender, RoutedEventArgs e)//视频管理->跟踪视频回放
        {
            MainWindow.opeation.OptionName = "跟踪视频回放";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            //popup3.IsOpen = false;
            TrackVideoPlayback p = new TrackVideoPlayback();
            content.Content = p;
        }
        private void automaticLinkageClick(object sender, RoutedEventArgs e)//光电联动控制->联动控制->单次控制，自动联动
        {
            int CheckPstatus = Photoelectricity.Verifydevicestatus();
            if (CheckPstatus ==-2)
            {
                MessageBoxX.Show("联动失败", "光电设备驱动未开！");
                return;
            }
            if (MonitoringX.deviceControlState == 1)
            {
                MainWindow.opeation.OptionName = "自动联动开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                MonitoringX.linkageContral = 2;
                popup4.IsOpen = false;

                MonitoringX.MonitoringXObj.link_auto();
            }
            else if (MonitoringX.deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }

        private void manualControlClick(object sender, RoutedEventArgs e)//光电联动控制->联动控制->多次控制，手动联动
        {
            int CheckPstatus = Photoelectricity.Verifydevicestatus();
            if (CheckPstatus == -2)
            {
                MessageBoxX.Show("联动失败", "光电设备驱动未开！");
                return;
            }
            if (MonitoringX.deviceControlState == 1)
            {
                MainWindow.opeation.OptionName = "手动联动开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                MonitoringX.linkageContral = 1;
                popup4.IsOpen = false;

                MonitoringX.MonitoringXObj.link_manual();
            }
            else if (MonitoringX.deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        public static int GetTimeStamp()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
        private void PhotoelectricMaintenanceClick(object sender, RoutedEventArgs e)//光电联动控制->光电维护
        {
            MainWindow.opeation.OptionName = "开启光电维护";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            PhotoelectricMaintenance pm = new PhotoelectricMaintenance();
            Application.Current.MainWindow = pm;
            pm.ShowDialog();
        }
        private void fusionParameterSettingClick(object sender, RoutedEventArgs e)//融合参数
        {
            MainWindow.opeation.OptionName = "开启融合参数设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            FusionParameterSetting w = new FusionParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void showBasisDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->基础显示
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            app.chartCtrl.SetDisplayCategory(DISPLAY_CATEGORY_NUM.DISPLAY_BASE);
            MainWindow.opeation.OptionName = "海图基础显示";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
        }

        private void showStandardDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->标准显示
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            app.chartCtrl.SetDisplayCategory(DISPLAY_CATEGORY_NUM.DISPLAY_STANDARD);
            MainWindow.opeation.OptionName = "海图标准显示";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
        }

        private void showAllDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->全部显示
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            app.chartCtrl.SetDisplayCategory(DISPLAY_CATEGORY_NUM.DISPLAY_ALL);
            MainWindow.opeation.OptionName = "海图全部显示";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
        }

        private void toBiggerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->放大
        {
            MainWindow.opeation.OptionName = "海图放大";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.ZoomIn();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)//绑定快捷键1
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed1(object sender, ExecutedRoutedEventArgs e)//绑定快捷键2
        {
            toBiggerClick(this, null);
        }

        private void toSmallerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->缩小
        {
            MainWindow.opeation.OptionName = "海图缩小";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.ZoomOut();
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
                app.chartCtrl.StartAreaZoom();
                MainWindow.opeation.OptionName = "区域放大开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                areaZoom = false;

                move.IsEnabled = false;
                measure.IsEnabled = false;
                poly.IsEnabled = false;
                pipe.IsEnabled = false;
                playback.IsEnabled = false;
                track.IsEnabled = false;
            }
            else
            {
                app.chartCtrl.EndAreaZoom();
                MainWindow.opeation.OptionName = "区域放大关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                areaZoom = true;

                move.IsEnabled = true;
                measure.IsEnabled = true;
                poly.IsEnabled = true;
                pipe.IsEnabled = true;
                playback.IsEnabled = true;
                track.IsEnabled = true;
            }
        }
        private void settingMeasuringScaleClick(object sender, RoutedEventArgs e)//海图管理->海图操作->指定比例尺
        {
            MainWindow.opeation.OptionName = "开启指定比例尺";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
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
                app.chartCtrl.StartHandRoam();
                MainWindow.opeation.OptionName = "海图漫游开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                isHandRoam = true;

                area.IsEnabled = false;
                measure.IsEnabled = false;
                poly.IsEnabled = false;
                pipe.IsEnabled = false;
                playback.IsEnabled = false;
                track.IsEnabled = false;
                MonitoringX.MonitoringXObj.hand();
            }
            else
            {
                app.chartCtrl.EndHandRoam();
                MainWindow.opeation.OptionName = "海图漫游关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                isHandRoam = false;

                area.IsEnabled = true;
                measure.IsEnabled = true;
                poly.IsEnabled = true;
                pipe.IsEnabled = true;
                playback.IsEnabled = true;
                track.IsEnabled = true;
                MonitoringX.MonitoringXObj.point();
            }
        }

        private void topMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->上移
        {
            MainWindow.opeation.OptionName = "海图上移";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Up);
        }

        private void CommandBinding_Executed3(object sender, ExecutedRoutedEventArgs e)
        {
            topMoveClick(this, null);
        }

        private void bottomMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->下移
        {
            MainWindow.opeation.OptionName = "海图下移";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Down);
        }

        private void CommandBinding_Executed4(object sender, ExecutedRoutedEventArgs e)
        {
            bottomMoveClick(this, null);
        }

        private void leftMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->左移
        {
            MainWindow.opeation.OptionName = "海图左移";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Left);
        }

        private void CommandBinding_Executed5(object sender, ExecutedRoutedEventArgs e)
        {
            leftMoveClick(this, null);
        }

        private void rightMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->右移
        {
            MainWindow.opeation.OptionName = "海图右移";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Right);
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
            app.chartCtrl.CenterMap();
        }

        private void targetConvertClick(object sender, RoutedEventArgs e)//海图管理->海图操作->目标归心
        {
            popup5.IsOpen = false;
            if (MonitoringX.nowTarget == null)
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
                app.chartCtrl.CenterMap(MonitoringX.nowTarget.Longitude, MonitoringX.nowTarget.Latitude);
            }
        }

        private void measureDistanceClick(object sender, RoutedEventArgs e)//海图管理->海图操作->测距
        {
            popup5.IsOpen = false;
            App app = (App)App.Current;
            if (measureDistance)
            {
                app.chartCtrl.StartRanging();
                MainWindow.opeation.OptionName = "海图测距开启";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                measureDistance = false;

                move.IsEnabled = false;
                area.IsEnabled = false;
                poly.IsEnabled = false;
                pipe.IsEnabled = false;
                playback.IsEnabled = false;
                track.IsEnabled = false;
            }
            else
            {
                app.chartCtrl.EndRanging();
                MainWindow.opeation.OptionName = "海图测距关闭";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
                measureDistance = true;

                move.IsEnabled = true;
                area.IsEnabled = true;
                poly.IsEnabled = true;
                pipe.IsEnabled = true;
                playback.IsEnabled = true;
                track.IsEnabled = true;
            }
        }

        private void mapManageClick(object sender, RoutedEventArgs e)//海图管理->图库管理
        {
            MainWindow.opeation.OptionName = "图库管理开启";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            MapManage w = new MapManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void linkageEventQueryClick(object sender, RoutedEventArgs e)//数据管理->联动事件查询
        {
            MainWindow.opeation.OptionName = "联动事件查询";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup6.IsOpen = false;
            LinkageEventQuery p = new LinkageEventQuery();
            content.Content = p;
            CurrentContent = content;
        }

        private void queryTrackClick(object sender, RoutedEventArgs e)//数据管理->航迹查询
        {
            if (!isInShowingTrackMode)
            {
                MainWindow.opeation.OptionName = "航迹查询";//日志入库
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                targetCenter.IsEnabled = false;
                measure.IsEnabled = false;
                area.IsEnabled = false;
                poly.IsEnabled = false;
                pipe.IsEnabled = false;
                playback.IsEnabled = false;
                getBank.IsEnabled = false;

                QueryTrack wqt = new QueryTrack();
                System.Windows.Application.Current.MainWindow = wqt;
                wqt.ShowDialog();
                isInShowingTrackMode = true;



            }
            else
            {
                queryTrackFlish();//航迹查询结束
            }
        }

        public void queryTrackFlish()
        {
            App app = (App)App.Current;
            app.chartCtrl.FinishShowTargetTrack();
            isInShowingTrackMode = false;

            targetCenter.IsEnabled = true;
            measure.IsEnabled = true;
            area.IsEnabled = true;
            poly.IsEnabled = true;
            pipe.IsEnabled = true;
            playback.IsEnabled = true;
            getBank.IsEnabled = true;
        }
        private void situationPlaybackClick(object sender, RoutedEventArgs e)//数据管理->态势回放
        {
            MainWindow.opeation.OptionName = "态势回放";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);



            SituationPlayback sp = new SituationPlayback();
            Application.Current.MainWindow = sp;
            sp.ShowDialog();
        }

        private void dataQueryClick(object sender, RoutedEventArgs e)//数据管理->数据查询
        {
            MainWindow.opeation.OptionName = "数据查询";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup6.IsOpen = false;
            DataQuery p = new DataQuery();
            content.Content = p;
            CurrentContent = content;
        }

        private void dateStatisticsClick(object sender, RoutedEventArgs e)//数据管理->数据统计
        {
            MainWindow.opeation.OptionName = "数据统计";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup6.IsOpen = false;
            DataStatistics p = new DataStatistics();
            content.Content = p;
        }

        private void dateExportClick(object sender, RoutedEventArgs e)//数据管理->数据导出
        {
            MainWindow.opeation.OptionName = "数据导出";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup6.IsOpen = false;
            DataExport p = new DataExport();
            content.Content = p;
            CurrentContent = content;
        }

        private void shipNumberImportClick(object sender, RoutedEventArgs e)//数据管理->船舷号导入
        {
            MainWindow.opeation.OptionName = "导入船舷号";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            ShipNumberImport sni = new ShipNumberImport();
            Application.Current.MainWindow = sni;
            sni.ShowDialog();
        }

        private void deviceOperationStatusClick(object sender, RoutedEventArgs e)//设备管理->设备工作状态 
        {
            MainWindow.opeation.OptionName = "查看设备工作状态";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup7.IsOpen = false;
            if (deviceOperationStatus == null)
            {
                DeviceOperationStatus p = DeviceOperationStatus.GetInstance();
                deviceOperationStatus = p;
            }
            content.Content = deviceOperationStatus;
            CurrentContent = content;
        }

        private void deviceNetworkStatuisClick(object sender, RoutedEventArgs e)//设备管理->设备网络状态
        {
            MainWindow.opeation.OptionName = "目查看网络设备状态";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
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
            MainWindow.opeation.OptionName = "用户管理";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup8.IsOpen = false;
            UserManagement p = new UserManagement();
            content.Content = p;
            CurrentContent = content;
        }

        private void roleManageClick(object sender, RoutedEventArgs e)//系统管理->权限管理->角色管理
        {
            MainWindow.opeation.OptionName = "角色管理";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup8.IsOpen = false;
            RoleManagement p = new RoleManagement();
            content.Content = p;
            CurrentContent = content;
        }

        private void networkParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->网络参数设置
        {
            MainWindow.opeation.OptionName = "网络参数设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            popup8.IsOpen = false;
            NetParameterSetting p = new NetParameterSetting();
            content.Content = p;
            CurrentContent = content;
        }

        private void gorgeParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->串口参数设置
        {
            MainWindow.opeation.OptionName = "串口参数设置";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);
            GorgeParameterSetting w = new GorgeParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void helpClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, ".\\使用手册.chm");
        }

        private void CommandBinding_Executed7(object sender, ExecutedRoutedEventArgs e)
        {
            helpClick(sender, e);
        }

        //***********************************************************************************
        //*******************************工具栏事件******************************************
        //***********************************************************************************
        private void doubleScreenShowClick(object sender, RoutedEventArgs e)//双屏显示
        {
            int sign = NVRCsharpDemo.DVRAPI.GetInstance().DVRAPI_Init();//初始化DVR登录
            if (sign == -1)
            {
                MessageBoxX.Show("异常信息", "无光电视频信号。");//显示异常信息
            }
            else
            {
                MainWindow.doubleScreen = !MainWindow.doubleScreen;
                if (MainWindow.doubleScreen)
                {
                    try
                    {
                        MainWindow.opeation.OptionName = "双屏显示";//日志入库
                        MainWindow.opeation.LogType = 2;
                        MainWindow.opeation.OptionTime = GetTime(GetTimeStampS().ToString());
                        MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

                        if (MainWindow.doubleScreen)
                        {
                            MainWindow.doubles = new DoubleScreen();
                            MainWindow.doubles.Closed += doubleScreenClosed;
                            System.Windows.Application.Current.MainWindow = MainWindow.doubles;
                            MainWindow.doubles.Show();
                            MonitoringX.MonitoringXObj.doubleScreen();//修改主界面
                        }
                    }
                    catch (Exception eex)
                    {
                        MessageBoxX.Show("异常信息", "未检测到扩展屏。");//显示异常信息
                        MainWindow.doubleScreen = false;
                    }
                }
                else
                {
                    MonitoringX.MonitoringXObj.doubleScreen();//修改主界面
                    if (MainWindow.doubles != null)
                    {
                        doubleScreenClosed(sender, e);
                    }
                }
            }
        }
        private void doubleScreenClosed(object sender, EventArgs e)
        //双屏显示的关闭
        {
            MainWindow.doubleScreen = false;
            MonitoringX.MonitoringXObj.doubleScreen();//修改主界面
            if (MainWindow.doubles != null)
            {
                MainWindow.doubles.close();
            }
            MainWindow.doubles = null;
        }

        private void returnClick(object sender, RoutedEventArgs e)//返回主界面
        {
            content.Content = MonitoringX.MonitoringXObj;
        }

        public void polyBack()//多边形
        {
            move.IsEnabled = true;
            measure.IsEnabled = true;
            area.IsEnabled = true;
            pipe.IsEnabled = true;
            playback.IsEnabled = true;
            track.IsEnabled = true;
        }

        public void pipeBack()//管道
        {
            move.IsEnabled = true;
            measure.IsEnabled = true;
            area.IsEnabled = true;
            poly.IsEnabled = true;
            playback.IsEnabled = true;
            track.IsEnabled = true;
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
            ais.IsChecked = app.chartCtrl.showAISTarget;
            radar.IsChecked = app.chartCtrl.showRadarTarget;
            mix.IsChecked = app.chartCtrl.showMergeTarget;
            radarLine.IsChecked = app.chartCtrl.showRadar;
            opt.IsChecked = app.chartCtrl.showOpt;

            if (MonitoringX.linkageContral == 0)
            {
                one.IsChecked = false;
                count.IsChecked = false;
            }
            else if (MonitoringX.linkageContral == 1)
            {
                one.IsChecked = false;
                count.IsChecked = true;
            }
            else if (MonitoringX.linkageContral == 2)
            {
                one.IsChecked = true;
                count.IsChecked = false;
            }
        }

        private void Menu_Close(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            Popup p = FindName(b.Tag.ToString()) as Popup;
            if (!p.IsMouseOver)
                p.IsOpen = false;
        }

        private void Menu_Close_Ensure(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (b.Tag.ToString() == "5")
            {
                popup51.IsOpen = false;
                popup52.IsOpen = false;
            }
            else
            {
                Popup p = FindName(b.Tag.ToString()) as Popup;
                p.IsOpen = false;
            }

        }

        public void FreshLantern_Device(int radar1, int radar2, int ais, int Photo)
        //设备灯
        {
            if (radar1 == 0)
            {
                baojingleida1.Source = new BitmapImage(new Uri(".\\Image\\RadarGreen.png", UriKind.Relative));

                baojingleida1.ToolTip = "雷达1工作正常";

            }
            else
            {
                baojingleida1.Source = new BitmapImage(new Uri(".\\Image\\RadarRed.png", UriKind.Relative));

                baojingleida1.ToolTip = "雷达1工作异常";

            }
            if (radar2 == 0)
            {
                baojingleida2.Source = new BitmapImage(new Uri(".\\Image\\RadarGreen.png", UriKind.Relative));
                baojingleida2.ToolTip = "雷达2工作正常";
            }
            else
            {
                baojingleida2.Source = new BitmapImage(new Uri(".\\Image\\RadarRed.png", UriKind.Relative));
                baojingleida2.ToolTip = "雷达2工作异常";
            }
            if (ais == 0)
            {
                baojingAIS.Source = new BitmapImage(new Uri(".\\Image\\AISGreen.png", UriKind.Relative));
                baojingAIS.ToolTip = "AIS工作正常";
            }
            else
            {
                baojingAIS.Source = new BitmapImage(new Uri(".\\Image\\AISRed.png", UriKind.Relative));
                baojingAIS.ToolTip = "AIS工作异常";
            }
            if (Photo == 0)
            {
                baojingguangdian.Source = new BitmapImage(new Uri(".\\Image\\MixGreen.png", UriKind.Relative));
                baojingguangdian.ToolTip = "光电工作正常";
            }
            else
            {
                baojingguangdian.Source = new BitmapImage(new Uri(".\\Image\\MixRed.png", UriKind.Relative));
                baojingguangdian.ToolTip = "光电工作异常";
            }

        }

        public void FreshLantern_Alarm(int pipe, int poly, int PreAlarm, int Quzhu, int Jinjie, int Pintai)
        {

            if (pipe == 0)
            {
                pipeL.Source = AlarmGreen;
            }
            else if (pipe > 0)
            {
                pipeL.Source = AlarmRed;
            }

            if (poly == 0)
            {
                polyL.Source = AlarmGreen;
            }
            else if (poly > 0)
            {
                polyL.Source = AlarmRed;
            }
            if (PreAlarm == 0)
            {
                PreAlarmL.Source = AlarmGreen;
            }
            else if (PreAlarm > 0)
            {
                PreAlarmL.Source = AlarmRed;
            }
            if (Quzhu == 0)
            {
                QuZhuL.Source = AlarmGreen;
            }
            else if (Quzhu > 0)
            {
                QuZhuL.Source = AlarmRed;
            }
            if (Jinjie == 0)
            {
                JinjieL.Source = AlarmGreen;
            }
            else if (Jinjie > 0)
            {
                JinjieL.Source = AlarmRed;
            }
            if (Pintai == 0)
            {
                PintaiL.Source = AlarmGreen;
            }
            else if (Pintai > 0)
            {
                PintaiL.Source = AlarmRed;
            }
        }
        public void freshTip(int recvAIS, int recvRadar, int recvFus, int proFUs, int AISCount, int RaderCount, int FusionCount)
        {
            PrecvAIS.Content = recvAIS.ToString();
            PrecvRader.Content = recvRadar.ToString();
            PrecvFus.Content = recvFus.ToString();
            AISObj.Content = AISCount.ToString();
            RaderObj.Content = RaderCount.ToString();
            FusionObj.Content = FusionCount.ToString();
        }
    }

}
