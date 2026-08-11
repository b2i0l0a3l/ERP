using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.ProductImages.Requests.Queries
{
    public record GetProductImagesByProductQuery : IRequest<Result<List<ProductImageDTO>>>
    {
        public int ProductId { get; set; }
    }
}
