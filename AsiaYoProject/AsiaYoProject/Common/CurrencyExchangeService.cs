using System;
using System.Globalization;

namespace AsiaYoProject.Common
{
    public class CurrencyExchangeService
    {
        private readonly Dictionary<string, Dictionary<string, decimal>> _exchangeRates = new Dictionary<string, Dictionary<string, decimal>>
        {
            {"TWD", new Dictionary<string, decimal>{{"TWD", 1}, {"JPY", 3.669m}, {"USD", 0.03281m}}},
            {"JPY", new Dictionary<string, decimal>{{"TWD", 0.26956m}, {"JPY", 1}, {"USD", 0.00885m}}},
            {"USD", new Dictionary<string, decimal>{{"TWD", 30.444m}, {"JPY", 111.801m}, {"USD", 1}}}
        };

        public decimal ConvertCurrency(string source, string target, decimal amount)
        {
            if (!_exchangeRates.ContainsKey(source))
            {
                throw new ArgumentException("輸入錯誤的[source]，請輸入 [TWD],[JPY],[USD] 其中一種。");
            }

            if (!_exchangeRates[source].ContainsKey(target))
            {
                throw new ArgumentException("輸入錯誤的[target]，請輸入 [TWD],[JPY],[USD] 其中一種。");
            }

            var rate = _exchangeRates[source][target];
            return amount * rate;
        }

        public bool IsValidCurrency(string currency)
        {
            return _exchangeRates.ContainsKey(currency);
        }
    }
}