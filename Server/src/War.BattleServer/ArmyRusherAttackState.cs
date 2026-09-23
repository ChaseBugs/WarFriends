namespace War.BattleServer;

public enum ArmyRusherAttackPhase { Ready, Windup, Firing, Cooldown }

/// <summary>Server-owned Rusher shot scheduler. It emits no damage by itself.</summary>
public sealed class ArmyRusherAttackState
{
    private readonly ArmyBaseShotStats definition;
    private readonly Func<float> random;
    private int windupTicks;
    private int batchCursor;
    private bool[] realShots=Array.Empty<bool>();

    public ArmyRusherAttackPhase Phase { get; private set; }=ArmyRusherAttackPhase.Ready;
    public int BatchSize { get; private set; }
    public int BatchCursor => batchCursor;
    public bool ShotDue => Phase==ArmyRusherAttackPhase.Firing && batchCursor<BatchSize;
    public bool CurrentShotIsReal => ShotDue && realShots[batchCursor];
    public int CooldownTicksRemaining { get; private set; }

    public ArmyRusherAttackState(ArmyBaseShotStats definition,Func<float>? random=null)
    {
        this.definition=definition ?? throw new ArgumentNullException(nameof(definition));
        if(definition.FireBatchSizeMin<1 || definition.FireBatchSizeMax<definition.FireBatchSizeMin ||
           definition.FireBatchSizeMax>14 || !float.IsFinite(definition.ProbabilityOfRealShot) ||
           definition.ProbabilityOfRealShot is <0 or >1 || !float.IsFinite(definition.MinShootTime) ||
           !float.IsFinite(definition.MaxShootTime) || definition.MinShootTime<0 ||
           definition.MaxShootTime<definition.MinShootTime)
            throw new InvalidDataException("Invalid Rusher attack definition.");
        this.random=random ?? Random.Shared.NextSingle;
    }

    public bool TryBegin(bool eligible,int strictDelayTicks,int windupTicks)
    {
        if(!eligible || Phase!=ArmyRusherAttackPhase.Ready || strictDelayTicks<1 || windupTicks<0)
            return false;
        this.windupTicks=windupTicks;
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
        return false;
    }

    public bool CommitShot()
    {
        if(!ShotDue)return false;
        batchCursor++;
        if(batchCursor==BatchSize)
        {
            int min=(int)MathF.Ceiling(definition.MinShootTime*MatchManifest.TickRate);
            int max=(int)MathF.Ceiling(definition.MaxShootTime*MatchManifest.TickRate);
            CooldownTicksRemaining=min + (int)MathF.Floor(Math.Clamp(random(),0f,.99999994f)*Math.Max(1,max-min));
            Phase=ArmyRusherAttackPhase.Cooldown;
        }
        return true;
    }
}
