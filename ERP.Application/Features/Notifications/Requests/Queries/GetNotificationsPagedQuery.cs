using ERP.Core.enums;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Queries
{
    public record GetNotificationsPagedQuery : IRequest<Result<PagedResult<NotificationDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? TargetUserId { get; set; }
        public enNotificationType? Type { get; set; }
        public bool? IsRead { get; set; }
    }
}
