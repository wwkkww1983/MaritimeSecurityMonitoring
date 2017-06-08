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
    /// NetLine.xaml 的交互逻辑
    /// </summary>
    public partial class NetLine : UserControl
    {

        /// <summary>
        /// 用于表示是否故障的依赖属性
        /// </summary>
        public static readonly DependencyProperty IsBrokenProperty = DependencyProperty.Register("IsBroken", typeof(bool), typeof(NetLine), null, null);
        public NetLine()
        {
            InitializeComponent();
        }


        public bool IsBroken
        {
            get
            {
                return (bool)GetValue(IsBrokenProperty);
            }
            set
            {
                SetValue(IsBrokenProperty, value);
            }
        }
    }
}
