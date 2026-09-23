using System.Numerics;

namespace War.BattleServer;

public sealed record ActiveWarCardEffect(string EffectId, string OwnerPlayerId,
    WarCardEffectDefinition Definition, Vector3 Target, ulong StartedTick, WarCardEffectLease Lease);

/// <summary>Authoritative runtime effect collection. Requests must be validated
/// before a lease is created; effect IDs make retries idempotent.</summary>
public sealed class WarCardEffectRuntime
{
    private readonly int capacity;
    private readonly Dictionary<string, ActiveWarCardEffect> active = new(StringComparer.Ordinal);
    private readonly WarCardEffectStack stack = new();
    public WarCardEffectRuntime(int capacity = 128)
    {
        if (capacity is < 1 or > 2048) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public int Count => active.Count;
    public IReadOnlyCollection<ActiveWarCardEffect> Snapshot() => active.Values.OrderBy(x => x.EffectId).ToArray();
    public bool TryGet(string effectId, out ActiveWarCardEffect? effect) => active.TryGetValue(effectId, out effect);
    public IReadOnlyList<ActiveWarCardEffect> ActiveForOwner(string ownerPlayerId) =>
        active.Values.Where(x => x.OwnerPlayerId == ownerPlayerId).OrderBy(x => x.EffectId).ToArray();
    public bool HasActiveKind(string ownerPlayerId, WarCardEffectKind kind) =>
        active.Values.Any(x => x.OwnerPlayerId == ownerPlayerId && x.Definition.Kind == kind);

    public bool TryApply(string effectId, string ownerPlayerId, WarCardEffectRequest request, ulong tick)
    {
        if (string.IsNullOrWhiteSpace(effectId) || effectId.Length > 64 || active.ContainsKey(effectId) ||
            !Guid.TryParseExact(ownerPlayerId, "N", out _) || active.Count >= capacity || tick > 10_000_000)
            return false;
        var definition = WarCardEffectRequestValidator.Validate(request);
        if (!stack.TryApply(definition.CardId, stackable: definition.Kind is WarCardEffectKind.Status or WarCardEffectKind.Modifier)) return false;
        active.Add(effectId, new ActiveWarCardEffect(effectId, ownerPlayerId, definition,
            request.Target, tick, new WarCardEffectLease(tick, request.DurationSeconds)));
        return true;
    }

    public int Expire(ulong tick)
    {
        var expired = active.Values.Where(x => !x.Lease.ActiveAt(tick)).Select(x => x.EffectId).ToArray();
        foreach (var id in expired) active.Remove(id);
        return expired.Length;
    }

    public IReadOnlyList<ActiveWarCardEffect> ExpireAndReturn(ulong tick)
    {
        var expired = active.Values.Where(x => !x.Lease.ActiveAt(tick)).OrderBy(x => x.EffectId).ToArray();
        foreach (var effect in expired) active.Remove(effect.EffectId);
        return expired;
    }

    public int RemoveOwner(string ownerPlayerId)
    {
        var ids = active.Values.Where(x => x.OwnerPlayerId == ownerPlayerId).Select(x => x.EffectId).ToArray();
        foreach (var id in ids) active.Remove(id);
        return ids.Length;
    }
}
