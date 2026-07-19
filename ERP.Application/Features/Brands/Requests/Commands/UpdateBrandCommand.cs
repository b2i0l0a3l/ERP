using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Requests.Commands
{
    public record UpdateBrandCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
