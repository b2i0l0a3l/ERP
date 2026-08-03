using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Commands
{
    public record DeleteProductCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
