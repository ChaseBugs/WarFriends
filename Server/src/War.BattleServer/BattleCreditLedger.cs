namespace War.BattleServer;

public sealed class BattleCreditLedger
{
    private readonly HashSet<string> hits=[];
    private readonly HashSet<string> kills=[];
    public uint HitCount { get; private set; }
    public uint KillCount { get; private set; }
    public int Count => hits.Count + kills.Count;
    public bool HasHit(string eventId) => hits.Contains(eventId);
    public bool HasKill(string eventId) => kills.Contains(eventId);
    public bool RecordHit(string eventId)
    {
        Validate(eventId);
        if(!hits.Add(eventId))return false;
        HitCount=checked(HitCount+1);return true;
    }
    public bool RecordKill(string eventId)
    {
        Validate(eventId);
        if(!kills.Add(eventId))return false;
        KillCount=checked(KillCount+1);return true;
    }
    private static void Validate(string id)
    { if(!Guid.TryParseExact(id,"N",out _))throw new InvalidDataException("Invalid battle credit event ID."); }
}
