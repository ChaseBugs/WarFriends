namespace War.BattleServer;

// One host-owned shield. Owner level and current cover must be proven by the
// allocator/match before this kernel may influence map collision or rewards.
internal sealed class ShieldLifecycle
{
    private readonly ShieldSourceCatalog policy;
    private float maximum;
    private ulong lastTick;
    private ulong destroyedTick;
    private bool missionStartApplied;
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
    internal void ApplyMissionStart(CoopShieldStart? start)
    {
        if (start == null)
            return;
        if (missionStartApplied || destroyedTick != 0 || Destroyed || Health != maximum ||
            !float.IsFinite(start.HealthRatio) || start.HealthRatio is < 0 or > 10 ||
            !float.IsFinite(start.MaxHealthRatio) || start.MaxHealthRatio is < 0 or > 10)
            throw new InvalidDataException("Invalid mission shield initialization.");
        float baseHealth = maximum;
        // Mission.OnAfterGameStarted computes current health before maximum.
        float initialHealth = start.HealthRatio * start.MaxHealthRatio * baseHealth;
        float initialMaximum = start.MaxHealthRatio * baseHealth;
        if (!float.IsFinite(initialHealth) || !float.IsFinite(initialMaximum))
            throw new InvalidDataException("Mission shield health overflow.");
        Health = initialHealth;
        maximum = initialMaximum;
        CanRegenerate = start.Regenerate;
        AutoRepair = start.AutoRepair;
        missionStartApplied = true;
    }
    internal void SetMaximumHealth(float newMaximum)
    {
        if (!float.IsFinite(newMaximum) || newMaximum < Health || newMaximum <= 0 ||
            newMaximum > 100_000_000)
            throw new InvalidDataException("Invalid source card shield maximum.");
        // DestroyableObject.maxHealth changes only the maximum. It does not
        // refill a shield that was already damaged.
        maximum = newMaximum;
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
    internal void ApplyUnitFlame(float sourceDamage,ulong tick)
    {
        Time(tick);
        if(!float.IsFinite(sourceDamage)||sourceDamage<0||sourceDamage>100000000)
            throw new InvalidDataException("Invalid host unit flame damage.");
        if(Destroyed||sourceDamage==0)return;
        // Shield.DoDamage applies UnitToShieldCoef only for DamageType.Shot.
        // FlameAmmo calls Burn, whose DamageType is Flame.
        Health-=sourceDamage;
        if(Health<=0){Health=0;Destroyed=true;destroyedTick=tick;}
    }
    internal void ApplyUnitExplosion(float sourceDamage,float multiplier,ulong tick)
    {
        if(!float.IsFinite(multiplier)||multiplier<0||multiplier>100)
            throw new InvalidDataException("Invalid army shield explosion multiplier.");
        ApplyUnitShot(sourceDamage*multiplier,tick);
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
