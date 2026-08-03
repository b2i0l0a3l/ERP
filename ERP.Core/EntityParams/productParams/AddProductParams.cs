using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.EntityParams.productParams
{
    public record AddProductParams
    {
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public  List<string>? ImageUrl { get; set; }
        public string? CreatedByUserId { get; set; }
    }
}