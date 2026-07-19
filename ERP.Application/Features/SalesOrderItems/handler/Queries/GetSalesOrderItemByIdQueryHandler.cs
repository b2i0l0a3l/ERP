using ERP.Application.Features.SalesOrderItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrderItems.Queries
{
    public class GetSalesOrderItemByIdQueryHandler : IRequestHandler<GetSalesOrderItemByIdQuery, Result<SalesOrderItemDTO>>
    {
        private readonly ISalesOrderItemRepo _repo;
        public GetSalesOrderItemByIdQueryHandler(ISalesOrderItemRepo repo) => _repo = repo;
        public async Task<Result<SalesOrderItemDTO>> Handle(GetSalesOrderItemByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
