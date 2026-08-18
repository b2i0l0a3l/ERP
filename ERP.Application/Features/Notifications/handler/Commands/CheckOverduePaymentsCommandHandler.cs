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
    public class CheckOverduePaymentsCommandHandler : IRequestHandler<CheckOverduePaymentsCommand, Result<bool>>
    {
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;

        public CheckOverduePaymentsCommandHandler(
            INotificationRepo notificationRepo,
            INotificationChannel notificationChannel)
        {
            _notificationRepo = notificationRepo;
            _notificationChannel = notificationChannel;
        }

        public async ValueTask<Result<bool>> Handle(CheckOverduePaymentsCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationRepo.GenerateOverduePaymentAlerts(30, cancellationToken);
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
