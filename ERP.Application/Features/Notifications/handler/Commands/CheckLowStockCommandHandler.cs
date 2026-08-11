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
        private readonly IDashboardRepo _dashboardRepo;
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;

        public CheckLowStockCommandHandler(
            IDashboardRepo dashboardRepo,
            INotificationRepo notificationRepo,
            INotificationChannel notificationChannel)
        {
            _dashboardRepo = dashboardRepo;
            _notificationRepo = notificationRepo;
            _notificationChannel = notificationChannel;
        }

        public async ValueTask<Result<bool>> Handle(CheckLowStockCommand request, CancellationToken cancellationToken)
        {
            var lowStockResult = await _dashboardRepo.GetLowStock();
            if (!lowStockResult.IsSuccess)
                return lowStockResult.Error!;

            var lowStockItems = lowStockResult.Value!;
            if (lowStockItems.Count == 0)
                return true;

            var oneDayAgo = DateTime.UtcNow.AddDays(-1);
            var alreadyNotifiedResult = await _notificationRepo.GetAlreadyNotifiedEntityIds(
                enNotificationType.LowStock, "Product", oneDayAgo);

            if (!alreadyNotifiedResult.IsSuccess)
                return alreadyNotifiedResult.Error!;

            var alreadyNotifiedIds = alreadyNotifiedResult.Value!;

            var newItems = lowStockItems
                .Where(item => !alreadyNotifiedIds.Contains(item.ProductId))
                .ToList();

            if (newItems.Count == 0)
                return true;

            var batchParams = newItems.Select(item => new AddNotificationParams
            {
                Type = enNotificationType.LowStock,
                Priority = enNotificationPriority.High,
                Title = "Low Stock Alert",
                Message = $"Product '{item.ProductName}' in warehouse '{item.WarehouseName}' is low on stock. Current: {item.Quantity}.",
                RelatedEntityType = "Product",
                RelatedEntityId = item.ProductId
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
