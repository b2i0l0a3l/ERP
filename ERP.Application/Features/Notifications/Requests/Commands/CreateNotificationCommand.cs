using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Commands
{
    public record CreateNotificationCommand : IRequest<Result<int>>
    {
        public int Type { get; set; }
        public int Priority { get; set; } = 2;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? TargetUserId { get; set; }
    }
}
