using System;
using System.Security.Cryptography;
using System.Text;

namespace XorPayCore.Sdk
{
    public class Util
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="is_16bit"></param>
        /// <returns></returns>
        public static string Md5Hash(string input, bool is16bit = false)
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var MD5 = new MD5CryptoServiceProvider();
            var byteArr = MD5.ComputeHash(buffer);
            var md5Str = BitConverter.ToString(byteArr).Replace("-", "");
            return is16bit ? md5Str.Substring(0, 16) : md5Str;
        }
    }
}
