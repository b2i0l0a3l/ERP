using ERP.Application.Features.Settings.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Settings.Commands
{
    public class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand, Result<bool>>
    {
        private readonly ISettingRepo _repo;
        public DeleteSettingCommandHandler(ISettingRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteSettingCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
