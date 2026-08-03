using ERP.Application.Features.Customers.Requests.Commands;
using ERP.Core.EntityParams.customerParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<int>>
    {
        private readonly ICustomerRepo _repo;
        public CreateCustomerCommandHandler(ICustomerRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateCustomerCommand request, CancellationToken ct)
            => await _repo.Add(new AddCustomerParams { FirstName = request.FirstName, LastName = request.LastName, Info = request.Info });
    }
}
