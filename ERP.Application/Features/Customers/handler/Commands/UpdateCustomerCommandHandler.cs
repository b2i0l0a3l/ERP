using ERP.Application.Features.Customers.Requests.Commands;
using ERP.Core.EntityParams.customerParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<bool>>
    {
        private readonly ICustomerRepo _repo;
        public UpdateCustomerCommandHandler(ICustomerRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateCustomerParams { FristName = request.FristName, LastName = request.LastName, Info = request.Info });
    }
}
