namespace War.BattleServer;

public sealed record WarArenaSnapshot(string EventId,string PlayerId,int Wins,int Lives,bool Flawless,ulong Revision);

public static class WarArenaSnapshotValidator
{
    public static void Validate(WarArenaSnapshot snapshot)
    {
        if(snapshot==null||!System.Text.RegularExpressions.Regex.IsMatch(snapshot.EventId??"",@"\Aarena-[0-9]{6,16}\z")||
           !Guid.TryParseExact(snapshot.PlayerId,"N",out _)||snapshot.Wins<0||snapshot.Wins>1_000_000||
           snapshot.Lives<0||snapshot.Lives>100||snapshot.Revision==0)
            throw new InvalidDataException("Invalid Arena snapshot.");
    }
}
