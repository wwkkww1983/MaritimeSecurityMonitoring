using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    public class SystemUser : INotifyPropertyChanged
    {
        private int id;
        private string userName;
        private string password;
        private string role;
        private string position;
        private string department;
        private string phone;
        private string mail;
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

        public string UserID { get; set; }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }

        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                NotifyPropertyChanged("Position");
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

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged("Phone");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                NotifyPropertyChanged("Mail");
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
