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

using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// ShowRadarTargetProperty.xaml 的交互逻辑
    /// </summary>
    public partial class ShowRadarTargetProperty : Window
    {
        public ShowRadarTargetProperty()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (MonitoringX.page == "当前")
            {
                if (MonitoringX.nowTarget.RadarBatchNum != 0)
                    radarNumber.Text = MonitoringX.nowTarget.RadarBatchNum.ToString();
                if (MonitoringX.nowTarget.RadarBatchNum2 != 0)
                    radarNumber2.Text = MonitoringX.nowTarget.RadarBatchNum2.ToString();
                trackAngle.Text = MonitoringX.nowTarget.Course.ToString();
                distance.Text = MonitoringX.nowTarget.Distance.ToString();
                north.Text = MonitoringX.nowTarget.North.ToString();
                longitude.Text = MonitoringX.nowTarget.Longitude.ToString();
                speed.Text = MonitoringX.nowTarget.Speed.ToString();
                lagitude.Text = MonitoringX.nowTarget.Latitude.ToString();
                findeTime.Text = MonitoringX.nowTarget.UpdateTime;
            }else if(MonitoringX.page == "回放")
            {
                if (MonitoringReturn.nowTarget.RadarBatchNum != 0)
                    radarNumber.Text = MonitoringReturn.nowTarget.RadarBatchNum.ToString();
                if (MonitoringReturn.nowTarget.RadarBatchNum2 != 0)
                    radarNumber2.Text = MonitoringReturn.nowTarget.RadarBatchNum2.ToString();
                trackAngle.Text = MonitoringReturn.nowTarget.Course.ToString();
                distance.Text = MonitoringReturn.nowTarget.Distance.ToString();
                north.Text = MonitoringReturn.nowTarget.North.ToString();
                longitude.Text = MonitoringReturn.nowTarget.Longitude.ToString();
                speed.Text = MonitoringReturn.nowTarget.Speed.ToString();
                lagitude.Text = MonitoringReturn.nowTarget.Latitude.ToString();
                findeTime.Text = MonitoringReturn.nowTarget.UpdateTime;
            }

        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
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
}
