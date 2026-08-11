
using ERP.Core.Interfaces;

namespace ERP.Api.BackgroundServices
{
    public class ERPBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ERPBackgroundService> _logger;
        private readonly TimeSpan _checkInterval;

        public ERPBackgroundService(IServiceProvider serviceProvider, ILogger<ERPBackgroundService> logger, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _checkInterval = TimeSpan.FromMinutes(
            configuration.GetValue<int>("BackgroundServices:CheckIntervalMinutes", 15));

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ERP Background Service started. Interval: {Interval}", _checkInterval);

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var checks = scope.ServiceProvider.GetServices<IPeriodicCheck>();

                foreach (var check in checks)
                {
                    try
                    {
                        _logger.LogDebug("Running {CheckName}...", check.Name);
                        await check.ExecuteAsync(stoppingToken);
                    }
                    catch (Exception ex) when (ex is not OperationCanceledException)
                    {
                        _logger.LogError(ex, "{CheckName} failed.", check.Name);
                    }
                }

                try
                {
                    await Task.Delay(_checkInterval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            _logger.LogInformation("ERP Background Service stopped.");
        }
    }
}
