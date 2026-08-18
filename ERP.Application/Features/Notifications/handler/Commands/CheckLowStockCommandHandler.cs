using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Notifications.Requests.Commands;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.handler.Commands
{
    public class CheckLowStockCommandHandler : IRequestHandler<CheckLowStockCommand, Result<bool>>
    {
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;

        public CheckLowStockCommandHandler(
            INotificationRepo notificationRepo,
            INotificationChannel notificationChannel)
        {
            _notificationRepo = notificationRepo;
            _notificationChannel = notificationChannel;
        }

        public async ValueTask<Result<bool>> Handle(CheckLowStockCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationRepo.GenerateLowStockAlerts(cancellationToken);
            if (!result.IsSuccess)
                return result.Error!;

            foreach (var notification in result.Value!)
            {
                await _notificationChannel.QueueNotificationAsync(notification, cancellationToken);
            }

            return true;
        }
    }
}
