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
    /// GorgeParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class GorgeParameterSetting : Window
    {
        SetConfig sc = new SetConfig();
        private SerialPortInfoManager port=new SerialPortInfoManager();//串口数据库设置
        private int baudRateText;
        private int dataBitsText;
        private int evenOddCheckText;
        private string evenOddCheckStr;
        private int stopBitText;

        private string[] str = { "Even", "Odd", "None", "Space", "Mark" };
        public GorgeParameterSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bool a=port.GetSerialPortInfo(out baudRateText, out dataBitsText, out evenOddCheckText,out stopBitText);
            if (evenOddCheckText == 0)
            {
                evenOddCheckStr = str[0];
            }
            else if (evenOddCheckText == 1)
            {
                evenOddCheckStr = str[1];
            }
            else if (evenOddCheckText == 2)
            {
                evenOddCheckStr = str[2];
            }
            else if (evenOddCheckText == 3)
            {
                evenOddCheckStr = str[3];
            }
            else if (evenOddCheckText == 4)
            {
                evenOddCheckStr = str[4];
            }
            if (!a)
            {
                baudRate.Text = "";
                dataBits.Text = "";
                evenOddCheck.Text = "";
                stopBit.Text = "";
            }
            else
            {
                baudRate.Text = baudRateText.ToString();
                dataBits.Text = dataBitsText.ToString();
                evenOddCheck.Text = evenOddCheckStr;
                stopBit.Text = stopBitText.ToString();
            }
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            if (baudRate.Text == "" || dataBits.Text == "" || evenOddCheck.Text == "" || stopBit.Text == "")
            {
                System.Windows.MessageBox.Show("输入IP内容不能为空，请输入。");
            }
            else
            {
                /*sc.write_string("serialPort", "baudRate", baudRate.Text);
                sc.write_string("serialPort", "dataBits", dataBits.Text);
                sc.write_string("serialPort", "parityBit", evenOddCheck.Text);
                sc.write_string("serialPort", "stopBit", stopBit.Text);*/

                int a=0;
                for(int i=0;i<str.Length;i++){
                    if(str[i]==evenOddCheck.Text){
                        a=i;
                    }
                }

                MainWindow.opeation.OptionName = "设置串口参数";
                MainWindow.opeation.LogType = 2;
                MainWindow.opeation.OptionTime = GetTime(GetTimeStamp().ToString());
                MainWindow.OperationLogData.WriteOperationLog(MainWindow.opeation);//操作入库
                port.SetSerialPortInfo((int)double.Parse(baudRate.Text), (int)double.Parse(dataBits.Text), a, (int)double.Parse(stopBit.Text));

                System.Windows.MessageBox.Show("IP保存成功。");
            }
            this.Close();
        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
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
           /* 
            baudRate.Text = sc.read_string("serialPort", "baudRate");
            dataBits.Text = sc.read_string("serialPort", "dataBits");
            evenOddCheck.Text = sc.read_string("serialPort", "parityBit");
            stopBit.Text = sc.read_string("serialPort", "stopBit");
           */
        }
    }
}
