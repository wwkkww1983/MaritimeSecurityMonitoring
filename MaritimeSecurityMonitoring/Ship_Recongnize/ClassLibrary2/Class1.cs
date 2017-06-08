using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using MySql;
namespace Shipname_Recongnize
{
    public class Recongize
    {
        private static MySqlConnection mycon;
        private static Recongize CurrentInstance;
        public static Recongize GetInstance(string databaseip = null, string name = null, string pwd = null, string dbname = null)
        {
            if (CurrentInstance == null)
            {
                CurrentInstance = new Recongize(databaseip, name, pwd, dbname);
            }
            return CurrentInstance;
        }
        private Recongize(string databaseip, string name, string pwd, string dbname)
        {
            string con = string.Format("Database={0};Data Source={1};User Id={2};Password={3}", dbname, databaseip, name, pwd);
            mycon = new MySqlConnection(con);
            mycon.Open();
        }
        ~Recongize()
        {
            mycon.Close();
        }
        public string Ship_Find(string mmsi)
        {
            string rst = "";
            string sqlstr = string.Format("select the_no from MMSI_The_No where MMSI={0}", mmsi);
            MySqlCommand cmd = new MySqlCommand(sqlstr, mycon);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                rst = reader["the_no".ToString()].ToString();
            }
            reader.Close();
            return rst;
        }
        public int Date_update(string path)
        //给定数据文件更新数据库
        //mmsi,the_no
        //1234,ldlldld
        //返回的是插入成功的数目
        {
            string sqlcmd = "insert into MMSI_The_No(MMSI,the_no) values";
            string line;
            string[] aryline;
            int cnt = 0;
            StreamReader reader = new StreamReader(path, System.Text.Encoding.Default);
            string sqlstr = sqlcmd;
            int NoCosume = 0;
            while ((line = reader.ReadLine()) != null)
            {
                aryline = line.Split(new char[] { ',' });
                if (aryline.Length != 2)
                {
                    continue;
                }
                string valueFormat = "(\'{0}\',\'{1}\')";
                string value = string.Format(valueFormat, aryline[0], aryline[1]);
                cnt += 1;
                NoCosume++;
                if (cnt % 500 == 0)
                {
                    sqlstr += value + ";";
                    MySqlCommand cmd = new MySqlCommand(sqlstr, mycon);
                    cmd.ExecuteNonQuery();
                    NoCosume = 0;
                    sqlstr = sqlcmd;
                }
                else
                {
                    sqlstr += value + ",";
                }
            }
            reader.Close();
            if (NoCosume != 0)
            {
                char[] tmp = sqlstr.ToCharArray();
                tmp[sqlstr.Length - 1] = ';';
                sqlstr = new string(tmp);
                MySqlCommand cmd = new MySqlCommand(sqlstr, mycon);
                cmd.ExecuteNonQuery();
            }
            return cnt;
        }
        public int getShipCnt()
        //
        {
            int Cnt;

            string sqlstr = "select count(*) from MMSI_The_No";
            MySqlCommand cmd = new MySqlCommand(sqlstr, mycon);
            Cnt = Int32.Parse(cmd.ExecuteScalar().ToString());
            return Cnt;

        }
    }
}
