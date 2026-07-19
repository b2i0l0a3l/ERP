using ERP.Application.Features.SalesOrders.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Queries
{
    public class GetSalesOrderByIdQueryHandler : IRequestHandler<GetSalesOrderByIdQuery, Result<SalesOrderDTO>>
    {
        private readonly ISalesOrderRepo _repo;
        public GetSalesOrderByIdQueryHandler(ISalesOrderRepo repo) => _repo = repo;
        public async Task<Result<SalesOrderDTO>> Handle(GetSalesOrderByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
