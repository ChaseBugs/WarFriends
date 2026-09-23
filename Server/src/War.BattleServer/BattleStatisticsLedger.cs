namespace War.BattleServer;

/// <summary>Match-owned statistics accumulator. Each transition has a stable
/// source event ID, so retransmission cannot inflate terminal results.</summary>
public sealed class BattleStatisticsLedger
{
    private readonly int capacity;
    private readonly BattleCreditLedger credits = new();
    private readonly HashSet<string> spawns = new();
    private readonly HashSet<string> losses = new();
    public BattleStatisticsLedger(int capacity = 100_000)
    {
        if (capacity is < 1 or > 1_000_000) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }
    public BattleStatistics Snapshot => new(credits.HitCount, credits.KillCount,
        checked((uint)spawns.Count), checked((uint)losses.Count));

    public bool RecordHit(string eventId)
    {
        Validate(eventId); if (credits.HasHit(eventId)) return false; EnsureCapacity(); return credits.RecordHit(eventId);
    }
    public bool RecordKill(string eventId)
    {
        Validate(eventId); if (credits.HasKill(eventId)) return false; EnsureCapacity(); return credits.RecordKill(eventId);
    }
    public bool RecordArmySpawn(string eventId) => Record(spawns, eventId);
    public bool RecordArmyLoss(string eventId)
    {
        Validate(eventId);
        if (losses.Contains(eventId)) return false;
        if (!spawns.Contains(eventId)) throw new InvalidDataException("Army loss has no source spawn transition.");
        EnsureCapacity();
        losses.Add(eventId); return true;
    }
    public void ValidateTerminal() => BattleStatisticsValidator.Validate(Snapshot);

    private bool Record(HashSet<string> set, string eventId)
    {
        Validate(eventId); if (set.Contains(eventId)) return false;
        EnsureCapacity();
        return set.Add(eventId);
    }
    private void EnsureCapacity()
    {
        if (credits.Count + spawns.Count + losses.Count >= capacity)
            throw new InvalidDataException("Statistics ledger capacity exceeded.");
    }
    private static void Validate(string eventId)
    {
        if (!Guid.TryParseExact(eventId, "N", out _)) throw new InvalidDataException("Invalid statistics event ID.");
    }
}
