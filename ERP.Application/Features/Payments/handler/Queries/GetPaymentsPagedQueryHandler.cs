using ERP.Application.Features.Payments.Requests.Queries;
using ERP.Core.EntityParams.paymentParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Payments.Queries
{
    public class GetPaymentsPagedQueryHandler : IRequestHandler<GetPaymentsPagedQuery, Result<PagedResult<PaymentDTO>>>
    {
        private readonly IPaymentRepo _repo;
        public GetPaymentsPagedQueryHandler(IPaymentRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<PaymentDTO>>> Handle(GetPaymentsPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, SaleOrderId = request.SaleOrderId, PurchaseOrderId = request.PurchaseOrderId });
    }
}
