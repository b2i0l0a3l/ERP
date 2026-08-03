using ERP.Application.Features.Notifications.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Notifications.Commands
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Result<bool>>
    {
        private readonly INotificationRepo _repo;
        public DeleteNotificationCommandHandler(INotificationRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteNotificationCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
