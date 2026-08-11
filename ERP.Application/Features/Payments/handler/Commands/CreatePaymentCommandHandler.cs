using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.EntityParams.paymentParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<int>>
    {
        private readonly IPaymentRepo _repo;
        private readonly INotificationRepo _notificationRepo;
        private readonly INotificationChannel _notificationChannel;
        private readonly ICurrentUserService _CurrentUser;

        public CreatePaymentCommandHandler(INotificationRepo notificationRepo, INotificationChannel notificationChannel, IPaymentRepo repo, ICurrentUserService currentUser)
        {
            _notificationChannel = notificationChannel;
            _notificationRepo = notificationRepo;
            _repo = repo;
            _CurrentUser = currentUser;
        }
        public async ValueTask<Result<int>> Handle(CreatePaymentCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            var userId = _CurrentUser.UserId;

            var result = await _repo.Pay(new PayParmas
            {
                SaleOrderId = request.SaleOrderId,
                PurchaseOrderId = request.PurchaseOrderId,
                Amount = request.Amount,
                Notes = request.Notes,
                ReferenceNumber = request.ReferenceNumber,
                PaymentMethod = request.PaymentMethod,
                CreatedByUserId = userId
            });
            if (!result.IsSuccess)
                return result.Error!;
            AddNotificationParams noty = new AddNotificationParams
            {
                Type = enNotificationType.NewOrder,
                Priority = enNotificationPriority.Low,
                Title = "عملية دفع",
                Message = $"دفع : الطلب {request.SaleOrderId} المبلغ {request.Amount}",
                RelatedEntityType = "Payments",
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