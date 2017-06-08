using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MaritimeSecurityMonitoring.MainInterfacePage;

using dataAnadll;
namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// AutomaticLinkage.xaml 的交互逻辑
    /// </summary>
    public partial class AutomaticLinkage : Window
    {
        IntPtr connectPictureBoxHandle;//获取播放窗口句柄
        public static int linkageStar = 0;//联动事件开始事件戳
        public int videoState = -2;
        public static Capture captureEvent;
        public static string pic_Full_path;
        public static string boat_Name;
        public static DateTime capTime;
        public AutomaticLinkage()
        {
            InitializeComponent();
            this.Closing += closeSoftware;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startPlay();
            linkageStar = GetTimeStamp();
            pic_Full_path = "";
            boat_Name = "";
            capTime = CaptureImages.GetTime(GetTimeStamp().ToString());
        }
        
        private void closeSoftware(object sender, System.ComponentModel.CancelEventArgs e)//当界面关闭的时候
        {
            //联动数据入库
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            int linkageEnd = GetTimeStamp();
            SeleCaptureManager capture = new SeleCaptureManager();
            Capture captureEvent = new Capture();
            captureEvent.capture_Time = capTime;
            captureEvent.linkage_start =CaptureImages.GetTime(AutomaticLinkage.linkageStar.ToString());
            captureEvent.linkage_end =  CaptureImages.GetTime(linkageEnd.ToString());
            captureEvent.picture_path = pic_Full_path;
  
            captureEvent.Ship_number = boat_Name;
            captureEvent.target_Id = MonitoringX.nowTarget.ID;
 
            capture.WriteSeleCapture(captureEvent);//截图联动事件入库
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                MessageBoxX.Show("联动事件", "入库成功");
            }
            ));
            NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState);
            this.Close();//关闭窗口
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            startPlay();//开始播放视频
        }
        /*光电视频播放模块（start）*************************************************************************************/
        public void realPlay()//开始播放
        {
            videoState = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, connectPictureBoxHandle);//长焦视频播放
        }
        private void startPlay()//获取视频句柄
        {
            connectPictureBoxHandle = connectPictureBox.Handle;//追踪
            Thread Thread = new Thread(new ThreadStart(realPlay));
            Thread.Start();
            Thread.Join();
            if (videoState < 0)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                MessageBoxX.Show("光电视频提示", "视频无信号");
                }
                ));                    
                return;
            }
        }
        private void captureClick(object sender, RoutedEventArgs e)
        {
            
            MonitoringX.captureImages();//截取长焦视频，保留到指定路径
            MonitoringX.eventCaputureTime = GetTimeStamp();//获取截图时间
         //   CaptureImages._mmsi = MonitoringX.linkageTarget.TargetMMSI; 该为由link_auto直接控制
           
           
            CaptureImages w = new CaptureImages();//打开新窗口，展示图片
            w.Closed += CaptureClosed;
            System.Windows.Application.Current.MainWindow = w;
           // this.Visibility = Visibility.Collapsed;//隐藏当前窗口
            w.Topmost = true; 
            Thread.Sleep(1000 * 1);
            w.ShowDialog();
          
            
        }
        public static int GetTimeStamp()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void CaptureClosed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            
        }
    }
}
