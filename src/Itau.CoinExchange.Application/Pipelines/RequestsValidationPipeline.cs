using FluentValidation;
using Itau.CoinExchange.Application.Notifications.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Pipelines
{
    public class RequestsValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly INotificationContext _notificationContext;

        public RequestsValidationPipeline(IEnumerable<IValidator<TRequest>> validator, INotificationContext notificationContext)
        {
            _validators = validator ?? throw new ArgumentNullException(nameof(_validators));
            _notificationContext = notificationContext;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<object>(request);

                var validationResults = _validators
                    .Select(v => v.Validate(context))
                    .ToList();

                if (validationResults != null && validationResults.Any())
                {
                    validationResults
                        .ForEach(validationResult => _notificationContext.AddNotifications(validationResult));

                    throw new ValidationException(ApplicationMessages.RequestValidationPipeline_Invalid_Request);
                }
            }

            return next();
        }
    }
}