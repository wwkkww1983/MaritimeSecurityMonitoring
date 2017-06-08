using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class Config
    {
        public string workBoatColors { get; set; }//工作船颜色
        public string merchantShipColors { get; set; }//商船颜色
        public string fishBoatColors { get; set; }//渔船颜色
        public string VietnameseBoatColors { get; set; }//越南渔船颜色
        public string unknownTargetColorS { get; set; }//不明目标颜色

        public bool showAwakLine { get; set; }//是否显示目标尾迹
        public bool awakLineBrokenLine { get; set; }//如果线性是折线，那么只有线宽和折线颜色属性。
        public bool awakLinePointLine { get; set; }//如果线性是点线，那么只有点半径和点颜色属性。
        public string awakLineWidth { get; set; }//折线图，线宽
        public string awakPointRadius { get; set; }//点线图，点半径
        public string straightLineColors { get; set; }//折线图颜色
        public string brokenLineColors { get; set; }//点线图颜色

        public string showLabelBox { get; set; }//标牌显示
        public string targetPosition { get; set; }//目标位置显示
        public string targetSpeed { get; set; }//目标初度显示
        public string targetAcceleratedSpeed { get; set; }//目标加速度显示
        public string enemyOrFriend { get; set; }//敌我属性
        public string recognition { get; set; }//识别属性

        public string boatIdentity { get; set; }//船舶标示
        public string callNumber { get; set; }//呼叫号
        public string boatHead { get; set; }//航首页
        public string sailingLine { get; set; }//航迹线
    }
}
