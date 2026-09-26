namespace War.BattleServer;

internal enum HeavyTurretAttackPhase { Cooldown, Aiming, Firing }

/// <summary>Server-owned reconstruction of TurretWeaponBasic and BatchedWeapon timing.</summary>
internal sealed class HeavyTurretAttackState
{
    private readonly HeavyTurretStats stats;private readonly Func<float> random;
    private readonly int cadenceTicks;private int aimTicks,shotDelayTicks;
    internal HeavyTurretAttackPhase Phase{get;private set;}=HeavyTurretAttackPhase.Cooldown;
    internal string TargetId{get;private set;}="";
    internal int BatchRemaining{get;private set;}
    internal int CooldownTicksRemaining{get;private set;}
    internal bool ShotDue=>Phase==HeavyTurretAttackPhase.Firing&&shotDelayTicks==0&&BatchRemaining>0;
    internal bool CurrentShotIsReal{get;private set;}

    internal HeavyTurretAttackState(HeavyTurretStats stats,Func<float> random)
    {
        this.stats=stats;this.random=random??throw new ArgumentNullException(nameof(random));
        cadenceTicks=(int)MathF.Ceiling(.2f*MatchManifest.TickRate);
        ScheduleCooldown();
    }
    internal bool TryBegin(string targetId)
    {
        if(Phase!=HeavyTurretAttackPhase.Cooldown||CooldownTicksRemaining>0||
           string.IsNullOrEmpty(targetId)||targetId.Length>64||targetId.Any(char.IsControl))return false;
        TargetId=targetId;aimTicks=(int)MathF.Ceiling(1f*MatchManifest.TickRate);
        int span=stats.BatchMaximum-stats.BatchMinimum;
        BatchRemaining=stats.BatchMinimum+(span==0?0:(int)MathF.Floor(Next()*span));
        if(BatchRemaining<=0)throw new InvalidDataException("Heavy Turret selected an empty batch.");
        Phase=HeavyTurretAttackPhase.Aiming;return true;
    }
    internal void AdvanceTick()
    {
        if(Phase==HeavyTurretAttackPhase.Cooldown)
        {if(CooldownTicksRemaining>0)CooldownTicksRemaining--;return;}
        if(Phase==HeavyTurretAttackPhase.Aiming)
        {if(aimTicks>0)aimTicks--;if(aimTicks==0)PrepareShot();return;}
        if(shotDelayTicks>0){shotDelayTicks--;if(shotDelayTicks==0)PrepareShot();}
    }
    internal bool CommitShot()
    {
        if(!ShotDue)return false;
        BatchRemaining--;
        if(BatchRemaining==0){TargetId="";ScheduleCooldown();}
        else{shotDelayTicks=cadenceTicks;CurrentShotIsReal=false;}
        return true;
    }
    internal void CancelTarget()
    {TargetId="";BatchRemaining=0;ScheduleCooldown();}
    private void PrepareShot()
    {CurrentShotIsReal=Next()<stats.RealShotProbability;shotDelayTicks=0;Phase=HeavyTurretAttackPhase.Firing;}
    private void ScheduleCooldown()
    {
        int min=(int)MathF.Ceiling(stats.ShootMinimum*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(stats.ShootMaximum*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(max==min?0:(int)MathF.Floor(Next()*(max-min)));
        aimTicks=0;shotDelayTicks=0;CurrentShotIsReal=false;Phase=HeavyTurretAttackPhase.Cooldown;
    }
    private float Next()=>Math.Clamp(random(),0,.99999994f);
}
