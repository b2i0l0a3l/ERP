using ERP.Application.Features.SalesOrderItems.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Commands
{
    public class DeleteSalesOrderItemCommandHandler : IRequestHandler<DeleteSalesOrderItemCommand, Result<bool>>
    {
        private readonly ISalesOrderItemRepo _repo;
        public DeleteSalesOrderItemCommandHandler(ISalesOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteSalesOrderItemCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
