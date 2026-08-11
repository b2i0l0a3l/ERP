using System.Threading;
using System.Threading.Tasks;
using ERP.Core.Models.NotificationModels;

namespace ERP.Core.Interfaces
{
    public interface INotificationChannel
    {
        ValueTask QueueNotificationAsync(NotificationDTO notification, CancellationToken cancellationToken = default);
    }
}
