namespace War.BattleServer;

public enum ArmyRusherAttackPhase { Ready, Windup, Firing, Cooldown }

/// <summary>Server-owned Rusher shot scheduler. It emits no damage by itself.</summary>
public sealed class ArmyRusherAttackState
{
    private readonly ArmyBaseShotStats definition;
    private readonly Func<float> random;
    private int windupTicks;
    private int shotIntervalTicks;
    private int shotIntervalRemaining;
    private int batchCursor;
    private bool[] realShots=Array.Empty<bool>();
    private readonly float cooldownMinSeconds;
    private readonly float cooldownMaxSeconds;
    private bool initialCooldownScheduled;

    public ArmyRusherAttackPhase Phase { get; private set; }=ArmyRusherAttackPhase.Ready;
    public int BatchSize { get; private set; }
    public int BatchCursor => batchCursor;
    public bool ShotDue => Phase==ArmyRusherAttackPhase.Firing && batchCursor<BatchSize && shotIntervalRemaining==0;
    public bool CurrentShotIsReal => ShotDue && realShots[batchCursor];
    public int CooldownTicksRemaining { get; private set; }

    public ArmyRusherAttackState(ArmyBaseShotStats definition,Func<float>? random=null,int shotIntervalTicks=0,
        float? cooldownMinSeconds=null,float? cooldownMaxSeconds=null)
    {
        this.definition=definition ?? throw new ArgumentNullException(nameof(definition));
        if(definition.FireBatchSizeMin<1 || definition.FireBatchSizeMax<definition.FireBatchSizeMin ||
           definition.FireBatchSizeMax>14 || !float.IsFinite(definition.ProbabilityOfRealShot) ||
           definition.ProbabilityOfRealShot is <0 or >40 || !float.IsFinite(definition.MinShootTime) ||
           !float.IsFinite(definition.MaxShootTime) || definition.MinShootTime<0 ||
           definition.MaxShootTime<definition.MinShootTime || shotIntervalTicks is <0 or >1800)
            throw new InvalidDataException("Invalid Rusher attack definition.");
        if(cooldownMinSeconds.HasValue!=cooldownMaxSeconds.HasValue ||
           cooldownMinSeconds is { } minimum && (!float.IsFinite(minimum)||minimum<0||minimum>180) ||
           cooldownMaxSeconds is { } maximum && (!float.IsFinite(maximum)||maximum<cooldownMinSeconds||maximum>180))
            throw new InvalidDataException("Invalid Rusher cooldown override.");
        this.shotIntervalTicks=shotIntervalTicks;
        this.random=random ?? Random.Shared.NextSingle;
        this.cooldownMinSeconds=cooldownMinSeconds??definition.MinShootTime;
        this.cooldownMaxSeconds=cooldownMaxSeconds??definition.MaxShootTime;
    }

    public bool TryBegin(bool eligible,int strictDelayTicks,int windupTicks)
    {
        if(!eligible || Phase!=ArmyRusherAttackPhase.Ready || strictDelayTicks<1 || windupTicks<0)
            return false;
        this.windupTicks=windupTicks;
        shotIntervalRemaining=0;
        BatchSize=definition.FireBatchSizeMin +
            (int)MathF.Floor(Math.Clamp(random(),0f,.99999994f)*
                (definition.FireBatchSizeMax-definition.FireBatchSizeMin));
        if(BatchSize<1)BatchSize=definition.FireBatchSizeMin;
        batchCursor=0;
        realShots=new bool[BatchSize];
        for(int i=0;i<BatchSize;i++)realShots[i]=random()<definition.ProbabilityOfRealShot;
        Phase=ArmyRusherAttackPhase.Windup;
        return true;
    }

    /// <summary>SwitchStateToWalking schedules its first shot instead of firing immediately.</summary>
    public void BeginInitialCooldown()
    {
        if(Phase!=ArmyRusherAttackPhase.Ready||initialCooldownScheduled)
            throw new InvalidDataException("Initial Rusher cooldown can only be scheduled once while ready.");
        initialCooldownScheduled=true;
        ScheduleCooldown();
        Phase=ArmyRusherAttackPhase.Cooldown;
    }

    public bool AdvanceTick()
    {
        if(Phase==ArmyRusherAttackPhase.Windup)
        {
            if(windupTicks>0){windupTicks--;return false;}
            Phase=ArmyRusherAttackPhase.Firing;return true;
        }
        if(Phase==ArmyRusherAttackPhase.Cooldown)
        {
            if(CooldownTicksRemaining>0)CooldownTicksRemaining--;
            if(CooldownTicksRemaining==0)Phase=ArmyRusherAttackPhase.Ready;
        }
        else if(Phase==ArmyRusherAttackPhase.Firing && shotIntervalRemaining>0)
            shotIntervalRemaining--;
        return false;
    }

    public bool CommitShot()
    {
        if(!ShotDue)return false;
        batchCursor++;
        if(batchCursor==BatchSize)
        {
            ScheduleCooldown();
            Phase=ArmyRusherAttackPhase.Cooldown;
        }
        else shotIntervalRemaining=shotIntervalTicks;
        return true;
    }

    private void ScheduleCooldown()
    {
        int min=(int)MathF.Ceiling(cooldownMinSeconds*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(cooldownMaxSeconds*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(int)MathF.Floor(Math.Clamp(random(),0f,.99999994f)*Math.Max(1,max-min));
    }
}
