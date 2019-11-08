using System;
using System.IO;
using System.Net;
using System.Text;

namespace XorPayCore.Sdk
{
    public class XorPayRequest
    {
        #region 发送请求(GET)
        /// <summary>
        /// 发送请求(GET)
        /// </summary>
        /// <returns></returns>
        public static string Get(string url, string para, string coding = "UTF-8")
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("请求地址为空");
            try
            {
                var wrq = WebRequest.Create(url + para);
                wrq.Method = "GET";
                var wrp = wrq.GetResponse();
                using (var sr = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding(coding)))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 发送请求(POST)
        /// <summary>
        /// 发送请求(POST)
        /// </summary>
        /// <returns></returns>
        public static string Post(string url, string para, string coding = "UTF-8")
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("请求地址为空");
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.Timeout = 20000;
                var body = Encoding.GetEncoding(coding).GetBytes(para);
                req.ContentLength = body.Length;
                using (var sm = req.GetRequestStream())
                {
                    sm.Write(body, 0, body.Length);
                    using (var wrp = req.GetResponse())
                    using (var sr = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding(coding)))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
