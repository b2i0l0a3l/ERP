using ERP.Application.Features.ProductImages.Requests.Commands;
using ERP.Core.EntityParams.productImageParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.ProductImages.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, Result<int>>
    {
        private readonly IProductImageRepo _repo;
        public CreateProductImageCommandHandler(IProductImageRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreateProductImageCommand request, CancellationToken ct)
            => await _repo.Add(new AddProductImageParams { ProductId = request.ProductId, ImageUrl = request.ImageUrl });
    }
}
