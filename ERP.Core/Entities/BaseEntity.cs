using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string? DeletedByUserId { get; set; }
        public virtual User? DeletedByUser { get; set; } 

        public string? CreatedByUserId { get; set; } 
        public virtual User? CreatedByUser { get; set; } 
    }
}