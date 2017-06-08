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
using Visifire.Charts;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DatabaseServerPage.xaml 的交互逻辑
    /// </summary>
    public partial class DatabaseServerPage : Page
    {
        private Chart chart1;
        private Chart chart2;
        private Chart chart3;
        private Chart chart4;
        private Grid gr1, gr2, gr3, gr4;
        private Queue<double> value1;//CPU
        private Queue<double> value2;//温度不使用！！！！
        private Queue<double> value3;//内存使用率
        private Queue<double> value4;//磁盘利用率
        private Queue<int> x;
        private int queueLength = 10;//只展示最近10次的数据
        public void Fresh(double _cpuUse, double _temperature, double _roomUse, double _disks)
        //页面数据刷新函数
        {
            //_roomUse = 100;
            //_disks = 100;
  
            cpuUse.Text = String.Format("{0,3:F3}", (_cpuUse)) + "%";//cpu使用率
            temperature.Text = "40°";//cpu温度
            rooms.Text = String.Format("{0,3:F3}", (_roomUse)) + "%";//内存
            disks.Text = String.Format("{0,3:F3}", (_disks)) + "%";//磁盘占用率

            if (x.Count >= queueLength)
            {
                x.Dequeue();
            }
            else
            {
                x.Enqueue(x.Count + 1);
            }
            if (value1.Count >= queueLength)
            {
                value1.Dequeue();
            }
            value1.Enqueue(_cpuUse);

            if (value2.Count >= queueLength)
            {
                value2.Dequeue();
            }
            value2.Enqueue(_temperature);

            if (value3.Count >= queueLength)
            {
                value3.Dequeue();
            }
            value3.Enqueue(_disks);

            if (value4.Count >= queueLength)
            {
                value4.Dequeue();
            }
            value4.Enqueue(_roomUse);


            double[] cpus = value1.ToArray();
            double[] temp = value2.ToArray();
            double[] disk = value3.ToArray();
            double[] roomss = value4.ToArray();
            DataSeries[] series = new DataSeries[4];
            series[0] = new DataSeries();
            series[1] = new DataSeries();
            series[2] = new DataSeries();
            series[3] = new DataSeries();

            for (int i = 0; i < value1.Count; i++)
            {
                DataPoint point1 = new DataPoint();
                DataPoint point2 = new DataPoint();
                DataPoint point3 = new DataPoint();
                DataPoint point4 = new DataPoint();
                point1.XValue = i;
                point2.XValue = i;
                point3.XValue = i;
                point4.XValue = i;

                point1.YValue = cpus[i];
                series[0].DataPoints.Add(point1);


                point2.YValue = temp[i];
                series[1].DataPoints.Add(point2);



                point4.YValue = disk[i];
                series[2].DataPoints.Add(point4);

                point3.YValue = roomss[i];
                series[3].DataPoints.Add(point3);



            }

            series[0].RenderAs = RenderAs.Spline;
            series[1].RenderAs = RenderAs.Spline;
            series[2].RenderAs = RenderAs.Spline;
            series[3].RenderAs = RenderAs.Spline;

            chart1.Series.Clear();
            chart1.Series.Add(series[0]);
            chart1.AxesY[0].AxisMaximum = value1.Max() + 0.2;
            chart1.AxesY[0].AxisMinimum = value1.Min() - 0.2;
            chart1.AxesY[0].Interval = ((double)chart1.AxesY[0].AxisMaximum - (double)chart1.AxesY[0].AxisMinimum) / 5;

            chart2.Series.Clear();
            chart2.Series.Add(series[1]);

            chart2.AxesY[0].AxisMaximum = value2.Max() + 0.2;
            chart2.AxesY[0].AxisMinimum = value2.Min() - 0.2;
            chart2.AxesY[0].Interval = ((double)chart2.AxesY[0].AxisMaximum - (double)chart2.AxesY[0].AxisMinimum) / 5;

            chart3.Series.Clear();
            chart3.Series.Add(series[2]);

            chart3.AxesY[0].AxisMaximum = value3.Max() + 0.2;
            chart3.AxesY[0].AxisMinimum = value3.Min() - 0.2;
            chart3.AxesY[0].Interval = ((double)chart3.AxesY[0].AxisMaximum - (double)chart3.AxesY[0].AxisMinimum) / 5;

            chart4.Series.Clear();
            chart4.Series.Add(series[3]);

            chart4.AxesY[0].AxisMaximum = value4.Max() + 0.2;
            chart4.AxesY[0].AxisMinimum = value4.Min() - 0.2;
            chart4.AxesY[0].Interval = ((double)chart4.AxesY[0].AxisMaximum - (double)chart4.AxesY[0].AxisMinimum) / 5;

            // MessageBox.Show(series[0].DataPoints[0].YValue.ToString() + "," + series[0].DataPoints[0].YValue.ToString());
            //label_Temp.Content = "(" + series[0].DataPoints[0].XValue.ToString() + "," + series[0].DataPoints[0].YValue.ToString() + ")";
            if (gr1 == null)
            {
                gr1 = new Grid();
            }
            if (gr2 == null)
            {
                gr2 = new Grid();
            }
            if (gr3 == null)
            {
                gr3 = new Grid();
            }
            if (gr4 == null)
            {
                gr4 = new Grid();
            }
            gr1.Children.Clear();
            gr1.Children.Add(chart1);
            Simon1.Children.Clear();
            Simon1.Children.Add(gr1);

            gr2.Children.Clear();
            gr2.Children.Add(chart2);
            Simon2.Children.Clear();
            Simon2.Children.Add(gr2);

            gr3.Children.Clear();
            gr3.Children.Add(chart3);
            Simon3.Children.Clear();
            Simon3.Children.Add(gr3);

            gr4.Children.Clear();
            gr4.Children.Add(chart4);
            Simon4.Children.Clear();
            Simon4.Children.Add(gr4);

        }
        static int flag = 0;

        void chart_Rendered(object sender, EventArgs e)
        {
            try
            {
                var c = sender as Chart;
                var legend = c.Legends[0];
                var root = legend.Parent as Grid;
                root.Children.RemoveAt(10);
                root.Children.RemoveAt(9);
            }
            catch (Exception ee)
            {

            }
        }
        public DatabaseServerPage()
        {
            InitializeComponent();
            chart1 = new Chart();
            chart2 = new Chart();
            chart3 = new Chart();
            chart4 = new Chart();

            chart1.Rendered += chart_Rendered;
            chart2.Rendered += chart_Rendered;
            chart3.Rendered += chart_Rendered;
            chart4.Rendered += chart_Rendered;

            chart1.BorderThickness = new Thickness(0);
            chart1.Background = Brushes.Transparent;
            chart1.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart1.ToolBarEnabled = false;

            //设置图标的属性
            chart1.ScrollingEnabled = false;//是否启用或禁用滚动
            chart1.View3D = true;//3D效果显示

            chart2.BorderThickness = new Thickness(0);
            chart2.Background = Brushes.Transparent;
            chart2.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart2.ToolBarEnabled = false;

            //设置图标的属性
            chart2.ScrollingEnabled = false;//是否启用或禁用滚动
            chart2.View3D = true;//3D效果显示

            chart3.BorderThickness = new Thickness(0);
            chart3.Background = Brushes.Transparent;
            chart3.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart3.ToolBarEnabled = false;

            //设置图标的属性
            chart3.ScrollingEnabled = false;//是否启用或禁用滚动
            chart3.View3D = true;//3D效果显示

            chart4.BorderThickness = new Thickness(0);
            chart4.Background = Brushes.Transparent;
            chart4.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart4.ToolBarEnabled = false;

            //设置图标的属性
            chart4.ScrollingEnabled = false;//是否启用或禁用滚动
            chart4.View3D = true;//3D效果显示



            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            yAxis.AxisMaximum = 100;
            yAxis.Interval = 20;
            //设置图表中Y轴的后缀          
            //yAxis.Suffix = sign;
            chart1.AxesY.Add(yAxis);

            Axis yAxis2 = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis2.AxisMinimum = 0;
            yAxis2.AxisMaximum = 100;
            yAxis2.Interval = 20;
            //设置图表中Y轴的后缀          
            //yAxis.Suffix = sign;
            chart2.AxesY.Add(yAxis2);


            Axis yAxis3 = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis3.AxisMinimum = 0;
            yAxis3.AxisMaximum = 100;
            yAxis3.Interval = 20;
            //设置图表中Y轴的后缀          
            //yAxis.Suffix = sign;
            chart3.AxesY.Add(yAxis3);


            Axis yAxis4 = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis4.AxisMinimum = 0;
            yAxis4.AxisMaximum = 100;
            yAxis4.Interval = 20;
            //设置图表中Y轴的后缀          
            //yAxis.Suffix = sign;
            chart4.AxesY.Add(yAxis4);


            value1 = new Queue<double>();
            value2 = new Queue<double>();
            value3 = new Queue<double>();
            value4 = new Queue<double>();
            x = new Queue<int>();

        }

        public void CreateChartSpline(List<DateTime> lsTime, List<string> value, string sign, Grid Simon)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            //            chart.Width = 530;
            //            chart.Height = 300;
            chart.BorderThickness = new Thickness(0);
            chart.Background = Brushes.Transparent;
            chart.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            //Title title = new Title();

            //设置标题的名称
            //title.Text = name;
            //title.Padding = new Thickness(0, 10, 5, 0);
            //title.FontSize = 18;

            //向图标添加标题
            //chart.Titles.Add(title);

            //初始化一个新的Axis
            Axis xaxis = new Axis();
            //设置Axis的属性
            //图表的X轴坐标按什么来分类，如时分秒
            xaxis.IntervalType = IntervalTypes.Seconds;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "ss";
            //给图标添加Axis            
            chart.AxesX.Add(xaxis);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            yAxis.AxisMaximum = 100;
            yAxis.Interval = 20;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = sign;
            chart.AxesY.Add(yAxis);


            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();
            // 设置数据线的格式。               
            //dataSeries.LegendText = "预警区";

            dataSeries.RenderAs = RenderAs.Spline;//折线图

            dataSeries.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(value[i]);
                dataPoint.MarkerSize = 8;
                //dataPoint.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);









            // 创建一个新的数据线。               
            /*DataSeries dataSeriesPineapple = new DataSeries();
            // 设置数据线的格式。         

            dataSeriesPineapple.LegendText = "警戒区";

            dataSeriesPineapple.RenderAs = RenderAs.Spline;//折线图

            dataSeriesPineapple.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint2;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint2 = new DataPoint();
                // 设置X轴点                    
                dataPoint2.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint2.YValue = double.Parse(pineapple[i]);
                dataPoint2.MarkerSize = 8;
                //dataPoint2.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint2.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeriesPineapple.DataPoints.Add(dataPoint2);
            }
            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeriesPineapple);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           







            // 创建一个新的数据线。               
            DataSeries dataSeriesPineapple1 = new DataSeries();
            // 设置数据线的格式。         

            dataSeriesPineapple1.LegendText = "驱逐区";

            dataSeriesPineapple1.RenderAs = RenderAs.Spline;//折线图

            dataSeriesPineapple1.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint3;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint3 = new DataPoint();
                // 设置X轴点                    
                dataPoint3.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint3.YValue = double.Parse(tianjia[i]);
                dataPoint3.MarkerSize = 8;
                //dataPoint2.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint3.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeriesPineapple1.DataPoints.Add(dataPoint3);
            }
            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeriesPineapple1);*/

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           



            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon.Children.Add(gr);
        }

        void dataPoint_MouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            //DataPoint dp = sender as DataPoint;
            //MessageBox.Show(dp.YValue.ToString());
        }
    }
}
