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
    /// IconButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconButton : UserControl
    {
        public IconButton()
        {
            InitializeComponent();
        }

        public ImageSource ImagesSource
        {
            get { return (ImageSource)GetValue(ImagesSourceProperty); }
            set { SetValue(ImagesSourceProperty, value); }
        }

        public static readonly DependencyProperty ImagesSourceProperty = DependencyProperty.Register("ImagesSource", typeof(ImageSource), typeof(IconButton));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(IconButton));

        private void IconButton_OnLoaded(object sender, RoutedEventArgs e)
        {
            var data = new IconButtonModel()
            {
                ImagesSource = ImagesSource,
                Text=Text,
            };
            this.DataContext = data;
        }

        public delegate void ClickEventArgs(object sender, RoutedEventArgs e);

        public event ClickEventArgs Click;
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }
        }
    }

    public class IconButtonModel
    {
        public ImageSource ImagesSource { get; set; }
        public string Text { get; set; }
    }
}