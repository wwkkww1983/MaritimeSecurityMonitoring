using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Media;

namespace MaritimeSecurityMonitoring
{
    class SetConfig
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public string read(string fir, string sec)
        {
            string result;
            XmlDocument doc = new XmlDocument();
            string strFileName = @"../../../MaritimeSecurityMonitoring/bin/Debug/MonitorConfig.xml";
            doc.Load(strFileName);
            XmlNode root = doc.SelectSingleNode("configuration");
            XmlNode xn = root.SelectSingleNode(fir);
            XmlNode tag = xn.SelectSingleNode(sec);
            if (tag == null)
                result = null;
            else
                result = tag.InnerText;
            return result;
        }
        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write(string fir, string sec, string value)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径　　
            string strFileName = @"../../../MaritimeSecurityMonitoring/bin/Debug/MonitorConfig.xml";
            doc.Load(strFileName);
            XmlNode root = doc.SelectSingleNode("configuration");
            XmlNode xn = root.SelectSingleNode(fir);
            XmlNode tag;
            if (xn.HasChildNodes)
            {
                tag = xn.SelectSingleNode(sec);
                if (tag == null)
                {
                    tag = doc.CreateElement(sec);
                    xn.AppendChild(tag);
                }
            }
            else
            {
                tag = doc.CreateElement(sec);
                xn.AppendChild(tag);
            }
            tag.InnerText = value;
            //保存上面的修改　　
            doc.Save(strFileName);
        }
        /// <summary>
        /// 将读取到的配置转换为double类型
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public double read_double(string fir, string sec)
        {
            double b = Convert.ToDouble(read(fir, sec));
            return b;
        }
        /// <summary>
        /// 将double类型转换为string类型写入配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write_double(string fir, string sec, double value)
        {
            string svalue = Convert.ToString(value);
            write(fir, sec, svalue);
        }
        /// <summary>
        /// 将读取到的配置转换为brush类型
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public Brush read_brush(string fir, string sec)
        {
            BrushConverter brush = new BrushConverter();
            Brush color = (Brush)brush.ConvertFromString(read(fir, sec));
            return color;
        }
        /// <summary>
        /// 将brush类型转换为string类型写入配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write_brush(string fir, string sec, Brush value)
        {
            string color = ((Brush)value).ToString();
            write(fir, sec, color);
        }
        /// <summary>
        /// 将读取到的配置转换为color类型
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public Color read_color(string fir, string sec)
        {
            Color color = (Color)ColorConverter.ConvertFromString(read(fir, sec));
            return color;
        }
        /// <summary>
        /// 将color类型转换为string类型写入配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write_color(string fir, string sec, Color value)
        {
            string color = ((Color)value).ToString();
            write(fir, sec, color);
        }

        /// <summary>
        /// 将读取到的配置转换为string类型
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public string read_string(string fir, string sec)
        {
            string b = Convert.ToString(read(fir, sec));
            return b;
        }
        /// <summary>
        /// 将string类型写入配置文件
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write_string(string fir, string sec, string value)
        {
            string svalue = Convert.ToString(value);
            write(fir, sec, svalue);
        }
        /// <summary>
        /// 将读取到的配置转换为bool类型
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public bool read_bool(string fir,string sec)
        {
            bool str = Convert.ToBoolean(read(fir,sec));
            return str;
        }
        /// <summary>
        /// 将bool类型转换为string类型写入配置文件中
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="sec"></param>
        /// <param name="value"></param>
        public void write_bool(string fir,string sec,bool value)
        {
            string str = Convert.ToString(value);
            write(fir, sec, str);
        }
    }
}
