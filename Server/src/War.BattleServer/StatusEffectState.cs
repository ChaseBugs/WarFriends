namespace War.BattleServer;

public sealed class StatusEffectState
{
    private readonly Dictionary<string,(ulong Expiry,int Stacks)> active=new(StringComparer.Ordinal);
    private readonly HashSet<string> immune=new(StringComparer.Ordinal);
    public int Count => active.Count;
    public IReadOnlyDictionary<string,(ulong Expiry,int Stacks)> Snapshot =>
        new Dictionary<string,(ulong Expiry,int Stacks)>(active,StringComparer.Ordinal);
    public void SetImmune(string effect,bool value){if(!Guid.TryParseExact(effect,"N",out _))throw new InvalidDataException("Invalid status effect.");if(value)immune.Add(effect);else immune.Remove(effect);}
    public bool Apply(string effect,ulong tick,float durationSeconds,bool stackable)
    {
        if(!Guid.TryParseExact(effect,"N",out _)||tick>10_000_000||!float.IsFinite(durationSeconds)||durationSeconds<=0||durationSeconds>600||immune.Contains(effect))return false;
        ulong expiry=checked(tick+(ulong)Math.Ceiling(durationSeconds*MatchManifest.TickRate));
        if(active.TryGetValue(effect,out var prior)&&prior.Expiry>tick){if(!stackable)return false;active[effect]=(Math.Max(prior.Expiry,expiry),Math.Min(16,prior.Stacks+1));}
        else active[effect]=(expiry,1);
        return true;
    }
    public bool Active(string effect,ulong tick)=>active.TryGetValue(effect,out var value)&&value.Expiry>tick;
    public int Expire(ulong tick)
    {
        if (tick > 10_000_000) throw new InvalidDataException("Invalid status tick.");
        var expired=active.Where(x=>x.Value.Expiry<=tick).Select(x=>x.Key).ToArray();
        foreach(var effect in expired) active.Remove(effect);
        return expired.Length;
    }
}
