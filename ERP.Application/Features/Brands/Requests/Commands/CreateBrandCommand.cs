using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Requests.Commands
{
    public record CreateBrandCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
