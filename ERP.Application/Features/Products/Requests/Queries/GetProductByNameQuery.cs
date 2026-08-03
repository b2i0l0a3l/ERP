using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Queries
{
    public record GetProductByNameQuery : IRequest<Result<ProductDTO>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
