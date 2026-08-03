using ERP.Core.enums;

namespace ERP.Core.EntityParams.notificationParams
{
    public record AddNotificationParams
    {
        public enNotificationType Type { get; set; }
        public enNotificationPriority Priority { get; set; } = enNotificationPriority.Normal;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? TargetUserId { get; set; }
    }
}
