namespace War.BattleServer;

public sealed class WarCardEffectStack
{
    private readonly Dictionary<string,int> counts=new(StringComparer.Ordinal);
    public bool TryApply(string cardId,bool stackable)
    {
        if(string.IsNullOrWhiteSpace(cardId)||!WarCardEffectCatalog.TryGet(cardId,out _))return false;
        int count=counts.GetValueOrDefault(cardId);
        if(!stackable&&count>0)return false;
        if(count>=16)return false;
        counts[cardId]=count+1;return true;
    }
    public int Count(string cardId)=>counts.GetValueOrDefault(cardId);
}
