using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateOnly CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly UpdatedAt { get; set; } 
        public DateOnly? DeletedAt { get; set; }
        public string? DeletedByUserId { get; set; }
        public virtual User? DeletedByUser { get; set; } 

        public string? CreatedByUserId { get; set; } 
        public virtual User? CreatedByUser { get; set; } 
    }
}