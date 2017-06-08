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
    /// ShowTargetProperty.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTargetProperty : Window
    {
        private SetConfig config = new SetConfig();
        public ShowTargetProperty()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if(config.read_bool("setting", "name"))
            {
                shipName.IsChecked = true;
            }
            else
            {
                shipName.IsChecked = false;
            }


            if(config.read_bool("setting", "speed"))
            {
                shipSpeed.IsChecked = true;
            }
            else
            {
                shipSpeed.IsChecked = false;
            }


            if(config.read_bool("setting", "angle"))
            {
                angle.IsChecked = true;
            }
            else
            {
                angle.IsChecked = false;
            }


            if(config.read_bool("setting", "time"))
            {
                arriveTime.IsChecked = true;
            }
            else
            {
                arriveTime.IsChecked = false;
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
        private void comfireClick(object sender, RoutedEventArgs e)
        {
            if (MonitoringX.page == "当前")
            {
                App app = (App)App.Current;
                if ((bool)shipName.IsChecked)
                {
                    app.chartCtrl.AppConfig.ShowTargetName = true;
                }
                else
                {
                    app.chartCtrl.AppConfig.ShowTargetName = false;
                }


                if ((bool)shipSpeed.IsChecked)
                {
                    app.chartCtrl.AppConfig.ShowTargetSpeed = true;
                }
                else
                {
                    app.chartCtrl.AppConfig.ShowTargetSpeed = false;
                }


                if ((bool)angle.IsChecked)
                {
                    app.chartCtrl.AppConfig.ShowTargetCourse = true;
                }
                else
                {
                    app.chartCtrl.AppConfig.ShowTargetCourse = false;
                }


                if ((bool)arriveTime.IsChecked)
                {
                    app.chartCtrl.AppConfig.ShowTargetArriveTime = true;
                }
                else
                {
                    app.chartCtrl.AppConfig.ShowTargetArriveTime = false;
                }
            }


            if (MonitoringX.page == "回放")
            {
                App app = (App)App.Current;
                if ((bool)shipName.IsChecked)
                {
                    app.returnBack.AppConfig.ShowTargetName = true;
                }
                else
                {
                    app.returnBack.AppConfig.ShowTargetName = false;
                }


                if ((bool)shipSpeed.IsChecked)
                {
                    app.returnBack.AppConfig.ShowTargetSpeed = true;
                }
                else
                {
                    app.returnBack.AppConfig.ShowTargetSpeed = false;
                }


                if ((bool)angle.IsChecked)
                {
                    app.returnBack.AppConfig.ShowTargetCourse = true;
                }
                else
                {
                    app.returnBack.AppConfig.ShowTargetCourse = false;
                }


                if ((bool)arriveTime.IsChecked)
                {
                    app.returnBack.AppConfig.ShowTargetArriveTime = true;
                }
                else
                {
                    app.returnBack.AppConfig.ShowTargetArriveTime = false;
                }
            }
            config.write_bool("setting", "name", (bool)shipName.IsChecked);
            config.write_bool("setting", "speed", (bool)shipSpeed.IsChecked);
            config.write_bool("setting", "angle", (bool)angle.IsChecked);
            config.write_bool("setting", "time", (bool)arriveTime.IsChecked);
            this.Close();
        }
        private void cancelClick(object sender, RoutedEventArgs e)
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
