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
using PhotoelectricModule;
using dataAnadll;
using MaritimeSecurityMonitoring.MainInterfacePage;
namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// RadarFirstPage.xaml 的交互逻辑
    /// </summary>
    public partial class RadarFirstPage : Page
    {
        public RadarFirstPage()
        {
            InitializeComponent();
            Fresh_Unlink();
        }
        public void Fresh_Unlink()
        {

              RadarStatus1.Text = "异常";
              AntStatus1.Text = string.Format("异常");
              TransStatus1.Text = string.Format("异常");
               RecStatus1.Text = string.Format("异常");
               ProcessorStatus1.Text = string.Format("异常");
               radarStatus2.Text = "异常";
               AntStatus2.Text = string.Format("异常");
               TransStatus2.Text = string.Format("异常");
               RecStatus2.Text = string.Format("异常");
               ProcessorStatus2.Text = string.Format("异常");
            
        }
        public void Fresh(dataAnadll.FUS_ICD.RdStatus_S rdStatus)
        {
            if (rdStatus.PardPara.ucRadarID == 1)
                //雷达1
            {
                
                if (rdStatus.ucRadarStatus == 1)
                {
                    RadarStatus1.Text = "正常";
                }
                else
                {
                    RadarStatus1.Text = "异常";
                }
                if (rdStatus.ucAntStatus == 1)
                {
                    AntStatus1.Text = "正常";
                }
                else
                {
                    AntStatus1.Text = string.Format("异常,故障码:{0}", rdStatus.ucAntStatus);
                }
                if (rdStatus.ucTransStatus == 1)
                {
                    TransStatus1.Text = "正常";
                }
                else
                {
                    TransStatus1.Text = string.Format("异常,故障码:{0}", rdStatus.ucTransStatus);
                }
                if (rdStatus.ucRecStatus == 1)
                {
                    RecStatus1.Text = "正常";
                }
                else
                {
                    RecStatus1.Text = string.Format("异常,故障码:{0}", rdStatus.ucRecStatus);
                }
                if (rdStatus.ucProcessorStatus == 1)
                {
                    ProcessorStatus1.Text = "正常";
                }
                else
                {
                    ProcessorStatus1.Text = string.Format("异常,故障码:{0}", rdStatus.ucProcessorStatus);
                }
            }
            else if (rdStatus.PardPara.ucRadarID == 2)
                //雷达2
            {
                if (rdStatus.ucRadarStatus == 1)
                {
                    radarStatus2.Text = "正常";
                }
                else
                {
                    radarStatus2.Text = "异常";
                }
                if (rdStatus.ucAntStatus == 1)
                {
                    AntStatus2.Text = "正常";
                }
                else
                {
                    AntStatus2.Text = string.Format("异常,故障码:{0}", rdStatus.ucAntStatus);
                }
                if (rdStatus.ucTransStatus == 1)
                {
                    TransStatus2.Text = "正常";
                }
                else
                {
                    TransStatus2.Text = string.Format("异常,故障码:{0}", rdStatus.ucTransStatus);
                }
                if (rdStatus.ucRecStatus == 1)
                {
                    RecStatus2.Text = "正常";
                }
                else
                {
                    RecStatus2.Text = string.Format("异常,故障码:{0}", rdStatus.ucRecStatus);
                }
                if (rdStatus.ucProcessorStatus == 1)
                {
                    ProcessorStatus2.Text = "正常";
                }
                else
                {
                    ProcessorStatus2.Text = string.Format("异常,故障码:{0}", rdStatus.ucProcessorStatus);
                }
            }
        }
        
    }
}
