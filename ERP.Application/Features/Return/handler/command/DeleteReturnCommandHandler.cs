using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Return.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Commands
{
    public class DeleteReturnCommandHandler : IRequestHandler<DeleteReturnCommand, Result>
    {
        private readonly IReturnRepo _repo;

        public DeleteReturnCommandHandler(IReturnRepo repo)
        {
            _repo = repo;
        }

        public async ValueTask<Result> Handle(DeleteReturnCommand request, CancellationToken ct)
        {
            return await _repo.Delete(request.ReturnId, request.UserId);
        }
    }
}
