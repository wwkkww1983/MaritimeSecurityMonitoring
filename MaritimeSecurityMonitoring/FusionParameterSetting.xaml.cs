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
    /// FusionParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class FusionParameterSetting : Window
    {
        SetConfig sc = new SetConfig();
 
        public static float fXYZThreshold = 5000;
        public static float fDisThreshold = 0;
        public static float fAngleThreshold = 0;
        public static byte ucAlarmThreshold = 1;//按钮
        public static long lRdDieTime = 36;
        public static long lAISDieTime = 36;
        public static long lM = 2;
        public static long lN = 3;
        public static byte UcEstiArith = 1;//按钮

        public static FuseParaManager fuse=new FuseParaManager();//融合数据库

        public FusionParameterSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
           this.DragMove();//实现整个窗口的拖动
        }
        private void promptClick(object sender, RoutedEventArgs e)
        {

        }
        private void warnClick(object sender, RoutedEventArgs e)
        {

        }
        private void optimalClick(object sender, RoutedEventArgs e)
        {

        }
        private void weightedClick(object sender, RoutedEventArgs e)
        {

        }
        private void SF(object sender, RoutedEventArgs e)
        {

        }

        private void yesClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (
                  float.Parse(xyzParameter.Text) > rule1.Max || float.Parse(xyzParameter.Text) < rule1.Min 
                || float.Parse(abrDistance.Text) > rule2.Max || float.Parse(abrDistance.Text) < rule2.Min 
                || float.Parse(abrAngle.Text) > rule3.Max || float.Parse(abrAngle.Text) < rule3.Min 
                || long.Parse(radarDisappearTime.Text) > rule4.Max || long.Parse(radarDisappearTime.Text) < rule4.Min 
                || long.Parse(AISDisappearTime.Text) > rule5.Max || long.Parse(AISDisappearTime.Text) < rule5.Min
                )
                    MessageBoxX.Show("提示", "数据超出范围！");
                else
                {
                    sc.write_string("fusion", "xyz", xyzParameter.Text);
                    sc.write_string("fusion", "abrDistance", abrDistance.Text);
                    sc.write_string("fusion", "abrAngle", abrAngle.Text);
                    sc.write_string("fusion", "radarMiss", radarDisappearTime.Text);
                    sc.write_string("fusion", "AISMiss", AISDisappearTime.Text);
                    sc.write_string("fusion", "IM", IMParameter.Text);
                    sc.write_string("fusion", "IN", INParameter.Text);
                    sc.write_bool("fusionRadio", "prompt", (bool)prompt.IsChecked);
                    sc.write_bool("fusionRadio", "warn", (bool)warn.IsChecked);
                    sc.write_bool("fusionRadio", "optimal", (bool)RadioB3.IsChecked);
                    sc.write_bool("fusionRadio", "weighted", (bool)RadioB4.IsChecked);
                    sc.write_bool("fusionRadio", "SF", (bool)RadioB5.IsChecked);

                    fXYZThreshold = (float)double.Parse(xyzParameter.Text);
                    fDisThreshold = (float)double.Parse(abrDistance.Text);
                    fAngleThreshold = (float)double.Parse(abrAngle.Text);
                    if ((bool)prompt.IsChecked)
                    {
                        ucAlarmThreshold = 1;
                    }
                    else
                    {
                        ucAlarmThreshold = 2;
                    }
                    lRdDieTime = (long)double.Parse(radarDisappearTime.Text);
                    lAISDieTime = (long)double.Parse(AISDisappearTime.Text);
                    lM = (long)double.Parse(IMParameter.Text);
                    lN = (long)double.Parse(INParameter.Text);
                    if ((bool)RadioB3.IsChecked)
                    {
                        UcEstiArith = 1;
                    }
                    else if ((bool)RadioB4.IsChecked)
                    {
                        UcEstiArith = 2;
                    }
                    else if ((bool)RadioB5.IsChecked)
                    {
                        UcEstiArith = 3;
                    }
                    MonitoringX.FusionBack();
                    MainWindow.opeation.OptionName = "设置融合参数";
                    MainWindow.opeation.LogType = 2;
                    MainWindow.opeation.OptionTime = GetTime(GetTimeStamp().ToString());
                    MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);//操作入库
                    MessageBoxX.Show("提示信息", "参数保存成功！");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBoxX.Show("警告", "输入数据有误！请重新输入！");
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
                xyzParameter.Text = "";
                abrDistance.Text = "";
                abrAngle.Text = "";
                radarDisappearTime.Text = "";
                AISDisappearTime.Text = "";
                IMParameter.Text = "";
                INParameter.Text = "";
                prompt.IsChecked = false;
                warn.IsChecked = false;
                RadioB3.IsChecked = false;
                RadioB4.IsChecked = false;
                RadioB5.IsChecked = false;
                this.Close();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FuseParas fus = fuse.GetFuseParas();//查询融合参数,初始化数据

            FusionParameter fp = new FusionParameter
            {
                xyzParameter = fus.XYZThreshold.ToString(),
                abrDistance = fus.DisThreshold.ToString(),
                abrAngle = fus.AngleThreshold.ToString(),
                radarMiss = fus.RadarDieTime.ToString(),
                AISMiss = fus.AISDieTime.ToString(),
                IM = fus.IM.ToString(),
                IN = fus.IN.ToString(),
            };
            DataContext = fp;
            if (fus.AlarmThreshold == 1)
            {
                prompt.IsChecked = true;
                warn.IsChecked = false;
            }
            else if (fus.AlarmThreshold == 2)
            {
                prompt.IsChecked = false;
                warn.IsChecked = true;
            }

            if (fus.EstiArith == 1)
            {
                RadioB3.IsChecked = true;
                RadioB4.IsChecked = false;
                RadioB5.IsChecked = false;
            }
            else if (fus.EstiArith == 2)
            {
                RadioB3.IsChecked = false;
                RadioB4.IsChecked = true;
                RadioB5.IsChecked = false;
            }
            else if(fus.EstiArith==3)
            {
                RadioB3.IsChecked = false;
                RadioB4.IsChecked = false;
                RadioB5.IsChecked = true;
            }
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


    class FusionParameter
    {
        public string xyzParameter { get; set; }
        public string abrDistance { get; set; }
        public string abrAngle { get; set; }
        public string radarMiss { get; set; }
        public string AISMiss { get; set; }
        public string IM { get; set; }
        public string IN { get; set; }
    }
}
