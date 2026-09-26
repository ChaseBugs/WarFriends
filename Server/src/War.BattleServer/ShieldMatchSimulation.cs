namespace War.BattleServer;

internal sealed record ShieldMutation(int CoverIndex,int OwnerFraction,float Health,float MaxHealth,
    bool Destroyed,ulong Revision);

// Eight source-bound cover shields; only a complete trusted two-rank allocation
// can construct this state. Unknown dynamic map owners stay collidable.
internal sealed class ShieldMatchSimulation
{
    private sealed class Entry(CoverNode cover,ShieldLifecycle lifecycle)
    {
        internal CoverNode Cover=cover;
        internal ShieldLifecycle Lifecycle=lifecycle;
        internal ulong Revision;
        internal ShieldMutation Snapshot()=>new(Cover.SourceIndex,Cover.Fraction,Lifecycle.Health,
            Lifecycle.MaxHealth,Lifecycle.Destroyed,Revision);
    }
    private readonly Entry[] entries;
    private readonly Dictionary<string,Entry> byOwner;
    private readonly ShieldSourceCatalog policy;
    private ulong lastTick;
    internal IReadOnlyList<ShieldMutation> Snapshot()=>Array.AsReadOnly(entries.Select(e=>e.Snapshot()).ToArray());
    internal ShieldMatchSimulation(RecoveredBattleMap map,ShieldSourceCatalog policy,MatchManifest manifest)
    {
        if(map==null || policy==null || manifest.Players.Length!=2 ||
            manifest.Players.Any(p=>!p.ShieldLevel.HasValue) ||
            manifest.Players.Select(p=>p.Fraction).Order().SequenceEqual(new[]{1,2})==false)
            throw new InvalidDataException("Shield simulation requires complete trusted allocation.");
        this.policy=policy;
        entries=map.Covers.Select(c=>new Entry(c,new ShieldLifecycle(policy,
            manifest.Players.Single(p=>p.Fraction==c.Fraction).ShieldLevel!.Value,0))).ToArray();
        byOwner=entries.ToDictionary(e=>e.Cover.SourcePath+"/riot_shield",StringComparer.Ordinal);
        if(entries.Length!=8 || byOwner.Count!=8)throw new InvalidDataException("Incomplete shield cover identity.");
    }
    internal bool ColliderEnabled(string dynamicOwner)=>!byOwner.TryGetValue(dynamicOwner,out var row) || row.Lifecycle.ColliderEnabled;
    internal bool IsLiveShield(string dynamicOwner)=>byOwner.TryGetValue(dynamicOwner,out var row) && !row.Lifecycle.Destroyed;
    internal bool IsLiveEnemyShield(string dynamicOwner,int shooterFraction)
    {
        if(shooterFraction is not (1 or 2))throw new InvalidDataException("Invalid shield shooter fraction.");
        return byOwner.TryGetValue(dynamicOwner,out var row) &&
            row.Cover.Fraction!=shooterFraction && !row.Lifecycle.Destroyed;
    }
    internal ShieldMutation? ApplyShot(string dynamicOwner,int shooterFraction,string weaponId,float damage,ulong tick)
    {
        if(tick!=lastTick || shooterFraction is not (1 or 2))
            throw new InvalidDataException("Invalid shield impact authority.");
        if(!byOwner.TryGetValue(dynamicOwner,out var row))return null;
        if(row.Cover.Fraction==shooterFraction || row.Lifecycle.Destroyed)return null;
        float before=row.Lifecycle.Health;
        row.Lifecycle.ApplyShot(weaponId,damage,tick);
        if(row.Lifecycle.Health==before)return null;
        row.Revision++;
        return row.Snapshot();
    }
    internal ShieldMutation? ApplyUnitShot(string dynamicOwner,int shooterFraction,float damage,ulong tick)
    {
        if(tick!=lastTick || shooterFraction is not (1 or 2))
            throw new InvalidDataException("Invalid army shield impact authority.");
        if(!byOwner.TryGetValue(dynamicOwner,out var row) ||
           row.Cover.Fraction==shooterFraction || row.Lifecycle.Destroyed)return null;
        float before=row.Lifecycle.Health;
        row.Lifecycle.ApplyUnitShot(damage,tick);
        if(row.Lifecycle.Health==before)return null;
        row.Revision++;return row.Snapshot();
    }
    internal ShieldMutation? ApplyExplosion(string dynamicOwner,int shooterFraction,string weaponId,float damage,ulong tick)
    {
        if(tick!=lastTick||shooterFraction is not (1 or 2)||!float.IsFinite(damage)||damage<0)
            throw new InvalidDataException("Invalid shield explosion authority.");
        if(!byOwner.TryGetValue(dynamicOwner,out var row)||row.Lifecycle.Destroyed)return null;
        float multiplier=policy.ExplosionCoefficient*(row.Cover.Fraction==shooterFraction?policy.FriendDamageCoefficient:1);
        float before=row.Lifecycle.Health;
        row.Lifecycle.ApplyShot(weaponId,damage*multiplier,tick);
        if(row.Lifecycle.Health==before)return null;
        row.Revision++;return row.Snapshot();
    }
    internal IReadOnlyList<ShieldMutation> BeginOvertime(ulong tick)
    {
        if(tick!=lastTick)throw new InvalidDataException("Shield overtime requires the current host tick.");
        var changed=new List<ShieldMutation>();
        foreach(var row in entries)
            if(row.Lifecycle.BeginOvertime(tick,policy.DestroyInOvertime))
            {row.Revision++;changed.Add(row.Snapshot());}
        return changed.AsReadOnly();
    }
    internal IReadOnlyList<ShieldMutation> Advance(ulong tick)
    {
        if(tick<lastTick || tick-lastTick>120 || tick>10000000)
            throw new InvalidDataException("Invalid shield simulation tick.");
        var changes=new List<ShieldMutation>();
        while(lastTick<tick)
        {
            lastTick++;
            foreach(var row in entries)
            {
                bool wasDestroyed=row.Lifecycle.Destroyed;
                row.Lifecycle.Advance(lastTick);
                if(wasDestroyed && !row.Lifecycle.Destroyed)
                {row.Revision++;changes.Add(row.Snapshot());}
            }
        }
        return changes.AsReadOnly();
    }
}
