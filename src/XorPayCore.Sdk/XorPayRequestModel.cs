namespace XorPayCore.Sdk
{
    public class XorPayRequestModel
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 支付类型，native
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 平台订单号，需要唯一
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// 订单用户如: abc@def.com
        /// </summary>
        public string order_uid { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string notify_url { get; set; }

        /// <summary>
        /// 支付成功跳转地址
        /// </summary>
        public string return_url { get; set; }

        /// <summary>
        /// 支付取消跳转地址
        /// </summary>
        public string cancel_url { get; set; }

        /// <summary>
        /// 订单其他信息，回调时原样传回
        /// </summary>
        public string more { get; set; }

        /// <summary>
        /// 用户openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 订单过期秒数，默认7200
        /// </summary>
        public int expire { get; set; } = 7200;

        /// <summary>
        /// 将参数按name + pay_type + price + order_id + notify_url + app secret顺序拼接后MD5(纯 value 拼接，不要包含 + 号)
        /// </summary>
        public string sign { get; set; }
    }
}
