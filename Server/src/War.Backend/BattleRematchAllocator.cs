using War.BattleServer;
using War.Persistence;
using War.Protocol;

namespace War.Backend;

/// <summary>Reserves a source-compatible match and retries provisioning from its frozen admission payload.</summary>
public sealed class BattleRematchAllocator
{
    private readonly Stores _stores;
    private readonly Hosting _hosting;

    /// <summary>Uses deployment-owned hosting policy and the existing durable battle authority stores.</summary>
    public BattleRematchAllocator(Stores stores, Hosting hosting)
    {
        _stores = stores;
        _hosting = hosting;
    }

    /// <summary>Returns a paired identity; connection capabilities remain on the existing grant endpoint.</summary>
    public async Task<MatchQueueReply> AllocateAsync(
        string sourceMatchId, string authenticatedPlayerId, CancellationToken cancellationToken)
    {
        var consent = await _stores.Consents.ReadAsync(sourceMatchId, authenticatedPlayerId,
            DateTimeOffset.UtcNow, cancellationToken);
        if (consent?.Status is not ("ready" or "allocated"))
        {
            throw new InvalidDataException("Both participants must consent before allocation.");
        }
        if (consent.Status == "ready")
        {
            consent = await PrepareReservationAsync(consent, authenticatedPlayerId, cancellationToken);
        }
        if (consent.NextCompatibilityKey != _hosting.CompatibilityKey)
        {
            throw new InvalidDataException("Reserved rematch belongs to a different deployment policy.");
        }
        return await ProvisionReservedAsync(consent, cancellationToken);
    }

    private async Task<BattleRematchConsentDocument> PrepareReservationAsync(
        BattleRematchConsentDocument consent, string playerId, CancellationToken cancellationToken)
    {
        BattleResultDocument result = await _stores.Results.Get(consent.Id, cancellationToken)
            ?? throw new InvalidDataException("Accepted rematch source result is missing.");
        MatchSnapshot terminal = TerminalOutbox.ValidatePayload(result.Snapshot, result.MatchId, result.Digest);
        byte[] source = await _stores.Snapshots.GetForParticipantsAsync(consent.Id, consent.Players, cancellationToken)
            ?? throw new InvalidDataException("Accepted rematch source manifest is missing.");
        string nextMatchId = "m" + Guid.NewGuid().ToString("N");
        PreparedBattleManifest prepared = await _hosting.Factory.PrepareRematchAsync(
            source, terminal.ManifestHash, nextMatchId, cancellationToken);
        var request = new BattleRematchReservation(consent.Id, playerId,
            _hosting.CompatibilityKey, DateTimeOffset.UtcNow)
        {
            PlayerOrder = MatchManifest.Parse(source).Players.Select(player => player.PlayerId).ToArray(),
            PreparedManifest = prepared.Manifest,
            ExpectedAccountRevisions = prepared.AccountRevisions,
        };
        return await _stores.Consents.ReserveAsync(request, cancellationToken);
    }

    private async Task<MatchQueueReply> ProvisionReservedAsync(
        BattleRematchConsentDocument consent, CancellationToken cancellationToken)
    {
        string matchId = consent.NextMatchId;
        var pair = await _stores.Queue.ForMatch(matchId, cancellationToken);
        if (pair == null || await _stores.Results.Get(matchId, cancellationToken) != null)
        {
            // Consumed intent must never reopen an already released or completed Worker identity.
            return new MatchQueueReply { Code = "completed", MatchId = matchId };
        }
        if (pair.Players == null || !pair.Players.SequenceEqual(consent.NextPlayers))
        {
            throw new InvalidDataException("Reserved rematch roster changed before provisioning.");
        }
        byte[] frozen = await _stores.Snapshots.Get(matchId, consent.NextPlayers, cancellationToken)
            ?? throw new InvalidDataException("Reserved rematch admission payload is missing.");
        try
        {
            string provisioned = await _hosting.Provisioner.Provision(frozen, cancellationToken);
            var reply = new MatchQueueReply
            {
                Code = provisioned == "cancelled" ? "cancelled" : "paired", MatchId = matchId,
            };
            if (reply.Code == "paired")
            {
                reply.PlayerIds.Add(consent.NextPlayers);
            }
            return reply;
        }
        catch (Exception exception) when (exception is HttpRequestException or InvalidDataException ||
            exception is OperationCanceledException && !cancellationToken.IsCancellationRequested)
        {
            throw new HttpRequestException("Reserved rematch provisioning must be retried.", exception);
        }
    }

    /// <summary>Groups durable dependencies without accepting caller-supplied participant assertions.</summary>
    public sealed record Stores(BattleRematchConsentStore Consents, BattleResultStore Results,
        BattleManifestSnapshotStore Snapshots, BattleMatchQueueStore Queue);

    /// <summary>Binds the configured catalog, Worker control endpoint and immutable compatibility policy.</summary>
    public sealed record Hosting(BattleManifestFactory Factory, BattleMatchProvisioner Provisioner,
        string CompatibilityKey);
}
