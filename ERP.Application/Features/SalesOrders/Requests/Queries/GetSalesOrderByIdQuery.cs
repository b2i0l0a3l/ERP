using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Requests.Queries
{
    public record GetSalesOrderByIdQuery : IRequest<Result<SalesOrderDTO>>
    {
        public int Id { get; set; }
    }
}
