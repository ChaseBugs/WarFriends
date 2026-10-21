namespace War.BattleServer;

public sealed class WarArenaPolicy
{
    private const int MaximumActiveBattles = 10000;
    private readonly string eventId;
    private readonly HashSet<string> active=[];
    public WarArenaPolicy(string eventId)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(eventId??"",@"\Aarena-[0-9]{6,16}\z"))
            throw new InvalidDataException("Invalid server Arena event identity.");
        this.eventId=eventId!;
    }
    public string EventId=>eventId;
    public bool TryEnter(string playerId)
    {
        if(!War.Shared.CanonicalGuid.IsCanonical(playerId))return false;
        if (active.Count >= MaximumActiveBattles) return false;
        return active.Add(playerId);
    }
    public bool Leave(string playerId)=>active.Remove(playerId);
    public bool IsActive(string playerId)=>active.Contains(playerId);
    public int ActiveCount=>active.Count;
}
