using MongoDB.Bson;
using MongoDB.Driver;
using War.BattleServer;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;

/// <summary>Checks recovery after Backend stops with an intent whose short-lived attempt receipt is absent.</summary>
internal sealed class UnattendedCancellationChecks
{
    private const int HistoricalAttemptAgeSeconds = 400;
    private const int MaximumRecoveryPolls = 750;
    private const int MaximumClaimPolls = 100;
    private const int FailedPassObservationSeconds = 35;
    private const int PollDelayMilliseconds = 100;
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleResultStore _results;
    private readonly BattleManifestSnapshotStore _manifests;
    private readonly CancellationToken _cancellationToken;
    private Pending? _pending;

    internal UnattendedCancellationChecks(
        BattleMatchQueueStore queue,
        BattleResultStore results,
        BattleManifestSnapshotStore manifests,
        CancellationToken cancellationToken)
    {
        _queue = queue;
        _results = results;
        _manifests = manifests;
        _cancellationToken = cancellationToken;
    }

    internal async Task PrepareAsync(IMongoDatabase database, string[] playerIds, BattleQueueAttemptTokens issuer)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long issued = now - HistoricalAttemptAgeSeconds;
        var attempts = playerIds.Select(playerId => issuer.ValidateForCancellation(
            issuer.Issue(playerId, issued), playerId, now)).ToArray();
        var pair = new BattlePairDocument
        {
            Id = Guid.NewGuid().ToString("N"), MatchId = "m" + Guid.NewGuid().ToString("N"),
            Players = playerIds.ToArray(), AttemptIds = attempts.Select(attempt => attempt.AttemptId).ToArray(),
            CompatibilityKey = "unattended-cancellation.fixture",
            CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(issued).UtcDateTime
        };
        // Model an older committed pair after receipt cleanup; no waiting ticket or Worker was registered.
        await database.GetCollection<BattlePairDocument>("battle_pairs")
            .InsertOneAsync(pair, cancellationToken: _cancellationToken);
        _pending = new Pending(database, attempts[0], pair);
    }

    internal async Task CommitWhileBackendStoppedAsync()
    {
        var pending = RequirePending();
        var captured = await _queue.CancelAttemptAsync(pending.Attempt, DateTimeOffset.UtcNow, _cancellationToken);
        if (captured.Code != "already-paired" || captured.MatchId != pending.Pair.MatchId)
        {
            throw new Exception("Abandoned cancellation did not persist its exact pair intent.");
        }

        await VerifyNoAttemptReceiptAsync(pending);
    }

    internal async Task VerifyDeferredAsync()
    {
        var pending = RequirePending();
        var rows = pending.Database.GetCollection<BattlePairDocument>("battle_pairs");
        bool hasClaim = false;
        for (int poll = 0; poll < MaximumClaimPolls; poll++)
        {
            var row = await rows.Find(pair => pair.Id == pending.Pair.Id).SingleAsync(_cancellationToken);
            if (row.Cancellation != null && row.Cancellation.RetryAfterUtc > row.Cancellation.RequestedUtc)
            {
                hasClaim = true;
                break;
            }

            await Task.Delay(PollDelayMilliseconds, _cancellationToken);
        }

        if (!hasClaim)
        {
            throw new Exception("Background recovery did not claim its durable cancellation intent.");
        }

        // Keep Worker down beyond the complete 30-second pass budget before allowing it to return.
        await Task.Delay(TimeSpan.FromSeconds(FailedPassObservationSeconds), _cancellationToken);
        if (await _results.Get(pending.Pair.MatchId, _cancellationToken) != null ||
            (await _queue.Existing(pending.Pair.Players[0], _cancellationToken))?.MatchId != pending.Pair.MatchId ||
            (await _queue.Existing(pending.Pair.Players[1], _cancellationToken))?.MatchId != pending.Pair.MatchId)
        {
            throw new Exception("Worker outage fabricated a result or released unproven cancellation authority.");
        }

        Console.WriteLine("PASS: Worker outage retains the claimed cancellation and pair without terminal proof");
    }

    internal async Task VerifyRecoveredAsync()
    {
        var pending = RequirePending();
        BattleResultDocument? result = null;
        for (int poll = 0; poll < MaximumRecoveryPolls; poll++)
        {
            result = await _results.Get(pending.Pair.MatchId, _cancellationToken);
            if (result != null && await _queue.Existing(pending.Pair.Players[0], _cancellationToken) == null &&
                await _queue.Existing(pending.Pair.Players[1], _cancellationToken) == null)
            {
                break;
            }

            await Task.Delay(PollDelayMilliseconds, _cancellationToken);
        }

        if (result == null || await _queue.Existing(pending.Pair.Players[0], _cancellationToken) != null ||
            await _queue.Existing(pending.Pair.Players[1], _cancellationToken) != null)
        {
            throw new Exception("Restarted Backend did not finish its cancellation without a client retry.");
        }

        await VerifyEvidenceAsync(pending, result);
        Console.WriteLine(
            "PASS: restarted Backend autonomously cancels an expired attempt without its receipt or client retry");
    }

    private async Task VerifyEvidenceAsync(Pending pending, BattleResultDocument result)
    {
        var terminal = TerminalOutbox.ValidatePayload(result.Snapshot, pending.Pair.MatchId, result.Digest);
        byte[] frozen = await _manifests.Get(pending.Pair.MatchId, pending.Pair.Players, _cancellationToken) ??
            throw new Exception("Autonomous cancellation has no frozen manifest proof.");
        if (terminal.Phase != BattlePhase.Aborted || terminal.TerminalReason != "cancelled-before-start" ||
            terminal.WinnerPlayerId.Length != 0 || terminal.ManifestHash != MatchManifest.Parse(frozen).Digest())
        {
            throw new Exception("Autonomous cancellation did not retain authoritative unscored Worker evidence.");
        }

        long grants = await pending.Database.GetCollection<BsonDocument>("battle_grants")
            .CountDocumentsAsync(new BsonDocument("MatchId", pending.Pair.MatchId),
                cancellationToken: _cancellationToken);
        if (grants != 0)
        {
            throw new Exception("Autonomous cancellation published a deliverable player grant.");
        }

        await VerifyNoAttemptReceiptAsync(pending);
    }

    private async Task VerifyNoAttemptReceiptAsync(Pending pending)
    {
        string id = pending.Attempt.PlayerId + ":" + pending.Attempt.AttemptId;
        long count = await pending.Database.GetCollection<BattleQueueAttemptDocument>("battle_queue_attempts")
            .CountDocumentsAsync(row => row.Id == id, cancellationToken: _cancellationToken);
        if (count != 0)
        {
            throw new Exception("Expired attempt unexpectedly recreated its short-lived receipt.");
        }
    }

    private Pending RequirePending()
    {
        return _pending ?? throw new InvalidOperationException("Prepare the unattended cancellation fixture first.");
    }

    private sealed class Pending
    {
        internal Pending(IMongoDatabase database, BattleQueueAttemptIdentity attempt, BattlePairDocument pair)
        {
            Database = database;
            Attempt = attempt;
            Pair = pair;
        }

        internal IMongoDatabase Database { get; }
        internal BattleQueueAttemptIdentity Attempt { get; }
        internal BattlePairDocument Pair { get; }
    }
}
