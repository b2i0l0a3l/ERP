using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.EntityParams.productParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? ProductName { get; set; }
        public string? BarCode { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}