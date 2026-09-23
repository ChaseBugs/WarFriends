namespace War.BattleServer;

public sealed record StableEntityRecord(StableEntityIdentity Identity, string OwnerPlayerId, string Kind);

/// <summary>Common bounded lifecycle registry for server-owned dynamic entities.</summary>
public sealed class StableEntityRegistry
{
    private readonly int capacity;
    private readonly Dictionary<ulong, StableEntityRecord> entities = [];
    public StableEntityRegistry(int capacity = 4096)
    {
        if (capacity is < 1 or > 65_536) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public int Count => entities.Count;
    public IReadOnlyList<StableEntityRecord> Snapshot() => entities.Values.OrderBy(x => x.Identity.EntityId).ToArray();
    public bool TrySpawn(StableEntityRecord record)
    {
        if (record is null || string.IsNullOrWhiteSpace(record.Kind) || record.Kind.Length > 64 ||
            !Guid.TryParseExact(record.OwnerPlayerId, "N", out _) || entities.Count >= capacity)
            return false;
        StableEntityIdentity identity;
        try { identity = StableEntityIdentityPolicy.Validate(record.Identity); }
        catch (InvalidDataException) { return false; }
        if (entities.ContainsKey(identity.EntityId)) return false;
        entities.Add(identity.EntityId, record with { Identity = identity });
        return true;
    }
    public bool TryGet(StableEntityIdentity identity, out StableEntityRecord? record)
    {
        StableEntityIdentityPolicy.Validate(identity);
        if (entities.TryGetValue(identity.EntityId, out var current) &&
            StableEntityIdentityPolicy.IsCurrent(current.Identity, identity)) { record = current; return true; }
        record = null; return false;
    }
    public bool TryDestroy(StableEntityIdentity identity)
    {
        return entities.TryGetValue(identity.EntityId, out var current) &&
            StableEntityIdentityPolicy.IsCurrent(current.Identity, identity) && entities.Remove(identity.EntityId);
    }
    public int RemoveOwner(string ownerPlayerId)
    {
        if (!Guid.TryParseExact(ownerPlayerId, "N", out _)) return 0;
        var ids = entities.Values.Where(x => x.OwnerPlayerId == ownerPlayerId).Select(x => x.Identity.EntityId).ToArray();
        foreach (var id in ids) entities.Remove(id);
        return ids.Length;
    }
}
