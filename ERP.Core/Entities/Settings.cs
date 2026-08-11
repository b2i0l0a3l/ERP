using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class Setting : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "DHs";
        public bool ShowImagesInInvoice { get; set; } = false;
        public int WarehouseId { get; set; }
        public decimal Tax { get; set; }
        public string? PhoneNumbder { get; set; }
        public virtual Warehouse Warehouse { get; set; } = new();
    }
}