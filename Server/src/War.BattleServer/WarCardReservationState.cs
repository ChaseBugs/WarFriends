namespace War.BattleServer;

public sealed class WarCardReservationState
{
    private readonly Dictionary<string,int> counts=new(StringComparer.Ordinal);
    private readonly Dictionary<string,string> reservations=new(StringComparer.Ordinal);
    public WarCardReservationState(IEnumerable<(string CardId,int Count)> inventory)
    {
        foreach(var (id,count) in inventory??throw new ArgumentNullException(nameof(inventory)))
        {
            if(string.IsNullOrWhiteSpace(id)||count<0||!counts.TryAdd(id,count))
                throw new InvalidDataException("Invalid authoritative card inventory.");
        }
    }
    public bool TryReserve(string requestId,string cardId)
    {
        if(!Guid.TryParseExact(requestId,"N",out _)||string.IsNullOrWhiteSpace(cardId)||
           reservations.ContainsKey(requestId))return false;
        if(!counts.TryGetValue(cardId,out int available)||available<1)return false;
        counts[cardId]=available-1;reservations.Add(requestId,cardId);return true;
    }
    public bool IsReserved(string requestId)=>reservations.ContainsKey(requestId);
    public bool TryRelease(string requestId)
    {
        if (!reservations.Remove(requestId, out var cardId)) return false;
        counts[cardId] = checked(counts[cardId] + 1); return true;
    }
    public int Remaining(string cardId)=>counts.GetValueOrDefault(cardId);
}
