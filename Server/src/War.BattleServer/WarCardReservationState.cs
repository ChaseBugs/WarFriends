namespace War.BattleServer;

public sealed class WarCardReservationState
{
    private sealed record Reservation(string OwnerPlayerId,string CardId);
    private readonly Dictionary<(string OwnerPlayerId,string CardId),int> counts=[];
    private readonly Dictionary<(string OwnerPlayerId,string RequestId),Reservation> reservations=[];
    public WarCardReservationState(IEnumerable<(string OwnerPlayerId,string CardId,int Count)> inventory)
    {
        foreach(var (owner,id,count) in inventory??throw new ArgumentNullException(nameof(inventory)))
        {
            if(!Guid.TryParseExact(owner,"N",out _)||owner!=owner.ToLowerInvariant()||
               string.IsNullOrWhiteSpace(id)||id.Length>128||id.Any(char.IsControl)||count<0||
               !counts.TryAdd((owner,id),count))
                throw new InvalidDataException("Invalid authoritative card inventory.");
        }
    }
    public bool TryReserve(string requestId,string ownerPlayerId,string cardId)
    {
        var request=(ownerPlayerId,requestId);var inventory=(ownerPlayerId,cardId);
        if(!Guid.TryParseExact(requestId,"N",out _)||!Guid.TryParseExact(ownerPlayerId,"N",out _)||
           ownerPlayerId!=ownerPlayerId.ToLowerInvariant()||string.IsNullOrWhiteSpace(cardId)||
           reservations.ContainsKey(request))return false;
        if(!counts.TryGetValue(inventory,out int available)||available<1)return false;
        counts[inventory]=available-1;reservations.Add(request,new(ownerPlayerId,cardId));return true;
    }
    public bool IsReserved(string requestId,string ownerPlayerId)=>reservations.ContainsKey((ownerPlayerId,requestId));
    public bool TryRelease(string requestId,string ownerPlayerId)
    {
        if (!reservations.Remove((ownerPlayerId,requestId), out var row)) return false;
        var key=(row.OwnerPlayerId,row.CardId);
        counts[key] = checked(counts[key] + 1); return true;
    }
    public int Remaining(string ownerPlayerId,string cardId)=>counts.GetValueOrDefault((ownerPlayerId,cardId));
}
