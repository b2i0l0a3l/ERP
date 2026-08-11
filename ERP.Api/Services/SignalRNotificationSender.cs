using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ERP.Infrastructure.Shared.Hubs;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;

namespace ERP.Api.Services
{
    public class SignalRNotificationSender : INotificationSender
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRNotificationSender(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(NotificationDTO notification)
        {
            if (!string.IsNullOrEmpty(notification.TargetUserId))
            {
                await _hubContext.Clients.Group($"User_{notification.TargetUserId}")
                    .SendAsync("ReceiveNotification", notification);
            }
            else
            {
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
            }
        }

        public async Task SendNotificationsAsync(List<NotificationDTO> notifications)
        {
            if (notifications.Count == 0) return;

            await _hubContext.Clients.All.SendAsync("ReceiveNotifications", notifications);
        }
    }
}
