using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.ProductModels
{
    public record ProductDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Brand { get; set; } 
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public List<string>? ImageUrl { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateOnly CreatedAt { get; set; }
        public string? CreatedByUser { get; set; }
    }
}