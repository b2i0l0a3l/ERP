using ERP.Core.Models.SupplierBalanceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Requests.Queries
{
    public record GetSupplierBalanceQuery : IRequest<Result<SupplierBalanceDTO>>
    {
        public int SupplierId { get; set; }
    }
}
