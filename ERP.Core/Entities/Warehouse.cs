using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual Setting? Setting { get; set; } 
        public virtual ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();
    }
}