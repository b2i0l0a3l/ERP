using ERP.Core.EntityParams.notificationParams;
using ERP.Core.enums;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface INotificationRepo
    {
        Task<Result<NotificationDTO>> GetById(int Id);
        Task<Result<PagedResult<NotificationDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddNotificationParams Params);
        Task<Result<bool>> Update(int Id, UpdateNotificationParams Params);

        Task<Result<HashSet<int>>> GetAlreadyNotifiedEntityIds(enNotificationType type, string relatedEntityType, DateTime since);

        Task<Result<List<NotificationDTO>>> AddBatch(List<AddNotificationParams> paramsList);
    }
}
