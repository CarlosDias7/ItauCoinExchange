using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Itau.CoinExchange.Application.Contracts.Notifications.Contexts
{
    public interface INotificationContext
    {
        bool HasNotifications { get; }

        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(string message);

        void AddNotification(string key, string message);

        void AddNotification(Notification notification);

        void AddNotification(Exception exception);

        void AddNotifications(IEnumerable<Notification> notifications);

        void AddNotifications(ValidationResult validationResult);
    }
}