namespace War.BattleServer;

public sealed record BattleInteractable(int EntityId, BattleObjectiveKind ObjectiveKind, int RequiredAmount);

/// <summary>Match-owned interactable identity map. Only registered source entities
/// can advance objectives; event IDs remain idempotent in the objective state.</summary>
public sealed class BattleInteractableRegistry
{
    private const int MaximumEventReceipts = 4096;
    private readonly Dictionary<int, BattleInteractable> entries = new();
    private readonly Dictionary<string, (int EntityId, string PlayerId, int Amount)> eventReceipts =
        new(StringComparer.Ordinal);
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
        // Skill-shot assignments read a selected ScoreManager flag, not an interactable event.
        if (interactable.EntityId <= 0 || interactable.RequiredAmount is < 1 or > 1000 ||
            interactable.ObjectiveKind == BattleObjectiveKind.GainSkillshots ||
            !Enum.IsDefined(interactable.ObjectiveKind) || entries.Count >= capacity ||
            !entries.TryAdd(interactable.EntityId, interactable)) return false;
        return true;
    }
    public bool TryRecord(string eventId, int entityId, string playerId, BattleObjectiveState state, int amount)
    {
        return TryRecord(eventId, entityId, playerId, state, amount, out _);
    }

    public bool IsReplay(string eventId, int entityId, string playerId, int amount)
    {
        if (!Guid.TryParseExact(eventId, "N", out _) ||
            eventId != eventId.ToLowerInvariant())
        {
            return false;
        }

        if (!eventReceipts.TryGetValue(eventId, out var previous))
        {
            return false;
        }

        if (previous.EntityId != entityId || previous.PlayerId != playerId ||
            previous.Amount != amount)
        {
            throw new InvalidDataException("Objective event replay changed its authority.");
        }

        return true;
    }

    public bool TryRecord(string eventId, int entityId, string playerId,
        BattleObjectiveState state, int amount, out bool applied)
    {
        applied = false;
        if (IsReplay(eventId, entityId, playerId, amount))
        {
            return true;
        }

        if (!entries.TryGetValue(entityId, out var interactable) ||
            !Guid.TryParseExact(playerId, "N", out _) ||
            playerId != playerId.ToLowerInvariant() || state is null ||
            !Guid.TryParseExact(eventId, "N", out _) ||
            eventId != eventId.ToLowerInvariant() ||
            eventReceipts.Count >= MaximumEventReceipts) return false;
        if (amount < 1 || amount > interactable.RequiredAmount) return false;
        state.RecordEvent(eventId, interactable.ObjectiveKind, amount);
        eventReceipts.Add(eventId, (entityId, playerId, amount));
        applied = true;
        return true;
    }
    public IReadOnlyCollection<BattleInteractable> Snapshot() => entries.Values.OrderBy(x => x.EntityId).ToArray();
    public bool Remove(int entityId) => entries.Remove(entityId);
}
