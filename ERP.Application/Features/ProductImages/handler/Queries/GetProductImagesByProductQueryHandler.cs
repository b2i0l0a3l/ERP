using ERP.Application.Features.ProductImages.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.ProductImages.Queries
{
    public class GetProductImagesByProductQueryHandler : IRequestHandler<GetProductImagesByProductQuery, Result<List<ProductImageDTO>>>
    {
        private readonly IProductImageRepo _repo;
        public GetProductImagesByProductQueryHandler(IProductImageRepo repo) => _repo = repo;
        public async ValueTask<Result<List<ProductImageDTO>>> Handle(GetProductImagesByProductQuery request, CancellationToken ct)
            => await _repo.GetByProductId(request.ProductId);
    }
}
