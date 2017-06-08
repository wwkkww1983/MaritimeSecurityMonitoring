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
using System.Windows.Forms;
using System.Collections.ObjectModel;

using MaritimeSecurityMonitoring.MainInterfacePage;
using MaritimeSecurityMonitoring.DataQuetycs;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DataQuery.xaml 的交互逻辑
    /// </summary>
    public partial class DataQuery : Page
    {
        private ObservableCollection<AISData> AISDataList = new ObservableCollection<AISData>();
        private ObservableCollection<radarData> radarDataList = new ObservableCollection<radarData>();
        private ObservableCollection<fuseData> fuseDataList = new ObservableCollection<fuseData>();
        private ObservableCollection<loginData> loginDataList = new ObservableCollection<loginData>();
        private ObservableCollection<operateData> operateDataList = new ObservableCollection<operateData>();
        private ObservableCollection<alarmData> alarmDataList = new ObservableCollection<alarmData>();
        private ObservableCollection<deviceData> deviceDataList = new ObservableCollection<deviceData>();
        private dataAnadll.AISDataProvider aisp;
        private dataAnadll.AlarmLogProvider alarmp;
        private dataAnadll.FUSDataProvider fusp;
        private dataAnadll.OperationLogProvider opep;
        private dataAnadll.SystemLogProvider devp;
        private dataAnadll.RadarDataProvider radarp;
        long starttime;
        long endtime;

        private string[] logNumber = { "", "登录", "操作" };
        private string[] state = { "未知", "敌", "我", "中立", "友", "可疑" };
        private string[] alarmType = { "驱逐区", "警戒区", "预警区", "多边形区域", "管道区域", "平台" };
        private string[] type = { "正常", "异常", "其他" };
        private string[] mix = { "AIS", "雷达", "融合" };
        private string[] logType = { "", "登录", "操作" };
        enum _listType { ais,alarm,fus,ope1,ope2,dev,radar} ;
        _listType listType;
        struct _PageIndex
        {
           
           public  int Current;
           public  int Total;
        };
        _PageIndex PageIndex;
        int ErrorMessageBox = 0;
        public void EmptyState(object sender, object e)
        {
            AIS.IsChecked = false;
            radar.IsChecked = false;
            fuse.IsChecked = false;
            login.IsChecked = false;
            operation.IsChecked = false;
            alarm.IsChecked = false;
            device.IsChecked = false;

            AISDataList.Clear();
            fuseDataList.Clear();
            radarDataList.Clear();
            loginDataList.Clear();
            alarmDataList.Clear();
            deviceDataList.Clear();
            operateDataList.Clear();

            PageIndex.Current = 0;
            PageIndex.Total = 0;
            totalPages.Text = "0";
            currentPage.Text = "0";
        }
        public DataQuery()
        {
            try
            {
                InitializeComponent();

                StartTime.PreviewMouseDown += EmptyState;
                EndTime.PreviewMouseDown += EmptyState;
                StartTime.SetTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                EndTime.SetTime = DateTime.Now;

                DataQueryPageNumber dqpn = new DataQueryPageNumber();
                pageNumber.DataContext = dqpn;

                PageIndex = new _PageIndex();
                AISList.Visibility = Visibility.Visible;
                starttime = GetTimeStamp(new DateTime(1970, 1, 1));
                endtime = GetTimeStamp(new DateTime(2099, 1, 1));
                aisp = new dataAnadll.AISDataProvider((uint)starttime, (uint)endtime);
                List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list;
                aisp.GetPageNum(out PageIndex.Total);
                aisp.GetFirtstPage(out list);
                PageIndex.Current = 1;
                AISDataList.Clear();
                for (int i = 1; i < list.Count; i++)
                {
                    AISData AIS = new AISData();

                    AIS.boatName = list[i].cName;
                    AIS.IMO = list[i].ulIMO;
                    AIS.MMSI =list[i].ulRecoCode;
                    AIS.call = list[i].cCall_ID;
                    AIS.country = list[i].country;
                    
                    AIS.longitude = list[i].dLong;
                    AIS.latitude = list[i].dLat;
                    AIS.angle = list[i].fDirectCourse;
                    AIS.speed = list[i].fDirectSpeed;
                    AIS.time = (GetTime((list[i].ulTime).ToString())).ToString();
                    AIS.trackState = list[i].ucSailStatus;
                    AIS.high = list[i].fMaxDeep;
                    AIS.people = list[i].ulCount;
                    AIS.destance = list[i].cDestination;
                    AISDataList.Add(AIS);
                }
                AISList.DataContext = AISDataList;
            }
            catch (Exception ee)
            {

            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private long[] dataTime()//获得时间控件的时间戳
        {
            string start=StartTime.year.Text+StartTime.month.Text+StartTime.day.Text+" "+StartTime.hour.Text+StartTime.minute.Text+StartTime.second.Text;
            string end = EndTime.year.Text + EndTime.month.Text + EndTime.day.Text + " "+EndTime.hour.Text + EndTime.minute.Text + EndTime.second.Text;
            System.DateTime timer = Convert.ToDateTime(start);//string转datatime（end）
            long linkStart = (long)GetTimeStamp(timer);//datatime时间戳（end）

            System.DateTime timer1 = Convert.ToDateTime(end);//string转datatime（end）
            long linkEnd = (long)GetTimeStamp(timer1);//datatime时间戳（end）
            long[] times={linkStart,linkEnd};
            if (linkStart >= linkEnd )
            {
                if ((ErrorMessageBox % 2) == 0)
                {
                    MessageBoxX.Show("数据导出提示", "时间设置错误");
                }
                ErrorMessageBox++;
            }
            return times;
        }
        private int GetTimeStamp(DateTime dt)//datatime转时间戳
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }
        private void AISClick(object sender, RoutedEventArgs e)//AIS
        {
            try
            {
                listType = _listType.ais;


                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                AIS.IsChecked = true;
                long startTime = dataTime()[0]+28800;//开始时间
                long endTime = dataTime()[1] + 28800;//结束时间
                int pages = 0;
                AISList.Visibility = Visibility.Visible;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;
                aisp = new dataAnadll.AISDataProvider((uint)startTime,(uint) endTime);
                List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list;

                aisp.GetPageNum(out PageIndex.Total);
                PageIndex.Current = 1;
                aisp.GetFirtstPage(out list);
                AISDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    AISData AISTarget = new AISData();

                    AISTarget.boatName = list[i].cName;
                    AISTarget.IMO = list[i].ulIMO;
                    AISTarget.MMSI = list[i].ulRecoCode;
                    AISTarget.call = list[i].cCall_ID;
                    AISTarget.country = list[i].country;
      
                    AISTarget.longitude = list[i].dLong;
                    AISTarget.latitude = list[i].dLat;
                    AISTarget.angle = list[i].fDirectCourse;
                    AISTarget.speed = list[i].fDirectSpeed;
                    AISTarget.time = (GetTime((list[i].ulTime).ToString())).ToString();
                    AISTarget.trackState = list[i].ucSailStatus;
                    AISTarget.high = list[i].fMaxDeep;
                    AISTarget.people = list[i].ulCount;
                    AISTarget.destance = list[i].cDestination;

                    AISDataList.Add(AISTarget);
                }
                AISList.DataContext = AISDataList;
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                numberRule.Max = PageIndex.Total;
            }
            catch (Exception ee)
            {

            }

        }
        private void radarClick(object sender, RoutedEventArgs e)//雷达
        {
            try
            {
                listType = _listType.radar;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                radar.IsChecked = true;
                long startTime = dataTime()[0] + 28800;//开始时间
                long endTime = dataTime()[1] + 28800;//结束时间

                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Visible;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;
                radarp = new dataAnadll.RadarDataProvider((uint)startTime, (uint)endTime);

                List<dataAnadll.FUS_ICD_MySql.RdDetectMsg_SS> list;
                radarp.GetPageNum(out PageIndex.Total);
                PageIndex.Current = 1;
                radarp.GetFirtstPage(out list);
                radarDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    radarData radarTarget = new radarData();
                    radarTarget.radarID = list[i].PardPara.ucRadarID.ToString();//雷达编号
                    radarTarget.number = list[i].lTargetNo;
                    radarTarget.distance = list[i].ulTargetDis;
                    radarTarget.longitude = list[i].dLongti;
                    radarTarget.latitude = list[i].dLati;
                    radarTarget.angle = list[i].ulTargetCourse;
                    radarTarget.north = list[i].dNorthCourse;
                    radarTarget.speed = list[i].ulTargetSpeed;
                    radarTarget.time = (GetTime((list[i].lFoundTime).ToString())).ToString();

                    radarDataList.Add(radarTarget);
                }
                radarList.DataContext = radarDataList;
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                numberRule.Max = PageIndex.Total;
            }
            catch (Exception ee)
            {

            }
        }
        private void fuseClick(object sender, RoutedEventArgs e)//融合
        {
            try
            {
                listType = _listType.fus;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                fuse.IsChecked = true;
                long startTime = dataTime()[0] + 28800;//开始时间
                long endTime = dataTime()[1] + 28800;//结束时间

                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Visible;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;

                fusp = new dataAnadll.FUSDataProvider((uint)startTime, (uint)endTime);


                List<dataAnadll.FUS_ICD_MySql.FusTarget_SS> list;
                fusp.GetPageNum(out PageIndex.Total);
                PageIndex.Current = 1;
                fusp.GetFirtstPage(out list);
                fuseDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    fuseData fuseTarget = new fuseData();
                    fuseTarget.number = list[i].lFusBatchID;
                    fuseTarget.time = (GetTime((list[i].lTime).ToString())).ToString();
                    string a = "";
                    if (list[i].FusDataType == "2")
                    {
                        a = mix[0];
                    }
                    else if (list[i].FusDataType == "3")
                    {
                        a = mix[1];
                    }
                    else if (list[i].FusDataType == "100")
                    {
                        a = mix[2];
                    }
                    fuseTarget.type = a;
                    fuseTarget.dataNumber = list[i].SrcNum;
                    fuseTarget.longitude = list[i].dLongti;
                    fuseTarget.latitude = list[i].dLati;
                    fuseTarget.angle = list[i].dNorthCourse;
                    fuseTarget.name = list[i].cName;
                    fuseTarget.call = list[i].cCall_ID;
                    fuseTarget.country = list[i].country;
                    fuseTarget.Atrrbi = state[Convert.ToInt32(list[i].ucIFFAttrib)];
                    fuseTarget.high = list[i].fMaxDeep;
                    fuseTarget.people = list[i].ulCount;
                    fuseTarget.IMO =list[i].ulAISBatchID;
                    fuseTarget.radar_batch_id = list[i].ulRdbatchID;
                    fuseTarget.radar_batch_id2 = list[i].ulOpticalID;
                    fuseDataList.Add(fuseTarget);
                }
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                fuseList.DataContext = fuseDataList;
                numberRule.Max = PageIndex.Total;
            }
            catch (Exception ee)
            {

            }
        }
       static public DateTime getTimeStamp(long timestamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = new TimeSpan(timestamp);
            return dtStart.AddSeconds(timestamp);
        }
        private void userLoginClick(object sender, RoutedEventArgs e)//登录日志
        {
  try
            {
                listType = _listType.ope1;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                login.IsChecked = true;
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间

                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Visible;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;

                opep = new dataAnadll.OperationLogProvider();
                int allpage = 0;
                opep.SearchLog(1, getTimeStamp(startTime), getTimeStamp(endTime), out PageIndex.Total);
                var a = getTimeStamp(startTime);
                var b = getTimeStamp(endTime);
                List<dataAnadll.OperationLog> list;
                PageIndex.Current = 1;
                opep.GetPage(1, out list);
                loginDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    loginData loginTarget = new loginData();

                    loginTarget.logNumber = i.ToString();
                    loginTarget.userName = list[i].UserName.ToString();
                    loginTarget.operate = list[i].OptionName;
                    loginTarget.time = list[i].OptionTime.ToString();
                    loginTarget.result = list[i].Result.ToString();
                    loginTarget.other = list[i].Note;
                    loginTarget.ip = list[i].IP.ToString();
                    loginTarget.type = logType[ list[i].LogType];
                    loginDataList.Add(loginTarget);
                }
                userLoginList.DataContext = loginDataList;
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                numberRule.Max = PageIndex.Total;
            }
            catch (Exception ee)
            {

            }

        }
        private void operationLogClick(object sender, RoutedEventArgs e)//界面操作日志
        {
try
            {
                listType = _listType.ope2;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                operation.IsChecked = true;
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间

                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Visible;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;

                opep = new dataAnadll.OperationLogProvider();
                int allpage;
                opep.SearchLog(2, getTimeStamp(startTime), getTimeStamp(endTime), out PageIndex.Total);
                List<dataAnadll.OperationLog> list;
                opep.GetPage(1, out list);
                PageIndex.Current = 1;
                operateDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    operateData operateTarget = new operateData();

                    operateTarget.logNumber = i.ToString();
                    operateTarget.userName = list[i].UserName.ToString();
                    operateTarget.operate = list[i].OptionName.ToString();
                    operateTarget.time = list[i].OptionTime.ToString();
                    operateTarget.result = list[i].Result;
                    operateTarget.other = list[i].Note.ToString();
                    operateTarget.ip = list[i].IP.ToString();
                    operateTarget.type = logType[ list[i].LogType];
                    operateDataList.Add(operateTarget);
                }
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                operateList.DataContext = operateDataList;
                numberRule.Max = PageIndex.Total;
            }
            catch (Exception ee)
            {

            }

        }
    
    private void alarmClick(object sender, RoutedEventArgs e)//报警日志
        {
            try
            {
                listType = _listType.alarm;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                alarm.IsChecked = true;
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间

                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Visible;
                deviceList.Visibility = Visibility.Collapsed;
                alarmp = new dataAnadll.AlarmLogProvider(getTimeStamp(startTime), getTimeStamp(endTime));
                List<dataAnadll.AlarmLog> list;
                alarmp.GetPageNum(out PageIndex.Total);
                PageIndex.Current = 1;
                alarmp.GetFirtstPage(out list);
                alarmDataList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    alarmData alarmTarget = new alarmData();

                    string a = "";

                    if (list[i].alarm_area_num == 201)
                    {
                        a = alarmType[0];
                    }
                    else if (list[i].alarm_area_num == 202)
                    {
                        a = alarmType[1];
                    }
                    else if (list[i].alarm_area_num == 203)
                    {
                        a = alarmType[2];
                    }
                    else if (list[i].alarm_area_num >= 210 && list[i].alarm_area_num <= 215)
                    {
                        a = alarmType[3];
                    }
                    else if (list[i].alarm_area_num >= 220 && list[i].alarm_area_num <= 225)
                    {
                        a = alarmType[4];
                    }
                    else if (list[i].alarm_area_num == 255)
                    {
                        a = alarmType[5];
                    }
                    alarmTarget.DisplayNumber = i.ToString();
                    alarmTarget.alarmNumber = a;
                    alarmTarget.time = list[i].time.ToString();
                    alarmTarget.radarNumber = list[i].radar_batch_id.ToString();
                    alarmTarget.radarNumber2 = list[i].radar_batch_id2.ToString();//告警日志添加雷达2 批号
                    alarmTarget.IMO = list[i].ais_batch_id.ToString();
                    switch (list[i].alarm_type)
                    {
                        case 1:
                            alarmTarget.alarmString = "驶入";
                            break;
                        case 2:
                            alarmTarget.alarmString = "驶出";
                            break;
                        default:
                            alarmTarget.alarmString = "未知报警";
                            break;
                    }
                    switch (list[i].country)
                    {
                        case 412:
                        case 413:
                            alarmTarget.country = "中国";
                            break;
                        case 574:
                        case 576:
                            alarmTarget.country = "越南";
                            break;
                        case 533:
                            alarmTarget.country = "马拉西亚";
                            break;
                        default:
                            alarmTarget.country = "其他";
                            break;
                    }

                    alarmTarget.Atrrib = state[list[i].iff_attrib];
                    alarmDataList.Add(alarmTarget);
                }
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                alarmList.DataContext = alarmDataList;
                numberRule.Max = PageIndex.Total;
            }
   			catch (Exception ee)
            {

            }

        }

        private void deviceClick(object sender, RoutedEventArgs e)//设备故障日志
        {
            try
            {
                listType = _listType.dev;
                AIS.IsChecked = false;
                radar.IsChecked = false;
                fuse.IsChecked = false;
                login.IsChecked = false;
                operation.IsChecked = false;
                alarm.IsChecked = false;
                device.IsChecked = false;

                device.IsChecked = true;
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间
                AISList.Visibility = Visibility.Collapsed;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Visible;

                devp = new dataAnadll.SystemLogProvider(getTimeStamp(startTime), getTimeStamp(endTime));
                List<dataAnadll.SystemLog> list;
                devp.GetPageNum(out PageIndex.Total);
                devp.GetFirtstPage(out list);
                deviceDataList.Clear();
                PageIndex.Current = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    deviceData deviceTarget = new deviceData();

                    deviceTarget.number = i.ToString();
                    deviceTarget.ip = list[i].machine_IP.ToString();
                    deviceTarget.device = list[i].machine_Name.ToString();
                    deviceTarget.networkState = type[list[i].machine_Network];
                    deviceTarget.workState = type[list[i].machine_Workstate];
                    deviceTarget.time = list[i].machine_time.ToString();
                    deviceTarget.other = list[i].reason.ToString();

                    deviceDataList.Add(deviceTarget);
                }
                currentPage.Text = PageIndex.Current.ToString();
                totalPages.Text = PageIndex.Total.ToString();
                deviceList.DataContext = deviceDataList;
                numberRule.Max = PageIndex.Total;
            }
			catch (Exception ee)
            {

            }


        }
 		void changeContent(_listType type, int currentPage)
            //将表格的内容进行切换
        {
            try
            {
                PageIndex.Current = currentPage;

                switch (type)
                {
                    case _listType.alarm:
                        List<dataAnadll.AlarmLog> list;
                        alarmp.GetPage(currentPage, out list);
                        alarmDataList.Clear();
                        for (int i = 0; i < list.Count; i++)
                        {
                            alarmData alarmTarget = new alarmData();

                            string a = "";

                            if (list[i].alarm_area_num == 201)
                            {
                                a = alarmType[0];
                            }
                            else if (list[i].alarm_area_num == 202)
                            {
                                a = alarmType[1];
                            }
                            else if (list[i].alarm_area_num == 203)
                            {
                                a = alarmType[2];
                            }
                            else if (list[i].alarm_area_num >= 210 && list[i].alarm_area_num <= 215)
                            {
                                a = alarmType[3];
                            }
                            else if (list[i].alarm_area_num >= 220 && list[i].alarm_area_num <= 225)
                            {
                                a = alarmType[4];
                            }
                            else if (list[i].alarm_area_num == 255)
                            {
                                a = alarmType[5];
                            }
                            alarmTarget.DisplayNumber = (i + (PageIndex.Current - 1) * 1000).ToString();
                            alarmTarget.alarmNumber = a;
                            alarmTarget.time = list[i].time.ToString();
                            alarmTarget.radarNumber = list[i].radar_batch_id.ToString();
                            alarmTarget.radarNumber2 = list[i].radar_batch_id2.ToString();//告警日志添加雷达2 批号

                            alarmTarget.IMO = list[i].ais_batch_id.ToString();
                            switch (list[i].alarm_type)
                            {
                                case 1:
                                    alarmTarget.alarmString = "驶入";
                                    break;
                                case 2:
                                    alarmTarget.alarmString = "驶出";
                                    break;
                                default:
                                    alarmTarget.alarmString = "未知报警";
                                    break;
                            }
                            switch (list[i].country)
                            {
                                case 412:
                                case 413:
                                    alarmTarget.country = "中国";
                                    break;
                                case 574:
                                case 576:
                                    alarmTarget.country = "越南";
                                    break;
                                case 533:
                                    alarmTarget.country = "马拉西亚";
                                    break;
                                default:
                                    alarmTarget.country = "其他";
                                    break;
                            }

                            alarmTarget.Atrrib = state[list[i].iff_attrib];
                            alarmDataList.Add(alarmTarget);
                        }
                        alarmList.DataContext = alarmDataList;
                        break;
                    case _listType.ais:
                        List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list_ais;
                        aisp.GetPage(currentPage, out list_ais);
                        AISDataList.Clear();
                        for (int i = 0; i < list_ais.Count; i++)
                        {
                            AISData AISTarget = new AISData();

                            AISTarget.boatName = list_ais[i].cName;
                            AISTarget.IMO = list_ais[i].ulIMO;
                            AISTarget.MMSI = list_ais[i].ulRecoCode;
                            AISTarget.call = list_ais[i].cCall_ID;
                            AISTarget.country = list_ais[i].country;
                            AISTarget.longitude = list_ais[i].dLong;
                            AISTarget.latitude = list_ais[i].dLat;
                            AISTarget.angle = list_ais[i].fDirectCourse;
                            AISTarget.speed = list_ais[i].fDirectSpeed;
                            AISTarget.time = (GetTime((list_ais[i].ulTime).ToString())).ToString();
                            AISTarget.trackState = list_ais[i].ucSailStatus;
                            AISTarget.high = list_ais[i].fMaxDeep;
                            AISTarget.people = list_ais[i].ulCount;
                            AISTarget.destance = list_ais[i].cDestination;

                            AISDataList.Add(AISTarget);
                        }
                        AISList.DataContext = AISDataList;
                        break;
                    case _listType.dev:

                        List<dataAnadll.SystemLog> list_dev;
                        devp.GetPage(currentPage, out list_dev);
                        deviceDataList.Clear();
                        for (int i = 0; i < list_dev.Count; i++)
                        {
       

                            deviceData deviceTarget = new deviceData();

                            deviceTarget.number = i.ToString();
                            deviceTarget.ip = list_dev[i].machine_IP.ToString();
                            deviceTarget.device = list_dev[i].machine_Name.ToString();
                            deviceTarget.networkState = this.type[list_dev[i].machine_Network];
                            deviceTarget.workState = this.type[list_dev[i].machine_Workstate];
                            deviceTarget.time = list_dev[i].machine_time.ToString();
                            deviceTarget.other = list_dev[i].reason.ToString();

                            deviceDataList.Add(deviceTarget);
                        }
                        deviceList.DataContext = deviceDataList;
                        break;
                    case _listType.fus:
                        List<dataAnadll.FUS_ICD_MySql.FusTarget_SS> list_fus;
                        fusp.GetPage(currentPage, out list_fus);
                        fuseDataList.Clear();
                        for (int i = 0; i < list_fus.Count; i++)
                        {
                            fuseData fuseTarget = new fuseData();
                            fuseTarget.number = list_fus[i].lFusBatchID;
                            fuseTarget.time = (GetTime((list_fus[i].lTime).ToString())).ToString();
                            string a = "";
                            if (list_fus[i].FusDataType == "2")
                            {
                                a = mix[0];
                            }
                            else if (list_fus[i].FusDataType == "3")
                            {
                                a = mix[1];
                            }
                            else if (list_fus[i].FusDataType == "100")
                            {
                                a = mix[2];
                            }
                            fuseTarget.type = a;
                            fuseTarget.dataNumber = list_fus[i].SrcNum;
                            fuseTarget.longitude = list_fus[i].dLongti;
                            fuseTarget.latitude = list_fus[i].dLati;
                            fuseTarget.angle = list_fus[i].dNorthCourse;
                            fuseTarget.name = list_fus[i].cName;
                            fuseTarget.call = list_fus[i].cCall_ID;
                            fuseTarget.country = list_fus[i].country;
                            fuseTarget.Atrrbi = state[Convert.ToInt32(list_fus[i].ucIFFAttrib)];
                            fuseTarget.high = list_fus[i].fMaxDeep;
                            fuseTarget.people = list_fus[i].ulCount;
                            fuseTarget.IMO = list_fus[i].ulAISBatchID;
                            fuseTarget.radar_batch_id = list_fus[i].ulRdbatchID;
                            fuseTarget.radar_batch_id2 = list_fus[i].ulOpticalID;
                            fuseDataList.Add(fuseTarget);
                        }
                        
                        fuseList.DataContext = fuseDataList;
                        break;
                    case _listType.radar:
                        List<dataAnadll.FUS_ICD_MySql.RdDetectMsg_SS> list_rd;
                        radarp.GetPage(currentPage, out list_rd);
                        radarDataList.Clear();
                        for (int i = 0; i < list_rd.Count; i++)
                        {
                            radarData radarTarget = new radarData();
                            radarTarget.radarID = list_rd[i].PardPara.ucRadarID.ToString();
                            radarTarget.number = list_rd[i].lTargetNo;
                            radarTarget.distance = list_rd[i].ulTargetDis;
                            radarTarget.longitude = list_rd[i].dLongti;
                            radarTarget.latitude = list_rd[i].dLati;
                            radarTarget.angle = list_rd[i].ulTargetCourse;
                            radarTarget.north = list_rd[i].dNorthCourse;
                            radarTarget.speed = list_rd[i].ulTargetSpeed;
                           // if (list_rd[i].radar_count == 70.ToString())
                            {
                             //   radarTarget.time = list_rd[i].lFoundTime;
                            }
                          //  else
                            {
                                radarTarget.time = (GetTime((list_rd[i].lFoundTime).ToString())).ToString();
                            }

                            radarDataList.Add(radarTarget);
                        }
                        radarList.DataContext = radarDataList;
                        break;
                    case _listType.ope1:
                        List<dataAnadll.OperationLog> list_ope1;
                        opep.GetPage(currentPage, out list_ope1);
                        loginDataList.Clear();
                        for (int i = 0; i < list_ope1.Count; i++)
                        {
                            loginData loginTarget = new loginData();

                            loginTarget.logNumber = (i+(PageIndex.Current-1)*1000).ToString();
                            loginTarget.userName = list_ope1[i].UserName.ToString();
                            loginTarget.operate = list_ope1[i].OptionName;
                            loginTarget.time = list_ope1[i].OptionTime.ToString();
                            loginTarget.result = list_ope1[i].Result.ToString();
                            loginTarget.other = list_ope1[i].Note;
                            loginTarget.ip = list_ope1[i].IP.ToString();
                            loginTarget.type =logType[ list_ope1[i].LogType].ToString();
                            loginDataList.Add(loginTarget);
                        }
                        userLoginList.DataContext = loginDataList;
                        break;
                    case _listType.ope2:
                        List<dataAnadll.OperationLog> list_ope2;
                        opep.GetPage(currentPage, out list_ope2);
                        operateDataList.Clear();
                        for (int i = 0; i < list_ope2.Count; i++)
                        {
                            operateData operateTarget = new operateData();

                            operateTarget.logNumber = (i + (PageIndex.Current - 1) * 1000).ToString();
                            operateTarget.userName = list_ope2[i].UserName.ToString();
                            operateTarget.operate = list_ope2[i].OptionName.ToString();
                            operateTarget.time = list_ope2[i].OptionTime.ToString();
                            operateTarget.result = list_ope2[i].Result;
                            operateTarget.other = list_ope2[i].Note.ToString();
                            operateTarget.ip = list_ope2[i].IP.ToString();
                            operateTarget.type =logType[ list_ope2[i].LogType].ToString();

                            operateDataList.Add(operateTarget);
                        }
                        operateList.DataContext = operateDataList;
                        break;
                }
            }
            catch (Exception ee)
            {

            }
        }
        private void listView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ToFirstPageClick(object sender, RoutedEventArgs e)//首页
        {
            PageIndex.Current = 1;
            changeContent(listType, PageIndex.Current);
            currentPage.Text = PageIndex.Current.ToString();
            totalPages.Text = PageIndex.Total.ToString();
        }
        private void btnPrevClick(object sender, RoutedEventArgs e)//上一页
        {
            PageIndex.Current--;
            PageIndex.Current = (PageIndex.Current <= 0) ? 1 : PageIndex.Current;
            changeContent(listType, PageIndex.Current);
            currentPage.Text = PageIndex.Current.ToString();
            totalPages.Text = PageIndex.Total.ToString();
        }
        private void btnNextClick(object sender, RoutedEventArgs e)//下一页
        {
            PageIndex.Current++;
            PageIndex.Current = (PageIndex.Current >= PageIndex.Total) ? PageIndex.Total : PageIndex.Current;
            changeContent(listType, PageIndex.Current);
            currentPage.Text = PageIndex.Current.ToString();
            totalPages.Text = PageIndex.Total.ToString();
        }
        private void ToLastPageClick(object sender, RoutedEventArgs e)//末页
        {

            PageIndex.Current = PageIndex.Total;
            changeContent(listType, PageIndex.Current);
            currentPage.Text = PageIndex.Current.ToString();
            totalPages.Text = PageIndex.Total.ToString();
        }
        public static DateTime GetTime(string timeStamp)//时间戳转datatime
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        private void SearchPageClick(object sender, RoutedEventArgs e)//转到某一页
        {
            if (String.IsNullOrWhiteSpace(pageNumber.Text))
                return;
            PageIndex.Current = Convert.ToInt32(pageNumber.Text);
            if (PageIndex.Current <= 1)

            {
                PageIndex.Current = 1;
            }
            if (PageIndex.Current >= PageIndex.Total)
            {
                PageIndex.Current = PageIndex.Total;
            }

            changeContent(listType, PageIndex.Current);
            currentPage.Text = PageIndex.Current.ToString();
            totalPages.Text = PageIndex.Total.ToString();
        }
    }

    class DataQueryPageNumber
    {
        public string number { get; set; }
    }
}