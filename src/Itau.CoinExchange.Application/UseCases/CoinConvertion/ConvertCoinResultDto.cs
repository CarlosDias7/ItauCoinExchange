using System;

namespace Itau.CoinExchange.Application.UseCases.CoinConvertion
{
    public class ConvertCoinResultDto
    {
        public string CoinFrom { get; set; }
        public string CoinTo { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal ResultAmount { get; set; }
    }
}