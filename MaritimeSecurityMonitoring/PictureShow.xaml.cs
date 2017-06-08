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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// PictureShow.xaml 的交互逻辑
    /// </summary>
    public partial class PictureShow : Window
    {
        public PictureShow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            image.Source = new BitmapImage(new Uri(LinkageEventQuery.picturePath, UriKind.Relative));
        }

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
    }
}
