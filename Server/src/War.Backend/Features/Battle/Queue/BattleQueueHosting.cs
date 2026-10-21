using War.Backend.Hosting.Configuration;
using War.Persistence;

namespace War.Backend.Features.Battle.Queue;

/// <summary>Owns the configured provisioning capability used after a durable pair is acquired.</summary>
public sealed class BattleQueueHosting
{
    private readonly BattleManifestSnapshotStore _snapshots;
    private readonly BattleMatchProvisioner _provisioner;
    private readonly BattleManifestFactory? _factory;

    public BattleQueueHosting(BackendBattleOptions deployment, BattleManifestSnapshotStore snapshots,
        BattleMatchProvisioner provisioner, BattleManifestFactory? factory = null)
    {
        CompatibilityKey = deployment.CompatibilityKey;
        _snapshots = snapshots;
        _provisioner = provisioner;
        _factory = factory;
    }

    public string? CompatibilityKey { get; }

    public bool CanProvision => _factory != null;

    public async Task<BattlePairingResult> ProvisionAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        BattleManifestFactory factory = _factory
            ?? throw new InvalidDataException("Battle manifest provisioning is unavailable.");
        byte[] frozen = await _snapshots.GetOrCreate(pair.MatchId!, pair.Players!,
            () => factory.Create(pair.MatchId!, pair.Players!, cancellationToken), cancellationToken);
        string code = await _provisioner.Provision(frozen, cancellationToken);
        return code == "cancelled" ? new BattlePairingResult("cancelled", null, null) : pair;
    }
}
