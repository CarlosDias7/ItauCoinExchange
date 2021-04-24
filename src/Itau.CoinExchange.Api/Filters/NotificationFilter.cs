using Itau.CoinExchange.Application.Notifications.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Api.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private const string ContentTypeJson = "application/json";
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (await CheckForFluentValidationNotificationsAsync(context)) return;
            await next();
        }

        private async Task<bool> CheckForFluentValidationNotificationsAsync(ResultExecutingContext context)
        {
            if (!_notificationContext.HasNotifications) return false;

            SetBadRequest(context);
            var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
            await context.HttpContext.Response.WriteAsync(notifications);

            return true;
        }

        private void SetBadRequest(ResultExecutingContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = ContentTypeJson;
        }
    }
}