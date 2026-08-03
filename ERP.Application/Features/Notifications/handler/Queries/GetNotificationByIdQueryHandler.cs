using ERP.Application.Features.Notifications.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Queries
{
    public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Result<NotificationDTO>>
    {
        private readonly INotificationRepo _repo;
        public GetNotificationByIdQueryHandler(INotificationRepo repo) => _repo = repo;
        public async ValueTask<Result<NotificationDTO>> Handle(GetNotificationByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
