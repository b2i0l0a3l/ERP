using ERP.Application.Features.Notifications.Requests.Commands;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Commands
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Result<int>>
    {
        private readonly INotificationRepo _repo;
        public CreateNotificationCommandHandler(INotificationRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateNotificationCommand request, CancellationToken ct)
            => await _repo.Add(new AddNotificationParams
            {
                Type = (enNotificationType)request.Type,
                Priority = (enNotificationPriority)request.Priority,
                Title = request.Title,
                Message = request.Message,
                RelatedEntityType = request.RelatedEntityType,
                RelatedEntityId = request.RelatedEntityId,
                TargetUserId = request.TargetUserId
            });
    }
}
