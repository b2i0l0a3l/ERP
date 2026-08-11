using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}