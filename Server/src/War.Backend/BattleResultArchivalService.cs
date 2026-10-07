using War.Persistence;

namespace War.Backend;

/// <summary>Drains old terminal evidence in small, validated MongoDB pages.</summary>
public sealed class BattleResultArchivalService : BackgroundService
{
    private const int MaximumPagesPerPass = 16;
    private static readonly TimeSpan LeaseLifetime = TimeSpan.FromMinutes(2);
    private static readonly TimeSpan Retention = TimeSpan.FromDays(30);
    private static readonly TimeSpan NormalInterval = TimeSpan.FromHours(1);
    private static readonly TimeSpan BacklogInterval = TimeSpan.FromMinutes(1);

    private readonly BattleResultStore results;
    private readonly BattleResultArchivalLeaseStore leases;
    private readonly ILogger<BattleResultArchivalService> logger;
    private readonly string ownerId = Guid.NewGuid().ToString("N");

    public BattleResultArchivalService(BattleResultStore results,
        BattleResultArchivalLeaseStore leases, ILogger<BattleResultArchivalService> logger)
    {
        this.results = results;
        this.leases = leases;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            TimeSpan nextInterval = NormalInterval;
            bool ownsLease = false;
            try
            {
                ownsLease = await leases.TryAcquire(ownerId, DateTime.UtcNow, LeaseLifetime, stoppingToken);
                if (!ownsLease)
                    nextInterval = BacklogInterval;

                for (int pageNumber = 0; ownsLease && pageNumber < MaximumPagesPerPass; pageNumber++)
                {
                    if (!await leases.TryAcquire(ownerId, DateTime.UtcNow, LeaseLifetime, stoppingToken))
                    {
                        nextInterval = BacklogInterval;
                        break;
                    }
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
            finally
            {
                if (ownsLease)
                {
                    try { await leases.Release(ownerId, CancellationToken.None); }
                    catch (Exception exception)
                    {
                        logger.LogError(exception, "Battle archival lease release failed; its expiry allows takeover.");
                    }
                }
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
