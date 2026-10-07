using War.Persistence;

namespace War.Backend;

/// <summary>Drains old terminal evidence in small, validated MongoDB pages.</summary>
public sealed class BattleResultArchivalService : BackgroundService
{
    private const int MaximumPagesPerPass = 16;
    private static readonly TimeSpan Retention = TimeSpan.FromDays(30);
    private static readonly TimeSpan NormalInterval = TimeSpan.FromHours(1);
    private static readonly TimeSpan BacklogInterval = TimeSpan.FromMinutes(1);

    private readonly BattleResultStore results;
    private readonly ILogger<BattleResultArchivalService> logger;

    public BattleResultArchivalService(BattleResultStore results, ILogger<BattleResultArchivalService> logger)
    {
        this.results = results;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            TimeSpan nextInterval = NormalInterval;
            try
            {
                for (int pageNumber = 0; pageNumber < MaximumPagesPerPass; pageNumber++)
                {
                    var page = await results.PrunePage(DateTimeOffset.UtcNow, Retention, stoppingToken);
                    if (page.Removed > 0)
                        logger.LogInformation("Archived {Count} old battle results.", page.Removed);

                    if (page.Inspected < BattleResultStore.ArchivalPageSize)
                        break;

                    // Another page may remain. Leave time for foreground work
                    // after this bounded pass, then resume the backlog.
                    nextInterval = BacklogInterval;
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Battle result archival stopped this pass; retrying without deleting unvalidated evidence.");
                nextInterval = BacklogInterval;
            }

            try
            {
                await Task.Delay(nextInterval, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
        }
    }
}
