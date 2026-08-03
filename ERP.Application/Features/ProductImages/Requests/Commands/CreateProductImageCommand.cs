using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Http;

namespace ERP.Application.Features.ProductImages.Requests.Commands
{
    public record CreateProductImageCommand : IRequest<Result<int>>
    {
        public int ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
