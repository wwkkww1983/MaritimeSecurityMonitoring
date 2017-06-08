using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    class TrackingEvent : INotifyPropertyChanged
    {
        private string startTime;
        private string endTime;
        private string eventName;
        private string eventType;
        private string description;

        public int ID { get; set; }

        public string StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                NotifyPropertyChanged("StartTime");
            }
        }

        public string EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                NotifyPropertyChanged("EndTime");
            }
        }

        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                NotifyPropertyChanged("EventName");
            }
        }

        public string EventType
        {
            get { return eventType; }
            set
            {
                eventType = value;
                NotifyPropertyChanged("EventType");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
