using System.Numerics;

namespace War.BattleServer;

public enum DeployableState { Armed, Triggered, Expired }

public sealed record DeployableEntity(int EntityId, string OwnerPlayerId, string CardId,
    Vector3 Position, int LifetimeTicks)
{
    public DeployableState State { get; internal set; } = DeployableState.Armed;
    public int RemainingTicks { get; internal set; } = LifetimeTicks;
    public int Charges { get; internal set; } = 1;
    public int CooldownTicks { get; internal set; }
}

/// <summary>Bounded server-owned deployable lifecycle. Client placement is never
/// allowed to mutate state directly or trigger an effect twice.</summary>
public sealed class DeployableRegistry
{
    private readonly int capacity;
    private readonly Dictionary<int, DeployableEntity> entities = new();
    private readonly HashSet<string> triggerEvents = new(StringComparer.Ordinal);
    public DeployableRegistry(int capacity = 64)
    {
        if (capacity is < 1 or > 512) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public int Count => entities.Count;
    public IReadOnlyCollection<DeployableEntity> Snapshot() => entities.Values.OrderBy(x => x.EntityId)
        .Select(x => new DeployableEntity(x.EntityId, x.OwnerPlayerId, x.CardId, x.Position, x.LifetimeTicks)
        { State = x.State, RemainingTicks = x.RemainingTicks, Charges = x.Charges, CooldownTicks = x.CooldownTicks }).ToArray();

    public bool TrySpawn(DeployableEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        if (entity.EntityId <= 0 || !Guid.TryParseExact(entity.OwnerPlayerId, "N", out _) ||
            !PlayerHitbox.Finite(entity.Position) || entity.LifetimeTicks is < 1 or > 30 * 60 ||
            entity.CardId is not ("LandMine" or "HeavyTurret") || entities.Count >= capacity ||
            !entities.TryAdd(entity.EntityId, entity)) return false;
        entity.Charges = entity.CardId == "HeavyTurret" ? 3 : 1;
        return true;
    }

    public bool TryTrigger(int entityId)
    {
        if (!entities.TryGetValue(entityId, out var entity) || entity.State != DeployableState.Armed || entity.Charges <= 0 || entity.CooldownTicks > 0) return false;
        entity.Charges--;
        entity.CooldownTicks = entity.CardId == "HeavyTurret" ? 15 : 0;
        entity.State = entity.CardId == "LandMine" || entity.Charges == 0
            ? DeployableState.Triggered : DeployableState.Armed;
        return true;
    }
    public bool TryTrigger(int entityId, string eventId)
    {
        if (string.IsNullOrWhiteSpace(eventId) || eventId.Length > 96 || !Guid.TryParseExact(eventId, "N", out _)) return false;
        if (triggerEvents.Contains(eventId)) return true;
        if (!TryTrigger(entityId)) return false;
        if (triggerEvents.Count >= 2048) triggerEvents.Remove(triggerEvents.First());
        triggerEvents.Add(eventId); return true;
    }

    public bool TryDespawn(int entityId) => entityId > 0 && entities.Remove(entityId);

    public void AdvanceTick()
    {
        foreach (var entity in entities.Values.ToArray())
        {
            if (entity.State != DeployableState.Armed) continue;
            if (entity.CooldownTicks > 0) entity.CooldownTicks--;
            if (--entity.RemainingTicks <= 0) { entity.RemainingTicks = 0; entity.State = DeployableState.Expired; }
        }
    }

    public int RemoveExpired() => RemoveWhere(x => x.State is DeployableState.Expired or DeployableState.Triggered);
    public int RemoveOwner(string ownerPlayerId) => RemoveWhere(x => x.OwnerPlayerId == ownerPlayerId);
    private int RemoveWhere(Func<DeployableEntity, bool> predicate)
    {
        var ids = entities.Values.Where(predicate).Select(x => x.EntityId).ToArray();
        foreach (var id in ids) entities.Remove(id);
        return ids.Length;
    }
}
