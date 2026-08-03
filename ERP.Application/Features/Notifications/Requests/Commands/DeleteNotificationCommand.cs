using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Requests.Commands
{
    public record DeleteNotificationCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
