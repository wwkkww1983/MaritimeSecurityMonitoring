using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring.DataQuetycs
{
    class AISData
    {
        public string boatName { get; set; }
        public string IMO { get; set; }
        public string MMSI { get; set; }
        public string call { get; set; }
        public string country { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string angle { get; set; }
        public string speed { get; set; }
        public string time { get; set; }
        public string trackState { get; set; }
        public string high { get; set; }
        public string people { get; set; }
        public string destance { get; set; }
    }
}
