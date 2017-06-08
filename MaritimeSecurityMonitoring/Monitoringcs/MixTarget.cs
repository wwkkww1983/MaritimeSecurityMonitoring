using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MaritimeSecurityMonitoring
{
    class MixTarget:INotifyPropertyChanged
    {
        public int targetId { get; set; }
        public string mixBatchNumber { get; set; }
        public string MMSI { get; set; }
        public string IMO { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string distance { get; set; }
        public string speed { get; set; }
        public string steeringAngle { get; set; }
        public string boatName { get; set; }
        public string callSign { get; set; }
        public string cargoType { get; set; }
        public string sailingStatus { get; set; }

        private bool isSelected = false;
        //目标是否被选中
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
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
