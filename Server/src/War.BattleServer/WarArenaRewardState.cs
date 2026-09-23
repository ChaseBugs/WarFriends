namespace War.BattleServer;

public sealed class WarArenaRewardState
{
    private readonly HashSet<string> claims=[];
    public bool TryClaim(string claimId,bool won,int gold)
    {
        if(!Guid.TryParseExact(claimId,"N",out _)||gold<0||gold>1_000_000||claims.Contains(claimId))return false;
        if(!won&&gold!=0)return false;
        claims.Add(claimId);return true;
    }
    public bool IsClaimed(string claimId)=>claims.Contains(claimId);
}
