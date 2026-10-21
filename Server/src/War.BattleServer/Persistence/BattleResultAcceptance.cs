namespace War.BattleServer;

public sealed class BattleResultAcceptance
{
    private readonly Dictionary<string,string> accepted=new(StringComparer.Ordinal);
    private readonly int capacity;
    public BattleResultAcceptance(int capacity=100_000){if(capacity<1||capacity>1_000_000)throw new InvalidDataException("Invalid result acceptance capacity.");this.capacity=capacity;}
    public bool Accept(BattleResultHandoff handoff,string digest)
    {
        BattleResultHandoffValidator.Validate(handoff);
        if(!System.Text.RegularExpressions.Regex.IsMatch(digest??"",@"\A[0-9a-f]{64}\z"))return false;
        string matchId=handoff.MatchId??throw new InvalidDataException("Missing battle result identity.");
        if(accepted.TryGetValue(matchId,out var existing))return existing==digest;
        if(accepted.Count>=capacity)return false;
        accepted[matchId]=digest!;return true;
    }
}
