using ERP.Core.enums;

namespace ERP.Core.EntityParams.notificationParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? TargetUserId { get; set; }
        public enNotificationType? Type { get; set; }
        public bool? IsRead { get; set; }
    }
}
