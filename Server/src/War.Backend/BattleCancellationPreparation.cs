using War.BattleServer;
using War.Infrastructure;
using War.Persistence;

namespace War.Backend;

/// <summary>Recovers interrupted allocation preparation without issuing a deliverable Backend grant.</summary>
public sealed class BattleCancellationPreparation
{
    private readonly BattleManifestSnapshotStore _snapshots;
    private readonly BattleMatchControlClient _control;
    private readonly BattleManifestFactory? _factory;
    private readonly Uri _endpoint;

    /// <summary>Uses normal admission settings, snapshots and the trusted registration endpoint.</summary>
    public BattleCancellationPreparation(
        BattleManifestSnapshotStore snapshots,
        BattleMatchControlClient control,
        BattleManifestFactory? factory,
        Uri endpoint)
    {
        _snapshots = snapshots;
        _control = control;
        _factory = factory;
        _endpoint = endpoint;
    }

    /// <summary>Reuses published settings or freezes trusted settings if preparation never finished.</summary>
    public Task<byte[]> GetFrozenManifestAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        if (pair.MatchId == null || pair.Players == null)
        {
            throw new InvalidDataException("Cancellation preparation requires its captured durable pair.");
        }

        return _snapshots.GetOrCreate(pair.MatchId, pair.Players,
            () => CreateManifestAsync(pair, cancellationToken), cancellationToken);
    }

    /// <summary>Registers only to obtain authoritative Worker cancellation proof; grants are not published.</summary>
    public async Task RegisterAsync(byte[] frozenManifest, CancellationToken cancellationToken)
    {
        var manifest = MatchManifest.Parse(frozenManifest);
        string[] players = manifest.Players.Select(player => player.PlayerId).ToArray();
        await _control.RegisterAsync(_endpoint, frozenManifest, manifest.MatchId, players, cancellationToken);
    }

    private Task<byte[]> CreateManifestAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        if (_factory == null)
        {
            throw new InvalidDataException("Cancellation has no configured source-backed manifest factory.");
        }

        return _factory.Create(pair.MatchId!, pair.Players!, cancellationToken);
    }
}
