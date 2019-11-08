namespace XorPayCore.Sdk.Models
{
    public class PcPayResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// XorPay 平台统一订单号
        /// </summary>
        public string aoid { get; set; }

        /// <summary>
        /// 订单过期秒数
        /// </summary>
        public int expire_in { get; set; }

        /// <summary>
        /// qr 支付二维码
        /// </summary>
        public code_info info { get; set; }
    }

    public class code_info
    {
        public string qr { get; set; }
    }
}
