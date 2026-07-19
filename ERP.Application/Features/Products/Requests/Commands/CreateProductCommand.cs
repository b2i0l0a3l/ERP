using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Requests.Commands
{
    public record CreateProductCommand : IRequest<Result<int>>
    {
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public List<string>? ImageUrl { get; set; }
        public string? CreatedByUserId { get; set; }
    }
}
