using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using MaritimeSecurityMonitoring.MainInterfacePage;
using YimaWF;
using dataAnadll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public YimaWF.YimaEncCtrl chartCtrl;
        public YimaWF.YimaEncCtrl returnBack;
        public MonitoringX mainWindow;
        public MonitoringInterface moninterface;
        public monitoringIn Inmon;
        public MonitoringReturn Return;

        public followVideo dialog;
    }
}
