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

using dataAnadll;
using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// PhotoelectricMaintenance.xaml 的交互逻辑
    /// </summary>
    public partial class PhotoelectricMaintenance : Window
    {
        private PhotoelectricParaManager photo = new PhotoelectricParaManager();//光电数据库实例
        
        public PhotoelectricMaintenance()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DriftCompensationAngle dca = new DriftCompensationAngle();
            PhotoelectricParas data = photo.GetPhotoelectricParas();//数据库查询光电参数
            dca.azimuth1 =data.AzimuthGyroCompensation.ToString();
            dca.pitch1 =data.PitchgGyroCompensation.ToString();
            dca.azimuth2 =data.AzimuthDriverCompensation.ToString();
            dca.pitch2 =data.PitchDriveCompensation.ToString();
            dca.height = data.SetHeight.ToString();
            DataContext = dca;
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void restartClick(object sender, RoutedEventArgs e)//控制杆重启
        {
            MonitoringX.restart();
        }

        int min = -200, max = 200;
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            TextBox tb = FindName(b.Tag.ToString()) as TextBox;
            int itry;
            if (!int.TryParse(tb.Text, out itry)) return;
            else if (itry < max && itry >= min)
                tb.Text = Convert.ToString(itry + 1);
            else
                tb.Text = min.ToString();
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            TextBox tb = FindName(b.Tag.ToString()) as TextBox;
            int itry;
            if (!int.TryParse(tb.Text, out itry)) return;
            else if (itry > max || itry <= min)
                tb.Text = max.ToString();
            else
                tb.Text = Convert.ToString(itry - 1);
        }

        private void comfirmClick(object sender, RoutedEventArgs e)//确定
        {
            try
            {
                if (int.Parse(Azimuth1.Text) > rule1.Max || int.Parse(Azimuth1.Text) < rule1.Min 
                    || int.Parse(Pitch1.Text) > rule2.Max || int.Parse(Pitch1.Text) < rule2.Min 
                    || int.Parse(Azimuth2.Text) > rule3.Max || int.Parse(Azimuth2.Text) < rule3.Min 
                    || int.Parse(Pitch2.Text) > rule4.Max || int.Parse(Pitch2.Text) < rule4.Min 
                    || float.Parse(Height.Text) > rule5.Max || float.Parse(Height.Text) < rule5.Min)
                    MessageBoxX.Show("提示", "数据超出范围！");
                else
                {
                    MonitoringX.azimuthgyroDriveDriftCompensate(int.Parse(Azimuth1.Text));
                    MonitoringX.pitchgyroDriveDriftCompensate(int.Parse(Pitch1.Text));
                    MonitoringX.AzimuthDriveDriftCompensate(int.Parse(Azimuth2.Text));
                    MonitoringX.PitchDriveDriftCompensate(int.Parse(Pitch2.Text));

                    PhotoelectricParas data = new PhotoelectricParas();
                    data.AzimuthDriverCompensation = int.Parse(Azimuth2.Text);
                    data.PitchDriveCompensation = int.Parse(Pitch2.Text);
                    data.AzimuthGyroCompensation = int.Parse(Azimuth1.Text);
                    data.PitchgGyroCompensation = int.Parse(Pitch1.Text);
                    data.SetHeight = float.Parse(Height.Text);
                    MonitoringX.photoHeight = float.Parse(Height.Text);

                    photo.UpdatePhotoelectricPara(data);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBoxX.Show("警告", "存在非法或为空的数据！");
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)//取消
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

    class DriftCompensationAngle
    {
        public string azimuth1 { get; set; }//螺旋方位值
        public string pitch1 { get; set; }//螺旋俯仰值
        public string azimuth2 { get; set; }//驱动漂移值
        public string pitch2 { get; set; }//驱动俯仰值
        public string height { get; set; }//光电架设高度
    } 
}
