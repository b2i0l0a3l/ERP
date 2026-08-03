using ERP.Application.Features.Notifications.Requests.Queries;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Queries
{
    public class GetNotificationsPagedQueryHandler : IRequestHandler<GetNotificationsPagedQuery, Result<PagedResult<NotificationDTO>>>
    {
        private readonly INotificationRepo _repo;
        public GetNotificationsPagedQueryHandler(INotificationRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<NotificationDTO>>> Handle(GetNotificationsPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TargetUserId = request.TargetUserId,
                Type = request.Type,
                IsRead = request.IsRead
            });
    }
}
