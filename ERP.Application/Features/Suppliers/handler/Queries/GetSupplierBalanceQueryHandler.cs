using ERP.Application.Features.Suppliers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SupplierBalanceModels;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Queries
{
    public class GetSupplierBalanceQueryHandler : IRequestHandler<GetSupplierBalanceQuery, Result<SupplierBalanceDTO>>
    {
        private readonly ISupplierRepo _supplierRepo;
        public GetSupplierBalanceQueryHandler(ISupplierRepo supplierRepo) => _supplierRepo = supplierRepo;

        public async ValueTask<Result<SupplierBalanceDTO>> Handle(GetSupplierBalanceQuery request, CancellationToken ct)
        {
            Result<SupplierDTO> supplierResult = await _supplierRepo.GetById(request.SupplierId);
            if (!supplierResult.IsSuccess)
                return supplierResult.Error!;

            Result<SupplierBalanceDTO> balanceResult = await _supplierRepo.GetSupplierBalance(request.SupplierId);
            if (!balanceResult.IsSuccess)
                return balanceResult.Error!;

            return new SupplierBalanceDTO
            {
                SupplierId = request.SupplierId,
                SupplierName = supplierResult.Value!.FullName,
                TotalPurchases = balanceResult.Value!.TotalPurchases,
                TotalPaid = balanceResult.Value!.TotalPaid,
                Balance = balanceResult.Value!.Balance
            };
        }
    }
}
