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

namespace MaritimeSecurityMonitoring.Content
{


    /// <summary>
    /// DeviceIcon.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceIcon : UserControl
    {
        /// <summary>
        /// 用于显示设备名称的依赖属性
        /// </summary>
        public static readonly DependencyProperty DeviceNameProperty = DependencyProperty.Register("DeviceName", typeof(string), typeof(DeviceIcon), null, null);

        /// <summary>
        /// 用于显示设备名称的依赖属性
        /// </summary>
        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(DeviceIcon), null, null);


        public DeviceIcon()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设备名
        /// </summary>
        public string DeviceName
        {
            get
            {
                return (string)GetValue(DeviceNameProperty);
            }
            set
            {
                SetValue(DeviceNameProperty, value);
            }
        }

        /// <summary>
        /// 设备名
        /// </summary>
        public ImageSource ImgSource
        {
            get
            {
                return (ImageSource)GetValue(ImgSourceProperty);
            }
            set
            {
                SetValue(ImgSourceProperty, value);
            }
        }
    }
}
