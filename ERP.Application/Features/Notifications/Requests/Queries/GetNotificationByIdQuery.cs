using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Queries
{
    public record GetNotificationByIdQuery : IRequest<Result<NotificationDTO>>
    {
        public int Id { get; set; }
    }
}
