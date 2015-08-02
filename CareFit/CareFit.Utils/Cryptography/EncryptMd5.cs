using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Utils.Cryptography
{
    public class EncryptMd5
    {
        public string GetHash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
            System.Text.StringBuilder sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
        public string GenerateRandomCode(int length)
        {
            Random rdm = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
                sb.Append(Convert.ToChar(rdm.Next(101, 132)));

            return sb.ToString();
        }
    }
}
