using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.Services
{
    public class NotificationChannel : BackgroundService, INotificationChannel
    {
        private readonly ILogger<NotificationChannel> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Channel<NotificationDTO> _channel;

        public NotificationChannel(IServiceScopeFactory scopeFactory, ILogger<NotificationChannel> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;

            var options = new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = false,
                SingleReader = true
            };

            _channel = Channel.CreateBounded<NotificationDTO>(options);
        }

        public async ValueTask QueueNotificationAsync(NotificationDTO notification, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(notification);
            await _channel.Writer.WriteAsync(notification, cancellationToken);
            _logger.LogInformation("Notification queued for sending.");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification Channel background service started.");

            await foreach (var notification in _channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var notificationSender = scope.ServiceProvider.GetRequiredService<INotificationSender>();
                    await notificationSender.SendNotificationAsync(notification);
                    _logger.LogInformation("Notification sent successfully to {Target}.", notification.TargetUserId ?? "All");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while processing notification");
                }
            }

            _logger.LogInformation("Notification Channel background service stopped.");
        }
    }
}
