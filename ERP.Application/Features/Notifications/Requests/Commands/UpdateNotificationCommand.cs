using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Commands
{
    public record UpdateNotificationCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public bool IsRead { get; set; } = true;
        public DateTime? ReadAt { get; set; }
    }
}
