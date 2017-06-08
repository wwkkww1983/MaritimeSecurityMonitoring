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
using System.ComponentModel;
using System.Threading;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// WinProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class WinProgressBar : Window
    {
        private BackgroundWorker bgWorker = new BackgroundWorker();
        public Action BgWork { get; set; }//关联的耗时任务
        public int MaxRespTime { get; set; }//预计的最大响应时间，单位秒
        public string BarTitle { get; set; }//进度条标题
        private Random rand;
        public WinProgressBar()
        {
            InitializeComponent();

            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += DoWork_Handler;
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
            rand = new Random(0);
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bgWorker.CancelAsync();
        }

        public void BeginWork()
        {
            if (bgWorker.IsBusy)
                return;
            bgWorker.RunWorkerAsync();
        }

        private void DoWork_Handler(object sender, DoWorkEventArgs e)
        {
            if (BgWork != null)
            {
                Thread thread = new Thread(new ThreadStart(BgWork));
                thread.Start();
                //
                BackgroundWorker worker = sender as BackgroundWorker;
                for (int i = 1; i <= 100; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        thread.Abort();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(MaxRespTime*10);
                        worker.ReportProgress(i);
                    }
                    if (thread.IsAlive== true)
                    {

                            if (i % 2 == 0)
                            {
                            if (i < 50)
                            {
                                MaxRespTime += (int)(Math.Log10(i * i));
                            }
                            else
                            {
                                MaxRespTime += (int)(Math.Min(128, Math.Pow(2, (i - 50)%10)));
                            }
                            }
           
                    }
                    else
                    {
                        MaxRespTime /= 64;
                    }
                }
                thread.Abort();
            }
        }

        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxX.Show("提示信息", "已取消等待！");
            }
            this.Close();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            title.Content = BarTitle;
            BeginWork();
        }
    }
}
