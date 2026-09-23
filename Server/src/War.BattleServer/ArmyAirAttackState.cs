namespace War.BattleServer;

public enum ArmyAirAttackPhase { Ready, Windup, Firing, Cooldown }

/// <summary>Deterministic attack scheduler for air families with a serialized vehicle shot contract.</summary>
public sealed class ArmyAirAttackState
{
    private readonly ArmyVehicleShotStats definition;
    private readonly Func<float> random;
    private int windup;
    private bool real;
    public ArmyAirAttackPhase Phase { get; private set; }=ArmyAirAttackPhase.Ready;
    public bool ShotDue => Phase==ArmyAirAttackPhase.Firing;
    public bool CurrentShotIsReal => ShotDue && real;
    public int CooldownTicksRemaining { get; private set; }

    public ArmyAirAttackState(ArmyVehicleShotStats definition,Func<float>? random=null)
    {
        if(!float.IsFinite(definition.ShotSpeed)||definition.ShotSpeed<=0||
           !float.IsFinite(definition.ProbabilityOfRealShot)||definition.ProbabilityOfRealShot is <0 or >1||
           definition.FireBatchSizeMin<0||definition.FireBatchSizeMax<definition.FireBatchSizeMin||
           definition.FireBatchSizeMax>14||!float.IsFinite(definition.MinShootTime)||
           !float.IsFinite(definition.MaxShootTime)||definition.MinShootTime<0||
           definition.MaxShootTime<definition.MinShootTime||definition.Crew<0)
            throw new InvalidDataException("Invalid air attack definition.");
        this.definition=definition;this.random=random??Random.Shared.NextSingle;
    }

    public bool TryBegin(bool eligible,int windupTicks)
    {
        if(!eligible||Phase!=ArmyAirAttackPhase.Ready||windupTicks<0||definition.FireBatchSizeMax==0)return false;
        windup=windupTicks;real=random()<definition.ProbabilityOfRealShot;Phase=ArmyAirAttackPhase.Windup;return true;
    }
    public bool AdvanceTick()
    {
        if(Phase==ArmyAirAttackPhase.Windup){if(windup>0){windup--;return false;}Phase=ArmyAirAttackPhase.Firing;return true;}
        if(Phase==ArmyAirAttackPhase.Cooldown&&--CooldownTicksRemaining<=0){CooldownTicksRemaining=0;Phase=ArmyAirAttackPhase.Ready;}
        return false;
    }
    public bool CommitShot()
    {
        if(!ShotDue)return false;
        int min=(int)MathF.Ceiling(definition.MinShootTime*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(definition.MaxShootTime*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(int)MathF.Floor(Math.Clamp(random(),0f,.99999994f)*Math.Max(1,max-min));
        Phase=ArmyAirAttackPhase.Cooldown;return true;
    }
}
