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
    /// DoubleScreen.xaml 的交互逻辑
    /// </summary>
    public partial class DoubleScreen : Window
    {
        IntPtr infraredRayPictureBoxHandle1;//获得句柄
        IntPtr infraredRayPictureBoxHandle2;//获得句柄
        IntPtr infraredRayPictureBoxHandle3;//获得句柄
        IntPtr infraredRayPictureBoxHandle4;//获得句柄

        private TrackEventManager TrackEvent = new TrackEventManager();//追踪数据库实例
        public static DateTime startime;
        public static long videoEndTime;
        private int sign = -1;
        private int[] VideoState = new int[4] { -1,-1,-1,-1};
        public DoubleScreen()
        {
            InitializeComponent();

            var firstScreen = System.Windows.Forms.Screen.AllScreens.Where(s => s.Primary).FirstOrDefault();
            var secondScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();

            var workingArea1 = secondScreen.WorkingArea;
            var workingArea2 = firstScreen.WorkingArea;

            IntPtr wnd = FindWindow(null, "海上平台水面安防预警系统");
            RECT rect = new RECT();
            if (wnd != IntPtr.Zero)
            {
                 GetWindowRect(wnd, ref rect);
            }
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Top = 0;
            this.Left = rect.Right % (System.Windows.SystemParameters.VirtualScreenWidth);
            this.Height = System.Windows.SystemParameters.VirtualScreenHeight;
            this.Width = rect.Right - rect.Left;
            
            infraredRayPictureBox1.mouseDoubleClick += longFocusPointDouble;//长焦双击回调注册
            infraredRayPictureBox2.mouseDoubleClick += infraredRayPointDouble;//红外双击回调注册
            infraredRayPictureBox3.mouseDoubleClick += telephotoPointDouble;//广角双击回调注册

            infraredRayPictureBox4.mouseSingleClick_Left += longFocusPointLeft;//追踪左键回调注册
            infraredRayPictureBox4.mouseSingleClick_Right += longFocusPointRight;//追踪右键回调注册

            infraredRayPictureBox1.change_Pic("..\\..\\Image\\video.png");
            infraredRayPictureBox2.change_Pic("..\\..\\Image\\video.png");
            infraredRayPictureBox3.change_Pic("..\\..\\Image\\video.png");
            infraredRayPictureBox4.change_Pic("..\\..\\Image\\video.png");

            infraredRayPictureBoxHandle1 = infraredRayPictureBox1.Handle;//长焦视频句柄
            infraredRayPictureBoxHandle2 = infraredRayPictureBox2.Handle;//红外视频句柄
            infraredRayPictureBoxHandle3 = infraredRayPictureBox3.Handle;//广角视频句柄
            infraredRayPictureBoxHandle4 = infraredRayPictureBox4.Handle;//一路视频句柄

            startime = GetTime(GetTimeStamp().ToString());
            startPlay();
        }
        public void close()
        {
            this.Close();
        }
        private void window_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /*
         * 视频播放模块（start）*************************************************************************************/
        public void realPlay()//开始播放
        {
            if (VideoState[0] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[0]);
            }
            if (VideoState[1] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[1]);
            }
            if (VideoState[2] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[2]);
            }

            if (VideoState[3] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[3]);
            }
            sign = NVRCsharpDemo.DVRAPI.GetInstance().DVRAPI_Init();//初始化DVR登录

            VideoState[0]= NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, infraredRayPictureBoxHandle1);//长焦视频播放
            VideoState[1]= NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(1, infraredRayPictureBoxHandle2);//红外视频播放
            VideoState[2]= NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(4, infraredRayPictureBoxHandle3);//广角视频播放
            VideoState[3]= NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, infraredRayPictureBoxHandle4);//一路视频播放

        }
        public void startPlay()//获取视频句柄
        {

            //Thread thread = new Thread(new ThreadStart(realPlay));
            // thread.Start();
            // thread.Join();
            WinProgressBar wpb = new WinProgressBar() { BgWork = realPlay, MaxRespTime = 2,BarTitle="双屏显示启动中" };
            wpb.ShowDialog();
            if (VideoState[0] < 0)
            {
                infraredRayPictureBox1.change_Pic("..\\..\\Image\\video.png");
            }
            if (VideoState[1] < 0)
            {
                infraredRayPictureBox2.change_Pic("..\\..\\Image\\video.png");
            }
            if (VideoState[2] < 0)
            {
                infraredRayPictureBox3.change_Pic("..\\..\\Image\\video.png");
            }
            if (VideoState[3] < 0)
            {
                infraredRayPictureBox4.change_Pic("..\\..\\Image\\video.png");
            }
        }
        void longFocusPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//长焦追踪（开关）
        {
            if (VideoState[3] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[3]);
            }
            VideoState[3]= NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, infraredRayPictureBoxHandle4);//长焦追踪
            startime = GetTime(GetTimeStamp().ToString());
            MonitoringX.nowVideoType = 3;

        }
        void infraredRayPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//红外追踪（开关）
        {
            if (VideoState[3] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[3]);
            }
            VideoState[3] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(1, infraredRayPictureBoxHandle4);//红外追踪
            startime = GetTime(GetTimeStamp().ToString());

			MonitoringX.nowVideoType = 1;
        }
        void telephotoPointDouble(object sender, System.Windows.Forms.MouseEventArgs e)//广角追踪（开关）
        {
            if (VideoState[3] >= 0)
            {
                NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(VideoState[3]);
            }
            VideoState[3] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(4, infraredRayPictureBoxHandle4);//广角追踪
            startime = GetTime(GetTimeStamp().ToString());

   			MonitoringX.nowVideoType = 4;
        }
        public void followPointMove(string x, string y)//控制十字标靶移动
        {
            if (MonitoringX.deviceControlState == 0)
            {
                //nothing
            }
            else
            {
                System.Drawing.Point point = new System.Drawing.Point();
                point.X = (short)double.Parse(x);
                point.Y = (short)double.Parse(y);
                infraredRayPictureBox4.drawNotion(point, 50);
            }
        }
        void longFocusPointLeft(object sender, System.Windows.Forms.MouseEventArgs e)//追踪（开关）
        {
            if (MonitoringX.deviceControlState == 0)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("提示", "无光电控制权");
                }
                ));
            }
            else
            {
                short x = (short)e.Location.X;
                short y = (short)e.Location.Y;
                int a = GetTimeStamp();
                MonitoringX.photoPoint(a, x, y);
                startime = GetTime(GetTimeStamp().ToString());
            }
        }
        void longFocusPointRight(object sender, System.Windows.Forms.MouseEventArgs e)//追踪（开关）
        {
            int a = GetTimeStamp();
            MonitoringX.photoClose(a);
            //this.Close();不关闭窗口
            videoEndTime = (long)GetTimeStamp();
            TrackEvent smtp = new TrackEvent();
            Application.Current.MainWindow = smtp;
            smtp.ShowDialog();
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

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Buttom;
        }
    }
}
