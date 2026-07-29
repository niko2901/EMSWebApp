using EMSWebApp.Data;
using EMSWebApp.Models.ModelEnums;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Services
{
    public class EventStatusWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EventStatusWorker> _logger;

        public EventStatusWorker(IServiceProvider serviceProvider, ILogger<EventStatusWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromHours(2));

            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    await MarkExpiredEventsCompletedAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while updating expired event statuses.");
                }
            }
        }

        private async Task MarkExpiredEventsCompletedAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var now = DateTime.UtcNow;

            int updatedCount = await db.UserEvents
                .Where(e => e.EndDate < now && e.Status == EventStatusEnum.Published)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Status, EventStatusEnum.Completed));

            if (updatedCount > 0)
            {
                _logger.LogInformation("Marked {Count} expired event(s) as Completed at {Time}", updatedCount, now);
            }
        }
    }
}
