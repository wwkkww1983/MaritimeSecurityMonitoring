using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class WarnTarget
    {
        public string mixBatchNumber { get; set; }
        public string alarmTime { get; set; }
        public string MMSI { get; set; }
        public string alarmType { get; set; }
        public string alarmContent { get; set; }
        public bool isCheck { get; set; }
        public bool isConfirmed { get; set; }
    }
}
