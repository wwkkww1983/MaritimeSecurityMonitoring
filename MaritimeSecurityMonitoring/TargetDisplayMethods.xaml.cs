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
using System.Runtime.InteropServices;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// TargetDisplayMethods.xaml 的交互逻辑
    /// </summary>
    public partial class TargetDisplayMethods : Window
    {
        [DllImport("gdi32")]
        private static extern int GetPixel(int hdc, int nXPos, int nYPos);
        [DllImport("user32")]
        private static extern int GetWindowDC(int hwnd);
        [DllImport("user32")]
        private static extern int ReleaseDC(int hWnd, int hDC);

        SetConfig sc = new SetConfig();
        public TargetDisplayMethods()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//弹窗居中
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭窗口
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void workBoatColorClick(object sender, RoutedEventArgs e)
        {
            wokerColorPlate.Visibility = Visibility.Visible;//出现工作船选色框
        }
        private void merchantShipColorClick(object sender, RoutedEventArgs e)
        {
            shipColorPlate.Visibility = Visibility.Visible;//出现商船选色框
        }
        private void fishBoatColorClick(object sender, RoutedEventArgs e)
        {
            fishColorPlate.Visibility = Visibility.Visible;//出现渔船选色框
        }
        private void vietnameseBoatClick(object sender, RoutedEventArgs e)
        {
            vietnamColorPlate.Visibility = Visibility.Visible;//出现越南渔选色框
        }
        private void unknownTargetColorClick(object sender, RoutedEventArgs e)
        {
            unknowColorPlate.Visibility = Visibility.Visible;//出现不明目标选色框
        }
        private void wokerColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);               //捕获鼠标在选色框点击点坐标
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));//获得点击点颜色值
            workBoatColor.Background = br;                         //将颜色值表现在按钮的颜色上
        }
        private void shipColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);               //捕获鼠标在选色框点击点坐标
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));//获得点击点颜色值
            merchantShipColor.Background = br;                         //将颜色值表现在按钮的颜色上
        }
        private void fishColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);               //捕获鼠标在选色框点击点坐标
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));//获得点击点颜色值
            fishBoatColor.Background = br;                         //将颜色值表现在按钮的颜色上
        }
        private void vietnamColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);               //捕获鼠标在选色框点击点坐标
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));//获得点击点颜色值
            vietnameseBoat.Background = br;                        //将颜色值表现在按钮的颜色上
        }
        private void unknowColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);               //捕获鼠标在选色框点击点坐标
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));//获得点击点颜色值
            unknownTargetColor.Background = br;                    //将颜色值表现在按钮的颜色上
        }
        private void wokerColorPlateDown(object sender, MouseEventArgs e)
        {
            wokerColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void shipColorPlateDown(object sender, MouseEventArgs e)
        {
            shipColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void fishColorPlateDown(object sender, MouseEventArgs e)
        {
            fishColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void vietnamColorPlateDown(object sender, MouseEventArgs e)
        {
            vietnamColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void unknowColorPlateDown(object sender, MouseEventArgs e)
        {
            unknowColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void brokenLineColorPlateDown(object sender, MouseEventArgs e)
        {
            brokenLineColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void straightLineColorPlateDown(object sender, MouseEventArgs e)
        {
            straightLineColorPlate.Visibility = Visibility.Collapsed;//点击获得颜色值后，消去选色板
        }
        private void brokenLineColorMove(object sender, MouseEventArgs e)
        {
            brokenLineColorPlate.Visibility = Visibility.Visible;//鼠标移出  获得颜色值后，消去选色板
        }
        private void pointLineColorMove(object sender, MouseEventArgs e)
        {
            straightLineColorPlate.Visibility = Visibility.Visible;//鼠标移出  点击获得颜色值后，消去选色板
        }
        private void brokenLineColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));
            brokenLineColor.Background = br;                       //获得点击点坐标，获得颜色值，并表现出来。
        }
        private void straightLineColorPlateMove(object sender, MouseEventArgs e)
        {
            var pos1 = e.GetPosition(null);
            Point pos = this.PointToScreen(pos1);
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)pos.X, (int)pos.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Brush br = new SolidColorBrush(Color.FromRgb(r, g, b));
            pointLineColor.Background = br;                      //获得点击点坐标，获得颜色值，并表现出来。
        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            sc.write_brush("targetColor", "workShip", workBoatColor.Background);
            sc.write_brush("targetColor", "merchantShip",merchantShipColor.Background);
            sc.write_brush("targetColor", "fishingShip", fishBoatColor.Background);
            sc.write_brush("targetColor", "vietnamShip", vietnameseBoat.Background);
            sc.write_brush("targetColor", "unknown", unknownTargetColor.Background);
            sc.write_brush("targetColor", "wakeWidth", brokenLineColor.Background);
            sc.write_brush("targetColor", "wakeRadius", pointLineColor.Background);
            sc.write_string("length", "lineWidth", lineWidth.Text);
            sc.write_string("length", "lineRadius", lineRadius.Text);
            sc.write_bool("targetShow", "brokenLine",(bool)brokenLine.IsChecked );
            sc.write_bool("targetShow", "pointLine",(bool)pointLine.IsChecked );
            sc.write_bool("targetShow", "targetWake" ,(bool)targetWake.IsChecked);
            sc.write_bool("targetShow", "signDisplay", (bool)signDisplay.IsChecked);
            sc.write_bool("targetShow", "position", (bool)position.IsChecked);
            sc.write_bool("targetShow", "speed", (bool)speed.IsChecked);
            sc.write_bool("targetShow", "acceleration", (bool)acceleration.IsChecked);
            sc.write_bool("targetShow", "IFF", (bool)IFF.IsChecked);
            sc.write_bool("targetShow", "recognitionProperties", (bool)recognitionProperties.IsChecked);
            sc.write_bool("targetShow", "shippingMark", (bool)shippingMark.IsChecked);
            sc.write_bool("targetShow", "shipPage", (bool)shipPage.IsChecked);
            sc.write_bool("targetShow", "callNumber", (bool)callNumber.IsChecked);
            sc.write_bool("targetShow", "trackLine", (bool)trackLine.IsChecked);
            System.Windows.MessageBox.Show("显示方式设置成功。");
            this.Close();                                           //设置数据成功。
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();                                          //取消设置。
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            workBoatColor.Background=sc.read_brush("targetColor", "workShip");
            merchantShipColor.Background = sc.read_brush("targetColor", "merchantShip");
            fishBoatColor.Background = sc.read_brush("targetColor", "fishingShip");
            vietnameseBoat.Background = sc.read_brush("targetColor", "vietnamShip");
            unknownTargetColor.Background = sc.read_brush("targetColor", "unknown");
            brokenLineColor.Background = sc.read_brush("targetColor", "wakeWidth");
            pointLineColor.Background = sc.read_brush("targetColor", "wakeRadius");
            lineWidth.Text = sc.read_string("length", "lineWidth");
            lineRadius.Text = sc.read_string("length", "lineRadius");
            brokenLine.IsChecked = sc.read_bool("targetShow", "brokenLine");
            pointLine.IsChecked = sc.read_bool("targetShow", "pointLine");
            targetWake.IsChecked = sc.read_bool("targetShow", "targetWake");
            signDisplay.IsChecked = sc.read_bool("targetShow", "signDisplay");
            position.IsChecked = sc.read_bool("targetShow", "position");
            speed.IsChecked = sc.read_bool("targetShow", "speed");
            acceleration.IsChecked = sc.read_bool("targetShow", "acceleration");
            IFF.IsChecked = sc.read_bool("targetShow", "IFF");
            recognitionProperties.IsChecked = sc.read_bool("targetShow", "recognitionProperties");
            shippingMark.IsChecked = sc.read_bool("targetShow", "shippingMark");
            shipPage.IsChecked = sc.read_bool("targetShow", "shipPage");
            callNumber.IsChecked = sc.read_bool("targetShow", "callNumber");
            trackLine.IsChecked = sc.read_bool("targetShow", "trackLine");
        }
    }
}