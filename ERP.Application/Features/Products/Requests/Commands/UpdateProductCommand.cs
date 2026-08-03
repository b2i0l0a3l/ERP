using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Commands
{
    public record UpdateProductCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
