using ERP.Core.enums;

namespace ERP.Core.Models.NotificationModels
{
    public record NotificationDTO
    {
        public int Id { get; init; }
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
