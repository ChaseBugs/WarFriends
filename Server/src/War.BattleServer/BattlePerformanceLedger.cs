namespace War.BattleServer;

public sealed class BattlePerformanceLedger
{
    public sealed record CardUsage(string OwnerPlayerId,string CardId,int Count);
    private readonly int capacity;
    private readonly Dictionary<string,(string OwnerPlayerId,string CardId)> cards = new(StringComparer.Ordinal);
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
    public bool RecordCard(string eventId,string ownerPlayerId) => RecordCard(eventId,ownerPlayerId,"");
    public bool RecordCard(string eventId,string ownerPlayerId,string cardId)
    {
        if(ownerPlayerId.Length!=0 && !Guid.TryParseExact(ownerPlayerId,"N",out _))
            throw new InvalidDataException("Invalid card activation owner.");
        if(cardId.Length!=0 && (ownerPlayerId.Length==0 || !WarCardEffectCatalog.TryGet(cardId,out _)))
            throw new InvalidDataException("Invalid card activation identity.");
        if(!Guid.TryParseExact(eventId,"N",out _))
            throw new InvalidDataException("Invalid performance event ID.");
        if(cards.TryGetValue(eventId,out var existing))
        {
            if(existing.OwnerPlayerId!=ownerPlayerId || existing.CardId!=cardId)
                throw new InvalidDataException("Card activation owner or identity changed on replay.");
            return false;
        }
        if(cards.Count+objectives.Count>=capacity)throw new InvalidDataException("Performance ledger capacity exceeded.");
        cards.Add(eventId,(ownerPlayerId,cardId));
        return true;
    }
    public int CardActivationsFor(string ownerPlayerId)
    {
        if(!Guid.TryParseExact(ownerPlayerId,"N",out _))throw new InvalidDataException("Invalid card activation owner.");
        return cards.Values.Count(row=>row.OwnerPlayerId==ownerPlayerId);
    }
    public IReadOnlyList<CardUsage> CardUsageSnapshot() => cards.Values
        .Where(row=>row.OwnerPlayerId.Length!=0 && row.CardId.Length!=0)
        .GroupBy(row=>row)
        .Select(group=>new CardUsage(group.Key.OwnerPlayerId,group.Key.CardId,group.Count()))
        .OrderBy(row=>row.OwnerPlayerId,StringComparer.Ordinal)
        .ThenBy(row=>row.CardId,StringComparer.Ordinal).ToArray();
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
