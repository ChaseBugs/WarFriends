using System.Numerics;

namespace War.BattleServer;

internal sealed record TimedMineEntity(
    ulong EntityId, string RequestId, string OwnerPlayerId, int OwnerFraction,
    Vector3 Position, float OuterDamage, float ExplosionDamage, ulong ExpiresTick);

/// <summary>
/// Match-local CardMineYourStep entities. A spent request ID remains a receipt
/// after its mine explodes so a retry can never plant a second mine.
/// </summary>
internal sealed class TimedMineMatchRegistry
{
    private const ulong FirstEntityId = 1UL << 63;
    private readonly Dictionary<ulong, TimedMineEntity> active = [];
    private readonly Dictionary<string, (string OwnerPlayerId, ulong EntityId)> receipts =
        new(StringComparer.Ordinal);
    private readonly int capacity;
    private ulong nextEntityId = FirstEntityId;

    internal TimedMineMatchRegistry(int capacity = 16)
    {
        if (capacity is < 1 or > 128) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }

    internal IReadOnlyList<TimedMineEntity> Snapshot() =>
        active.Values.OrderBy(mine => mine.EntityId).ToArray();

    internal bool TryReplay(string requestId, string ownerPlayerId) =>
        receipts.TryGetValue(requestId, out var receipt) && receipt.OwnerPlayerId == ownerPlayerId;

    internal bool TrySpawn(string requestId, string ownerPlayerId, int ownerFraction,
        MineYourStepPlacement placement, ulong startedTick, out TimedMineEntity? spawned)
    {
        spawned = null;
        if (!Guid.TryParseExact(requestId, "N", out _) || requestId != requestId.ToLowerInvariant() ||
            !Guid.TryParseExact(ownerPlayerId, "N", out _) || ownerFraction is not (1 or 2) ||
            placement == null || !PlayerHitbox.Finite(placement.Position) ||
            placement.FirstEnemyCover < 0 || placement.SecondEnemyCover < 0 ||
            placement.SecondEnemyCover != placement.FirstEnemyCover + 1 ||
            !float.IsFinite(placement.OuterDamage) || !float.IsFinite(placement.ExplosionDamage) ||
            placement.OuterDamage <= 0 || placement.ExplosionDamage <= 0 ||
            placement.ExplosionDamage > 10_000_000 ||
            Math.Abs(placement.OuterDamage - placement.ExplosionDamage * 0.1f) > 0.001f ||
            startedTick > 10_000_000 || active.Count >= capacity ||
            receipts.Count >= 256 || receipts.ContainsKey(requestId) || nextEntityId == ulong.MaxValue)
            return false;

        ulong durationTicks = (ulong)(MineYourStepSourcePolicy.DurationSeconds * MatchManifest.TickRate);
        var mine = new TimedMineEntity(nextEntityId++, requestId, ownerPlayerId, ownerFraction,
            placement.Position, placement.OuterDamage, placement.ExplosionDamage,
            checked(startedTick + durationTicks));
        active.Add(mine.EntityId, mine);
        receipts.Add(requestId, (ownerPlayerId, mine.EntityId));
        spawned = mine;
        return true;
    }

    internal bool TryRemove(ulong entityId, out TimedMineEntity? removed) =>
        active.Remove(entityId, out removed);

    internal IReadOnlyList<TimedMineEntity> Due(ulong tick) =>
        active.Values.Where(mine => mine.ExpiresTick <= tick)
            .OrderBy(mine => mine.ExpiresTick).ThenBy(mine => mine.EntityId).ToArray();

    internal IReadOnlyList<TimedMineEntity> RemoveOwner(string ownerPlayerId)
    {
        var removed = active.Values.Where(mine => mine.OwnerPlayerId == ownerPlayerId)
            .OrderBy(mine => mine.EntityId).ToArray();
        foreach (var mine in removed) active.Remove(mine.EntityId);
        return removed;
    }

    internal bool TryRollbackSpawn(string requestId, string ownerPlayerId)
    {
        if (!receipts.TryGetValue(requestId, out var receipt) ||
            receipt.OwnerPlayerId != ownerPlayerId) return false;
        active.Remove(receipt.EntityId);
        receipts.Remove(requestId);
        return true;
    }
}
