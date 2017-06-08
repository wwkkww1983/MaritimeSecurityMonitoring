﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;

using dataAnadll;
using Visifire.Charts;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DataStatistics.xaml 的交互逻辑
    /// </summary>
    public partial class DataStatistics : Page
    {
        ObservableCollection<string> child = new ObservableCollection<string>();
        private CountManager count = new CountManager();//数据库统计实例
        private List<string> mouth = new List<string>();//月数名list
        private dataAnadll.CountType type= CountType.All;//目标类型
        private string title = "圈层报警";//标题

        Dictionary<string, List<int>> dic;//结果字典
        List<int> list;//结果list
        private int tip = 0;//报警类型标志位：1圈层，2多边形，3管道，4平台

        int startYear = DateTime.Now.Year;
        int startMonth = 1;
        int endYear = DateTime.Now.Year;
        int endMonth = DateTime.Now.Month;

        //柱状图y值
        private List<string> strListy1 = new List<string>() { };
        //柱状图x值
        private List<string> strListx1 = new List<string>() { };
        //备选月份
        private List<string> mouthStr = new List<string>() { "", "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
        //折线x值
        private List<DateTime> LsTime1 = new List<DateTime>(){};
        public DataStatistics()
        {
            InitializeComponent();

            StartTime.SelectedDate = new DateTime(DateTime.Now.Year, 1, 1);
            EndTime.SelectedDate = DateTime.Now;
           
            dic = count.CountCircleProtectAreaAlarm(StartTime.SelectedDate.Value.Year, StartTime.SelectedDate.Value.Month, EndTime.SelectedDate.Value.Month);

            foreach (string key in dic.Keys)
            {
                child.Add(key);
            }
            childBox.DataContext = child;
            tip = 1;
        }
        private int GetTimeStamp(DateTime dt)//datatime转时间戳
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 0, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }
        private void choose(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ComboBoxItem cbi = cb.SelectedItem as ComboBoxItem;
            if (cbi.HasContent&&cbi.Content.ToString() == "所有目标")
            {
                type = CountType.All;
                getList();
            }
            else if (cbi.HasContent && cbi.Content.ToString() == "可疑目标")
            {
                type = CountType.Suspicious;
                getList();
            }
            else if (cbi.HasContent && cbi.Content.ToString() == "越南渔船")
            {
                type = CountType.Vietnam;
                getList();
            }
        }

        private void getList()
        {
            child.Clear();//刷新列表

            startYear = StartTime.SelectedDate.Value.Year;
            startMonth = StartTime.SelectedDate.Value.Month;

            endYear = EndTime.SelectedDate.Value.Year;
            endMonth = EndTime.SelectedDate.Value.Month;

            if (endYear != startYear)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("提示", "不支持跨年查询！");
                }
));

            }
            else if (endYear == startYear)
            {
                if (title == "圈层报警")
                {
                    dic = count.CountCircleProtectAreaAlarm(startYear, startMonth, endMonth, type);

                    foreach (string key in dic.Keys)
                    {
                        child.Add(key);
                    }

                    title = "圈层报警";
                }
                else if (title == "多边形报警")
                {
                    dic = count.CountPolygonAlarm(startYear, startMonth, endMonth, type);
                    foreach (string key in dic.Keys)
                    {
                        child.Add(key);
                    }

                    title = "多边形报警";
                }
                else if (title == "管道报警")
                {
                    dic = count.CountPipelineAlarm(startYear, startMonth, endMonth, type);
                    foreach (string key in dic.Keys)
                    {
                        child.Add(key);
                    }

                    title = "管道报警";
                }
                else if (title == "平台报警")
                {
                    list = count.CountPlantformAlarm(startYear, startMonth, endMonth, type);
                    child.Add("平台中心");

                    title = "平台中心报警";
                }
                else if (title == "所有区域")
                {
                    list = count.CountAllAlarm(startYear, startMonth, endMonth, type);
                    child.Add("所有区域");

                    title = "所有区域报警";
                }
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child.Clear();//刷新列表

            ComboBox cb = sender as ComboBox;
            ComboBoxItem cbi = cb.SelectedItem as ComboBoxItem;


            startYear = StartTime.SelectedDate.Value.Year;
            startMonth = StartTime.SelectedDate.Value.Month;

            endYear = EndTime.SelectedDate.Value.Year;
            endMonth = EndTime.SelectedDate.Value.Month;

            if (endYear != startYear)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxX.Show("提示", "不支持跨年查询！");
                }
));
                
            }
            else if (endYear == startYear)
            {

                startYear = StartTime.SelectedDate.Value.Year;
                startMonth = StartTime.SelectedDate.Value.Month;

                endYear = EndTime.SelectedDate.Value.Year;
                endMonth = EndTime.SelectedDate.Value.Month;
                if (startYear == endYear&& startMonth< endMonth)
                {
                    if (cbi.HasContent && cbi.Content.ToString() == "圈层报警")
                    {
                        dic = count.CountCircleProtectAreaAlarm(startYear, startMonth, endMonth,type);

                        foreach (string key in dic.Keys)
                        {
                            child.Add(key);
                        }

                        title = "圈层报警";
                    }
                    else if (cbi.HasContent && cbi.Content.ToString() == "多边形报警")
                    {
                        dic = count.CountPolygonAlarm(startYear, startMonth, endMonth,type);
                        foreach (string key in dic.Keys)
                        {
                            child.Add(key);
                        }

                        title = "多边形报警";
                    }
                    else if (cbi.HasContent && cbi.Content.ToString() == "管道报警")
                    {
                        dic = count.CountPipelineAlarm(startYear, startMonth, endMonth,type);
                        foreach (string key in dic.Keys)
                        {
                            child.Add(key);
                        }

                        title = "管道报警";
                    }
                    else if (cbi.HasContent && cbi.Content.ToString() == "平台报警")
                    {
                        list = count.CountPlantformAlarm(startYear, startMonth, endMonth, type);
                        child.Add("平台中心");

                        title = "平台中心报警";
                    }
                    else if (cbi.HasContent && cbi.Content.ToString() == "所有区域")
                    {
                        list = count.CountAllAlarm(startYear, startMonth, endMonth, type);
                        child.Add("所有区域");

                        title = "所有区域报警";
                    }
                }
            }
        }
        private void statisticsClick(object sender, RoutedEventArgs e)
        {
            if (childBox.Text == "")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
  MessageBoxX.Show("提示", "未选择对应子项！");
                }
));
              
            }
            else
            {
                startYear = StartTime.SelectedDate.Value.Year;
                startMonth = StartTime.SelectedDate.Value.Month;

                endYear = EndTime.SelectedDate.Value.Year;
                endMonth = EndTime.SelectedDate.Value.Month;
                if (startMonth > endMonth)
                {
                    MessageBoxX.Show("提示", "时间设置不正常");
                    return;
                }
                if (endYear != startYear)
                {
                    MessageBoxX.Show("提示", "不支持跨年查询！");
                }
                else if (endYear == startYear)
                {
                    mouth.Clear();//刷新
                    strListx1.Clear();//清空
                    strListy1.Clear();//清空
                    LsTime1.Clear();//清除

                    startYear = StartTime.SelectedDate.Value.Year;
                    startMonth = StartTime.SelectedDate.Value.Month;

                    endYear = EndTime.SelectedDate.Value.Year;
                    endMonth = EndTime.SelectedDate.Value.Month;


                    if (startYear == endYear)
                    {
                        if (title == "圈层报警")
                        {
                            dic = count.CountCircleProtectAreaAlarm(startYear, startMonth, endMonth, type);
                            tip = 1;
                        }
                        else if (title == "多边形报警")
                        {
                            dic = count.CountPolygonAlarm(startYear, startMonth, endMonth, type);
                            tip = 2;
                        }
                        else if (title == "管道报警")
                        {
                            dic = count.CountPipelineAlarm(startYear, startMonth, endMonth, type);
                            tip = 3;
                        }
                        else if (title == "平台中心报警")
                        {
                            list = count.CountPlantformAlarm(startYear, startMonth, endMonth,type);
                            tip = 4;
                        }
                        else if (title == "所有区域报警")
                        {
                            list = count.CountAllAlarm(startYear, startMonth, endMonth, type);
                            tip = 5;
                        }
                    }

                    if (tip == 1)
                    {
                        for (int i = 0; i < dic[childBox.Text].Count; i++)
                        {
                            mouth.Add(dic[childBox.Text][i].ToString());
                        };

                    }
                    else if (tip == 2)
                    {

                        for (int i = 0; i < dic[childBox.Text].Count; i++)
                        {
                            mouth.Add(dic[childBox.Text][i].ToString());
                        };

                    }
                    else if (tip == 3)
                    {

                        for (int i = 0; i < dic[childBox.Text].Count; i++)
                        {
                            mouth.Add(dic[childBox.Text][i].ToString());
                        };

                    }
                    else if (tip == 4)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            mouth.Add(list[i].ToString());
                        };
                    }
                    else if (tip == 5)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            mouth.Add(list[i].ToString());
                        };
                    }

                    //数据层
                    for (int a = startMonth; a <= endMonth; a++)
                    {
                        strListx1.Add(mouthStr[a]);
                        strListy1.Add(mouth[a - startMonth]);
                        LsTime1.Add(new DateTime(startYear, a , 1));
                    }

                    if (chartType.Text == "柱状图")
                    {
                        ButColumn1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButColumn1));
                    }
                    if (chartType.Text == "饼状图")
                    {
                        ButPie1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButPie1));
                    }
                    if (chartType.Text == "折线图")
                    {
                        ButSpline1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButSpline1));
                    }
                }
            }
        }
        private void ButColumn_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartColumn1(title+"统计", strListx1, strListy1);
        }

        private void ButPie_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartPie1(title + "统计", strListx1, strListy1);
            int count = 0;
            for (int i=0;i<strListy1.Count();i++){
                if (strListy1[i]!="0")
                {
                    count = 1;
                }
            }

            if (count == 0)
            {

                MessageBoxX.Show("提示","报警次数为零！");
            }
        }
        private void ButSpline_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartSpline1(title + "统计", LsTime1, strListy1);
        }
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
        #region 柱状图
        public void CreateChartColumn1(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();
            chart.Rendered += chart_Rendered;
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
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);
            title.FontSize = 18;

            //向图标添加标题
            chart.Titles.Add(title);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "次";
            chart.AxesY.Add(yAxis);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.StackedColumn;//柱状Stacked


            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 饼状图
        public void CreateChartPie1(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();
            chart.Rendered += chart_Rendered;
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
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);
            title.FontSize = 18;

            //向图标添加标题
            chart.Titles.Add(title);

            //Axis yAxis = new Axis();
            ////设置图标中Y轴的最小值永远为0           
            //yAxis.AxisMinimum = 0;
            ////设置图表中Y轴的后缀          
            //yAxis.Suffix = "斤";
            //chart.AxesY.Add(yAxis);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.Pie;//柱状Stacked


            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];

                dataPoint.LegendText = "##" + valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 折线图
        public void CreateChartSpline1(string name, List<DateTime> lsTime, List<string> cherry)
        {
            //创建一个图标
            Chart chart = new Chart();
            chart.Rendered += chart_Rendered;
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
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);
            title.FontSize = 18;

            //向图标添加标题
            chart.Titles.Add(title);

            //初始化一个新的Axis
            Axis xaxis = new Axis();
            //设置Axis的属性
            //图表的X轴坐标按什么来分类，如时分秒
            xaxis.IntervalType = IntervalTypes.Months;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "MM月";
            //给图标添加Axis            
            chart.AxesX.Add(xaxis);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "次";
            chart.AxesY.Add(yAxis);








            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();
            // 设置数据线的格式。               
            dataSeries.LegendText = "报警";

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
                dataPoint.YValue = double.Parse(cherry[i]);
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


            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 点击事件
        //点击事件
        void dataPoint_MouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            //DataPoint dp = sender as DataPoint;
            //MessageBox.Show(dp.YValue.ToString());
        }
        #endregion
    }

    #region 年月日历
    public class DatePickerCalendar
    {

        public static bool GetIsYear(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsYearProperty);
        }

        public static void SetIsYear(DependencyObject obj, bool value)
        {
            obj.SetValue(IsYearProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsYear.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsYearProperty =
            DependencyProperty.RegisterAttached("IsYear", typeof(bool), typeof(DatePickerCalendar), new PropertyMetadata(false, new PropertyChangedCallback(OnIsMonthYearChanged)));



        public static readonly DependencyProperty IsMonthYearProperty =
        DependencyProperty.RegisterAttached("IsMonthYear", typeof(bool), typeof(DatePickerCalendar),
                                            new PropertyMetadata(OnIsMonthYearChanged));

        public static bool GetIsMonthYear(DependencyObject dobj)
        {
            return (bool)dobj.GetValue(IsMonthYearProperty);
        }

        public static void SetIsMonthYear(DependencyObject dobj, bool value)
        {
            dobj.SetValue(IsMonthYearProperty, value);
        }

        private static void OnIsMonthYearChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = (DatePicker)dobj;

            Application.Current.Dispatcher
                .BeginInvoke(DispatcherPriority.Loaded,
                             new Action<DatePicker, DependencyPropertyChangedEventArgs>(SetCalendarEventHandlers),
                             datePicker, e);
        }

        private static void SetCalendarEventHandlers(DatePicker datePicker, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue)
                return;

            if ((bool)e.NewValue)
            {
                datePicker.CalendarOpened += DatePickerOnCalendarOpened;
                datePicker.CalendarClosed += DatePickerOnCalendarClosed;
            }
            else
            {
                datePicker.CalendarOpened -= DatePickerOnCalendarOpened;
                datePicker.CalendarClosed -= DatePickerOnCalendarClosed;
            }
        }

        private static void DatePickerOnCalendarOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            var calendar = GetDatePickerCalendar(sender);
            if (GetIsYear(sender as DatePicker))
            {
                calendar.DisplayMode = CalendarMode.Decade;
            }
            else
            {
                calendar.DisplayMode = CalendarMode.Year;
            }

            calendar.DisplayModeChanged += CalendarOnDisplayModeChanged;
        }

        private static void DatePickerOnCalendarClosed(object sender, RoutedEventArgs routedEventArgs)
        {
            var datePicker = (DatePicker)sender;
            var calendar = GetDatePickerCalendar(sender);
            datePicker.SelectedDate = calendar.SelectedDate;

            calendar.DisplayModeChanged -= CalendarOnDisplayModeChanged;
        }

        private static void CalendarOnDisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            var calendar = (Calendar)sender;
            var datePicker = GetCalendarsDatePicker(calendar);

            bool mode = (GetIsYear(datePicker) && calendar.DisplayMode != CalendarMode.Year) || (GetIsMonthYear(datePicker) && calendar.DisplayMode != CalendarMode.Month);

            if (mode)
                return;

            calendar.SelectedDate = GetSelectedCalendarDate(calendar.DisplayDate);

            datePicker.IsDropDownOpen = false;
        }

        private static Calendar GetDatePickerCalendar(object sender)
        {
            var datePicker = (DatePicker)sender;
            var popup = (Popup)datePicker.Template.FindName("PART_Popup", datePicker);
            return ((Calendar)popup.Child);
        }

        private static DatePicker GetCalendarsDatePicker(FrameworkElement child)
        {
            var parent = (FrameworkElement)child.Parent;
            if (parent.Name == "PART_Root")
                return (DatePicker)parent.TemplatedParent;
            return GetCalendarsDatePicker(parent);
        }

        private static DateTime? GetSelectedCalendarDate(DateTime? selectedDate)
        {
            if (!selectedDate.HasValue)
                return null;
            return new DateTime(selectedDate.Value.Year, selectedDate.Value.Month, 1);
        }
    }
    #endregion
}
