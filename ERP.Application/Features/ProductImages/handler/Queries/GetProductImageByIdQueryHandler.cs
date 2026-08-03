using ERP.Application.Features.ProductImages.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.ProductImages.Queries
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQuery, Result<ProductImageDTO>>
    {
        private readonly IProductImageRepo _repo;
        public GetProductImageByIdQueryHandler(IProductImageRepo repo) => _repo = repo;
        public async ValueTask<Result<ProductImageDTO>> Handle(GetProductImageByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
