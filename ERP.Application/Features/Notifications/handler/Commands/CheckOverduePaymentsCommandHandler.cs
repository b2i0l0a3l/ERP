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
        private readonly IDashboardRepo _dashboardRepo;
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;

        public CheckOverduePaymentsCommandHandler(
            IDashboardRepo dashboardRepo,
            INotificationRepo notificationRepo,
            INotificationChannel notificationChannel)
        {
            _dashboardRepo = dashboardRepo;
            _notificationRepo = notificationRepo;
            _notificationChannel = notificationChannel;
        }

        public async ValueTask<Result<bool>> Handle(CheckOverduePaymentsCommand request, CancellationToken cancellationToken)
        {
            var thirtyDaysAgo = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30));
            var overdueResult = await _dashboardRepo.GetOverdueOrders(thirtyDaysAgo);
            if (!overdueResult.IsSuccess)
                return overdueResult.Error!;

            var overdueOrders = overdueResult.Value!;
            if (overdueOrders.Count == 0)
                return true;

            var alreadyNotifiedResult = await _notificationRepo.GetAlreadyNotifiedEntityIds(
                enNotificationType.PaymentOverdue, "SalesOrder", DateTime.MinValue);

            if (!alreadyNotifiedResult.IsSuccess)
                return alreadyNotifiedResult.Error!;

            var alreadyNotifiedIds = alreadyNotifiedResult.Value!;

            var newOrders = overdueOrders
                .Where(order => !alreadyNotifiedIds.Contains(order.OrderId))
                .ToList();

            if (newOrders.Count == 0)
                return true;

            var batchParams = newOrders.Select(order => new AddNotificationParams
            {
                Type = enNotificationType.PaymentOverdue,
                Priority = enNotificationPriority.Critical,
                Title = "Payment Overdue Alert",
                Message = $"Sales Order #{order.OrderId} is overdue. Total: {order.Total}, Paid: {order.PaidAmount}, Remaining: {order.RemainingBalance}.",
                RelatedEntityType = "SalesOrder",
                RelatedEntityId = order.OrderId
            }).ToList();

            var addResult = await _notificationRepo.AddBatch(batchParams);
            if (!addResult.IsSuccess)
                return addResult.Error!;

            foreach (var notification in addResult.Value!)
            {
                await _notificationChannel.QueueNotificationAsync(notification, cancellationToken);
            }

            return true;
        }
    }
}
