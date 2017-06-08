using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class AllTarget
    {
        public int targetId { get; set; }
        public string dataType { get; set; }
        public string batchNumber { get; set; }
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
        public bool alarmState { get; set; }
   
    }
}
