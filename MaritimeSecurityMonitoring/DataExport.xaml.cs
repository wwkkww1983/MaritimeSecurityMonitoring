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
using System.Windows.Forms;
using System.Collections.ObjectModel;

using MaritimeSecurityMonitoring.MainInterfacePage;
using MaritimeSecurityMonitoring.DataQuetycs;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DataExport.xaml 的交互逻辑
    /// </summary>
    public partial class DataExport : Page
    {
        private ObservableCollection<AISData> AISDataList = new ObservableCollection<AISData>();
        private ObservableCollection<radarData> radarDataList = new ObservableCollection<radarData>();
        private ObservableCollection<fuseData> fuseDataList = new ObservableCollection<fuseData>();
        private ObservableCollection<loginData> loginDataList = new ObservableCollection<loginData>();
        private ObservableCollection<operateData> operateDataList = new ObservableCollection<operateData>();
        private ObservableCollection<alarmData> alarmDataList = new ObservableCollection<alarmData>();
        private ObservableCollection<deviceData> deviceDataList = new ObservableCollection<deviceData>();

        long starttime, endtime;
        private string nowListString = "AIS";

        private string[] AIStitle = { "船名", "IMO", "MMSI", "呼号", "国籍", "经度(°)", "纬度(°)", "航向角(°)", "対地速度（节）", "发现时间", "航向状态", "最大吃水（米）深度（米）", "船载人数", "目的地" };
        private string[] radartitle = { "批号", "距离(米)", "航向角(°)", "真北方位", "対地速度（节）", "发现时间"};
        private string[] fusetitle = { "融合批号", "发现时间", "融合类型", "子源个数", "经度(°)", "纬度(°)", "距离(米)", "航向角(°)", "船名", "呼号", "国籍", "敌我属性","最大吃水（米）深度（米）", "船载人数","MMSI"};

        private string[] logintitle = {  "用户编号", "操作名", "操作时间", "操作结果", "备注信息", "计算计IP", "日志类型"};
        private string[] opearatetitle = { "用户编号", "操作名", "操作时间", "操作结果", "备注信息", "计算计IP", "日志类型" };
        private string[] alarmtitle = { "告警时间", "雷达1批号", "雷达2批号", "MMSI", "报警区域编号", "告警类型","国籍","敌我属性" };
        private string[] devicetitle = { "设备IP", "设备名称", "设备联网状态", "设备工作状态","时间", "备注" };


        private string[] logNumber = { "", "登录", "操作" };
        private string[] state = {"未知","敌","我","中立","友","可疑" };
        private string[] alarmType = {"驱逐区","警戒区","预警区","多边形区域","管道区域","平台"};
        private string[] type = { "正常", "异常", "其他" };
        private string[] mix = {"AIS","雷达","融合"};


        private dataAnadll.AISDataProvider aisp;
        private dataAnadll.AlarmLogProvider alarmp;
        private dataAnadll.FUSDataProvider fusp;
        private dataAnadll.OperationLogProvider opep;
        private dataAnadll.SystemLogProvider devp;
        private dataAnadll.RadarDataProvider radarp;
        int ErrorMessageBox = 0;
        enum _listType { ais, alarm, fus, ope1, ope2, dev, radar };
        _listType listType;
        struct _PageIndex
        {

            public int Current;
            public int Total;
        };
        _PageIndex PageIndex;



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


        }

        public DataExport()
        {
 			InitializeComponent();
            try
            {
                WrapPanelForMartime.Visibility = Visibility.Hidden;
                MartimeData.Visibility = Visibility.Hidden;
                MartimeDataLogo.Visibility = Visibility.Hidden;
                WrapPanelForMartime.IsEnabled = false;
                MartimeDataLogo.IsEnabled = false;
                MartimeData.IsEnabled = false;


                StartTime.PreviewMouseDown += EmptyState;
                EndTime.PreviewMouseDown += EmptyState;
                StartTime.SetTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                EndTime.SetTime = DateTime.Now;


                //PageIndex = new _PageIndex();
                //AISList.Visibility = Visibility.Visible;
                //starttime = GetTimeStamp(new DateTime(1970, 1, 1));
                //endtime = GetTimeStamp(new DateTime(2099, 1, 1));
                //aisp = new dataAnadll.AISDataProvider((uint)starttime,(uint) endtime);
                //List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list;
                //aisp.GetPageNum(out PageIndex.Total);
               
                //PageIndex.Current = 1;
                //for (int j = 0; j < PageIndex.Total; j++)

                //{
                //    aisp.GetPage(j+1,out list);
                //    for (int i = 1; i < list.Count; i++)
                //    {
                //        AISData AIS = new AISData();

                //        AIS.boatName = list[i].cName;
                //        AIS.IMO = list[i].ulIMO;
                //        AIS.MMSI = list[i].ulRecoCode;
                //        AIS.call = list[i].cCall_ID;
                //        AIS.country = list[i].country;
                //        AIS.longitude = list[i].dLong;
                //        AIS.latitude = list[i].dLat;
                //        AIS.angle = list[i].fDirectCourse;
                //        AIS.speed = list[i].fDirectSpeed;
                //        AIS.time = (GetTime((list[i].ulTime).ToString())).ToString();
                //        AIS.trackState = list[i].ucSailStatus;
                //        AIS.high = list[i].fMaxDeep;
                //        AIS.people = list[i].ulCount;
                //        AIS.destance = list[i].cDestination;
                //        AISDataList.Add(AIS);
                //    }
                //}
                //AISList.DataContext = AISDataList;
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
            string start = StartTime.year.Text + StartTime.month.Text + StartTime.day.Text + " " + StartTime.hour.Text + StartTime.minute.Text + StartTime.second.Text;
            string end = EndTime.year.Text + EndTime.month.Text + EndTime.day.Text + " " + EndTime.hour.Text + EndTime.minute.Text + EndTime.second.Text;
            System.DateTime timer = Convert.ToDateTime(start);//string转datatime（end）
            long linkStart = (long)GetTimeStamp(timer);//datatime时间戳（end）

            System.DateTime timer1 = Convert.ToDateTime(end);//string转datatime（end）
            long linkEnd = (long)GetTimeStamp(timer1);//datatime时间戳（end）
            long[] times = { linkStart, linkEnd };
            if (linkStart >= linkEnd) 
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
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间
                int pages = 0;
                AISList.Visibility = Visibility.Visible;
                radarList.Visibility = Visibility.Collapsed;
                fuseList.Visibility = Visibility.Collapsed;
                userLoginList.Visibility = Visibility.Collapsed;
                operateList.Visibility = Visibility.Collapsed;
                alarmList.Visibility = Visibility.Collapsed;
                deviceList.Visibility = Visibility.Collapsed;
                aisp = new dataAnadll.AISDataProvider((uint)startTime, (uint)endTime);
                List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list;

                aisp.GetPageNum(out PageIndex.Total);
                PageIndex.Current = 1;            
                AISDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    aisp.GetPage(j+1,out list);
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
                }
                AISList.DataContext = AISDataList;
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
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间

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
                
                radarDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    radarp.GetPage(j+1,out list);
                    for (int i = 0; i < list.Count; i++)
                    {
                        radarData radarTarget = new radarData();
                        radarTarget.radarID = list[i].PardPara.ucRadarID.ToString();
                        radarTarget.number = list[i].radar_count;
                        radarTarget.distance = list[i].ulTargetDis;
                        radarTarget.longitude = list[i].dLongti;
                        radarTarget.latitude = list[i].dLati;
                        radarTarget.angle = list[i].ulTargetCourse;
                        radarTarget.north = list[i].dNorthCourse;
                        radarTarget.speed = list[i].ulTargetSpeed;
                        radarTarget.time = (GetTime((list[i].lFoundTime).ToString())).ToString();

                        radarDataList.Add(radarTarget);
                    }
                }
                radarList.DataContext = radarDataList;
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
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间

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
                
                fuseDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    fusp.GetPage(j+1,out list);
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
                        fuseTarget.IMO = list[i].ulAISBatchID;
                        fuseTarget.radar_batch_id = list[i].ulRdbatchID;
                        fuseTarget.radar_batch_id2 = list[i].ulOpticalID;
                        fuseDataList.Add(fuseTarget);
                    }
                }
          
                fuseList.DataContext = fuseDataList;
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
                
                loginDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    opep.GetPage(1+j, out list);
                    for (int i = 0; i < list.Count; i++)
                    {
                       
                        loginData loginTarget = new loginData();

                        loginTarget.logNumber = (j*1000+i).ToString();
                        loginTarget.userName = list[i].UserName;
                        loginTarget.operate = list[i].OptionName;
                        loginTarget.time = list[i].OptionTime.ToString();
                        loginTarget.result = list[i].Result.ToString();
                        loginTarget.other = list[i].Note;
                        loginTarget.ip = list[i].IP.ToString();
                        loginTarget.type = logNumber[list[i].LogType];
                        loginDataList.Add(loginTarget);
                    }
                }
                userLoginList.DataContext = loginDataList;
               
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

                
                PageIndex.Current = 1;
                operateDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    opep.GetPage(1+j, out list);
                    for (int i = 0; i < list.Count; i++)
                    {
                        operateData operateTarget = new operateData();

                        operateTarget.logNumber = (j*1000+i).ToString();
                        operateTarget.userName = list[i].UserName;
                        operateTarget.operate = list[i].OptionName.ToString();
                        operateTarget.time = list[i].OptionTime.ToString();
                        operateTarget.result = list[i].Result;
                        operateTarget.other = list[i].Note.ToString();
                        operateTarget.ip = list[i].IP.ToString();
                        operateTarget.type = logNumber[list[i].LogType].ToString();
                        operateDataList.Add(operateTarget);
                    }
                }
                operateList.DataContext = operateDataList;
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
                //alarmp.GetFirtstPage(out list);
                alarmDataList.Clear();
                for (int j = 0; j < PageIndex.Total; j++)
                {
                    alarmp.GetPage(j + 1, out list);
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
                        alarmTarget.DisplayNumber = (i+(j)*1000).ToString();
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
                }
                alarmList.DataContext = alarmDataList;
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
                deviceDataList.Clear();
                PageIndex.Current = 1;
                for (int j = 0; j < PageIndex.Total; j++)
                {                
                    devp.GetPage(j+1,out list);
                    for (int i = 0; i < list.Count; i++)
                    {
                        deviceData deviceTarget = new deviceData();

                        deviceTarget.number = (j*1000+i).ToString();
                        deviceTarget.ip = list[i].machine_IP.ToString();
                        deviceTarget.device = list[i].machine_Name.ToString();

                        deviceTarget.networkState = type[list[i].machine_Network];
                        deviceTarget.workState = type[list[i].machine_Workstate];

                        deviceTarget.time = list[i].machine_time.ToString();
                        deviceTarget.other = list[i].reason.ToString();

                        deviceDataList.Add(deviceTarget);
                    }
                }
             
                deviceList.DataContext = deviceDataList;
            }
            catch (Exception ee)
            {

            }


        }

        private void listView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void chooseFilePathClick(object sender, RoutedEventArgs e)//选择路径
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
           
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                filePathText.Text = fbd.SelectedPath;
            }
        }
        private void exportClick(object sender, RoutedEventArgs e)//导出
        {
           try
            {
                if (string.IsNullOrWhiteSpace(filePathText.Text))
                {
                    MessageBoxX.Show("导出提示", "未设置文件路径");
                    return;
                }
                long startTime = dataTime()[0];//开始时间
                long endTime = dataTime()[1];//结束时间
                int allPage = 0;
                int cnt = 0;
                string filePath="";
                if (listType==_listType.ais)
                {
                    //List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list = MainWindow.data.AIS(startTime, endTime, MainWindow.mycon, 1, 10);

                    dataAnadll.AISDataProvider dataprovider = new dataAnadll.AISDataProvider((uint)startTime, (uint)endTime);
                    dataprovider.GetPageNum(out allPage);
                    List<dataAnadll.FUS_ICD_MySql.AISMsg_SS> list;

                    for (int i = 0; i < allPage; i++)
                    {
                        dataprovider.GetPage(i + 1, out list);
                        //alldata.Add();
                        cnt+=dataAnadll.SaveToExcel.Save_AISdata(filePathText.Text + "\\ais.xls", list, AIStitle, 14);

                    }
                    filePath ="AIS.xls";

                }
                else if (listType==_listType.radar)
                {
                    dataAnadll.RadarDataProvider radarp = new dataAnadll.RadarDataProvider((uint)startTime,(uint) endTime);

                    radarp.GetPageNum(out allPage);
                    List<dataAnadll.FUS_ICD_MySql.RdDetectMsg_SS> list;
                    for (int i = 0; i < allPage; i++)
                    {
                        radarp.GetPage(i + 1, out list);
                        cnt+=dataAnadll.SaveToExcel.Save_Radardata(filePathText.Text + "\\radar.xls", list, radartitle, 6);
                    }
                   filePath = "radar.xls";

                }
                else if (listType==_listType.fus)
                {

                    dataAnadll.FUSDataProvider radarp = new dataAnadll.FUSDataProvider((uint)startTime,(uint) endTime);

                    radarp.GetPageNum(out allPage);
                    List<dataAnadll.FUS_ICD_MySql.FusTarget_SS> list;
                    for (int i = 0; i < allPage; i++)
                    {
                        radarp.GetPage(i + 1, out list);
                        //SaveToExcel.Save_Fusedata(filePathText.Text + "/radar.xls", list, radartitle, 6);  
                        cnt+=dataAnadll.SaveToExcel.Save_Fusedata(filePathText.Text + "\\fuse.xls", list, fusetitle, 15);
                    }
                    //List<dataAnadll.FUS_ICD_MySql.FusTarget_SS> list = MainWindow.data.Fuse(startTime, endTime, MainWindow.mycon);
                   filePath = "fuse.xls";
                }
                else if (listType==_listType.ope1)
                {
                    dataAnadll.OperationLogProvider radarp = new dataAnadll.OperationLogProvider();
                    radarp.SearchLog(1, DataQuery.getTimeStamp(startTime), DataQuery.getTimeStamp(endTime), out allPage);

                    List<dataAnadll.OperationLog> list;
                    List<string[]> loginList = new List<string[]>();
                    for (int i = 0; i < allPage; i++)
                    {
                        radarp.GetPage(i + 1, out list);
                        for (int j = 0; j < list.Count; j++)
                        {
                            string[] str = new string[8];
                           // str[0] = "#############";
                            str[0] = list[j].UserName.ToString();
                            str[1] = list[j].OptionName.ToString();
                            str[2] = list[j].OptionTime.ToString();
                            str[3] = list[j].Result.ToString();
                            str[4] = list[j].Note.ToString();
                            str[5] = list[j].IP.ToString();
                            str[6] = logNumber[ list[j].LogType].ToString();
                            loginList.Add(str);
                        }
                    }
                    cnt+=dataAnadll.SaveToExcel.Save_Optionlog(filePathText.Text + "\\login.xls", loginList, logintitle, 7);
                   filePath = "login.xls";
                }
                else if (listType==_listType.ope2)
                {
                    dataAnadll.OperationLogProvider radarp = new dataAnadll.OperationLogProvider();
                    radarp.SearchLog(2, DataQuery.getTimeStamp(startTime), DataQuery.getTimeStamp(endTime), out allPage);

                    List<dataAnadll.OperationLog> list;
                    List<string[]> opeList = new List<string[]>();
                    for (int i = 0; i < allPage; i++)
                    {
                        radarp.GetPage(i + 1, out list);
                        for (int j = 0; j < list.Count; j++)
                        {
                            string[] str = new string[7];
                            //str[0] = "#############";
                            str[0] = list[j].UserName.ToString();
                            str[1] = list[j].OptionName.ToString();
                            str[2] = list[j].OptionTime.ToString();
                            str[3] = list[j].Result.ToString();
                            str[4] = list[j].Note.ToString();
                            str[5] = list[j].IP.ToString();
                            str[6] = logNumber[ list[j].LogType].ToString();
                            opeList.Add(str);
                        }
                    }
                    cnt+=dataAnadll.SaveToExcel.Save_Optionlog(filePathText.Text + "\\operate.xls", opeList, opearatetitle, 7);
                   filePath = "operate.xls";
                }
                else if (listType == _listType.alarm)
                {
                    dataAnadll.AlarmLogProvider radarp = new dataAnadll.AlarmLogProvider(DataQuery.getTimeStamp(startTime), DataQuery.getTimeStamp(endTime));
                    radarp.GetPageNum(out allPage);

                    List<dataAnadll.AlarmLog> list;
                    List<string[]> loginList = new List<string[]>();
                    for (int i = 0; i < allPage; i++)
                    {
                        radarp.GetPage(i + 1, out list);
                        for (int j = 0; j < list.Count; j++)
                        {
                            string[] str = new string[8];
                            //str[0] = "###############";

                            alarmData alarmTarget = new alarmData();
                            string a = "";

                            if (list[j].alarm_area_num == 201)
                            {
                                a = alarmType[0];
                            }
                            else if (list[j].alarm_area_num == 202)
                            {
                                a = alarmType[1];
                            }
                            else if (list[j].alarm_area_num == 203)
                            {
                                a = alarmType[2];
                            }
                            else if (list[j].alarm_area_num >= 210 && list[j].alarm_area_num <= 215)
                            {
                                a = alarmType[3];
                            }
                            else if (list[j].alarm_area_num >= 220 && list[j].alarm_area_num <= 225)
                            {
                                a = alarmType[4];
                            }
                            else if (list[j].alarm_area_num == 255)
                            {
                                a = alarmType[5];
                            }
                            alarmTarget.alarmNumber = a;
                            alarmTarget.time = list[j].time.ToString();
                            alarmTarget.radarNumber = list[j].radar_batch_id.ToString();
                            alarmTarget.radarNumber2 = list[i].radar_batch_id2.ToString();//告警日志添加雷达2 批号

                            alarmTarget.IMO = list[j].ais_batch_id.ToString();
                            switch (list[j].alarm_type)
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
                            switch (list[j].country)
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
                            alarmTarget.Atrrib = state[list[j].iff_attrib];
                            str[0] = alarmTarget.time;
                            str[1] = alarmTarget.radarNumber;// list[j].radar_batch_id.ToString();
                            str[2] = alarmTarget.radarNumber2;
                            str[3] = alarmTarget.IMO;// list[j].ais_batch_id.ToString();
                            str[4] = alarmTarget.alarmNumber;// list[j].alarm_area_num.ToString();
                            str[5] = alarmTarget.alarmString;// list[j].alarm_type.ToString();
                            str[6] = alarmTarget.country;// list[j].country.ToString();
                            str[7] = alarmTarget.Atrrib;// list[j].iff_attrib.ToString();
                            loginList.Add(str);

                        }
                    }
                    cnt+=dataAnadll.SaveToExcel.Save_AlarmLog(filePathText.Text + "\\alarm.xls", loginList, alarmtitle, 8);
                    filePath =  "alarm.xls";
                }
                else if (listType == _listType.dev)
                {
                    dataAnadll.SystemLogProvider sysp = new dataAnadll.SystemLogProvider(DataQuery.getTimeStamp(startTime), DataQuery.getTimeStamp(endTime));
                    sysp.GetPageNum(out allPage);
                    List<dataAnadll.SystemLog> list;
                    List<string[]> sysList = new List<string[]>();
                    for (int i = 0; i < allPage; i++)
                    {
                        sysp.GetPage(i + 1, out list);

                        for (int j = 0; j < list.Count; j++)
                        {
                            string[] str = new string[6];
                            //str[0] = "###########";
                            str[0] = list[j].machine_IP.ToString();
                            str[1] = list[j].machine_Name.ToString();
                            str[2] = type[list[j].machine_Network];
                            str[3] = type[list[j].machine_Workstate];
                            str[4] = list[j].machine_time.ToString();
                            str[5] = list[j].reason.ToString();
                            sysList.Add(str);
                        }

                    }
                   cnt+=dataAnadll.SaveToExcel.Save_SystemLog(filePathText.Text + "\\device.xls", sysList, devicetitle, 6);
                    filePath = "device.xls";


                }
                if (cnt > 0)
                {
                MessageBoxX.Show("导出提示", string.Format("导出至{0}!",filePath));
                }
                else
                {
                    MessageBoxX.Show("导出提示", string.Format("数据为空,导出失败"));
                }
            }
            catch (Exception ee)
            {

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