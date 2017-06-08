using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MaritimeSecurityMonitoring
{
    class Encrpty
    {
        public Encrpty()
        {

        }
        static public string Encrypt(string str, string plain)
            //str:加密密钥,plain明文
        {
            string rst="";
            byte[] Key = System.Text.ASCIIEncoding.ASCII.GetBytes(str.Substring(0,7));
            byte[] IV = System.Text.ASCIIEncoding.ASCII.GetBytes("01234567");

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, aes.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            return rst;
        }
        static public string Decrypt(string str, string enplain)
        //str:加密密钥,plain密文
        {
            string rst="";
            return rst;
        }
    }
}
