using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Requests.Queries
{
    public record GetBrandByNameQuery : IRequest<Result<BrandDTO>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
