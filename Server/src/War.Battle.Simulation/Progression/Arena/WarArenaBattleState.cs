namespace War.BattleServer;

public sealed class WarArenaBattleState
{
    private const int MaximumSettlements = 256;
    private readonly int maxLives;
    private readonly Dictionary<string,bool> settlements=[];
    public int Lives { get; private set; }
    public int Wins { get; private set; }
    public bool Terminal { get; private set; }
    public WarArenaBattleState(int startingLives)
    {
        if(startingLives is <1 or >100)throw new InvalidDataException("Invalid Arena lives.");
        maxLives=startingLives;Lives=startingLives;
    }
    public bool Settle(string settlementId,bool won)
    {
        if(!War.Shared.CanonicalGuid.IsCanonical(settlementId)||Terminal||settlements.ContainsKey(settlementId)||settlements.Count>=MaximumSettlements)return false;
        settlements.Add(settlementId,won);
        if(won)Wins=checked(Wins+1);else Lives--;
        if(Lives==0||won)Terminal=true;
        return true;
    }
    public bool TryGetSettlement(string settlementId, out bool won)
        => settlements.TryGetValue(settlementId ?? "", out won);
    public void Validate(){
        if(Lives<0||Lives>maxLives||Wins<0||Wins>settlements.Count||settlements.Count>MaximumSettlements||
           (!Terminal&&Lives==0)||settlements.Values.Count(x=>!x)+Lives!=maxLives)
            throw new InvalidDataException("Invalid Arena state.");
    }
}
