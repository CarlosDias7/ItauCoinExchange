using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Itau.CoinExchange.Application.Notifications.Contexts;
using Itau.CoinExchange.Application.Pipelines;
using Itau.CoinExchange.Application.UseCases.Segments;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Itau.CoinExchange.Application.DependencyInjection
{
    public static class ApplicationInjection
    {
        public static void UseApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestsValidationPipeline<,>));
            services.AddScoped<INotificationContext, NotificationContext>();

            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetSegmentsUseCase, GetSegmentsUseCase>();
            services.AddScoped<IUpdateSegmentExchangeRateUseCase, UpdateSegmentExchangeRateUseCase>();
        }
    }
}