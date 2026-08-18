using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Commands
{
    public record BulkUpdatePricesCommand : IRequest<Result<bool>>
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public decimal Percentage { get; set; }
        public bool UpdateCostPrice { get; set; }
    }
}
