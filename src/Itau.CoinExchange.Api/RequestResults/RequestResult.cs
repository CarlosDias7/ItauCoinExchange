using Itau.CoinExchange.Application.Contracts.Notifications;
using System.Collections.Generic;

namespace Itau.CoinExchange.Api.RequestResults
{
    public class RequestResult<TData>
        where TData : class
    {
        public bool Success { get; set; }
        public TData Data { get; set; }
        public ICollection<Notification> Messages { get; set; }
    }
}