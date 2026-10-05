namespace War.BattleServer;

public sealed class BattlePerformanceLedger
{
    private readonly int capacity;
    private readonly Dictionary<string,string> cards = new(StringComparer.Ordinal);
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
    public bool RecordCard(string eventId) => RecordCard(eventId,"");
    public bool RecordCard(string eventId,string ownerPlayerId)
    {
        if(ownerPlayerId.Length!=0 && !Guid.TryParseExact(ownerPlayerId,"N",out _))
            throw new InvalidDataException("Invalid card activation owner.");
        if(!Guid.TryParseExact(eventId,"N",out _))
            throw new InvalidDataException("Invalid performance event ID.");
        if(cards.TryGetValue(eventId,out var owner))
        {
            if(owner!=ownerPlayerId)throw new InvalidDataException("Card activation owner changed on replay.");
            return false;
        }
        if(cards.Count+objectives.Count>=capacity)throw new InvalidDataException("Performance ledger capacity exceeded.");
        cards.Add(eventId,ownerPlayerId);
        return true;
    }
    public int CardActivationsFor(string ownerPlayerId)
    {
        if(!Guid.TryParseExact(ownerPlayerId,"N",out _))throw new InvalidDataException("Invalid card activation owner.");
        return cards.Values.Count(owner=>owner==ownerPlayerId);
    }
    public bool CanRecordCard(string eventId)
    {
        if(!Guid.TryParseExact(eventId,"N",out _))return false;
        return !cards.ContainsKey(eventId)&&cards.Count+objectives.Count<capacity;
    }
    internal bool TryRollbackCard(string eventId)=>cards.Remove(eventId);
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
