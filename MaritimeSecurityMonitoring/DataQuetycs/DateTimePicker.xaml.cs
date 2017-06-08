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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DateTimePicker.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimePicker : UserControl
    {
        public DateTime SetTime { get; set; }

        public DateTimePicker()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string),
            typeof(DateTimePicker),
            new PropertyMetadata("TextBlock", new PropertyChangedCallback(OnTextChanged)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        static void OnTextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            DateTimePicker source = (DateTimePicker)sender;
            source.tb.Text = (string)args.NewValue;
        }

        private void ShowCalendarClick(object sender, RoutedEventArgs e)
        {
            cPopup.IsOpen = true;
        }

        private void ShowDate(object sender, SelectionChangedEventArgs e)
        {
            year.Text = Convert.ToString(Calendar1.SelectedDate.Value.Year) + " /";
            if (Calendar1.SelectedDate.Value.Month >= 10)
                month.Text = Convert.ToString(Calendar1.SelectedDate.Value.Month) + " /";
            else
                month.Text = "0" + Convert.ToString(Calendar1.SelectedDate.Value.Month) + " /";
            if (Calendar1.SelectedDate.Value.Day >= 10)
                day.Text = Convert.ToString(Calendar1.SelectedDate.Value.Day);
            else
                day.Text = "0" + Convert.ToString(Calendar1.SelectedDate.Value.Day);
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int itry;
            if (b.Tag.ToString() == "hour"){
                if (!int.TryParse(HourSet.Text, out itry)) return;
                else if (itry < 23 && itry >= 0)
                    HourSet.Text = Convert.ToString(itry + 1);
                else
                    HourSet.Text = "0";
            }
                
            else if (b.Tag.ToString() == "minute"){
                if (!int.TryParse(MinuteSet.Text, out itry)) return;
                else if (itry < 59 && itry>=0)
                    MinuteSet.Text = Convert.ToString(itry + 1);
                else
                    MinuteSet.Text = "0";
            }

            else if (b.Tag.ToString() == "second")
            {
                if (!int.TryParse(SecondSet.Text, out itry)) return;
                else if (itry < 59 && itry >= 0)
                    SecondSet.Text = Convert.ToString(itry + 1);
                else
                    SecondSet.Text = "0";
            }
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int itry;
            if (b.Tag.ToString() == "hour")
            {
                if (!int.TryParse(HourSet.Text, out itry)) return;
                else if (itry > 23 || itry <= 0)
                    HourSet.Text = "23";
                else
                    HourSet.Text = Convert.ToString(itry - 1);
            }

            else if (b.Tag.ToString() == "minute")
            {
                if (!int.TryParse(MinuteSet.Text, out itry)) return;
                else if (itry > 59 || itry <= 0)
                    MinuteSet.Text = "59";
                else
                    MinuteSet.Text = Convert.ToString(itry - 1);
            }

            else if (b.Tag.ToString() == "second")
            {
                if (!int.TryParse(SecondSet.Text, out itry)) return;
                else if (itry > 59 || itry <= 0)
                    SecondSet.Text = "59";
                else
                    SecondSet.Text = Convert.ToString(itry - 1);
            }
        }

        private void ShowHour(object sender, TextChangedEventArgs e)
        {
            int itry;
            if (!int.TryParse(HourSet.Text, out itry)) return;
            else if (itry < 0 || itry > 23) return;
            else if (itry < 10)
                hour.Text = "0" + Convert.ToString(itry) + " :";
            else
                hour.Text = Convert.ToString(itry) + " :";
        }

        private void ShowMinute(object sender, TextChangedEventArgs e)
        {
            int itry;
            if (!int.TryParse(MinuteSet.Text, out itry)) return;
            else if (itry < 0 || itry > 59) return;
            else if (itry < 10)
                minute.Text = "0" + Convert.ToString(itry) + " :";
            else
                minute.Text = Convert.ToString(itry) + " :";
        }

        private void ShowSecond(object sender, TextChangedEventArgs e)
        {
            int itry;
            if (!int.TryParse(SecondSet.Text, out itry)) return;
            else if (itry < 0 || itry > 59) return;
            else if (itry < 10)
                second.Text = "0" + Convert.ToString(itry);
            else
                second.Text = Convert.ToString(itry);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar1.SelectedDate = SetTime;
            ShowDate(Calendar1, new SelectionChangedEventArgs(Calendar.SelectedDatesChangedEvent, Calendar1.SelectedDates, Calendar1.SelectedDates));

            DateTimeData dt = new DateTimeData
            {
                Hour = SetTime.Hour.ToString(),
                Minute = SetTime.Minute.ToString(),
                Second = SetTime.Second.ToString(),
            };
            DataContext = dt;
        }
    }
}
