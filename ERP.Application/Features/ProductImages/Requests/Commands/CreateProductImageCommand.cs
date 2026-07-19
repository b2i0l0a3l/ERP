using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.ProductImages.Requests.Commands
{
    public record CreateProductImageCommand : IRequest<Result<int>>
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
