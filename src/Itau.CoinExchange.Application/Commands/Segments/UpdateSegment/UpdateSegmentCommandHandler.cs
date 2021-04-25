using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.Notifications.Contexts;
using Itau.CoinExchange.Application.Notifications.Contexts;
using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Commands.Segments.UpdateSegment
{
    public class UpdateSegmentCommandHandler : IRequestHandler<UpdateSegmentCommand, bool>
    {
        private readonly ISegmentRepository _segmentRepository;
        private readonly INotificationContext _notificationContext;

        public UpdateSegmentCommandHandler(ISegmentRepository segmentRepository, INotificationContext notificationContext)
        {
            _segmentRepository = segmentRepository;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(UpdateSegmentCommand request, CancellationToken cancellationToken)
        {
            if(!request.Segment.Valid)
            {
                _notificationContext.AddNotifications(request.Segment.ValidationResult);
                return false;
            }

            await _segmentRepository.UpdateAsync(request.Segment, cancellationToken);
            return true;
        }
    }
}
