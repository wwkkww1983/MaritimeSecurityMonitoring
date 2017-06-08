using MaritimeSecurityMonitoring.MainInterfacePage;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MessageBoxX.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxX : Window
    {
        private MessageBoxX()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }


        public new string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }  
        }

        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }

        public static bool ? Show(string title, string msg)
        {

                MessageBoxX msgBox = new MessageBoxX();
                msgBox.Title = title;
                msgBox.Message = msg;
                msgBox.Topmost = true;
                return msgBox.ShowDialog();
            

            return true;
        }

        private void OK_MouseLeftButtonDown(object sender, RoutedEventArgs e)
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
