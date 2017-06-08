﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Threading;
using PhotoelectricModule;
using System.Threading;
using System.Windows.Controls.Primitives;

using dataAnadll;
using YimaWF.data;

namespace MaritimeSecurityMonitoring.MainInterfacePage
{
    /// <summary>
    /// MonitoringX.xaml 的交互逻辑
    /// </summary>
    public partial class MonitoringX : Page
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

        IntPtr infraredRayRealWndHandle;//视频窗口句柄
        IntPtr followingPictureRealWndHandle;//视频窗口句柄
        IntPtr telephotoRealWndHandle;//视频窗口句柄

        public static int[] videoState = new int[3] { -1,-1,-1};//光电视频标识子
        public static int nowVideoType = 3;//当前跟踪视频类型
        int sign=111;//DVR登录状态
        public static float photoHeight = 0f;//光电高度
        public static dataAna device = new dataAna();//通信实例

        public static int linkageContral = 0;//联动状态（0是不联动，1是手动联动，2是自动联动）
        public static int nowLink;
        private int lastTargetID = -1;//海图自动联动停止标示位

        public static long eventCaputureTime;//截图时间
        public static long linkageSstart;//联动开始时间
        private string listViewState = "allListView";//当前选中列表标识位

        public static int deviceControlState = 0;//控制权标识位
        private int powerState = 0;//驱动标识位

        public static string photoelectricEquipmentRuningStateStr = " --";//光电设备开机状态
        public static string pitchDriveModeStr = " --";//俯仰驱动模式
        public static string bearingDriveModeStr = " --";//方位驱动模式
        public static string InfraredStateStr = " --";//红外热相仪状态
        public static string pitchDriveLimitUpStr = " --";//俯仰驱动上限度位
        public static string pitchDriveLimitDownStr = " --";//俯仰驱动上下度位
        public static string bearingDriveLimitLeftStr = " --";//俯仰驱动左限度位
        public static string bearingDriveLimitRightStr = " --";//俯仰驱动右限度位
        public static string videoSwitchStateStr = " --";//当前视频显示
        public static string controllerInitializationStateStr = " --";//控制器初始化状态
        public static string servoStateStr = " --";//伺服状态
        public static string driveEnabledStateStr = " --";//驱动使能状态
        public static string hardDiskVideoStatusStr = " --";//硬盘录像机状态
        public static string wideAngledCameraStatusStr = " --";//广角摄像机状态
        public static string telephotoCameraStatusStr = " --";//长焦摄像机状态

        public static string targetTrackingStateStr = " --";//目标跟踪状态
        public static string videoTrackingStatusStr = " --";//视频跟踪状态
        public static string movingTargetDetectionStr = " --";//移动目标侦测控制
        public static string pitchAngleMeasurementStr = " --";//俯仰侧角状态
        public static string azimuthAngleMeasurementStr = " --";//方位测角状态
        public static string waveGateCenterCoordinateYControlStr = " --";//门中心点Y控制
        public static string waveGateCenterCoordinateXControlStr = " --";//门中心点X控制
        public static string pitchMissDistanceControlStr = " --";//俯仰脱靶量控制
        public static string azimuthMissDistanceControlStr = " --";//方位脱靶量控制


        static public string WaveGateCenterCoordinateX;               // 波门中心点X坐标([-384, 384]像素)
        static public string WaveGateCenterCoordinateY;               // 波门中心点Y坐标([-288, 288]像素)
        static public string OpticalAxisHorizontalAngle;             // 光轴水平角度（值域：[-180, 180-90/2^14]）
        static public string OpticalAxisPitchAngle;                  // 光轴俯仰角度（值域：[-90, 180-90/2^14]）
        static public string AzimuthMissDistance;                    // 方位脱靶量（值域：[-180, 180-90/2^14]）
        static public string PitchMissDistance;                      // 俯仰脱靶量（值域：[-90, 180-90/2^14]）

        public static string picfile_path;//截图路径
        public static string picfile_name;//
        public static string picDirect;//截图目录
        public static string localPicPath;
        public static byte SlpingstateValue = 1;//设备网络状态
        public static byte AISpingstateValue = 1;//AIS网络状态
        public static byte RaderpingstateValue = 1;//雷达网络状态
        public static byte lightpingstateValue = 1;//光电设备网络状态
        public static byte DBPingValue = 1;//dbp状态
        public static byte clientApingValue = 1;//显控1状态
        public static byte clientBpingValue = 1;//显控2状态
        public static byte FusionPingValue = 1;//融合服务器断开
        public static byte channe = 2; //天线信道报警 0正常 1有故障
        public static byte genaral = 2; //0正常 1 一般故障
        public static byte clock = 2; //时钟报警 0正常 1有故障
        public static byte MKD = 2; //MKD报警 0正常 1 有故障
        public static byte EPFS = 2; //电子定位系统报警 0正常 1丢失
        public static byte sensor = 2;//传感器报警 0正常  1故障
        public static byte information = 2; //信息状态报警  0正常 1有无效信息故障
        public static byte Machine = 2; // ais多部件状态txt信息（非报警） 0表示未发出状态 

        public static byte Machines = 0;//id  1，2,3,4分别对应融合服务器 数据库服务器 显控A 显控B
        public static float CPU = 0f;//cpu使用率
        public static float Room = 0f;//内存使用率
        public static float Disk = 0f;//磁盘占用率

        followVideo foll;//追踪视频界面实例化
        DoubleScreen doubleS;//双屏显示界面实例化
        public static Target nowTarget;//当前目标实例化
        public static double[] center = { 0, 0 };//海图中心位置
        public static string page = "当前";

        public static CircleProtectAreaManager circleData = new CircleProtectAreaManager();//圈层数据库实例
        public static PolygonAreaManager polygonDate = new PolygonAreaManager();//多边形数据库实例
        public static PipeLineProtectAreaManager pipeLine = new PipeLineProtectAreaManager();//管道数据库实例
        public static PlatformManager platform = new PlatformManager();//平台数据库实例
        public static TargetTrackProvider track = new TargetTrackProvider();//航迹查询数据库实例
        public static FuseParaManager fuse = new FuseParaManager();//融合参数数据库实例
        private PhotoelectricParaManager photo = new PhotoelectricParaManager();//光电数据库实例
        public static PhotoelectricControl photoControl = new PhotoelectricControl();//光电主控权数据库实例

        public static bool trackState = false;//追踪事件标识位
        public static long trackStartTime = 0;//追踪事件开始时间

        public static MonitoringX MonitoringXObj;
        //联动跟踪目标结构
        public static _LinkageTarget linkageTarget = new _LinkageTarget();

        //设备状态关键字: 蒋
        byte Machine_NetWork_State_Windows = 0;//表示网络状态的窗口数
        byte Machine_Hardware_State_Windows = 0;//表示机器运行状态的显示窗口数
        byte AIS_AlrTxt_Windows = 0;//AIS设备的显示窗口数,0表示当时无窗口显示

        private SetConfig config = new SetConfig();//配置文件实例
        private ObservableCollection<Target> alarmList = new ObservableCollection<Target>();//报警list

