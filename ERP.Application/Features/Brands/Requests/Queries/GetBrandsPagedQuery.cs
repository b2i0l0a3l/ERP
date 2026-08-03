using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Requests.Queries
{
    public record GetBrandsPagedQuery : IRequest<Result<PagedResult<BrandDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
