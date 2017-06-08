using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    class LinkageTarget : INotifyPropertyChanged
    {
        private int id;
        private string startTime;
        private string endTime;
        private string target;
        private string number;
        private string imagePath;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

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

        public string Target
        {
            get { return target; }
            set
            {
                target = value;
                NotifyPropertyChanged("Target");
            }
        }

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyPropertyChanged("Number");
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                NotifyPropertyChanged("ImagePath");
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
