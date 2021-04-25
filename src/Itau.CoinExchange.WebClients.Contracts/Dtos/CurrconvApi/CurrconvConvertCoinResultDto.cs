namespace Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi
{
    public class CurrconvConvertCoinResultDto
    {
        public string CoinFrom { get; set; }
        public string CoinTo { get; set; }
        public decimal CurrencyValue { get; set; }
    }
}