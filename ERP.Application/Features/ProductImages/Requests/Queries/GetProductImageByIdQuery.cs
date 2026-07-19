using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.ProductImages.Requests.Queries
{
    public record GetProductImageByIdQuery : IRequest<Result<ProductImageDTO>>
    {
        public int Id { get; set; }
    }
}
