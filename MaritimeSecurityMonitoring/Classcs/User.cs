using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    class User:INotifyPropertyChanged
    {
        private string userNumber;

        public string UserNumber
        {
            get { return userNumber; }
            set
            {
                userNumber = value;
                NotifyPropertyChanged("UserNumber");
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
