using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class Notification
    { 
        public int Id { get; set; }

        public enNotificationType Type { get; set; }
        public enNotificationPriority Priority { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }

        public string? TargetUserId { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}