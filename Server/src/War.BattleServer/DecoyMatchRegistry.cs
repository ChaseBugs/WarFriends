using System.Numerics;

namespace War.BattleServer;

internal sealed record DecoyMatchEntity(
    ulong EntityId, string RequestId, string OwnerPlayerId,
    int OwnerFraction, int ObstacleComponentFileId,
    Vector3 Position, Vector3 Facing, float Health, float MaximumHealth);

/// <summary>
/// Match-owned Decoy health, obstacle occupancy, and request receipts.
/// </summary>
internal sealed class DecoyMatchRegistry
{
    private sealed record Receipt(string OwnerPlayerId, ulong[] EntityIds);
    private readonly int capacity;
    private readonly Dictionary<ulong, DecoyMatchEntity> entities = [];
    private readonly Dictionary<string, Receipt> receipts =
        new(StringComparer.Ordinal);
    private readonly HashSet<int> occupied = [];
    private ulong nextEntityId;

    internal DecoyMatchRegistry(int capacity = 48)
    {
        if (capacity is < 3 or > 256)
            throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }

    internal IReadOnlySet<int> OccupiedObstacleIds => occupied;
    internal IReadOnlyList<DecoyMatchEntity> Snapshot() =>
        entities.Values.OrderBy(entity => entity.EntityId).ToArray();

    internal bool TryReplay(string requestId, string ownerPlayerId,
        out IReadOnlyList<DecoyMatchEntity> rows)
    {
        rows = [];
        if (!receipts.TryGetValue(requestId, out Receipt? receipt) ||
            receipt.OwnerPlayerId != ownerPlayerId)
            return false;
        rows = receipt.EntityIds.Where(entities.ContainsKey)
            .Select(id => entities[id]).ToArray();
        return true;
    }

    internal bool TrySpawn(string requestId, string ownerPlayerId,
        int ownerFraction, float maximumHealth,
        IReadOnlyList<(DecoyObstacleSlot Slot, Vector3 Position,
            Vector3 Facing)> placements,
        out IReadOnlyList<DecoyMatchEntity> spawned)
    {
        spawned = [];
        if (!CanonicalGuid(requestId) || !CanonicalGuid(ownerPlayerId) ||
            ownerFraction is not (1 or 2) ||
            !float.IsFinite(maximumHealth) ||
            maximumHealth is <= 0 or > 10_000_000 ||
            placements == null || placements.Count != 3 ||
            entities.Count > capacity - placements.Count ||
            receipts.ContainsKey(requestId))
            return false;

        var slotIds = new HashSet<int>();
        foreach (var placement in placements)
        {
            if (placement.Slot == null ||
                placement.Slot.Fraction != ownerFraction ||
                placement.Slot.ComponentFileId <= 0 ||
                !slotIds.Add(placement.Slot.ComponentFileId) ||
                occupied.Contains(placement.Slot.ComponentFileId) ||
                !PlayerHitbox.Finite(placement.Position) ||
                !PlayerHitbox.Finite(placement.Facing) ||
                Math.Abs(placement.Facing.LengthSquared() - 1) > 0.0001f)
                return false;
        }
        if (nextEntityId > ulong.MaxValue - (ulong)placements.Count)
            return false;

        var accepted = new DecoyMatchEntity[placements.Count];
        for (int index = 0; index < accepted.Length; index++)
        {
            var placement = placements[index];
            ulong id = ++nextEntityId;
            accepted[index] = new(id, requestId, ownerPlayerId,
                ownerFraction, placement.Slot.ComponentFileId,
                placement.Position, placement.Facing,
                maximumHealth, maximumHealth);
        }
        foreach (DecoyMatchEntity entity in accepted)
        {
            entities.Add(entity.EntityId, entity);
            if (!occupied.Add(entity.ObstacleComponentFileId))
                throw new InvalidDataException(
                    "Decoy obstacle transaction diverged.");
        }
        receipts.Add(requestId, new(ownerPlayerId,
            accepted.Select(entity => entity.EntityId).ToArray()));
        spawned = accepted;
        return true;
    }

    internal bool TryDamage(ulong entityId, float damage,
        out DecoyMatchEntity? before, out bool destroyed)
    {
        destroyed = false;
        before = null;
        if (!entities.TryGetValue(entityId, out DecoyMatchEntity? entity) ||
            !float.IsFinite(damage) || damage is <= 0 or > 10_000_000)
            return false;

        before = entity;
        float remainingHealth = Math.Max(0, entity.Health - damage);
        if (remainingHealth <= 0)
        {
            entities.Remove(entityId);
            if (!occupied.Remove(entity.ObstacleComponentFileId))
                throw new InvalidDataException(
                    "Decoy obstacle occupancy diverged.");
            destroyed = true;
        }
        else
            entities[entityId] = entity with { Health = remainingHealth };
        return true;
    }

    internal IReadOnlyList<DecoyMatchEntity> RemoveOwner(string ownerPlayerId)
    {
        DecoyMatchEntity[] removed = entities.Values
            .Where(entity => entity.OwnerPlayerId == ownerPlayerId)
            .OrderBy(entity => entity.EntityId).ToArray();
        foreach (DecoyMatchEntity entity in removed)
        {
            entities.Remove(entity.EntityId);
            if (!occupied.Remove(entity.ObstacleComponentFileId))
                throw new InvalidDataException(
                    "Decoy obstacle occupancy diverged.");
        }
        return removed;
    }

    internal bool TryRollbackSpawn(string requestId, string ownerPlayerId)
    {
        if (!receipts.TryGetValue(requestId, out Receipt? receipt) ||
            receipt.OwnerPlayerId != ownerPlayerId)
            return false;
        foreach (ulong id in receipt.EntityIds)
        {
            if (entities.Remove(id, out DecoyMatchEntity? entity) &&
                !occupied.Remove(entity.ObstacleComponentFileId))
                throw new InvalidDataException(
                    "Decoy obstacle rollback diverged.");
        }
        receipts.Remove(requestId);
        return true;
    }

    private static bool CanonicalGuid(string value)
    {
        return Guid.TryParseExact(value, "N", out _) &&
            value == value.ToLowerInvariant();
    }
}
