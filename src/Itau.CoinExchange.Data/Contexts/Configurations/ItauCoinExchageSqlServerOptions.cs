using System.Collections.Generic;

namespace Itau.CoinExchange.Data.Contexts.Configurations
{
    public class ItauCoinExchageSqlServerOptions
    {
        public int MaxRetryCount { get; set; }
        public int MaxRetryDelayInSeconds { get; set; }
        public ICollection<int> ErrorNumbersToAdd { get; set; }
    }
}