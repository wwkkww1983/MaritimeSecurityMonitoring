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
using System.IO;
using MaritimeSecurityMonitoring.MainInterfacePage;
using System.Windows.Forms;
using dataAnadll;
using Shipname_Recongnize;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// ShipNumberImport.xaml 的交互逻辑
    /// </summary>
    public partial class ShipNumberImport : Window
    {
        private string filePath = "";
        public ShipNumberImport()
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
        private void searchPath(object sender, RoutedEventArgs e)//文件路径查找
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV文件|*.csv";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = open.FileName;
                path.Text = open.FileName;
            } 
        }
        
        private void sure(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePath) || File.Exists(filePath) == false)
            {
                MessageBoxX.Show("舷号导入提示", "数据文件为空或不存在");
                //this.Close();
                return;
            }
            WinProgressBar wpb = new WinProgressBar() { BgWork = Update_ShipName, MaxRespTime =30, BarTitle="船舷号导入中" };
            
            wpb.ShowDialog();

            this.Close();
        }
        static public bool UpdateWell=false;
        private void Update_ShipName()
        {
            UpdateWell = false;
            Recongize shopRecongnize = Recongize.GetInstance(MainWindow.dbIP, MainWindow.dbUser, MainWindow.dbPassword, MainWindow.dbName);//数据识别实例化，需要数据库数据
            shopRecongnize.Date_update(filePath);//上传 
            UpdateWell = true;
        }
        private void cancel(object sender, RoutedEventArgs e)
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
}
