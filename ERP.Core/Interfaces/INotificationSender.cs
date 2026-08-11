using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Core.Models.NotificationModels;

namespace ERP.Core.Interfaces
{
    public interface INotificationSender
    {
        Task SendNotificationAsync(NotificationDTO notification);
        Task SendNotificationsAsync(List<NotificationDTO> notifications);
    }
}
