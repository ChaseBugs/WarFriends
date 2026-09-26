namespace War.BattleServer;

// One host-owned shield. Owner level and current cover must be proven by the
// allocator/match before this kernel may influence map collision or rewards.
internal sealed class ShieldLifecycle
{
    private readonly ShieldSourceCatalog policy;
    private readonly float maximum;
    private ulong lastTick;
    private ulong destroyedTick;
    internal float Health {get;private set;}
    internal float MaxHealth=>maximum;
    internal bool Destroyed {get;private set;}
    internal bool ColliderEnabled=>!Destroyed;
    internal bool CanRegenerate {get;set;}
    internal bool HasPlayer {get;set;}
    internal bool AutoRepair {get;set;}=true;
    internal ulong DestroyedTick=>destroyedTick;
    internal ShieldLifecycle(ShieldSourceCatalog policy,int provenZeroBasedLevel,ulong startingTick)
    {
        this.policy=policy??throw new ArgumentNullException(nameof(policy));
        if(startingTick>10000000)throw new InvalidDataException("Invalid shield starting tick.");
        maximum=policy.Health(provenZeroBasedLevel);Health=maximum;lastTick=startingTick;
    }
    internal void ApplyShot(string weaponId,float sourceDamage,ulong tick)
    {
        Time(tick);
        if(!float.IsFinite(sourceDamage) || sourceDamage<0 || sourceDamage>100000000)
            throw new InvalidDataException("Invalid host shield damage.");
        float amount=sourceDamage*policy.DamageToShield(weaponId);
        if(!float.IsFinite(amount) || amount>100000000)
            throw new InvalidDataException("Shield damage overflow.");
        if(Destroyed || amount==0)return;
        Health-=amount;
        if(Health<=0)
        {
            Health=0;Destroyed=true;destroyedTick=tick;
        }
    }
    internal void ApplyUnitShot(float sourceDamage,ulong tick)
    {
        Time(tick);
        if(!float.IsFinite(sourceDamage) || sourceDamage<0 || sourceDamage>100000000)
            throw new InvalidDataException("Invalid host unit shield damage.");
        float amount=sourceDamage*policy.UnitToShieldCoefficient;
        if(!float.IsFinite(amount) || amount>100000000)
            throw new InvalidDataException("Unit shield damage overflow.");
        if(Destroyed || amount==0)return;
        Health-=amount;
        if(Health<=0){Health=0;Destroyed=true;destroyedTick=tick;}
    }
    internal bool BeginOvertime(ulong tick,bool destroy)
    {
        Time(tick);
        AutoRepair=false;
        if(!destroy || Destroyed)return false;
        Health=0;Destroyed=true;destroyedTick=tick;
        return true;
    }
    internal void Advance(ulong tick)
    {
        if(tick!=lastTick+1 || tick>10000000)throw new InvalidDataException("Shield lifecycle requires the next tick.");
        lastTick=tick;
        if(Destroyed)
        {
            if(AutoRepair && policy.RepairEnabled &&
                tick-destroyedTick>=MathF.Ceiling(policy.RepairSeconds*MatchManifest.TickRate))
            {Health=maximum;Destroyed=false;destroyedTick=0;}
            return;
        }
        if(CanRegenerate && HasPlayer && AutoRepair && Health<maximum)
            Health=Math.Min(maximum,Health+1f/MatchManifest.TickRate*policy.RespawnRatePerSecond*maximum);
    }
    private void Time(ulong tick)
    {if(tick!=lastTick || tick>10000000)throw new InvalidDataException("Shield damage must use the current host tick.");}
}
