namespace Itau.CoinExchange.WebClients.ExchangeRateApi.Configurations
{
    public class ExchangeRateApiOptions
    {
        public string AccessKey { get; set; }
        public string BaseAddress { get; set; }
        public int RetryCount { get; set; }
        public int SleepDurationInSeconds { get; set; }
        public int HandledEventsAllowedBeforeBreaking { get; set; }
        public int DurationOfBreakInSeconds { get; set; }
    }
}