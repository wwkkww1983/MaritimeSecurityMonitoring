using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    public class NetDevice : INotifyPropertyChanged
    {
        private int id;
        private string ip;
        private string name;
        private string port1;
        private string port2;
        private string port3;
        private string port4;
        private bool readOnly;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string IP
        {
            get { return ip; }
            set
            {
                ip = value;
                NotifyPropertyChanged("IP");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Port1
        {
            get { return port1; }
            set
            {
                port1 = value;
                NotifyPropertyChanged("Port1");
            }
        }

        public string Port2
        {
            get { return port2; }
            set
            {
                port2 = value;
                NotifyPropertyChanged("Port2");
            }
        }

        public string Port3
        {
            get { return port3; }
            set
            {
                port3 = value;
                NotifyPropertyChanged("Port3");
            }
        }

        public string Port4
        {
            get { return port4; }
            set
            {
                port4 = value;
                NotifyPropertyChanged("Port4");
            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                NotifyPropertyChanged("ReadOnly");
            }
        }

        public bool IsConfirm { get; set; }

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
