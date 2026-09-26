using System.Numerics;
namespace War.BattleServer;

public sealed record VehicleEntity(ulong EntityId, string UnitId, string OwnerPlayerId, uint Generation)
{
    public System.Numerics.Vector3 Position { get; internal set; }
}

public sealed class VehicleEntityRegistry
{
    private readonly IReadOnlyDictionary<string, int> caps;
    private readonly Dictionary<ulong, VehicleEntity> entities = new();
    private readonly Dictionary<ulong, VehicleAttackState> attacks = new();
    private readonly Dictionary<ulong, VehicleHealthState> health = new();
    private readonly Dictionary<ulong, Dictionary<string, VehiclePartState>> parts = new();
    public VehicleEntityRegistry(IReadOnlyDictionary<string, int> familyCaps)
    {
        if (familyCaps is null || familyCaps.Count == 0 || familyCaps.Any(x => string.IsNullOrWhiteSpace(x.Key) || x.Value is < 1 or > 8))
            throw new InvalidDataException("Invalid vehicle family caps.");
        caps = new Dictionary<string, int>(familyCaps, StringComparer.Ordinal);
    }
    public int Count => entities.Count;
    public IReadOnlyCollection<VehicleEntity> Snapshot() => entities.Values.OrderBy(x => x.EntityId)
        .Select(x => new VehicleEntity(x.EntityId, x.UnitId, x.OwnerPlayerId, x.Generation) { Position = x.Position })
        .ToArray();
    public bool TryGet(ulong entityId, out VehicleEntity? entity)
    {
        if (!entities.TryGetValue(entityId, out var current)) { entity = null; return false; }
        entity = new VehicleEntity(current.EntityId, current.UnitId, current.OwnerPlayerId, current.Generation)
        { Position = current.Position };
        return true;
    }
    public bool TryMove(ulong entityId, Vector3 next, float sourceSpeed)
    {
        if (!entities.TryGetValue(entityId, out var entity)) return false;
        entity.Position = VehicleMotionPolicy.ValidateStep(entity.Position, next, sourceSpeed);
        return true;
    }
    public bool TrySpawn(VehicleEntity entity)
    {
        if (entity is null || entity.EntityId == 0 || entity.Generation == 0 ||
            !Guid.TryParseExact(entity.OwnerPlayerId, "N", out _) || !caps.ContainsKey(entity.UnitId) ||
            entities.ContainsKey(entity.EntityId) || entities.Values.Count(x => x.UnitId == entity.UnitId) >= caps[entity.UnitId]) return false;
        entities.Add(entity.EntityId, entity); return true;
    }
    public bool TryBindHealth(ulong entityId, float maximum) => entities.ContainsKey(entityId) && health.TryAdd(entityId, new VehicleHealthState(maximum));
    public bool TryBindPart(VehiclePartState part)
    {
        part.Validate();
        if (!entities.TryGetValue(part.VehicleId, out var vehicle) || vehicle.Generation != part.VehicleGeneration) return false;
        if (!parts.TryGetValue(part.VehicleId, out var rows)) parts[part.VehicleId] = rows = new(StringComparer.Ordinal);
        if (rows.ContainsKey(part.PartId) || rows.Count >= 32) return false;
        rows.Add(part.PartId, part); return true;
    }
    public IReadOnlyList<VehiclePartState> Parts(ulong entityId) =>
        parts.TryGetValue(entityId, out var rows) ? rows.Values.OrderBy(x => x.PartId).ToArray() : Array.Empty<VehiclePartState>();
    public bool TrySetPassenger(ulong entityId, uint generation, string partId, string? passenger)
    {
        if (!entities.TryGetValue(entityId, out var vehicle) || vehicle.Generation != generation ||
            !parts.TryGetValue(entityId, out var rows) || !rows.TryGetValue(partId, out var part) ||
            (passenger != null && !Guid.TryParseExact(passenger, "N", out _))) return false;
        rows[partId] = part with { PassengerPlayerId = passenger }; return true;
    }
    public bool TryDamagePart(ulong entityId, uint generation, string partId, float amount, out bool destroyed)
    {
        destroyed = false;
        if (!entities.TryGetValue(entityId, out var vehicle) || vehicle.Generation != generation ||
            !parts.TryGetValue(entityId, out var rows) || !rows.TryGetValue(partId, out var part)) return false;
        if (!float.IsFinite(amount) || amount <= 0 || amount > 10_000_000) throw new InvalidDataException("Invalid vehicle part damage.");
        var health = Math.Max(0, part.Health - amount); destroyed = health <= 0;
        rows[partId] = part with { Health = health, PassengerPlayerId = destroyed ? null : part.PassengerPlayerId }; return true;
    }
    public bool TryDamage(ulong entityId, float amount, out float applied, out bool destroyed)
    {
        applied = 0; destroyed = false;
        if (!health.TryGetValue(entityId, out var state)) return false;
        applied = state.ApplyDamage(amount); destroyed = state.Destroyed; return true;
    }
    public bool TryHeal(ulong entityId,float amount,out float applied)
    {
        applied=0;
        if(!health.TryGetValue(entityId,out var state))return false;
        applied=state.ApplyHeal(amount);return true;
    }
    public bool TryGetHealth(ulong entityId, out VehicleHealthState? state) => health.TryGetValue(entityId, out state);
    public bool TryDestroy(ulong entityId, uint generation)
    {
        var removed = entities.TryGetValue(entityId, out var entity) && entity.Generation == generation && entities.Remove(entityId);
        if (removed) { attacks.Remove(entityId); health.Remove(entityId); parts.Remove(entityId); }
        return removed;
    }
    public bool TryBindAttack(ulong entityId, ArmyVehicleShotStats definition,
        float cadenceSeconds=1f/MatchManifest.TickRate,Func<float>? random = null)
    {
        if (!entities.ContainsKey(entityId) || attacks.ContainsKey(entityId)) return false;
        attacks.Add(entityId, new VehicleAttackState(definition,cadenceSeconds,random));
        return true;
    }
    public bool TryBeginAttack(ulong entityId, bool eligible, int windupTicks) =>
        attacks.TryGetValue(entityId, out var attack) && attack.TryBegin(eligible, windupTicks);
    public bool AdvanceAttack(ulong entityId) => attacks.TryGetValue(entityId, out var attack) && attack.AdvanceTick();
    public bool BeginInitialAttackCooldown(ulong entityId) =>
        attacks.TryGetValue(entityId,out var attack)&&attack.BeginInitialCooldown();
    internal bool ResetAttack(ulong entityId)
    {if(!attacks.TryGetValue(entityId,out var attack))return false;attack.DisableAndReset();return true;}
    public bool TryCommitAttack(ulong entityId) => attacks.TryGetValue(entityId, out var attack) && attack.CommitShot();
    public bool TryGetAttack(ulong entityId, out VehicleAttackState? attack) => attacks.TryGetValue(entityId, out attack);
    public int RemoveOwner(string ownerPlayerId)
    {
        if (!Guid.TryParseExact(ownerPlayerId, "N", out _)) return 0;
        var ids = entities.Values.Where(x => x.OwnerPlayerId == ownerPlayerId).Select(x => x.EntityId).ToArray();
        foreach (var id in ids) { entities.Remove(id); attacks.Remove(id); health.Remove(id); parts.Remove(id); }
        return ids.Length;
    }
}
