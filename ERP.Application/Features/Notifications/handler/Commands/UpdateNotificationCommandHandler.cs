using ERP.Application.Features.Notifications.Requests.Commands;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Commands
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Result<bool>>
    {
        private readonly INotificationRepo _repo;
        public UpdateNotificationCommandHandler(INotificationRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateNotificationCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateNotificationParams
            {
                IsRead = request.IsRead,
                ReadAt = request.ReadAt ?? DateTime.UtcNow
            });
    }
}
