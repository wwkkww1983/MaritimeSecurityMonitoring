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
    /// ShowAISTargetProperty.xaml 的交互逻辑
    /// </summary>
    public partial class ShowAISTargetProperty : Window
    {
        public ShowAISTargetProperty()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (MonitoringX.page == "当前")
            {

                boatName.Text = MonitoringX.nowTarget.Name;
                trackAngle.Text = MonitoringX.nowTarget.Course.ToString();
                IMO.Text = MonitoringX.nowTarget.IMO.ToString();
                speed.Text = MonitoringX.nowTarget.Speed.ToString();
                MMSI.Text = MonitoringX.nowTarget.MIMSI;
                findTime.Text = MonitoringX.nowTarget.UpdateTime;
                boatNumber.Text = MonitoringX.nowTarget.CallSign;
                trackStatus.Text = SailStatusToStringConverter.SailStatusMap[MonitoringX.nowTarget.SailStatus];
                country.Text = MonitoringX.nowTarget.Nationality;
                high.Text = MonitoringX.nowTarget.MaxDeep.ToString();
                longitude.Text = MonitoringX.nowTarget.Longitude.ToString();
                peopleNumber.Text = MonitoringX.nowTarget.Capacity.ToString();
                latitude.Text = MonitoringX.nowTarget.Latitude.ToString();
                destination.Text = MonitoringX.nowTarget.Destination;

            }else if(MonitoringX.page == "回放")
            {
                boatName.Text = MonitoringReturn.nowTarget.Name;
                trackAngle.Text = MonitoringReturn.nowTarget.Course.ToString();
                IMO.Text = MonitoringReturn.nowTarget.IMO.ToString();
                speed.Text = MonitoringReturn.nowTarget.Speed.ToString();
                MMSI.Text = MonitoringReturn.nowTarget.MIMSI;
                findTime.Text = MonitoringReturn.nowTarget.UpdateTime;
                boatNumber.Text = MonitoringReturn.nowTarget.CallSign;
                trackStatus.Text = SailStatusToStringConverter.SailStatusMap[MonitoringReturn.nowTarget.SailStatus];
                country.Text = MonitoringReturn.nowTarget.Nationality;
                high.Text = MonitoringReturn.nowTarget.MaxDeep.ToString();
                longitude.Text = MonitoringReturn.nowTarget.Longitude.ToString();
                peopleNumber.Text = MonitoringReturn.nowTarget.Capacity.ToString();
                latitude.Text = MonitoringReturn.nowTarget.Latitude.ToString();
                destination.Text = MonitoringReturn.nowTarget.Destination;
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
