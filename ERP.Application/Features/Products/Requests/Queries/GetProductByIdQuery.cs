using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Queries
{
    public record GetProductByIdQuery : IRequest<Result<ProductDTO>>
    {
        public int Id { get; set; }
    }
}