        private BridgeBetweenX bridge;//信息中介
        private int pipe;
        private int poly;
        private int Pintai;
        private int Quzhu;
        private int Yujing;
        private int Jingjie;
        public MonitoringX()
        {
            InitializeComponent();
            App app = (App)App.Current;
            app.chartCtrl = yimaEncCtrl;

            app.mainWindow = this;

            bridge = new BridgeBetweenX();
            pipe = 0;
            poly = 0;
            Pintai = 0;
            Quzhu = 0;
            Yujing = 0;
            Jingjie = 0;
            device.anaInit(new dataAna.DMMmessage(get), "192.6.1.102", 8123, 8066);//融合信息交互接口      
            device.anaInit(showstatus);//网络，硬件状态返回参数
            device.anaInit(SyncInfo);//显控同步数据 注释

            new Photoelectricity().GetDeviceRuningState(new Photoelectricity.GetDRSDelegate(ShowState));//光电面板返回参数

            Photoelectricity.StartideoPlayingReg(new Photoelectricity.StartideoPlayingDelegate(startPlay));

            yimaEncCtrl.AddedForbiddenZone += YimaEncCtrl_AddedForbiddenZone;//绘制多边形的回调函数注册
            yimaEncCtrl.AddedPipeline += YimaEncCtrl_AddedPipeline;//绘制管道的回调函数注册

            yimaEncCtrl.ShowTargetDetail += YimaEncCtrl_ShowTargetDetail;//海图大标牌显示回调
            yimaEncCtrl.ManualTrackTarget += YimaEncCtrl_ManualTrackTarget;//海图手动联动回调
            yimaEncCtrl.AutoTrackTarget += YimaEncCtrl_AutoTrackTarget;//海图自动联动回调
            yimaEncCtrl.TargetSelect += YimaEncCtrl_SelectTarget;//海图选中目标回调

            yimaEncCtrl.ShowMessage += YimaEncCtrl_ShowMessage;//海图showmessage回调
            yimaEncCtrl.GetAlarm += YimaEncCtrl_getAlarm;//海图报警回调

            infraredRayPictureBox.mouseDoubleClick += longFocusPointDouble;//长焦双击回调注册
            followingPictureBox.mouseDoubleClick += infraredRayPointDouble;//红外双击回调注册
            telephotoPictureBox.mouseDoubleClick += telephotoPointDouble;//广角双击回调注册

            allListView.ItemsSource = app.chartCtrl.AllTargetList;//所有目标列表数据绑定
            AISListView.ItemsSource = app.chartCtrl.AISTargetList;//AIS目标列表数据绑定
            mixListView.ItemsSource = app.chartCtrl.MergeTargetList;//融合目标列表数据绑定
            radarListView.ItemsSource = app.chartCtrl.RadarTargetList;//雷达目标列表数据绑定

            //warnListView.ItemsSource = app.chartCtrl.AlarmTargetList;//报警目标列表数据绑定
            warnListView.ItemsSource = alarmList;//报警目标列表数据绑定

            DispatcherTimer AlarmTimer = new DispatcherTimer();//报警刷新计时器
            AlarmTimer.Interval = TimeSpan.FromSeconds(3600);//刷新间隔
            AlarmTimer.Tick += new EventHandler(AlarmRefresh);
            AlarmTimer.Start();

            List<ProtectZone> list0 = circleData.GetAllCircleProtectArea(app.chartCtrl.GetGeoMultiFactor());//圈层数据初始化
            for (int i = 0; i < list0.Count; i++)
            {
                app.chartCtrl.AddProtectZone(list0[i]);//初始化圈层
            }
            
            List<ForbiddenZone> list1 = polygonDate.GetAllPolygonArea(app.chartCtrl.GetGeoMultiFactor());//多边形所有目标      
            for (int i = 0; i < list1.Count; i++)
            {
                app.chartCtrl.AddForbiddenZone(list1[i]);//初始化多边形
            }

            List<Pipeline> list2 = pipeLine.GetAllPipeLineProtectArea(app.chartCtrl.GetGeoMultiFactor());//管道所有目标
            for (int i = 0; i < list2.Count; i++)
            {
                app.chartCtrl.AddPipeline(list2[i]);//初始化管道
            }
            
            double longi = 0;
            double lati = 0;
            platform.GetPlatform(out longi, out lati);//查询平台中心
            center[0] = longi;
            center[1] = lati;
            app.chartCtrl.SetPlatform(center[0], center[1]);//初始化平台中心坐标
            

            app.chartCtrl.SetScale(197530);//初始化比例尺20海里
            config.write_string("messure", "value1", "197530");
            //platform.SavePlatform(MonitoringX.center[0], MonitoringX.center[1]);//平台中心入库


            doubleScreen();
            infraredRayPictureBox.change_Pic("..\\..\\Image\\video.png");
            followingPictureBox.change_Pic("..\\..\\Image\\video.png");
            telephotoPictureBox.change_Pic("..\\..\\Image\\video.png");

            if (config.read_bool("setting", "name"))//目标属性初始化
            {
                app.chartCtrl.AppConfig.ShowTargetName = true;
            }
            else
            {
                app.chartCtrl.AppConfig.ShowTargetName = false;
            }


            if (config.read_bool("setting", "speed"))
            {
                app.chartCtrl.AppConfig.ShowTargetSpeed = true;
            }
            else
            {
                app.chartCtrl.AppConfig.ShowTargetSpeed = false;
            }


            if (config.read_bool("setting", "angle"))
            {
                app.chartCtrl.AppConfig.ShowTargetCourse = true;
            }
            else
            {
                app.chartCtrl.AppConfig.ShowTargetCourse = false;
            }


            if (config.read_bool("setting", "time"))
            {
                app.chartCtrl.AppConfig.ShowTargetArriveTime = true;
            }
            else
            {
                app.chartCtrl.AppConfig.ShowTargetArriveTime = false;
            }

          PhotoelectricParas data = photo.GetPhotoelectricParas();//数据库查询光电参数
           photoHeight = data.SetHeight;

            MonitoringX.MonitoringXObj = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            app.chartCtrl.CenterMap();//初始化视角中心坐标
            startPlay();//开始播放视频
        }
        public void doubleScreen()
        {
            if (MainWindow.doubleScreen)
            {
                Grid.SetColumnSpan(formshost, 2);//双屏显示控制
            }
            else
            {
                Grid.SetColumnSpan(formshost, 1);//双屏显示控制
            }
        }
        /*光电视频播放模块（start）*************************************************************************************/
        public void realPlay()//开始播放
        {
            sign = NVRCsharpDemo.DVRAPI.GetInstance().DVRAPI_Init();//初始化DVR登录
            if (videoState[0] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[0]);
            }
            if (videoState[1] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[1]);
            }
            if (videoState[2] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[2]);
            }
            videoState[0] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, infraredRayRealWndHandle);//长焦视频播放
            videoState[1] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(1, followingPictureRealWndHandle);//红外视频播放
            videoState[2] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(4, telephotoRealWndHandle);//广角视频播放
        }
        private void startPlay()//获取视频句柄
        {
            //infraredRayRealWndHandle = infraredRayPictureBox.Handle;//长焦
            //followingPictureRealWndHandle = followingPictureBox.Handle;//红外
            //telephotoRealWndHandle = telephotoPictureBox.Handle;//广角
            //Thread Thread = new Thread(new ThreadStart(realPlay));
            //Thread.Start();
            Dispatcher.Invoke(new Action(() =>//同步登陆DVR
            {
                infraredRayRealWndHandle = infraredRayPictureBox.Handle;//长焦
                followingPictureRealWndHandle = followingPictureBox.Handle;//红外
                telephotoRealWndHandle = telephotoPictureBox.Handle;//广角
            }));
            Thread Thread = new Thread(new ThreadStart(realPlay));
            Thread.Start();

            //处理双屏
            if (MainWindow.doubleScreen == true)
                //双屏
            {
                Dispatcher.Invoke(new Action(()=>
                    {
                    MainWindow.doubles.startPlay();
                }));         
            }
            
        }
        public static int updataPictureBack(string user, string sPassword, string localPath, string serverIp, string serverPath)//图片上传
        {
            int rst = NVRCsharpDemo.DVRAPI.GetInstance().Upload_Picture(user, sPassword, localPath, serverIp, serverPath);
            return rst;
        }

        /*光电视频播放模块（end）*************************************************************************************/
        private void YimaEncCtrl_ShowMessage(string message)
        {
            this.Dispatcher.Invoke(new Action(() =>//必须在UI线程中进行后台操作，否则后台操作是无法实现并且报错的。
            {
                MessageBoxX.Show("海图提示", message);
            }));
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

        private void AlarmRefresh(object sender, EventArgs e)//报警列表刷新
        {
            for(int i = 0; i < alarmList.Count; i++)
            {
                if ((DateTime.Now - DateTime.Parse(alarmList[i].AlarmTime)).TotalSeconds >= 24*3600)
                {
                    alarmList.RemoveAt(i);
                    if (i < alarmList.Count)
                        i--;
                };
            }
            /*int b = alarmList.Count;
            for (int j = b-a; j > 0; j--)
            {
                alarmList.RemoveAt(a);
            }*/ 
        }

        /*融合参数设置模块（start）**********************************************************************************/
        public static void FusionBack()//融合参数设置函数
        {
            //模拟发送融合参数
            FUS_ICD.FusPara_S fuspara = new FUS_ICD.FusPara_S();
            fuspara.fXYZThreshold = FusionParameterSetting.fXYZThreshold;
            fuspara.fDisThreshold = FusionParameterSetting.fDisThreshold;
            fuspara.fAngleThreshold = FusionParameterSetting.fAngleThreshold;
            fuspara.ucAlarmThreshold = FusionParameterSetting.ucAlarmThreshold;
            fuspara.lRdDieTime = FusionParameterSetting.lRdDieTime;
            fuspara.lAISDieTime = FusionParameterSetting.lAISDieTime;
            fuspara.lM = FusionParameterSetting.lM;
            fuspara.lN = FusionParameterSetting.lN;
            fuspara.UcEstiArith = FusionParameterSetting.UcEstiArith;
            byte[] reserve = new byte[2];
            fuspara.reserve = reserve;
            App app = (App)App.Current;

            device.SendFusParaS(fuspara);
            FuseParas fus = new FuseParas();
            fus.XYZThreshold = fuspara.fXYZThreshold;
            fus.DisThreshold = fuspara.fDisThreshold;
            fus.AngleThreshold = fuspara.fAngleThreshold;
            fus.AlarmThreshold = fuspara.ucAlarmThreshold;
            fus.RadarDieTime = (int)fuspara.lRdDieTime;
            fus.AISDieTime = (int)fuspara.lAISDieTime;
            fus.IM = (int)fuspara.lM;
            fus.IN = (int)fuspara.lN;
            fus.EstiArith = (int)fuspara.UcEstiArith;
            fuse.UpdateFuseArea(fus);
            var a = 1;
        }
        /*融合参数设置模块（end）***********************************************************************************/

        public void hand()//鼠标小手
        {
            formshost.Cursor = System.Windows.Input.Cursors.Hand;
        }
        public void point()//鼠标指针
        {
            formshost.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        /*保护区域设置模块（start）*********************************************************************************/
        //添加区域分为绘图开始函数，绘图结束两个函数
        public static bool AddedForbiddenZoneBack()//添加多边形区域[绘图开始]
        {
            //模拟多边形区域设置（创建）
            bool a=true;
            App app = (App)App.Current;
            a=app.chartCtrl.StartAddForbiddenZone();
            return a;
        }
        public static bool AddedPipelineBack()//添加管道区域[绘图开始]
        {
            //模拟管道区域设置（创建）
            bool a = true;
            App app = (App)App.Current;
            a=app.chartCtrl.StartAddPipeline();
            return a;
        }
        private static void YimaEncCtrl_AddedForbiddenZone(ForbiddenZone f)//添加多边形区域回调函数[绘图结束]
        {
            
            App app = (App)App.Current;
            MonitoringInterface.moninterface.polyBack();//按钮警用状态

            if (f == null)
            {
                //nothing
            }
            else
            {
                PolygonDialog w = new PolygonDialog();//多边形命名的弹窗
                System.Windows.Application.Current.MainWindow = w;
                w.ShowDialog();


                for (int j = 215; j > 210; j--)
                {
                    int count = 0;

                    for (int i = 0; i < app.chartCtrl.ForbiddenZoneList.Count; i++)
                    {
                        if (j == app.chartCtrl.ForbiddenZoneList[i].ID)
                        {
                            count = 1;
                        }
                    }

                    if (count == 0)
                    {
                        f.ID = j;
                    }
                }

                f.Name = PolygonDialog.polygonNameText;//多边形区域名称存入

                int aLarmRank = (int)double.Parse(PolygonDialog.aLarmRankText);

                FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];//回传给融合数据
                for (int i = 0; i < f.PointList.Count; i++)
                {
                    points[i].dLati = f.PointList[i].x;
                    points[i].dLongti = f.PointList[i].y;
                    points[i].fHeight = 0;
                };

                FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
                test.ucAlarmLevel = (byte)aLarmRank;
                test.ucPolygonAlarmNum = (byte)(210 + aLarmRank);
                test.ucPotNum = Convert.ToByte(f.PointList.Count);
                test.PotArray = points;
                device.SetAlarmAear(test, 2, 4);

                string polygon_alert_area_ID = "";//id
                string uc_alarm_level = "";//报警等级
                string polygon_alert_area_name = "";//区域名称
                string polygon_alert_area_string = "";//点构成string
                string polygon_alert_area_ucPotNum = "";//点数
                string log = PolygonDialog.logText;//备注
                f.Remark = log;

                polygon_alert_area_ID = f.ID.ToString();
                uc_alarm_level = "4";
                f.AlarmLevel = (int)double.Parse(uc_alarm_level);
                polygon_alert_area_name = PolygonDialog.polygonNameText;

                int pointNumber = 0;
                for (int i = 0; i < f.PointList.Count; i++)//拼接点字符串
                {
                    int x = f.PointList[i].x;
                    int y = f.PointList[i].y;
                    int z = 0;

                    polygon_alert_area_string += x.ToString() + "," + y.ToString() + "," + z.ToString() + ";";
                    pointNumber++;
                };
                polygon_alert_area_ucPotNum = pointNumber.ToString();

                polygonDate.UpdatePolygonArea(f, app.chartCtrl.GetGeoMultiFactor());//多边形入库
            }
        }
        private static void YimaEncCtrl_AddedPipeline(Pipeline p)//添加管道区域回调函数[绘图结束]
        {
            App app = (App)App.Current;

            MonitoringInterface.moninterface.pipeBack();//按钮警用状态

            if (p == null)
            {
                //nothing
            }
            else
            {
                PipelineDialog w = new PipelineDialog();//管道命名弹窗
                System.Windows.Application.Current.MainWindow = w;
                w.ShowDialog();

                for (int j = 225; j > 220; j--)
                {
                    int count = 0;

                    for (int i = 0; i < app.chartCtrl.PipelineList.Count; i++)
                    {
                        if (j == app.chartCtrl.PipelineList[i].ID)
                        {
                            count = 1;
                        }
                    }

                    if (count == 0)
                    {
                        p.ID = j;
                    }
                }

                p.Name = PipelineDialog.pipelineNameText;
                p.width = (int)double.Parse(PipelineDialog.pipelineWidthText);
                int aLarmRank = 4;
                p.AlarmLevel = aLarmRank;

                FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];

                for (int i = 0; i < p.PointList.Count; i++)
                {
                    points[i].dLati = p.PointList[i].x;
                    points[i].dLongti = p.PointList[i].y;
                    points[i].fHeight = 0;
                };

                FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
                test.ucAlarmLevel = (byte)aLarmRank;
                test.ucPolygonAlarmNum = (byte)(220 + aLarmRank);
                test.ucPotNum = Convert.ToByte(p.PointList.Count);
                test.PotArray = points;

                device.SetAlarmAear(test, 3, 4);

                string protect_area_ID = "";//id
                string protect_area_name = "";//区域名称
                string protect_area_string = "";//点构成string
                string protect_area_ucPotNum = "";//点数
                string protect_area_level = "";//报警等级
                string protect_r = "";//管道直径
                string log = PipelineDialog.logText;//备注
                p.Remark = log;
                protect_area_ID = p.ID.ToString();
                protect_area_name = PipelineDialog.pipelineNameText;

                int pointNumber = 0;
                for (int i = 0; i < p.PointList.Count; i++)
                {
                    int x = p.PointList[i].x;
                    int y = p.PointList[i].y;
                    int z = 0;

                    protect_area_string += x.ToString() + "," + y.ToString() + "," + z.ToString() + ";";

                    pointNumber++;
                };
                protect_area_ucPotNum = pointNumber.ToString();
                protect_r = PipelineDialog.pipelineWidthText;

                protect_area_level = "4";

                pipeLine.UpdatePipeLineProtectArea(p, app.chartCtrl.GetGeoMultiFactor());
                //管道入库
            }
        }
        public static void updataProtectZoneBack(string id, string name, string r, string color)//更新圈层保护区
        {
            App app = (App)App.Current;

            ProtectZone target = app.chartCtrl.FindProtectZoneByName(name);

            FUS_ICD.Alarm_Dot_S centerPoint = new FUS_ICD.Alarm_Dot_S();
            centerPoint.dLongti = 0f;
            centerPoint.dLati = 0f;
            centerPoint.fHeight = 0f;

            FUS_ICD.Alarm_Circle_S circle = new FUS_ICD.Alarm_Circle_S();
            circle.fAlarmR = (float)double.Parse(r);//报警半径
            if (id == "201")
            {
                circle.ucAlarmLevel = 2;//报警等级
            }
            else if (id == "202")
            {
                circle.ucAlarmLevel = 3;//报警等级
            }
            else if (id == "203")
            {
                circle.ucAlarmLevel = 4;//报警等级
            }
            circle.ucCycleAlarmNum = (byte)double.Parse(id);//告警编号【201-205】
            circle.AlarmCenter = centerPoint;//报警中心
            System.Drawing.Color colorValue = ColorTranslator.FromHtml(color);//颜色转换

            ThreadPool.QueueUserWorkItem(_ => updateTime(name, r, colorValue));//在线程中修改,更新ui

            device.SetAlarmAear(circle, 1, circle.ucAlarmLevel);

            int uc_cycle_alarm_num;//告警圈层
            float f_alarm_r = 0f;//告警半径
            uc_cycle_alarm_num = (int)double.Parse(id);
            f_alarm_r = (float)double.Parse(r) * 1000;//换算单位

        }
        private static void updateTime(string name, string r, System.Drawing.Color colorValue)//修改圈层参数的ui线程
        {
            while (true)
            {
                App app = (App)App.Current;
                ProtectZone obj = app.chartCtrl.FindProtectZoneByName(name);//报警名称（海图)
                obj.Radius = (float)double.Parse(r) * 1000;
                obj.ContentColor = colorValue;
                obj.AlarmLevel = obj.ID - 199;
                circleData.UpdateCircleProtectArea(obj, app.chartCtrl.GetGeoMultiFactor());//圈层更新入库
                break;
            }
        }
        //更新多边形保护区

        //更新管道保护区

        //删除多边形保护区
        public static void deleteForbiddenZone(string name, int num)//通过name
        {
            App app = (App)App.Current;
            var a = app.chartCtrl.ForbiddenZoneList;
            app.chartCtrl.DeleteForbiddenZoneByName(name);
            device.CancelAlarmAear(2, num);
        }

        //删除管道保护区
        public static void deletePipeline(string name, int num)//通过name
        {
            App app = (App)App.Current;
            var a = app.chartCtrl.PipelineList;
            app.chartCtrl.DeletePipelineByName(name);
            device.CancelAlarmAear(3, num);
        }

        /*保护区域设置模块（end）*********************************************************************************/
        private void ShowState(Photoelectricity.DRSN drsn)//光电设备状态回调函数
        {
            if (foll != null)
            {
                foll.followPointMove(drsn.WaveGateCenterCoordinateX, drsn.WaveGateCenterCoordinateY);
            }
            if (MainWindow.doubles != null)
            {
                MainWindow.doubles.followPointMove(drsn.WaveGateCenterCoordinateX, drsn.WaveGateCenterCoordinateY);
            }
            this.Dispatcher.Invoke(new Action(() =>//必须在UI线程中进行后台操作，否则后台操作是无法实现并且报错的。
            {
                TcAngle.Text = drsn.TcviewingAngle;
                redAngle.Text = drsn.InfviewAngle;
                horizontalAngle.Text = drsn.OpticalAxisHorizontalAngle;
                verticalAngle.Text = drsn.OpticalAxisPitchAngle;

                int angles=(int)double.Parse(drsn.TcviewingAngle);
                int angle=(int)double.Parse(drsn.OpticalAxisHorizontalAngle);
                App app = (App)App.Current;
                app.chartCtrl.SetOptAngle(angle);
                app.chartCtrl.SetOptScanAngle(angles);
            }));
            if (drsn.PhotoelectricEquipmentRuningState == 0)
            {
                photoelectricEquipmentRuningStateStr = "故障";//光电设备开机状态
            }
            else if (drsn.PhotoelectricEquipmentRuningState == 1)
            {
                photoelectricEquipmentRuningStateStr = "正常";//光电设备开机状态
            }
            pitchDriveModeStr = drsn.PitchDriveMode;//俯仰驱动模式
            bearingDriveModeStr = drsn.BearingDriveMode;//方位驱动模式

            pitchDriveLimitUpStr = drsn.PitchDriveLimitUp;//俯仰驱动上限度位
            pitchDriveLimitDownStr = drsn.PitchDriveLimitDown;//俯仰驱动上下度位
            bearingDriveLimitLeftStr = drsn.BearingDriveLimitLeft;//俯仰驱动左限度位
            bearingDriveLimitRightStr = drsn.BearingDriveLimitRight;//俯仰驱动右限度位
            videoSwitchStateStr = drsn.VideoSwitchState;//当前视频显示
            controllerInitializationStateStr = drsn.ControllerInitializationState;//控制器初始化状态
            servoStateStr = drsn.ServoState;//伺服状态


            hardDiskVideoStatusStr = drsn.HardDiskVideoStatus;//硬盘录像机状态
            wideAngledCameraStatusStr = drsn.WideAngledCameraStatus;//广角摄像机状态
            telephotoCameraStatusStr = drsn.TelephotoCameraStatus;//长焦摄像机状态

            targetTrackingStateStr = drsn.TargetTrackingState;//目标跟踪状态
            videoTrackingStatusStr = drsn.VideoTrackingStatus;//视频跟踪状态
            if (drsn.MovingTargetDetection == 0)
            {
                movingTargetDetectionStr = "无效";//移动目标侦测控制
            }
            else if (drsn.MovingTargetDetection == 1)
            {
                movingTargetDetectionStr = "有效";
            }
            pitchAngleMeasurementStr = drsn.PitchAngleMeasurement;//俯仰侧角状态
            azimuthAngleMeasurementStr = drsn.AzimuthAngleMeasurement;//方位测角状态
            waveGateCenterCoordinateYControlStr = drsn.WaveGateCenterCoordinateYControl;//门中心点Y控制
            waveGateCenterCoordinateXControlStr = drsn.WaveGateCenterCoordinateXControl;//门中心点X控制
            pitchMissDistanceControlStr = drsn.PitchMissDistanceControl;//俯仰脱靶量控制
            azimuthMissDistanceControlStr = drsn.AzimuthMissDistanceControl;//方位脱靶量控制
            WaveGateCenterCoordinateX = drsn.WaveGateCenterCoordinateX;
            WaveGateCenterCoordinateY = drsn.WaveGateCenterCoordinateY;
            OpticalAxisHorizontalAngle = drsn.OpticalAxisHorizontalAngle;
            OpticalAxisPitchAngle = drsn.OpticalAxisPitchAngle;
            AzimuthMissDistance = drsn.AzimuthMissDistance;
            PitchMissDistance = drsn.PitchMissDistance;
            //20170419 蒋明昊 添加
            //光电状态刷新
            Dispatcher.Invoke(new Action(() =>
            {
                if (MonitoringInterface.CurrentContent != null && DeviceOperationStatus.optoelectronicp != null
                && DeviceOperationStatus.CurrentControl != null && MonitoringInterface.CurrentContent.Content == DeviceOperationStatus.GetInstance() 
                && DeviceOperationStatus.optoelectronicp!=null
                && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.optoelectronicp)
                {
                    DeviceOperationStatus.optoelectronicp.Fresh();
                }

                driveEnabledStateStr = drsn.DriveEnabledState;//驱动使能状态

                if (driveEnabledStateStr == "使能")
                {
                    driveSwitchButton.IsChecked = true;
                    powerState = 1;
                }
                else
                {
                    driveSwitchButton.IsChecked = false;
                    powerState = 0;
                }

                InfraredStateStr = drsn.InfraredState;//红外热像仪状态

                if (InfraredStateStr == "红外加电且正常")
                {
                    red.IsChecked = true;
                }
                else
                {
                    red.IsChecked = false;
                }
            }));
        }

        private void showstatus(int type, object obj)//网络硬件设备
        {
            App app = (App)App.Current;
            if (type == 1)
            {
                dataAnadll.FUS_ICD.Machine_NetWork_State target = (dataAnadll.FUS_ICD.Machine_NetWork_State)obj;

                SlpingstateValue = target.Slpingstate;//设备网络状态
                AISpingstateValue = target.AISpingstate;//AIS网络状态
                RaderpingstateValue = target.Raderpingstate;//雷达网络状态
                lightpingstateValue = target.lightpingstate;//光电网络状态
                DBPingValue = target.DBPing;//数据库网络状态
                clientApingValue = target.clientAping;//显控1网络状态
                clientBpingValue = target.clientBping;//显控2网络状态
                FusionPingValue = target.fusstatus;//融合网络状态

                //20170419 蒋明昊 添加
                //刷新显示窗口
                Dispatcher.Invoke(
                    new Action(() =>
                    {
                        if (MonitoringInterface.CurrentContent != null && MonitoringInterface.fullNetStatus != null && MonitoringInterface.fullNetStatus == MonitoringInterface.CurrentContent.Content)
                        //当前展示的是网络状态
                        {
                            MonitoringInterface.fullNetStatus.Fresh();
                        };
                        if (DeviceOperationStatus.optoelectronicp != null && lightpingstateValue == 1)
                        //光电断开
                        {
                            DeviceOperationStatus.optoelectronicp.Fresh_ASunlink();
                        }
                        if (RaderpingstateValue == 1) 
                            //雷达断开,删除雷达目标
                        {
                            app.chartCtrl.DeleteAllRadarTarget();
                            this.Dispatcher.Invoke(new Action(() =>
                                {
                                    if (MonitoringInterface.CurrentContent != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus && DeviceOperationStatus.radarFirstp != null && DeviceOperationStatus.CurrentControl != null && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.radarFirstp)
                                    {

                                        DeviceOperationStatus.radarFirstp.Fresh_Unlink();
                                    }
                                }));
                           
                        }
                        if (AISpingstateValue == 1)
                            //AIS断开,删除AIS目标
                        {
                            //app.chartCtrl.DeleteAllAISTarget();
                        }
                    
                        if (FusionPingValue == 1)
                            //融合断开,全部删除
                        {
                            app.chartCtrl.DeleteAllMergeTarget();
                            app.chartCtrl.DeleteAllAISTarget();
                            app.chartCtrl.DeleteAllRadarTarget();
                        }
                        bridge.Device_change(target.Raderpingstate, target.Raderpingstate, target.AISpingstate,lightpingstateValue);
                        bridge.Tip_change(PrerecvAIS, PrerecvRader, PrerecvFus, ProcessFus, app.chartCtrl.AISTargetList.Count, app.chartCtrl.RadarTargetList.Count, app.chartCtrl.MergeTargetList.Count);
                     
                    }
                 ));
            }
            else if (type == 2)
            {
                dataAnadll.FUS_ICD.Machine_Hardware_State target = (dataAnadll.FUS_ICD.Machine_Hardware_State)obj;
                Machines = target.Machine_id;
                CPU = target.CPUrate;
                Room = target.Roomrate;
                Disk = target.Diskrate;

                //刷新显示窗口
                Dispatcher.Invoke(new Action(() =>
                {
                    switch (Machines)
                    {
                        case 1:
                            //融合服务器
                            if (MonitoringInterface.CurrentContent != null && MonitoringInterface.deviceOperationStatus != null 
                            && DeviceOperationStatus.CurrentControl != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus 
                            && DeviceOperationStatus.CurrentControl.Content != null 
                            && DeviceOperationStatus.mixServerp!=null
                            && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.mixServerp)
                            //当前显示的设备的硬件状态,并且是显示硬件状态
                            {
                                DeviceOperationStatus.mixServerp.Fresh(CPU, 40, Room, Disk);
                            }

                            break;
                        case 2:
                            //数据库服务器
                            if (MonitoringInterface.CurrentContent != null && MonitoringInterface.deviceOperationStatus != null && DeviceOperationStatus.CurrentControl != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus && DeviceOperationStatus.CurrentControl.Content != null && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.dataServerp)
                            //当前显示的设备的硬件状态,并且是显示硬件状态
                            {
                                DeviceOperationStatus.dataServerp.Fresh(CPU, 40, Room, Disk);
                            }
                            break;
                        case 3:
                            //显控A
                            if (MonitoringInterface.CurrentContent != null && MonitoringInterface.deviceOperationStatus != null 
                                && DeviceOperationStatus.CurrentControl != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus 
                                && DeviceOperationStatus.CurrentControl.Content != null 
                                && DeviceOperationStatus.monitoringFirstp!=null
                                && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.monitoringFirstp)
                            //当前显示的设备的硬件状态,并且是显示硬件状态
                            {
                                DeviceOperationStatus.monitoringFirstp.Fresh(CPU, 40, Room, Disk);
                            }
                            break;
                        case 4:
                            //显控B
                            if (MonitoringInterface.CurrentContent != null && MonitoringInterface.deviceOperationStatus != null
                            && DeviceOperationStatus.CurrentControl != null
                            && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus
                            && DeviceOperationStatus.CurrentControl.Content != null
                            && DeviceOperationStatus.monitoringSecondp != null
                            && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.monitoringSecondp)
                            //当前显示的设备的硬件状态,并且是显示硬件状态
                            {
                                DeviceOperationStatus.monitoringSecondp.Fresh(CPU, 40, Room, Disk);
                            }
                            break;
                    }
                }));
            }
            else if (type == 3)
            {
                dataAnadll.FUS_ICD.AIS_AlrTxt target = (dataAnadll.FUS_ICD.AIS_AlrTxt)obj;
                channe = target.channe_alert; //天线信道报警 0正常 1有故障
                genaral = target.genaral_alert; //通用模块报警 0正常 1 一般故障
                clock = target.clock_alert; //时钟报警 0正常 1有故障
                MKD = target.MKD_alert; //MKD报警 0正常 1 有故障
                EPFS = target.EPFS_alert; //电子定位系统报警 0正常 1丢失
                sensor = target.sensor_alert;//传感器报警 0正常  1故障
                information = target.information_alert; //信息状态报警  0正常 1有无效信息故障
                Machine = target.Machine_State; // ais多部件状态txt信息（非报警） 0表示未发出状态 
                //刷新显示窗口
                Dispatcher.Invoke(new Action(() =>
                {
                    //;
                    //if (MonitoringInterface.CurrentContent != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus && DeviceOperationStatus.aisp != null && DeviceOperationStatus.aisp == DeviceOperationStatus.CurrentControl.Content)

                    if(DeviceOperationStatus.aisp!=null)
                    //当前显示的是设备状态,并且显示的是AIS面板
                    {
                        DeviceOperationStatus.aisp.Fresh();
                    }
                }
                ));
            }
            else if (type == 4)
                //雷达设备状态
            {
                Dispatcher.Invoke(new Action(() =>
                    {
                        //if (MonitoringInterface.CurrentContent != null && MonitoringInterface.CurrentContent.Content == MonitoringInterface.deviceOperationStatus && DeviceOperationStatus.radarFirstp != null && DeviceOperationStatus.CurrentControl != null && DeviceOperationStatus.CurrentControl.Content == DeviceOperationStatus.radarFirstp)

                        if(DeviceOperationStatus.radarFirstp!=null)
                        {
 
                            DeviceOperationStatus.radarFirstp.Fresh((dataAnadll.FUS_ICD.RdStatus_S) obj);
                        }
                    }
                    ));
            }
        }
        private void SyncInfo(int type,double dScanCourse,float fSacanSpeed)//显控同步数据
        {
            App app = (App)App.Current;
            if (type == 177)
            {
                //平台中心设置
                double longi = 0;
                double lati = 0;
                platform.GetPlatform(out longi, out lati);//查询平台中心
                center[0] = longi;
                center[1] = lati;
                app.chartCtrl.SetPlatform(center[0], center[1]);//初始化平台中心坐标
                app.chartCtrl.CenterMap(center[0], center[1]);//初始化视角中心坐标
            }
            if (type == 200)
            {
                //融入
            }
            if (type >= 201 && type <= 205)
            {
                app.chartCtrl.DeleteProtectZoneByID(201);
                app.chartCtrl.DeleteProtectZoneByID(202);
                app.chartCtrl.DeleteProtectZoneByID(203);

                List<ProtectZone> list0 = circleData.GetAllCircleProtectArea(app.chartCtrl.GetGeoMultiFactor());//圈层数据初始化

                for (int i = 0; i < list0.Count; i++)
                {
                    app.chartCtrl.AddProtectZone(list0[i]);//初始化圈层
                }
            }

            if ((type >= 211 && type <= 215) || (type >= 241 && type <= 245))
            {

                for (int i = 0; i < app.chartCtrl.ForbiddenZoneList.Count; i++)
                {
                    app.chartCtrl.DeleteForbiddenZoneByID(app.chartCtrl.ForbiddenZoneList[i].ID);
                }

                List<ForbiddenZone> list1 = polygonDate.GetAllPolygonArea(app.chartCtrl.GetGeoMultiFactor());//多边形所有目标      
                for (int i = 0; i < list1.Count; i++)
                {
                    app.chartCtrl.AddForbiddenZone(list1[i]);
                }
            }

            if (type >= 221 && type <= 225 || (type >= 251 && type <= 255))
            {

                for (int i = 0; i < app.chartCtrl.PipelineList.Count; i++)
                {
                    app.chartCtrl.DeletePipelineByID(app.chartCtrl.PipelineList[i].ID);
                }

                List<Pipeline> list2 = pipeLine.GetAllPipeLineProtectArea(app.chartCtrl.GetGeoMultiFactor());//管道所有目标
                for (int i = 0; i < list2.Count; i++)
                {
                    app.chartCtrl.AddPipeline(list2[i]);
                }
            }
            if (type == 1)
            {
                app.chartCtrl.SetRadarAngle((int)dScanCourse, 1);
                app.chartCtrl.SetRadarSpeed((double)fSacanSpeed, 1);
            }

            if (type == 2)
            {
                app.chartCtrl.SetRadarAngle((int)dScanCourse, 2);
                app.chartCtrl.SetRadarSpeed((double)fSacanSpeed, 2);
            }

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

        int PrerecvAIS=0;
        int PrerecvRader=0;
        int PrerecvFus=0;
        int ProcessFus=0;
        int aisCnt = 0;
        int raderCnt = 0;
        int fusionCnt = 0;
        public void get(int tip, object data)//航船目标AIS，雷达，融合数据接收回调函数
        {
            App app = (App)App.Current;


            Target mapTarget = (Target)data;//通信object强制转换为target

            if (mapTarget.Source == TargetSource.AIS)
            {
                PrerecvAIS++;
            }
            else if (mapTarget.Source == TargetSource.Merge)
            {
                PrerecvFus++;
            }
            else if (mapTarget.Source == TargetSource.Radar)
            {
                PrerecvRader++;
            }
            if (linkageContral == 2 || YimaLinkageControl == 2)
            //开启多次联动,列表的多次联动与海图上的多次联动
            {
                if (linkageTarget.TargetID>=0)
                {
                    if (mapTarget.ID ==linkageTarget.TargetID && (linkageTarget.TargetType ==(int)mapTarget.Source ))
                    //相同目标，ID相同，同时ID的类型相同
                    //linkageTarget保证了自动联动的目标
                    {
                       int sendTime = GetTimeStamp();
                       PhotoelectricParas data1 = photo.GetPhotoelectricParas();//数据库查询光电参数
                       photoHeight = data1.SetHeight;
                       Photoelectricity.PhotoelectricLinkage(sendTime, mapTarget.Longitude, mapTarget.Latitude, center[0], center[1], 2, photoHeight);//视频转向
                    }
                }
                //else
                //{
                //    this.Dispatcher.Invoke(new Action(() =>
                //    {
                //        MessageBoxX.Show("提示","未选择目标！");
                //    }
                //    ));
                    
               // }
            }
            this.Dispatcher.BeginInvoke(new Action(() =>//必须在UI线程中进行后台操作，否则后台操作是无法实现并且报错的。
            {
                if (mapTarget.Source == TargetSource.AIS)
                {//ais数据 
                    //PrerecvAIS++;
                    if (tip == 0)
                    {
                        yimaEncCtrl.AddAISTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加AIS目标
                    }
                    else if (tip == 1)
                    {
                        yimaEncCtrl.UpdateAISTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新AIS目标
                    }
                    else if (tip == 2)
                    {
                        yimaEncCtrl.DeleteAISTarget(mapTarget.ID);//删除AIS目标
                    }
                    

                }
                else if (mapTarget.Source == TargetSource.Radar)
                {//雷达数据
                    if (tip == 0)
                    {
                        yimaEncCtrl.AddRadarTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加雷达目标
                    }
                    else if (tip == 1)
                    {
                        yimaEncCtrl.UpdateRadarTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新雷达目标
                    }
                    else if (tip == 2)
                    {
                        yimaEncCtrl.DeleteRadarTarget(mapTarget.RadarID, mapTarget.ID);//删除雷达目标
                    }
                }
                else if (mapTarget.Source == TargetSource.Merge)
                {//融合数据
                    //PrerecvFus++;
                    if (tip == 0)
                    {
                        yimaEncCtrl.AddMergeTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//添加融合目标
                    }
                    else if (tip == 1)
                    {
                        yimaEncCtrl.UpdateMergeTarget(mapTarget, mapTarget.Longitude, mapTarget.Latitude);//更新融合目标
                    }
                    else if (tip == 2)
                    {
                        yimaEncCtrl.DeleteMergeTarget(mapTarget.ID);//删除融合目标
                    }
                    if (mapTarget.Action == AlarmAction.Into)
                    {
                        AlarmType at = (AlarmType)mapTarget.Alarm;
                        switch (at)
                        {
                            case AlarmType.ForbiddenZone:
                                poly++;
                                break;
                            case AlarmType.None:

                                break;
                            case AlarmType.Pipeline:
                                pipe += 1;
                                break;
                            //return "管道告警";
                            case AlarmType.Contact:
                                Pintai += 1;
                                break;
                            //return "平台接触告警";
                            case AlarmType.ExpulsionArea:
                                Quzhu += 1;
                                break;
                            //return "驱逐区告警";
                            case AlarmType.AlertArea:
                                Jingjie += 1;
                                break;
                            //return "警戒区告警";
                            case AlarmType.EarlyWarningArea:
                                Yujing += 1;
                                break;
                            //return "预警区告警";
                            case AlarmType.Checked:
                            //return "已确认";
                            default:
                                break;
                        }
                    }
                    else if (mapTarget.Action == AlarmAction.Out)
                    {
                        AlarmType at = (AlarmType)mapTarget.Alarm;
                        switch (at)
                        {
                            case AlarmType.ForbiddenZone:
                                poly--;
                                break;
                            case AlarmType.None:

                                break;
                            case AlarmType.Pipeline:
                                pipe--;
                                break;
                            //return "管道告警";
                            case AlarmType.Contact:
                                Pintai--;
                                break;
                            //return "平台接触告警";
                            case AlarmType.ExpulsionArea:
                                Quzhu--;
                                break;
                            //return "驱逐区告警";
                            case AlarmType.AlertArea:
                                Jingjie--;
                                break;
                            //return "警戒区告警";
                            case AlarmType.EarlyWarningArea:
                                Yujing--;
                                break;
                            //return "预警区告警";
                            case AlarmType.Checked:
                            //return "已确认";
                            default:
                                break;
                        }

                    }

                    bridge.Alarm_change(pipe, poly, Yujing, Quzhu, Jingjie, Pintai);
                    ProcessFus++;
                };             
            }));

            this.Dispatcher.BeginInvoke(new Action (()=>
                {
                bridge.Tip_change(PrerecvAIS, PrerecvRader, PrerecvFus, ProcessFus,app.chartCtrl.AISTargetList.Count,app.chartCtrl.RadarTargetList.Count,app.chartCtrl.MergeTargetList.Count);
            }));
        }
        private void ListView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//列表联动事件(所有)
        {
            App app = (App)App.Current;
            int sendTime = GetTimeStamp();
            System.Windows.Controls.ListView lv = sender as System.Windows.Controls.ListView;
            lv.ScrollIntoView(lv.SelectedItem);

            if (lv.Name == listViewState && listViewState == "allListView")
            {
                //"allListView"

                //0419 蒋明昊 添加
                if (allListView.SelectedIndex < 0)
                {
                   // nowTarget = null;
                    linkageTarget.TargetID = -1;
                    return;
                }

                Target targetAll = app.chartCtrl.AllTargetList[allListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetAll;
                app.chartCtrl.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
                linkageTarget.TargetID = nowTarget.ID;
                linkageTarget.TargetType = (int)nowTarget.Source;
            }
            else if (lv.Name == listViewState && listViewState == "AISListView")
            {
                //"AISListView"
                //0419 蒋明昊 添加
                if (AISListView.SelectedIndex < 0)
                {
                    //nowTarget = null;
                    linkageTarget.TargetID = -1;
                    return;
                }

                Target targetAis = app.chartCtrl.AISTargetList[AISListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetAis;
                app.chartCtrl.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
                linkageTarget.TargetID = nowTarget.ID;
                linkageTarget.TargetType = (int)nowTarget.Source;
            }
            else if (lv.Name == listViewState && listViewState == "radarListView")
            {
                //"radarListView":

                //0419 蒋明昊 添加
                if (radarListView.SelectedIndex < 0)
                {
                    //nowTarget = null;
                    linkageTarget.TargetID = -1;
                    return;
                }
                Target targetRadar = app.chartCtrl.RadarTargetList[radarListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetRadar;
                app.chartCtrl.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
                linkageTarget.TargetID = nowTarget.ID;
                linkageTarget.TargetType = (int)nowTarget.Source;
            }
            else if (lv.Name == listViewState && listViewState == "mixListView")
            {
                //"mixListView"

                //0419 蒋明昊 添加
                if (mixListView.SelectedIndex < 0)
                {
                    //nowTarget = null;
                    linkageTarget.TargetID = -1;
                    return;
                }
                Target targetMix = app.chartCtrl.MergeTargetList[mixListView.SelectedIndex];//获取选中target的经纬度
                nowTarget = targetMix;
                app.chartCtrl.SetSelectedTarget(nowTarget);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (nowTarget.ID == alarmList[i].ID)
                    {
                        alarmList[i].IsSelected = nowTarget.IsSelected;
                        break;
                    }
                }
                linkageTarget.TargetID = nowTarget.ID;
                linkageTarget.TargetType = (int)nowTarget.Source;
            }

            if (linkageContral == 0)
            {
                //nothing
            }
            else if (linkageContral == 1)
            {


            }
            else if (linkageContral == 2)
            {


            }
        }

        private void TargetConvertClick(object sender, System.Windows.Input.MouseButtonEventArgs e)//列表双击事件
        {
            ListView lv = sender as ListView;
            if (lv.SelectedIndex < 0) return;
            App app = (App)App.Current;
            Target t;
            switch (lv.Name)
            {
                case "allListView": t = app.chartCtrl.AllTargetList[lv.SelectedIndex];
                    app.chartCtrl.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "AISListView": t = app.chartCtrl.AISTargetList[lv.SelectedIndex];
                    app.chartCtrl.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "radarListView": t = app.chartCtrl.RadarTargetList[lv.SelectedIndex];
                    app.chartCtrl.CenterMap(t.Longitude, t.Latitude);
                    break;
                case "mixListView": t = app.chartCtrl.MergeTargetList[lv.SelectedIndex];
                    app.chartCtrl.CenterMap(t.Longitude, t.Latitude);
                    break;
            }
        }

        private void TargetConvertClick_2(object sender, System.Windows.Input.MouseButtonEventArgs e)//告警列表双击事件
        {
            ListView lv = sender as ListView;
            if (lv.SelectedIndex < 0) return;
            App app = (App)App.Current;
            for (int i = 0; i < app.chartCtrl.AlarmTargetList.Count; i++)
                if (app.chartCtrl.AlarmTargetList[i].ID == alarmList[lv.SelectedIndex].ID)
                {
                    app.chartCtrl.CenterMap(app.chartCtrl.AlarmTargetList[i].Longitude, app.chartCtrl.AlarmTargetList[i].Latitude);
                    break;
                }
        }

        private void SortClick(object sender, RoutedEventArgs e)//列表排序
        {
            ListView lv = sender as ListView;
            App app = (App)App.Current;
            if (e.OriginalSource is GridViewColumnHeader)
            { 
                GridViewColumn clickedColumn = (e.OriginalSource as GridViewColumnHeader).Column; 
                if (clickedColumn != null)
                {
                    if(lv.Name=="allListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.chartCtrl.AllTargetList.Count; i++)
                            tempList.Add(app.chartCtrl.AllTargetList[i]);
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
                        app.chartCtrl.AllTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.chartCtrl.AllTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "AISListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.chartCtrl.AISTargetList.Count; i++)
                            tempList.Add(app.chartCtrl.AISTargetList[i]);
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
                        app.chartCtrl.AISTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.chartCtrl.AISTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "radarListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.chartCtrl.RadarTargetList.Count; i++)
                            tempList.Add(app.chartCtrl.RadarTargetList[i]);
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
                        app.chartCtrl.RadarTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.chartCtrl.RadarTargetList.Add(tempList[i]);
                    }
                    else if (lv.Name == "mixListView")
                    {
                        List<Target> tempList = new List<Target>();
                        for (int i = 0; i < app.chartCtrl.MergeTargetList.Count; i++)
                            tempList.Add(app.chartCtrl.MergeTargetList[i]);
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
                        app.chartCtrl.MergeTargetList.Clear();
                        for (int i = 0; i < tempList.Count; i++)
                            app.chartCtrl.MergeTargetList.Add(tempList[i]);
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

        public void link_manual()
        //手动联动
        {
            if (linkageTarget.TargetID == -1)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("光电视频提示", "未选中联动目标");
                }
                ));
                SetLinkageState(sign, new EventArgs());
                return;
            }

            if (videoState[0] < 0)
            //长焦视频

            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("光电视频提示", "视频无信号");
                }
                ));
                SetLinkageState(sign, new EventArgs());
                return;
            }
            int sendTime = GetTimeStamp();

            AutomaticLinkage w = new AutomaticLinkage();//联动窗口
            System.Windows.Application.Current.MainWindow = w;

            PhotoelectricParas data1 = photo.GetPhotoelectricParas();//数据库查询光电参数
            photoHeight = data1.SetHeight;
            Photoelectricity.PhotoelectricLinkage(sendTime, nowTarget.Longitude, nowTarget.Latitude, center[0], center[1], 1, photoHeight);//视频转向
            w.Closed += SetLinkageState;
            if (nowTarget.MIMSI != null)
                //雷达为空
            {
                CaptureImages._mmsi = nowTarget.MIMSI;
            }
            if (w.videoState < 0)
            {
                w.Close();
            }
            else
            {
                w.ShowDialog();
            }
           
        }

        public void link_auto()
            //自动联动的逻辑
        {
            if (linkageTarget.TargetID == -1)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("提示", "未选择目标！");
                }
                ));
                SetLinkageState(sign, new EventArgs());
                return;
            }
            if ( videoState[0] < 0)
            //长焦视频

            {

                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                      MessageBoxX.Show("光电视频提示", "视频无信号");
                }
));
              
         
               
                SetLinkageState(sign, new EventArgs());
                return;
            }
            int sendTime = GetTimeStamp();
            //去调用海图的手电联动即可。
            linkageTarget.TargetType = (int)nowTarget.Source;
            linkageTarget.TargetID = (int)nowTarget.ID;
            //linkageTarget.TargetID =nowTarget.
            //linkageTarget.TargetMMSI = nowTarget.MIMSI.ToString();
            //linkageContral = 2;
            AutomaticLinkage w = new AutomaticLinkage();//联动窗口           

            PhotoelectricParas data1 = photo.GetPhotoelectricParas();//数据库查询光电参数
            photoHeight = data1.SetHeight;
            Photoelectricity.PhotoelectricLinkage(sendTime, nowTarget.Longitude, nowTarget.Latitude, center[0], center[1], 1, photoHeight);//视频转向
            System.Windows.Application.Current.MainWindow = w;
            isLinkage++;//新增一个窗口用于自动联动 
            w.Closed += SetLinkageState;
            if (nowTarget.MIMSI != null)
            //雷达为空
            {
                CaptureImages._mmsi = nowTarget.MIMSI;
            }
            if (w.videoState < 0)
            {
                w.Close();
            }
            else
            {
                w.ShowDialog();
            }

        }

        public void YimaEncCtrl_SelectTarget(Target t)//海图选中目标回调
        {
            nowTarget = t;

            linkageTarget.TargetID = nowTarget.ID;
            linkageTarget.TargetType = (int)nowTarget.Source;

            for (int i = 0; i < alarmList.Count; i++)
            {
                if (nowTarget.ID == alarmList[i].ID)
                {
                    alarmList[i].IsSelected = nowTarget.IsSelected;
                    break;
                }
            }
        }
        public void YimaEncCtrl_ManualTrackTarget(Target t, double longitude, double latitude)//海图手动联动回调
        {
        }
        public void YimaEncCtrl_AutoTrackTarget(Target t, double longitude, double latitude)//海图自动联动回调
        {
        }
        /*截图------------------------------------------------------------------------------------------*/
        public static void captureImages()
        {
            if (linkageContral == 0 && YimaLinkageControl == 0)
            {
                //nothing(未进入联动状态),两个都没进入联动
            }
            else
            {
                Random rand = new Random();
                picfile_name = string.Format("picture{0}.png", rand.Next(0, 100000));
                picDirect = string.Format("{0}//..//..//CaptureImage//", System.Environment.CurrentDirectory);
                localPicPath = string.Format("{0}//..//..//CaptureImages//", System.Environment.CurrentDirectory);
                picfile_path = picDirect + picfile_name;
                NVRCsharpDemo.DVRAPI.GetInstance().Capture_Picture(videoState[0], picfile_path);//只截取长焦视频，图片文件路径
                eventCaputureTime = GetTimeStamps();
            }
        }
        /*截图------------------------------------------------------------------------------------------*/
        private void ListView2_SelectionChanged(object sender, SelectionChangedEventArgs e)//告警列表事件
        {
            if (warnListView.SelectedIndex >= 0)
            {
                int index = 0;
                for(int i = 0; i < warnListView.Items.Count; i++)
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
                for (int i = 0; i < app.chartCtrl.AlarmTargetList.Count; i++)
                    if (app.chartCtrl.AlarmTargetList[i].ID == alarmList[warnListView.SelectedIndex].ID)
                    {
                        app.chartCtrl.SetSelectedTarget(app.chartCtrl.AlarmTargetList[i]);
                        nowTarget = app.chartCtrl.AlarmTargetList[i];
                        break;
                    }
                warnListView.ScrollIntoView(warnListView.SelectedItem);
            }
        }
        public static long GetTimeStamps()//获得当前时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)ts.TotalSeconds;
        }
        public static DateTime GetTime(string timeStamp)//时间戳转化
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        public static int GetTimeStamp()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
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

        /*列表数据显示模块（end）***********************************************************************************/
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
        private void DimensionalControlUpClick(object sender, RoutedEventArgs e)//光电球上移
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    short RockerBearingDriveVolumeb = 0;
                    short RockerPitchDriveVolume = +200;
                    Photoelectricity.ThreeDimensionalControl(sendTime, RockerBearingDriveVolumeb, RockerPitchDriveVolume);
                }
                else if (powerState == 0)
                {
                    MessageBoxX.Show("提示", "未开启驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void DimensionalControlDownClick(object sender, RoutedEventArgs e)//光电球下移
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    short RockerBearingDriveVolumeb = 0;
                    short RockerPitchDriveVolume = -200;
                    Photoelectricity.ThreeDimensionalControl(sendTime, RockerBearingDriveVolumeb, RockerPitchDriveVolume);
                }
                else if (powerState == 0)
                {
                    MessageBoxX.Show("提示", "未开启驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void DimensionalControlLeftClick(object sender, RoutedEventArgs e)//光电球左移
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1) { 
                int sendTime = GetTimeStamp();
                short RockerBearingDriveVolumeb = -200;
                short RockerPitchDriveVolume = 0;
                Photoelectricity.ThreeDimensionalControl(sendTime, RockerBearingDriveVolumeb, RockerPitchDriveVolume);
            }
            else if (powerState == 0)
            {
                MessageBoxX.Show("提示", "未开启驱动！");
            }
        }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void DimensionalControlRightClick(object sender, RoutedEventArgs e)//光电球右移
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    short RockerBearingDriveVolumeb = +200;
                    short RockerPitchDriveVolume = 0;
                    Photoelectricity.ThreeDimensionalControl(sendTime, RockerBearingDriveVolumeb, RockerPitchDriveVolume);
                }
                else if(powerState == 0)
                {
                    MessageBoxX.Show("提示", "未开启驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void CameraLensRoomIncreaseClick(object sender, RoutedEventArgs e)//长焦变焦加
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomIncreaseStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void CameraLensRoomReduceClick(object sender, RoutedEventArgs e)//长焦变焦减
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomReduceStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void InfraredThermalImagerLensRoomIncreaseClick(object sender, RoutedEventArgs e)//红外变焦加
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomIncreaseStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void InfraredThermalImagerLensRoomReduceClick(object sender, RoutedEventArgs e)//红外变焦减
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomReduceStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void CameraLensFocusingIncreaseClick(object sender, RoutedEventArgs e)//长焦调焦加
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingIncreaseStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void CameraLensFocusingReduceClick(object sender, RoutedEventArgs e)//长焦调焦减
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingReduceStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void InfraredThermalImagerLensFocusingIncreaseClick(object sender, RoutedEventArgs e)//红外调焦加
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingIncreaseStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void InfraredThermalImagerLensFocusingReduceClick(object sender, RoutedEventArgs e)//红外调焦减
        {
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingReduceStart(sendTime);
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void redSwitchClick(object sender, RoutedEventArgs e)//红外开关
        {
            ToggleButton tb = sender as ToggleButton;
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {

                    if ((bool)tb.IsChecked)
                    {
                        int sendTime = GetTimeStamp();
                        Photoelectricity.ISetInfraredSwitch(sendTime, 1);
                    }
                    else
                    {
                        int sendTime = GetTimeStamp();
                        Photoelectricity.ISetInfraredSwitch(sendTime, 0);
                    }
                }else if (powerState == 0)
                {
                    tb.IsChecked = false;
                    MessageBoxX.Show("提示", "未开启驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                tb.IsChecked = false;
                MessageBoxX.Show("提示", "未获取控制权！");
                
            }
        }
        private void changeClick(object sender, RoutedEventArgs e)//红外矫正
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    Photoelectricity.ISetInfraredCameraImageCorrection(sendTime, 1);
                }else if (powerState == 0)
                {
                    MessageBoxX.Show("提示", "未打开驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void powerClick(object sender, RoutedEventArgs e)//驱动开关
        {
            ToggleButton tb = sender as ToggleButton;
            if (deviceControlState == 1)
            {
                int sendTime = GetTimeStamp();
                if ((bool)tb.IsChecked)
                {
                    int a = Photoelectricity.ISetDriveSwitch(sendTime, 1);
                    powerState = 1;
                }
                else
                {
                    int a = Photoelectricity.ISetDriveSwitch(sendTime, 0);
                    powerState = 0;
                }
            }
            else if (deviceControlState == 0)
            {
                tb.IsChecked = false;
                MessageBoxX.Show("提示", "未取得控制权！");
                
            }
        }
        private void ScanParameterSettingClick(object sender, RoutedEventArgs e)//扇扫开关
        {
            ToggleButton tb = sender as ToggleButton;
            if (deviceControlState == 1)
            {              
                if ((bool)tb.IsChecked)
                {
                    if (powerState == 1)
                    {
                        ScanParameterSetting w = new ScanParameterSetting();//扇扫参数设置界面
                        System.Windows.Application.Current.MainWindow = w;
                        w.ShowDialog();
                        if (ScanParameterSetting.rst == true)
                        //确认才扇扫
                        {
                            int a = GetTimeStamp();
                            Photoelectricity.IFanSweepStart(a, int.Parse(ScanParameterSetting.sp.angle1), int.Parse(ScanParameterSetting.sp.angle2), int.Parse(ScanParameterSetting.sp.percent));
                        }
                    }else if (powerState == 0)
                    {
                        tb.IsChecked = false;
                        MessageBoxX.Show("提示", "未打开驱动！");
                    }
                    else
                    {
                        tb.IsChecked = false;
                    }
                }
                else
                {
                    int a = GetTimeStamp();
                    Photoelectricity.IFanSweepEnd(a);
                }
            }
            else if (deviceControlState == 0)
            {
                tb.IsChecked = false;
                MessageBoxX.Show("提示", "未获取控制权！");

            }
        }
        public static void scanPa()
        {
            int a = GetTimeStamp();
            Photoelectricity.IFanSweepStart(a, int.Parse(ScanParameterSetting.sp.angle1), int.Parse(ScanParameterSetting.sp.angle2), int.Parse(ScanParameterSetting.sp.percent));
        }

        private void DimensionalControlRestartClick(object sender, RoutedEventArgs e)//光电重启
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    Photoelectricity.SystemShutDown(sendTime, 3);
                }else if (powerState == 0)
                {
                    MessageBoxX.Show("提示", "未开启驱动！");
                }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void DimensionalControlCloseClick(object sender, RoutedEventArgs e)//光电关闭
        {
            if (deviceControlState == 1)
            {
                if (powerState == 1)
                {
                    int sendTime = GetTimeStamp();
                    Photoelectricity.SystemShutDown(sendTime, 2);
                }else if (powerState == 0)
                {
                    MessageBoxX.Show("提示", "未开启驱动！");
                }

            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void deviceControlClick(object sender, RoutedEventArgs e)//主控开关
        {
            int sendTime = GetTimeStamp();
            ToggleButton tb = sender as ToggleButton;
            if ((bool)tb.IsChecked)
            {
                string message = "";
                int a = photoControl.GetPhotoelectricControl(MainWindow.userInfor.ID, out message);
                //a = true;////临时修改
                if (a >= 0)
                {
                    deviceControlState = 1;
                    tb.IsChecked = true;
                    tb.Content = "释放控制权";
                }
                else
                {
                    deviceControlState = 0;
                    tb.IsChecked = false;
                    driveSwitchButton.IsChecked = false;
                    MessageBoxX.Show("提示", message);
                    tb.Content = "获取控制权";
                }
            }
            else
            {

                if (!(bool)scan.IsChecked && !(bool)driveSwitchButton.IsChecked )
                    //红外可以不关闭
                {
                    bool a = photoControl.UpdatePhotoelectricControl(MainWindow.userInfor.ID);
                    if (a)
                    {
                        deviceControlState = 0;
                        tb.IsChecked = false;
                        scan.IsChecked = false;
                        red.IsChecked = false;
                        driveSwitchButton.IsChecked = false;
                        tb.Content = "获取控制权";
                    }
                    else
                    {
                        deviceControlState = 1;
                        tb.IsChecked = true;
                        MessageBoxX.Show("提示", "释放控制权失败！");
                        tb.Content = "释放控制权";
                    }
                }
                else
                {
                    tb.IsChecked = true;
                    MessageBoxX.Show("提示", "驱动或扇扫未关闭！");
                }
            }

        }
        public static void azimuthgyroDriveDriftCompensate(int offset)//螺旋方位补偿
        {
            int sendTime = GetTimeStamp();
            Photoelectricity.ISetazimuthgyroDriveDriftCompensate(sendTime,offset);
        }
        public static void pitchgyroDriveDriftCompensate(int offset)//螺旋俯仰补偿
        {
            int sendTime = GetTimeStamp();
            Photoelectricity.ISetpitchgyroDriveDriftCompensate(sendTime, offset);
        }
        public static void AzimuthDriveDriftCompensate(int offset)//驱动方位补偿
        {
            int sendTime = GetTimeStamp();
            Photoelectricity.ISetAzimuthDriveDriftCompensate(sendTime, offset);
        }
        public static void PitchDriveDriftCompensate(int offset)//驱动俯仰补偿
        {
            int sendTime = GetTimeStamp();
            Photoelectricity.ISetPitchDriveDriftCompensate(sendTime, offset);
        }
        public static void restart()//操纵杆重启
        {
            int sendTime = GetTimeStamp();
            Photoelectricity.OperationBoardCtr(sendTime,1);
        }

        /*控制面板-----------------------------------------------------------------------------------------*/

        /*光电追踪-----------------------------------------------------------------------------------------*/
        void longFocusPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//长焦追踪（开关）
        {
            if (deviceControlState == 1)
            {
            if ( videoState[0] < 0 )
                //长焦视频
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
  MessageBoxX.Show("光电视频提示", "视频无信号");
                }
));
              
                return;
            }

            if (!trackState)
            {
                trackState = true;
                trackStartTime = (long)GetTimeStamp();
                nowVideoType = 3;
                foll = new followVideo();
                    foll.Closed += follVideo_Closed;
                    System.Windows.Application.Current.MainWindow = foll;
                    foll.Show();
            }else
            {
                followVideos();
            }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        void infraredRayPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//红外追踪（开关）
        {
            if (deviceControlState == 1)
            {
            if ( videoState[1] < 0)
            //长焦视频

            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("光电视频提示", "视频无信号");
                }
));
             
                return;
            }
            if (!trackState)
            {
                trackState = true;
                trackStartTime = (long)GetTimeStamp();
                nowVideoType = 1;
                foll = new followVideo();
                    foll.Closed += follVideo_Closed;
                    System.Windows.Application.Current.MainWindow = foll;
                foll.Show();
            }else
            {
                followVideos();
            }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }

        }
        void telephotoPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//广角追踪（开关）
        {
            if (deviceControlState == 1)
            {
            if (videoState[2] < 0)
            //长焦视频

            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
 MessageBoxX.Show("光电视频提示", "视频无信号");
                }
));
               
                return;
            }
            
            if (!trackState)
            {
                trackState = true;
                trackStartTime = (long)GetTimeStamp();
                nowVideoType = 4;
                foll = new followVideo();
                    foll.Closed += follVideo_Closed;
                System.Windows.Application.Current.MainWindow = foll;
                foll.Show();
            }else
            {
                followVideos();
            }
            }
            else if (deviceControlState == 0)
            {
                MessageBoxX.Show("提示", "未获取控制权！");
            }
        }
        private void follVideo_Closed(object sender, object ee)
        {
            trackState = false;
        }
        private void followVideos()
        {
            int a = GetTimeStamp();
            followVideo.dialog.changeVideoType();//更新videoType
            if (MonitoringX.nowVideoType == 3)
            {
                MonitoringX.photoType(a, 0);
            }
            else if (MonitoringX.nowVideoType == 1)
            {
                MonitoringX.photoType(a, 1);
            }
            else if (MonitoringX.nowVideoType == 4)
            {
                MonitoringX.photoType(a, 2);
            }
        }
        public static void photoType(int time,int type){//追踪视频类型
            Photoelectricity.ISetTrackingImage(time,type);
        }
        public static void photoPoint(int a,short x,short y) {//追踪坐标开始
            Photoelectricity.ITrackStart(a, x, y);
        }
        public static void photoClose(int a) {//追踪结束
            Photoelectricity.IFanSweepEnd(a);
        }

        /*光电追踪-----------------------------------------------------------------------------------------*/

        /*航迹查询-----------------------------------------------------------------------------------------*/
        public static List<int[]> radarTargetListBack(long start,long end,int tip)//雷达列表
        {
            List<int[]> radarList = track.GetRadarTargetIDList(GetTimex(start.ToString()), GetTimex(end.ToString()),tip); ;
            return radarList;
        }
        public static List<int> AISTargetListBack(long start, long end)//AIS列表
        {
            List<int> AISList=track.GetAISTargetIDList(GetTimex(start.ToString()), GetTimex(end.ToString()));
            return AISList;
        }
        public static List<int> fuseTargetListBack(long start, long end)//融合列表
        {
            List<int> FuseList = track.GetFuseTargetIDList(GetTimex(start.ToString()), GetTimex(end.ToString()));
            return FuseList;
        }
        public static void radarTrackBack(long start, long end, int targetInfor, int radarId)//雷达航迹查询
        {
            App app = (App)App.Current;
            Target a = track.GetRadarTargetTrack(GetTimex(start.ToString()), GetTimex(end.ToString()), targetInfor, radarId, app.chartCtrl.GetGeoMultiFactor());
            app.chartCtrl.ShowTargetTrack(a);
        }
        public static void AISTrackBack(long start, long end, int targetInfor)//AIS航迹查询
        {
            App app = (App)App.Current;
            Target a=track.GetAISTargetTrack(GetTimex(start.ToString()), GetTimex(end.ToString()), targetInfor, app.chartCtrl.GetGeoMultiFactor());
            app.chartCtrl.ShowTargetTrack(a);
        }
        public static void mixTrackBack(long start, long end, int targetInfor)//融合航迹查询
        {
            App app = (App)App.Current;
            Target a = track.GetFuseTargetTrack(GetTimex(start.ToString()), GetTimex(end.ToString()), targetInfor, app.chartCtrl.GetGeoMultiFactor());
            app.chartCtrl.ShowTargetTrack(a);
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        /*航迹查询-----------------------------------------------------------------------------------------*/
        public static DateTime GetTimex(string timeStamp)//时间戳转datatime
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        public class _LinkageTarget
        {
            public int TargetType; //联动目标类型,可以是AIS,融合,雷达
            public int TargetID;   //目的ID,根据不同TargetType会有不同的含义 
            public string TargetMMSI;
           public _LinkageTarget()
            {
                TargetType = -1;
                TargetID = -1;
                TargetMMSI = "";
            }
        };
        public static int isLinkage = 0;//表示当前有几个目标在进行自动联动,正常情况下isLinkage为1或0
        public  void SetLinkageState(object Sender, EventArgs args)
        //每次列表联动视频窗口关闭时调用,将isLinkage的值进行调整
        {
            isLinkage--;
            linkageContral = 0;
            CaptureImages._mmsi = "";
            //linkageTarget.TargetID = -1;
            // linkageTarget.TargetType = -1;
            Photoelectricity.isLinkageFirtTime = true;
        }
        public static int YimaLinkageControl=0;//海图联动标识位,YimaLinageControl==0 海图不联动,==2海图多次联动,==1海图手动一次联动

        private void SetYimaLinkageState(object Sender, EventArgs args)
        //每次列表联动视频窗口关闭时调用,将isLinkage的值进行调整
        {
            YimaLinkageControl = 0 ;
            lastTargetID = -1;
          
        }
        private void warnListChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //warnListView.
            
        }

        
    }
}
