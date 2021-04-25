using System;

namespace Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi
{
    public class CurrconvConvertCoinDto
    {
        public string CoinFrom { get; set; }
        public string CoinTo { get; set; }
        public DateTime Date { get; set; }

        public CurrconvConvertCoinDto(string coinFrom, string coinTo)
        {
            CoinFrom = coinFrom;
            CoinTo = coinTo;
            Date = DateTime.Today;
        }

        public CurrconvConvertCoinDto(string coinFrom, string coinTo, DateTime date)
        {
            CoinFrom = coinFrom;
            CoinTo = coinTo;
            Date = DateTime.Today;
        }
    }
}