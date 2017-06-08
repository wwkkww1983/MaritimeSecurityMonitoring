using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetProcess;
namespace MaritimeSecurityMonitoring
{
    class BridgeBetweenX
    {
        public delegate void _FreshLantern_Device_State(int radar1, int radar2, int ais, int fusion);
        public delegate void _FreshLantern_Alarm(int pipe,int poly,int PreAlarm,int Quzhu,int Jinjie,int Pintai);
        public delegate void _FreshTips(int recvAIS, int recvRadar, int recvFus, int proFUs, int AISCount, int RaderCount, int FusionCount);
        static public _FreshLantern_Alarm fresh_Alarm_lantern;//告警灯
        static public _FreshLantern_Device_State fresh_device_lantern;//设备灯
        static public _FreshTips freshTips;
        public void Device_change(int radar1,int radar2,int ais,int fusion)
        {
            fresh_device_lantern(radar1, radar2, ais, fusion);
        }
        public void Alarm_change(int pipe, int poly, int PreAlarm, int Quzhu, int Jinjie, int Pintai)
        {
            fresh_Alarm_lantern(pipe, poly, PreAlarm, Quzhu, Jinjie, Pintai);
        }

        public void Tip_change(int recvAIS, int recvRadar, int recvFus, int proFUs, int AISCount, int RaderCount, int FusionCount)
        {
            freshTips( recvAIS,  recvRadar,  recvFus,  proFUs,  AISCount,  RaderCount,  FusionCount);
        }

    }
    class ProcessManager
    {
        static public bool IsRunning(string processName)
        {
            int twice = 0;
            var list = GetProcess.ProcessManager.GetProcess();
            for (int i = 0; i < list.Count; i++)
            {
                if (processName == list[i])
                {
                    twice++;
                }
            }
            return twice>1 ;
        }
    }
}
