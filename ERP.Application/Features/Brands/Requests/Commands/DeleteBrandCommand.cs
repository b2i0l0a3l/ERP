using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Requests.Commands
{
    public record DeleteBrandCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
