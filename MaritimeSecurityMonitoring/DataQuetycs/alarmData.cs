using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring.DataQuetycs
{
    class alarmData
    {
        public string alarmNumber { get; set; }
        public string time { get; set; }
        public string radarNumber { get; set; }
        public string radarNumber2 { get; set; }
        public string IMO { get; set; }
        public string alarmString { get; set; }
        public string country { get; set; }//国籍
        public string Atrrib { get; set; }//属性
        public string DisplayNumber { get; set; } //设置界面展示ID
    }
}
