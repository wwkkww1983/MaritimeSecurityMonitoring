using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    class PolygonArea : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private string level;
        private string description;
        private bool readOnly;

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
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

        public string Level
        {
            get { return level; }
            set
            {
                level = value;
                NotifyPropertyChanged("Level");
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

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                NotifyPropertyChanged("ReadOnly");
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
