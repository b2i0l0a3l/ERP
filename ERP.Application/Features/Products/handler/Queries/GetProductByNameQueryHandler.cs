using ERP.Application.Features.Products.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Queries
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, Result<ProductDTO>>
    {
        private readonly IProductRepo _repo;
        public GetProductByNameQueryHandler(IProductRepo repo) => _repo = repo;
        public async Task<Result<ProductDTO>> Handle(GetProductByNameQuery request, CancellationToken ct)
            => await _repo.GetByName(request.Name);
    }
}
