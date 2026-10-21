namespace War.BattleServer;

/// <summary>Tracks bounded objective progress and exact event replays for one player.</summary>
public sealed class BattleObjectiveState
{
    private const int MaximumEvents = 4096;
    private const int MaximumEventAmount = 1000;
    private const int MaximumTarget = 100000;

    private readonly Dictionary<BattleObjectiveKind, int> progress = new();
    private readonly Dictionary<string, (BattleObjectiveKind Kind, int Amount, int Result)> events =
        new(StringComparer.Ordinal);
    private readonly IReadOnlyDictionary<BattleObjectiveKind, int> targets;

    /// <summary>Creates the match-owned progress lanes from validated targets.</summary>
    public BattleObjectiveState(IReadOnlyDictionary<BattleObjectiveKind, int> targets)
    {
        if (targets == null || targets.Count == 0 || targets.Any(target =>
            !Enum.IsDefined(target.Key) || target.Value is < 1 or > MaximumTarget))
        {
            throw new InvalidDataException("Invalid battle objective targets.");
        }

        this.targets = new Dictionary<BattleObjectiveKind, int>(targets);
        foreach (BattleObjectiveKind kind in targets.Keys)
        {
            progress.Add(kind, 0);
        }
    }

    /// <summary>Applies one trusted progress increment up to its target.</summary>
    public int Record(BattleObjectiveKind kind, int amount)
    {
        if (amount is < 1 or > MaximumEventAmount || !targets.TryGetValue(kind, out int target))
        {
            throw new InvalidDataException("Invalid objective event.");
        }

        int next = Math.Min(target, checked(progress[kind] + amount));
        progress[kind] = next;
        return next;
    }

    /// <summary>Applies an event once and returns its original result on replay.</summary>
    public int RecordEvent(string eventId, BattleObjectiveKind kind, int amount)
    {
        if (!War.Shared.CanonicalGuid.IsCanonical(eventId))
        {
            throw new InvalidDataException("Invalid objective event ID.");
        }

        if (events.TryGetValue(eventId, out var previous))
        {
            if (previous.Kind != kind || previous.Amount != amount)
            {
                throw new InvalidDataException("Objective event replay changed its kind or amount.");
            }

            return previous.Result;
        }

        if (events.Count >= MaximumEvents)
        {
            throw new InvalidDataException("Objective event capacity exhausted.");
        }

        int value = Record(kind, amount);
        events.Add(eventId, (kind, amount, value));
        return value;
    }

    public bool Complete(BattleObjectiveKind kind)
    {
        return targets.TryGetValue(kind, out int target) && progress[kind] >= target;
    }

    public int Progress(BattleObjectiveKind kind) => progress.GetValueOrDefault(kind);

    public IReadOnlyDictionary<BattleObjectiveKind, int> ProgressSnapshot() =>
        new Dictionary<BattleObjectiveKind, int>(progress);

    public IReadOnlyDictionary<BattleObjectiveKind, int> TargetSnapshot() =>
        new Dictionary<BattleObjectiveKind, int>(targets);
}
