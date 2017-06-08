using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class RadarTarget
    {
        public int targetId { get; set; }
        public int radarId { get; set; }
        public string batchNumber { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string distance{ get; set; }
        public string speed { get; set; }
        public string steeringAngle { get; set; }
    }
}
