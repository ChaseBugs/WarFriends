using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;

namespace War.Backend;

/// <summary>Finishes committed cancellation intents even when the initiating client never retries.</summary>
public sealed class BattleCancellationRecoveryService : BackgroundService
{
    private const int PassTimeoutSeconds = 30;
    private static readonly TimeSpan PollInterval = TimeSpan.FromSeconds(5);
    private readonly BattleMatchQueueStore _queue;
    private readonly BattlePairedCancellation _cancellation;
    private readonly ILogger<BattleCancellationRecoveryService> _logger;

    /// <summary>Uses durable pair claims and the same authoritative cancellation path as HTTP requests.</summary>
    public BattleCancellationRecoveryService(
        BattleMatchQueueStore queue,
        BattlePairedCancellation cancellation,
        ILogger<BattleCancellationRecoveryService> logger)
    {
        _queue = queue;
        _cancellation = cancellation;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var pass = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            pass.CancelAfter(TimeSpan.FromSeconds(PassTimeoutSeconds));
            try
            {
                var pairs = await _queue.ClaimCancellationsAsync(DateTimeOffset.UtcNow, pass.Token);
                // The bounded page runs concurrently so every operation stays inside its 60-second claim.
                await Task.WhenAll(pairs.Select(pair => RecoverAsync(pair, pass.Token)));
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception failure) when (
                failure is MongoException or BsonException or FormatException or InvalidDataException or
                TimeoutException or OperationCanceledException)
            {
                _logger.LogError(failure,
                    "Cancellation recovery deferred its pass without releasing unproven pairs.");
            }

            try
            {
                await Task.Delay(PollInterval, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
        }
    }

    private async Task RecoverAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        try
        {
            await _cancellation.CancelAsync(pair, cancellationToken);
        }
        catch (Exception failure) when (failure is HttpRequestException or InvalidDataException or
            MongoException or TimeoutException or OperationCanceledException)
        {
            // Running matches remain owned by the Worker; transport failure retains the durable intent for retry.
            _logger.LogWarning(failure,
                "Cancellation recovery deferred match {MatchId} until its next claim.", pair.MatchId);
        }
    }
}
