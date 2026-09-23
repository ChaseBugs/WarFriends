namespace War.BattleServer;

public sealed record BattleResultHandoff(string MatchId,string ManifestHash,BattleStatistics Statistics,bool Scored);

public static class BattleResultHandoffValidator
{
    public static void Validate(BattleResultHandoff handoff)
    {
        if(handoff==null||!System.Text.RegularExpressions.Regex.IsMatch(handoff.MatchId??"",@"\A[a-zA-Z0-9_-]{1,64}\z")||
           !System.Text.RegularExpressions.Regex.IsMatch(handoff.ManifestHash??"",@"\A[0-9a-f]{64}\z"))
            throw new InvalidDataException("Invalid battle result handoff identity.");
        BattleStatisticsValidator.Validate(handoff.Statistics);
    }
}
