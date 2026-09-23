namespace War.BattleServer;

public sealed record BattleInteractable(int EntityId, BattleObjectiveKind ObjectiveKind, int RequiredAmount);

/// <summary>Match-owned interactable identity map. Only registered source entities
/// can advance objectives; event IDs remain idempotent in the objective state.</summary>
public sealed class BattleInteractableRegistry
{
    private readonly Dictionary<int, BattleInteractable> entries = new();
    private readonly int capacity;
    public BattleInteractableRegistry(int capacity = 512)
    {
        if (capacity is < 1 or > 4096) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public int Count => entries.Count;
    public bool TryRegister(BattleInteractable interactable)
    {
        ArgumentNullException.ThrowIfNull(interactable);
        if (interactable.EntityId <= 0 || interactable.RequiredAmount is < 1 or > 1000 ||
            !Enum.IsDefined(interactable.ObjectiveKind) || entries.Count >= capacity ||
            !entries.TryAdd(interactable.EntityId, interactable)) return false;
        return true;
    }
    public bool TryRecord(string eventId, int entityId, string playerId, BattleObjectiveState state, int amount)
    {
        if (!entries.TryGetValue(entityId, out var interactable) ||
            !Guid.TryParseExact(playerId, "N", out _) || state is null) return false;
        if (amount < 1 || amount > interactable.RequiredAmount) return false;
        state.RecordEvent(eventId, interactable.ObjectiveKind, amount);
        return true;
    }
    public IReadOnlyCollection<BattleInteractable> Snapshot() => entries.Values.OrderBy(x => x.EntityId).ToArray();
    public bool Remove(int entityId) => entries.Remove(entityId);
}
