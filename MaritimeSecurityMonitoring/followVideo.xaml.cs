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
using NVRCsharpDemo;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// followVideo.xaml 的交互逻辑
    /// </summary>
    public partial class followVideo : Window
    {
        IntPtr followPictureBoxHandle;//获得句柄
        //public static long videoStartTime;
        public static long videoEndTime;
        //private int left = 0;//右键关闭状态位,0不弹出事件记录，1弹出实际记录
        public static followVideo dialog;
        int vidioState = 0;
        public followVideo()
        { 
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Closing += closeSoftware;
            this.Closed += closeWindowClick;
            followPictureBox.mouseSingleClick_Left += longFocusPointLeft;//长焦左键回调注册
            followPictureBox.mouseSingleClick_Right += longFocusPointRight;//长焦右键回调注册

            int a=GetTimeStamp();
            title.Content = "追踪视频";
            if (MonitoringX.nowVideoType == 3)
            {
                MonitoringX.photoType(a,0);
            }
            else if (MonitoringX.nowVideoType == 1)
            {
                MonitoringX.photoType(a, 1);
            }
            else if (MonitoringX.nowVideoType == 4)
            {
                MonitoringX.photoType(a, 2);
            }

            this.Topmost=true;//置于顶层
            
            //videoStartTime = (long)GetTimeStamp();
            startPlay();
            followVideo.dialog = this;
        }
        public void changeVideoType()//播放视屏类型
        {
            startPlay();
        }
        private void closeSoftware(object o, object e)//关闭界面时关闭跟踪
        {
            int a = GetTimeStamp();
            MonitoringX.photoClose(a);
        }
        private void closeWindowClick(object sender, object e)
        {
            MonitoringX.trackState = false;//追踪事件状态位归零
            NVRCsharpDemo.DVRAPI.GetInstance().Stop_PlayBack(vidioState);
            this.Close();//关闭窗口
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        /*光电视频播放模块（start）*************************************************************************************/
        public void realPlay()//开始播放
        {
            int sign = NVRCsharpDemo.DVRAPI.GetInstance().DVRAPI_Init();//初始化DVR登录
            vidioState=NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(MonitoringX.nowVideoType, followPictureBoxHandle);//长焦视频播放
        }
        public void startPlay()//获取视频句柄
        {
            followPictureBoxHandle = followPictureBox.Handle;//追踪
            Thread Thread = new Thread(new ThreadStart(realPlay));
            Thread.Start();
        }
        public void followPointMove(string x,string y)//控制十字标靶移动
        {
            System.Drawing.Point point = new System.Drawing.Point();
            point.X = (short)double.Parse(x);
            point.Y = (short)double.Parse(y);
            followPictureBox.drawNotion(point,50);
        }
        void longFocusPointLeft(object sender, System.Windows.Forms.MouseEventArgs e)//追踪（开关）
        {
            short x = (short)e.Location.X;
            short y = (short)e.Location.Y;
            int a = GetTimeStamp();
            MonitoringX.photoPoint(a,x,y);
            MonitoringX.trackStartTime = a;
        }
        void longFocusPointRight(object sender, System.Windows.Forms.MouseEventArgs e)//追踪（开关）
        {
            int a = GetTimeStamp();
            this.Visibility = Visibility.Collapsed;
            MonitoringX.photoClose(a);
            //this.Close();不关闭窗口
            videoEndTime = (long)GetTimeStamp();
            TrackEvent smtp = new TrackEvent();
            smtp.Closed += TrackEventClosed;
            Application.Current.MainWindow = smtp;
            smtp.ShowDialog();
			//先将回放界面隐藏
        }
        public static int GetTimeStamp()//当前时间转换时间戳
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
        private void TrackEventClosed(object sender, object ee)
        {
            this.Visibility = Visibility.Visible;
        }
    }
}
