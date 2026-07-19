using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class UpdateSalesOrderStatusCommandHandler : IRequestHandler<UpdateSalesOrderStatusCommand, Result<bool>>
    {
        private readonly ISalesOrderRepo _repo;
        public UpdateSalesOrderStatusCommandHandler(ISalesOrderRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateSalesOrderStatusCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateSalesOrderParams { Status = (enStatus)request.Status });
    }
}
