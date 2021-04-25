using System;

namespace Itau.CoinExchange.WebClients.Contracts.Dtos.ExchangeRateApi
{
    public class ExchangeRateConvertCoinDto
    {
        public string CoinFrom { get; set; }
        public string CoinTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public ExchangeRateConvertCoinDto(string coinFrom, string coinTo, decimal amount)
        {
            CoinFrom = coinFrom;
            CoinTo = coinTo;
            Amount = amount;
            Date = DateTime.Today;
        }

        public ExchangeRateConvertCoinDto(string coinFrom, string coinTo, decimal amount, DateTime date)
        {
            CoinFrom = coinFrom;
            CoinTo = coinTo;
            Amount = amount;
            Date = date;
        }
    }
}