namespace War.BattleServer;

internal enum HeavyTurretAttackPhase { Cooldown, Aiming, Firing }

/// <summary>Server-owned reconstruction of TurretWeaponBasic and BatchedWeapon timing.</summary>
internal sealed class HeavyTurretAttackState
{
    private readonly HeavyTurretStats stats;private readonly Func<float> random;
    private readonly int cadenceTicks;private int aimTicks,shotDelayTicks;
    private bool[] rounds=[];private int roundIndex;
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
        Phase=HeavyTurretAttackPhase.Aiming;return true;
    }
    internal void AdvanceTick()
    {
        if(Phase==HeavyTurretAttackPhase.Cooldown)
        {if(CooldownTicksRemaining>0)CooldownTicksRemaining--;return;}
        if(Phase==HeavyTurretAttackPhase.Aiming)
        {if(aimTicks>0)aimTicks--;if(aimTicks==0){
            int span=stats.BatchMaximum-stats.BatchMinimum;
            BatchRemaining=stats.BatchMinimum+(span==0?0:(int)MathF.Floor(Next()*span));
            if(BatchRemaining<=0)throw new InvalidDataException("Heavy Turret selected an empty batch.");
            PrepareShot();}return;}
        if(shotDelayTicks>0){shotDelayTicks--;if(shotDelayTicks==0)PrepareShot();}
    }
    internal bool CommitShot()
    {
        if(!ShotDue||rounds.Length==0)return false;
        BatchRemaining--;roundIndex++;
        if(BatchRemaining==0){TargetId="";ScheduleCooldown();}
        else{shotDelayTicks=cadenceTicks;CurrentShotIsReal=false;}
        return true;
    }
    internal void CancelTarget()
    {TargetId="";BatchRemaining=0;ScheduleCooldown();}
    private void PrepareShot()
    {CurrentShotIsReal=rounds.Length>0&&rounds[roundIndex];shotDelayTicks=0;Phase=HeavyTurretAttackPhase.Firing;}
    internal void PrepareBatchRounds()
    {
        if(!ShotDue)throw new InvalidDataException("Heavy Turret batch is not ready.");
        if(rounds.Length>0)return;
        rounds=new bool[BatchRemaining];roundIndex=0;
        for(int i=0;i<rounds.Length;i++)rounds[i]=Next()<stats.RealShotProbability;
        CurrentShotIsReal=rounds[0];
    }
    private void ScheduleCooldown()
    {
        int min=(int)MathF.Ceiling(stats.ShootMinimum*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(stats.ShootMaximum*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(max==min?0:(int)MathF.Floor(Next()*(max-min)));
        aimTicks=0;shotDelayTicks=0;rounds=[];roundIndex=0;CurrentShotIsReal=false;Phase=HeavyTurretAttackPhase.Cooldown;
    }
    private float Next()
    {float value=random();if(!float.IsFinite(value)||value is <0 or >=1)throw new InvalidDataException("Invalid Heavy Turret random authority.");return value;}
}
