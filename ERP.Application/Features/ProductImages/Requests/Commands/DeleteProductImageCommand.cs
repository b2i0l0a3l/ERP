using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.ProductImages.Requests.Commands
{
    public record DeleteProductImageCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
