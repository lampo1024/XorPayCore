using System;
using System.Web;

namespace XorPayCore.Sdk
{
    public class XorPay
    {
        #region 获取支付二维码
        /// <summary>
        /// 获取支付二维码
        /// </summary>
        /// <returns></returns>
        public static string GetPayInfo(XorPayRequestModel request, string aid, string xorPaySecret)
        {
            if (string.IsNullOrEmpty(xorPaySecret))
            {
                throw new ArgumentNullException("XorPay的应用密钥未指定");
            }
            string sign = Util.Md5Hash($"{request.name}{request.pay_type}{request.price}{request.order_id}{request.notify_url}{xorPaySecret}");
            string parameters = $"name={request.name}&pay_type={request.pay_type}&price={request.price}&order_id={request.order_id}&sign={sign}&notify_url={HttpUtility.UrlEncode(request.notify_url)}&order_uid={request.order_uid}&more={request.more}&expire={request.expire}&openid={request.openid}";
            return XorPayRequest.Post($"https://xorpay.com/api/pay/{aid}", parameters);
        }
        #endregion
    }
}
