﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    public class SystemRole : INotifyPropertyChanged
    {
        private int id;
        private string code;
        private string name;
        private string right;
        private string description;
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

        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                NotifyPropertyChanged("Code");
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

        public string Right
        {
            get { return right; }
            set
            {
                right = value;
                NotifyPropertyChanged("Right");
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
