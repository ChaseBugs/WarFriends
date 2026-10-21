namespace War.BattleServer;

public static class WarArenaSnapshotValidator
{
    public static void Validate(WarArenaSnapshot snapshot)
    {
        if(snapshot==null||!System.Text.RegularExpressions.Regex.IsMatch(snapshot.EventId??"",@"\Aarena-[0-9]{6,16}\z")||
           !War.Shared.CanonicalGuid.IsCanonical(snapshot.PlayerId)||snapshot.Wins<0||snapshot.Wins>1_000_000||
           snapshot.Lives<0||snapshot.Lives>100||snapshot.Revision==0)
            throw new InvalidDataException("Invalid Arena snapshot.");
    }
}
