using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Requests.Commands
{
    public record DeleteBrandCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
