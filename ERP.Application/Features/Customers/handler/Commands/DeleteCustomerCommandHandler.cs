using ERP.Application.Features.Customers.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<bool>>
    {
        private readonly ICustomerRepo _repo;
        public DeleteCustomerCommandHandler(ICustomerRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteCustomerCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
