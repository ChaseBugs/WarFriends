namespace War.BattleServer;

/// <summary>Bounded match-owned air entity collection. Mutations are intentionally
/// explicit so deployment and death transitions cannot be inferred from clients.</summary>
public sealed class AirEntityRegistry
{
    private readonly int capacity;
    private readonly Dictionary<ulong, AirBattleEntity> entities = new();

    public AirEntityRegistry(int capacity = 32)
    {
        if (capacity is < 1 or > 256) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }

    public int Count => entities.Count;
    public IReadOnlyCollection<AirBattleEntity> Snapshot() => entities.Values.ToArray();

    public bool TrySpawn(AirBattleEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        if (entities.ContainsKey(entity.EntityKey) || entities.Count >= capacity) return false;
        entities.Add(entity.EntityKey, entity);
        return true;
    }

    public bool TryDespawn(ulong entityKey) => entityKey != 0 && entities.Remove(entityKey);

    public int RemoveOwner(string ownerPlayerId)
    {
        if (!Guid.TryParseExact(ownerPlayerId, "N", out _)) return 0;
        var ids = entities.Values.Where(x => x.AttackerPlayerId == ownerPlayerId).Select(x => x.EntityKey).ToArray();
        foreach (var id in ids) entities.Remove(id);
        return ids.Length;
    }

    public bool TryApplyDamage(ulong entityKey, float trustedDamage, out float applied)
    {
        applied = 0;
        if (!entities.TryGetValue(entityKey, out var entity) || entity.Health.IsDead) return false;
        applied = entity.Health.ApplyDamage(trustedDamage);
        if (entity.Health.IsDead) entities.Remove(entityKey);
        return applied > 0;
    }

    public bool TryGet(ulong entityKey, out AirBattleEntity? entity) =>
        entities.TryGetValue(entityKey, out entity);

    public void AdvanceTick()
    {
        foreach (var entity in entities.Values.OrderBy(e => e.EntityKey)) entity.AdvanceTick();
    }
}
