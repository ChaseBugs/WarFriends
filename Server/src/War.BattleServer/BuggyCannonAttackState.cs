namespace War.BattleServer;

/// <summary>Recovered Buggy paired-cannon timing. The primary schedules turret cooldown;
/// the secondary launches independently after TurretWeaponMultipleWeapons.delay.</summary>
internal sealed class BuggyCannonAttackState
{
    private readonly ArmyVehicleCannonStats stats;
    private readonly Func<float> random;
    private readonly int secondaryDelayTicks;
    private int aimTicks,secondaryTicks=-1;
    internal ArmyAirAttackPhase Phase{get;private set;}=ArmyAirAttackPhase.Ready;
    internal int CooldownTicksRemaining{get;private set;}
    internal bool PrimaryDue{get;private set;}
    internal bool SecondaryDue{get;private set;}
    internal float DamagePerMissile=>stats.Damage*.5f;

    internal BuggyCannonAttackState(ArmyVehicleCannonStats stats,float secondaryDelaySeconds,
        Func<float>? random=null)
    {
        if(stats==null||!float.IsFinite(stats.Damage)||stats.Damage<=0||
           !float.IsFinite(stats.MinShootTime)||!float.IsFinite(stats.MaxShootTime)||
           stats.MinShootTime<0||stats.MaxShootTime<stats.MinShootTime||
           !float.IsFinite(secondaryDelaySeconds)||secondaryDelaySeconds<0||secondaryDelaySeconds>10)
            throw new InvalidDataException("Invalid Buggy cannon timing authority.");
        this.stats=stats;this.random=random??Random.Shared.NextSingle;
        secondaryDelayTicks=(int)MathF.Ceiling(secondaryDelaySeconds*MatchManifest.TickRate);
    }
    internal bool BeginInitialCooldown()
    {if(Phase!=ArmyAirAttackPhase.Ready)return false;ScheduleCooldown();return true;}
    internal bool TryBegin(int windupTicks)
    {
        if(Phase!=ArmyAirAttackPhase.Ready||windupTicks<0)return false;
        aimTicks=windupTicks;Phase=ArmyAirAttackPhase.Windup;return true;
    }
    internal bool AdvanceTick()
    {
        bool due=false;
        if(secondaryTicks>=0&&--secondaryTicks<=0)
        {secondaryTicks=-1;SecondaryDue=true;due=true;}
        if(Phase==ArmyAirAttackPhase.Windup)
        {
            if(aimTicks>0)aimTicks--;
            else {PrimaryDue=true;Phase=ArmyAirAttackPhase.Firing;due=true;}
        }
        else if(Phase==ArmyAirAttackPhase.Cooldown&&--CooldownTicksRemaining<=0)
        {CooldownTicksRemaining=0;Phase=ArmyAirAttackPhase.Ready;}
        return due;
    }
    internal bool CommitPrimary()
    {
        if(!PrimaryDue)return false;
        PrimaryDue=false;secondaryTicks=Math.Max(1,secondaryDelayTicks);ScheduleCooldown();return true;
    }
    internal bool CommitSecondary()
    {if(!SecondaryDue)return false;SecondaryDue=false;return true;}
    internal void DisableAndReset()
    {aimTicks=0;secondaryTicks=-1;PrimaryDue=false;SecondaryDue=false;ScheduleCooldown();}
    private void ScheduleCooldown()
    {
        int min=(int)MathF.Ceiling(stats.MinShootTime*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(stats.MaxShootTime*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(max==min?0:(int)MathF.Floor(
            Math.Clamp(random(),0,.99999994f)*(max-min)));
        Phase=CooldownTicksRemaining==0?ArmyAirAttackPhase.Ready:ArmyAirAttackPhase.Cooldown;
    }
}
