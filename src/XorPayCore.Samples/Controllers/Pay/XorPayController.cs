using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using XorPayCore.Samples.ViewModels;
using XorPayCore.Samples.ViewModels.Options;
using XorPayCore.Sdk;
using XorPayCore.Sdk.Models;

namespace XorPayCore.Samples.Controllers.Pay
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class XorPayController : ControllerBase
    {
        private readonly IOptions<XorPayOption> _xorPayOption;
        public XorPayController(IOptions<XorPayOption> xorPayOption)
        {
            _xorPayOption = xorPayOption;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetQr(GetQrCommand command)
        {
            var request = new XorPayRequestModel
            {
                cancel_url = "",
                expire = 7200,
                more = "",
                name = "会员充值",
                notify_url = _xorPayOption.Value.NotifyUrl,
                pay_type = command.Type,
                price = command.Amount,
                order_id = $"CD{DateTime.Now.Ticks}",
                order_uid = ""
            };
            var json = XorPay.GetPayInfo(request, _xorPayOption.Value.AppId, _xorPayOption.Value.AppSecret);
            var response = JsonConvert.DeserializeObject<PcPayResponse>(json);
            return Ok(response);
        }
    }
}