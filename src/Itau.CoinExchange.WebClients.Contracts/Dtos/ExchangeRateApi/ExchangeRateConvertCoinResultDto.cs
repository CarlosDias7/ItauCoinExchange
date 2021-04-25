using System;

namespace Itau.CoinExchange.WebClients.Contracts.Dtos.ExchangeRateApi
{
    public class ExchangeRateConvertCoinResultDto
    {
        public bool Success { get; set; }
        public QueryConvertCoinResultDto Query { get; set; }
        public InfoConvertCoinResultDto Info { get; set; }
        public string Historical { get; set; }
        public DateTime Date { get; set; }
        public decimal Result { get; set; }
    }

    public class QueryConvertCoinResultDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }

    public class InfoConvertCoinResultDto
    {
        public decimal Rate { get; set; }
    }
}