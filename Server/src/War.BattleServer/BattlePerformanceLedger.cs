namespace War.BattleServer;

public sealed class BattlePerformanceLedger
{
    private readonly int capacity;
    private readonly HashSet<string> cards = new();
    private readonly HashSet<string> objectives = new();
    public ulong StartTick { get; private set; }
    public ulong EndTick { get; private set; }
    public int CardActivations => cards.Count;
    public int ObjectiveCredits => objectives.Count;
    public BattlePerformanceLedger(int capacity = 4096)
    {
        if (capacity is < 1 or > 1_000_000) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }

    public void Start(ulong tick)
    {
        if (StartTick != 0 || tick > 10_000_000) throw new InvalidDataException("Invalid battle start tick.");
        StartTick = tick;
    }
    public void End(ulong tick)
    {
        if (StartTick == 0 || EndTick != 0 || tick < StartTick || tick > 10_000_000)
            throw new InvalidDataException("Invalid battle end tick.");
        EndTick = tick;
    }
    public bool RecordCard(string eventId) => Record(cards, eventId);
    public bool RecordObjective(string eventId) => Record(objectives, eventId);
    public ulong DurationTicks => EndTick == 0 ? 0 : EndTick - StartTick;

    private bool Record(HashSet<string> set, string eventId)
    {
        if (!Guid.TryParseExact(eventId, "N", out _)) throw new InvalidDataException("Invalid performance event ID.");
        if (set.Contains(eventId)) return false;
        if (cards.Count + objectives.Count >= capacity) throw new InvalidDataException("Performance ledger capacity exceeded.");
        return set.Add(eventId);
    }
}
