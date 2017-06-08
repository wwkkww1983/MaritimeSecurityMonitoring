using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    public class WhiteTarget : INotifyPropertyChanged
    {
        private int id;
        private string mmsi;
        private string number;
        private string imo;
        private string callSign;
        private string name;
        private string department;
        private string usage;
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

        public string MMSI
        {
            get { return mmsi; }
            set
            {
                mmsi = value;
                NotifyPropertyChanged("MMSI");
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

        public string IMO
        {
            get { return imo; }
            set
            {
                imo = value;
                NotifyPropertyChanged("IMO");
            }
        }

        public string CallSign
        {
            get { return callSign; }
            set
            {
                callSign = value;
                NotifyPropertyChanged("CallSign");
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

        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                NotifyPropertyChanged("Department");
            }
        }

        public string Usage
        {
            get { return usage; }
            set
            {
                usage = value;
                NotifyPropertyChanged("Usage");
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
