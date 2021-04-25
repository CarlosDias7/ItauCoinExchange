namespace Itau.CoinExchange.WebClients.Contracts.Dtos.ExchangeRateApi
{
    public class ExchangeRateConvertCoinErrorDto
    {
        public ConvertCoinErrorDetailDto Error { get; set; }
    }

    public class ConvertCoinErrorDetailDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}