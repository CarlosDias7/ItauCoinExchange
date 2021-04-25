namespace Itau.CoinExchange.WebClients.CurrconvApi.Configurations
{
    public class CurrconvApiOptions
    {
        public string ApiKey { get; set; }
        public string BaseAddress { get; set; }
        public int RetryCount { get; set; }
        public int SleepDurationInSeconds { get; set; }
        public int HandledEventsAllowedBeforeBreaking { get; set; }
        public int DurationOfBreakInSeconds { get; set; }
    }
}