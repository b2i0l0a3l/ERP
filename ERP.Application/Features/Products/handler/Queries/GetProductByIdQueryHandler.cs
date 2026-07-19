using ERP.Application.Features.Products.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDTO>>
    {
        private readonly IProductRepo _repo;
        public GetProductByIdQueryHandler(IProductRepo repo) => _repo = repo;
        public async Task<Result<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
