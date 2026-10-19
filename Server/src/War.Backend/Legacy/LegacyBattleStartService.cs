using System.Globalization;
using System.Text.Json.Nodes;
using War.BattleServer;
using War.Persistence;
using War.Protocol;

namespace War.Backend.Legacy;

/// <summary>Acknowledges the recovered loading callback against an already allocated self-hosted battle.</summary>
public sealed class LegacyBattleStartService
{
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleGrantStore _grants;
    private readonly BattleManifestSnapshotStore _snapshots;
    private readonly BattleResultStore _results;

    /// <summary>Uses durable assignment evidence without creating a match or changing a wallet.</summary>
    public LegacyBattleStartService(BattleMatchQueueStore queue, BattleGrantStore grants,
        BattleManifestSnapshotStore snapshots, BattleResultStore results)
    {
        _queue = queue;
        _grants = grants;
        _snapshots = snapshots;
        _results = results;
    }

    /// <summary>Completes OnGameStarted for a published PvP assignment with no durable terminal result.</summary>
    public async Task<IResult> AcknowledgeAsync(LegacyRequest request, LegacyPlayerDocument player,
        LegacyCatalog catalog, CancellationToken cancellationToken)
    {
        if (!HasSupportedRequest(request, catalog))
        {
            return LegacyResponse.Failure(DatabaseResult.ServerDidntRespondBeforeGame);
        }

        try
        {
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (now is < 0 or > int.MaxValue)
            {
                return LegacyResponse.Failure(DatabaseResult.ServerDidntRespondBeforeGame);
            }
            int clientTime = (int)now;
            BattlePairingResult? pair = await _queue.ReadStartablePairAsync(player.Id, cancellationToken);
            if (pair?.MatchId == null || pair.Players == null || request.Field("BattleId") != pair.MatchId)
            {
                return LegacyResponse.Failure(DatabaseResult.ServerDidntRespondBeforeGame);
            }

            await RequirePublishedAssignmentAsync(new AssignedPair(pair.MatchId, pair.Players),
                player.Id, now, cancellationToken);
            return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
            {
                ["Time"] = clientTime,
                ["BattleId"] = pair.MatchId
            });
        }
        catch (InvalidDataException)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerDidntRespondBeforeGame);
        }
    }

    private async Task RequirePublishedAssignmentAsync(AssignedPair pair, string playerId,
        long now, CancellationToken cancellationToken)
    {
        MatchConnectionGrant grant = await _grants.GetAssignmentForPlayer(pair.MatchId, playerId, now,
            cancellationToken) ?? throw new InvalidDataException("The battle assignment has not been published.");
        byte[] bytes = await _snapshots.Get(pair.MatchId, pair.Players, cancellationToken)
            ?? throw new InvalidDataException("The battle manifest is unavailable.");
        MatchManifest manifest = MatchManifest.Parse(bytes);
        if (manifest.MatchId != pair.MatchId || manifest.Digest() != grant.ManifestHash ||
            manifest.MapId != grant.MapId || manifest.MapRevision != grant.MapRevision ||
            manifest.Mode is not ("unscored-rifle-combat" or "unscored-shotgun-combat" or "unscored-mixed-combat") ||
            !manifest.Players.Select(participant => participant.PlayerId).SequenceEqual(pair.Players) ||
            await _results.Get(pair.MatchId, cancellationToken) != null)
        {
            throw new InvalidDataException("The battle start acknowledgement has stale assignment authority.");
        }

        BattlePairingResult? current = await _queue.ReadStartablePairAsync(playerId, cancellationToken);
        if (current?.MatchId != pair.MatchId || current.Players == null ||
            !current.Players.SequenceEqual(pair.Players))
        {
            throw new InvalidDataException("The battle pair changed during acknowledgement.");
        }
        // This is a read-only loading acknowledgement. Only the UDP host can accept readiness or start combat.
        // The old Master/Client labels do not grant either participant authority over results or the peer.
    }

    private static bool HasSupportedRequest(LegacyRequest request, LegacyCatalog catalog)
    {
        int? refill = catalog.ConstantInt("DogTagRefillTime");
        int? capacity = catalog.ConstantInt("DogTagCap");
        return request.Action is DatabaseAction.GameStartedMaster or DatabaseAction.GameStartedClient &&
            request.Field("IsMatchMaking") == "1" && request.Field("IsWarArenaBattle") == "0" &&
            (request.Action == DatabaseAction.GameStartedMaster
                ? request.Field("IsHitList") is null or "0" : request.Field("IsHitList") == "0") &&
            request.Field("BotId") == null && request.Field("BotName") == null && request.Field("BotLevel") == null &&
            refill is > 0 && capacity is > 0 &&
            request.Field("DogTagRefillTime") == refill.Value.ToString(CultureInfo.InvariantCulture) &&
            request.Field("DogTagCap") == capacity.Value.ToString(CultureInfo.InvariantCulture);
    }

    private sealed record AssignedPair(string MatchId, IReadOnlyList<string> Players);
}
