using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Return.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Commands
{
    public class UndoReturnCommandHandler : IRequestHandler<UndoReturnCommand, Result>
    {
        private readonly IReturnRepo _repo;

        public UndoReturnCommandHandler(IReturnRepo repo)
        {
            _repo = repo;
        }

        public async ValueTask<Result> Handle(UndoReturnCommand request, CancellationToken ct)
        {
            return await _repo.UndoReturn(request.ReturnId);
        }
    }
}
