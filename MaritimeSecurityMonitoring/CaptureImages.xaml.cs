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
using System.Windows.Forms;

using MaritimeSecurityMonitoring.MainInterfacePage;
using dataAnadll;
using Shipname_Recongnize;
using System.IO;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// CaptureImages.xaml 的交互逻辑
    /// </summary>
    public partial class CaptureImages : Window
    {
        private SeleCaptureManager capture = new SeleCaptureManager();//联动事件查询入库
        private DateTime capTime;
        public static string _mmsi;
        public CaptureImages()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;       

            BoatInfo bi = new BoatInfo() { MMSI = _mmsi };

          //MMSIText.Text = _mmsi;
            DataContext = bi;
           
            capTime=GetTime(GetTimeStamp().ToString());
            Picture.ImageSource = new BitmapImage(new Uri(MonitoringX.picfile_path,UriKind.Relative));
        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void recognitionClick(object sender, RoutedEventArgs e)//识别
        {
            MainWindow.opeation.OptionName = "航迹识别";//日志入库
            MainWindow.opeation.LogType = 2;
            MainWindow.opeation.OptionTime = GetTime(GetTimeStamp().ToString());
            MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);

            Recongize shopRecongnize = Recongize.GetInstance(MainWindow.dbIP, MainWindow.dbUser, MainWindow.dbPassword, MainWindow.dbName);//数据识别实例化，需要数据库数据
            string str="";
            try
            {
                Convert.ToInt32(MMSIText.Text);
                str = shopRecongnize.Ship_Find(MMSIText.Text);
            }
            catch
            {

            }
            if (str=="")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
//识别失败返回空字符
                MessageBoxX.Show("舷号识别","识别失败，请手动录入船舷号！");
                }
));
                
            }
            else
            {
                boatNumber.Text = str;//识别成功返回str
            }
        }
        int _rst_update_pic;
        void _Update_Pic()
            //线程使用
        {
            //_rst_update_pic = MonitoringX.updataPictureBack(user, sPassword, localPath, serverIp, serverPath);//上传图片到服务器
            var info = new DirectoryInfo(MonitoringX.picDirect);
            if (info.Exists == false)
            {
                info.Create();
            }
            File.Copy( localPath, MonitoringX.localPicPath + MonitoringX.picfile_name,true);
        }
        void Update_Pic()
        {
            WinProgressBar wpb = new WinProgressBar() { BgWork = _Update_Pic, MaxRespTime = 5 ,BarTitle="正在转存图片"};
            wpb.Topmost = true;
            wpb.ShowDialog();
            int rst = _rst_update_pic;

            if (rst == 0)
                //上传成功,删除图片
            {
                DirectoryInfo info = new DirectoryInfo(MonitoringX.picDirect);
                if (info.Exists)
                {
                    // System.Threading.Thread.Sleep(3000);
                    var files = info.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Name != MonitoringX.picfile_name)
                        {
                            files[i].Delete();
                        }
                    }
                  
                }
            }
        }

        string user = "zhy-mysql";//登录操作系统的名称，密码
        string sPassword = "147";
        string localPath = MonitoringX.picfile_path;
        string serverIp = MainWindow.dbIP;
        //string serverPath = @"/home/zhy-mysql/Image/" + MonitoringX.picfile_name;

        string serverPath ="..//CaptureImages//";
        private void comfirmClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int linkageEnd = GetTimeStamp();
                //WinProgressBar wpb = new WinProgressBar() { BgWork = Update_Pic, MaxRespTime = 10 };
                //wpb.ShowDialog();
                
                AutomaticLinkage.pic_Full_path = serverPath;
                AutomaticLinkage.boat_Name = boatNumber.Text;
                AutomaticLinkage.capTime = capTime;
                Update_Pic();
//                Capture captureEvent = new Capture();
//                captureEvent.capture_Time = capTime;
//                captureEvent.linkage_start = GetTime(AutomaticLinkage.linkageStar.ToString());
//                captureEvent.linkage_end = GetTime(linkageEnd.ToString());
//                captureEvent.picture_path = serverPath;
//                //captureEvent.remark=没有备注界面吧？;
//                captureEvent.Ship_number = boatNumber.Text;
//                captureEvent.target_Id = MonitoringX.nowTarget.ID;
//                //captureEvent.target_type=?
//                capture.WriteSeleCapture(captureEvent);//截图联动事件入库
//                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
//                {
//                        MessageBoxX.Show("联动事件", "入库成功");
//                }
//));

               
                this.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                     MessageBoxX.Show("提示", "船舷号数据有误！");
                }
));
              
            }
        }
        public static int GetTimeStamp()//当前时间转换时间戳
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
        private void cancelClick(object sender, RoutedEventArgs e)//取消关闭
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

    class BoatInfo
    {
        public string boatNumber { get; set; }
        public string MMSI { get; set; }
    }
}
