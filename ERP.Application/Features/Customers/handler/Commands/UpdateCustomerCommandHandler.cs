using ERP.Application.Features.Customers.Requests.Commands;
using ERP.Core.EntityParams.customerParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<bool>>
    {
        private readonly ICustomerRepo _repo;
        public UpdateCustomerCommandHandler(ICustomerRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateCustomerParams { FirstName = request.FirstName, LastName = request.LastName, Info = request.Info });
    }
}
