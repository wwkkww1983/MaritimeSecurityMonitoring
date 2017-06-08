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

using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// OptoelectronicPage.xaml 的交互逻辑
    /// </summary>
    public partial class OptoelectronicPage : Page
    {
		//2017 04 18 蒋明昊添加

        public void Fresh()
        {
            if (MonitoringX.photoelectricEquipmentRuningStateStr == "正常")
            {
                right.IsChecked = true;
                worry.IsChecked = false;
            }
            else if (MonitoringX.photoelectricEquipmentRuningStateStr == "故障")
            {
                right.IsChecked = false;
                worry.IsChecked = true;
            }

            text2.Text = MonitoringX.pitchDriveModeStr;
            text3.Text = MonitoringX.bearingDriveModeStr;
            text4.Text = MonitoringX.InfraredStateStr;
            text5.Text = MonitoringX.pitchDriveLimitUpStr;
            text6.Text = MonitoringX.pitchDriveLimitDownStr;
            text7.Text = MonitoringX.bearingDriveLimitLeftStr;
            text8.Text = MonitoringX.bearingDriveLimitRightStr;
            text9.Text = MonitoringX.videoSwitchStateStr;
            text10.Text = MonitoringX.controllerInitializationStateStr;
            text11.Text = MonitoringX.servoStateStr;
            text12.Text = MonitoringX.driveEnabledStateStr;
            text13.Text = MonitoringX.hardDiskVideoStatusStr;
            text14.Text = MonitoringX.wideAngledCameraStatusStr;
            text15.Text = MonitoringX.telephotoCameraStatusStr;

            test1.Text = MonitoringX.targetTrackingStateStr;
            test2.Text = MonitoringX.videoTrackingStatusStr;
            test3.Text = MonitoringX.movingTargetDetectionStr;
            pictchAngle.Text = MonitoringX.pitchAngleMeasurementStr;
            azimuthAngle.Text = MonitoringX.azimuthAngleMeasurementStr;
            waveGateY.Text = MonitoringX.waveGateCenterCoordinateYControlStr;
            waveGateX.Text = MonitoringX.waveGateCenterCoordinateXControlStr;
            pictchMiss.Text = MonitoringX.pitchMissDistanceControlStr;
            azimuthMiss.Text = MonitoringX.azimuthMissDistanceControlStr;

            waveGateXValue.Text = MonitoringX.WaveGateCenterCoordinateX;
            waveGateYValue.Text = MonitoringX.WaveGateCenterCoordinateY;
            OpticalAxisHorizontal.Text = MonitoringX.OpticalAxisHorizontalAngle;
            OpticalAxisPictch.Text = MonitoringX.OpticalAxisPitchAngle;
            pictchMissValue.Text = MonitoringX.PitchMissDistance;
            AzimuthMissValue.Text = MonitoringX.AzimuthMissDistance;
        }

        public void Fresh_ASunlink()
        {

            right.IsChecked = false;
            worry.IsChecked = true;
            text2.Text = "--";
            text3.Text = "--";
            text4.Text = "--";
            text5.Text = "--";
            text6.Text = "--";
            text7.Text = "--";
            text8.Text = "--";
            text9.Text = "--";
            text10.Text = "--";
            text11.Text = "--";
            text12.Text = "--";
            text13.Text = "--";
            text14.Text = "--";
            text15.Text = "--";

            test1.Text = "--";
            test2.Text = "--";
            test3.Text = "--";
            pictchAngle.Text = "--";
            azimuthAngle.Text = "--";
            waveGateY.Text = "--";
            waveGateX.Text = "--";
            pictchMiss.Text = "--";
            azimuthMiss.Text = "--";

            waveGateXValue.Text = "--";
            waveGateYValue.Text = "--";
            OpticalAxisHorizontal.Text = "--";
            OpticalAxisPictch.Text = "--";
            pictchMissValue.Text = "--";
            AzimuthMissValue.Text = "--";
        }
        public OptoelectronicPage()
        {
            InitializeComponent();
            Fresh();
        }
    }
}
