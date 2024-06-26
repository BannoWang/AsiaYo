using AsiaYoProject.Common;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AsiaYoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly CurrencyExchangeService _currencyExchangeService;

        public ExchangeController(CurrencyExchangeService currencyExchangeService)
        {
            _currencyExchangeService = currencyExchangeService;
        }

        [HttpGet("convert")]
        public IActionResult ConvertCurrency([FromQuery] string source, [FromQuery] string target, [FromQuery] string amount)
        {
            if (!_currencyExchangeService.IsValidCurrency(source))
            {
                return BadRequest(new { msg = "輸入錯誤的[source]，請輸入 [TWD],[JPY],[USD] 其中一種。" });
            }

            if (!_currencyExchangeService.IsValidCurrency(target))
            {
                return BadRequest(new { msg = "輸入錯誤的[target]，請輸入 [TWD],[JPY],[USD] 其中一種。" });
            }

            if (!decimal.TryParse(amount.Replace(",", ""), out var amountDecimal))
            {
                return BadRequest(new { msg = "錯誤的[amount]" });
            }

            try
            {
                var convertedAmount = _currencyExchangeService.ConvertCurrency(source, target, amountDecimal);
                var formattedAmount = string.Format(CultureInfo.InvariantCulture, "{0:N2}", convertedAmount);
                return Ok(new { msg = "success", amount = formattedAmount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }
    }
}