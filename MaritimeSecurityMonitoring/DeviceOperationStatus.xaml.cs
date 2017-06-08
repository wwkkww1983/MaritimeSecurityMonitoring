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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DeviceOperationStatus.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceOperationStatus : Page
    {
		static public AISPage aisp;
        static public RadarFirstPage radarFirstp;
       // static public RadarSecondPage radarSecondp;
        static public OptoelectronicPage optoelectronicp;
        static public MixServerPage mixServerp;
        static public DatabaseServerPage dataServerp;
       // static public InterchangePage interchangep;
        static public MonitoringFirstPage monitoringFirstp;
        static public MonitoringSecondPage monitoringSecondp;
        static public DeviceOperationStatus CurrentInstance;

        static public ContentControl CurrentControl;//保存当前显示的页面
      static public DeviceOperationStatus GetInstance()
        {
            if (CurrentInstance == null)
            {
                CurrentInstance = new DeviceOperationStatus();
            }
            return CurrentInstance;
        }
        private DeviceOperationStatus()
        {
            InitializeComponent();
            content.NavigationUIVisibility = NavigationUIVisibility.Hidden;
 			CurrentControl = new ContentControl();
        }
        private void AISClick(object sender, RoutedEventArgs e)
        {
               if (aisp == null)
            {
                AISPage p = new AISPage();
                aisp = p;
            }
            content.Content = aisp;
            CurrentControl = content;
        }
        private void radarFirstClick(object sender, RoutedEventArgs e)
        {
            if (radarFirstp == null)
            {
                RadarFirstPage p = new RadarFirstPage();
                radarFirstp = p;
            }
            content.Content = radarFirstp;
            CurrentControl = content;
        }
 
        private void optoelectronicClick(object sender, RoutedEventArgs e)
        {
             if (optoelectronicp == null)
            {
                OptoelectronicPage p = new OptoelectronicPage();
                optoelectronicp = p;
            }
            content.Content = optoelectronicp;
            CurrentControl = content;
        }
        private void mixServerClick(object sender, RoutedEventArgs e)
        {  
            if (mixServerp == null)
            {

                MixServerPage p = new MixServerPage();
                mixServerp = p;
            }
            content.Content = mixServerp;
            CurrentControl = content;
        }

 
        private void mornitoringFirstClick(object sender, RoutedEventArgs e)
        {
            if (monitoringFirstp == null)
            {
                MonitoringFirstPage p = new MonitoringFirstPage();
                monitoringFirstp = p;
            }
            content.Content = monitoringFirstp;
            CurrentControl = content;
        }
        private void mornitoringSecondClick(object sender, RoutedEventArgs e)
        {
            if (monitoringSecondp == null)
            {
                MonitoringSecondPage p = new MonitoringSecondPage();
                monitoringSecondp = p;
            }
            content.Content = monitoringSecondp;
            CurrentControl = content;
        }

  		private void databaseServerClick(object sender, RoutedEventArgs e)
        {
            if (dataServerp == null)
            {
                DatabaseServerPage p = new DatabaseServerPage();
                dataServerp = p;
            }
            content.Content = dataServerp;
            CurrentControl = content;
        }
    }
}
