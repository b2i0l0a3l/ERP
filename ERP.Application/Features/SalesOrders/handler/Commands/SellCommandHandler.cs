using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class SellCommandHandler : IRequestHandler<SellCommand, Result<int>>
    {
        private readonly ISalesOrderRepo _repo;
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;
        private readonly ICurrentUserService _CurrentUser;

        public SellCommandHandler(INotificationRepo notificationRepo, INotificationChannel notificationChannel, ISalesOrderRepo repo, ICurrentUserService currentUser)
        {
            _notificationChannel = notificationChannel;
            _notificationRepo = notificationRepo;
            _repo = repo;
            _CurrentUser = currentUser;
        }
        public async ValueTask<Result<int>> Handle(SellCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            var userId = _CurrentUser.UserId;

            var result = await _repo.Sell(new SellParams
            {
                WarehouseId = request.WarehouseId,
                CustomerId = request.CustomerId,
                Discount = request.Discount,
                CreatedByUserId = userId,
                PaymentStatus = request.PaymentStatus,
                Items = request.Items
            });
            if (!result.IsSuccess)
                return result.Error!;
            AddNotificationParams noty = new AddNotificationParams
            {
                Type = enNotificationType.NewOrder,
                Priority = enNotificationPriority.Low,
                Title = "طلب جديد",
                Message = $"طلب جديد : العميل : {request.CustomerId} حالة الدفع : {request.PaymentStatus} بائع :{userId}.",
                RelatedEntityType = "SaleOrders",
                RelatedEntityId = result.Value
            };
            var addResult = await _notificationRepo.Add(noty);
            if (!addResult.IsSuccess)
                return addResult.Error!;

            await _notificationChannel.QueueNotificationAsync(new NotificationDTO()
            {
                CreatedAt = DateTime.UtcNow,
                Id = addResult.Value,
                IsRead = false,
                Message = noty.Message,
                Priority = noty.Priority,
                ReadAt = null,
                RelatedEntityId = noty.RelatedEntityId,
                RelatedEntityType = noty.RelatedEntityType,
                TargetUserId = userId,
                Title = noty.Title,
                Type = noty.Type
            }, ct);

            return result.Value;
        }
    }
}
