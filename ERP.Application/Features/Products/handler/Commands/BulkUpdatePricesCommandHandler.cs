using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Commands
{
    public class BulkUpdatePricesCommandHandler : IRequestHandler<BulkUpdatePricesCommand, Result<bool>>
    {
        private readonly IProductRepo _repo;
        public BulkUpdatePricesCommandHandler(IProductRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(BulkUpdatePricesCommand request, CancellationToken ct)
            => await _repo.BulkUpdatePrices(request.CategoryId, request.BrandId, request.Percentage, request.UpdateCostPrice, ct);
    }
}
