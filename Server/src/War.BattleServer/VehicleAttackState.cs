namespace War.BattleServer;

/// <summary>Recovered ground-vehicle batch scheduler. Integer Random.Range uses an exclusive upper bound.</summary>
public sealed class VehicleAttackState
{
    private readonly ArmyVehicleShotStats definition;
    private readonly Func<float> random;
    private readonly int cadenceTicks;
    private int windupTicks,batchRemaining;
    private bool cadenceDelay;
    public float ShotSpeed => definition.ShotSpeed;
    public ArmyAirAttackPhase Phase { get; private set; }=ArmyAirAttackPhase.Ready;
    public bool ShotDue => Phase==ArmyAirAttackPhase.Firing;
    public bool CurrentShotIsReal { get; private set; }
    public int CooldownTicksRemaining { get; private set; }
    public int BatchRemaining => batchRemaining;

    public VehicleAttackState(ArmyVehicleShotStats definition,float cadenceSeconds=1f/MatchManifest.TickRate,
        Func<float>? random=null)
    {
        if(!float.IsFinite(definition.ShotSpeed)||definition.ShotSpeed<=0||
           !float.IsFinite(definition.ProbabilityOfRealShot)||definition.ProbabilityOfRealShot is <0 or >1||
           definition.FireBatchSizeMin<0||definition.FireBatchSizeMax<definition.FireBatchSizeMin||
           definition.FireBatchSizeMax>64||!float.IsFinite(definition.MinShootTime)||
           !float.IsFinite(definition.MaxShootTime)||definition.MinShootTime<0||
           definition.MaxShootTime<definition.MinShootTime||definition.Crew<0||
           !float.IsFinite(cadenceSeconds)||cadenceSeconds<=0||cadenceSeconds>10)
            throw new InvalidDataException("Invalid vehicle attack definition.");
        this.definition=definition;this.random=random??Random.Shared.NextSingle;
        cadenceTicks=Math.Max(1,(int)MathF.Ceiling(cadenceSeconds*MatchManifest.TickRate));
    }
    public bool TryBegin(bool eligible,int aimTicks)
    {
        if(!eligible||Phase!=ArmyAirAttackPhase.Ready||aimTicks<0||definition.FireBatchSizeMax==0)return false;
        int span=definition.FireBatchSizeMax-definition.FireBatchSizeMin;
        batchRemaining=definition.FireBatchSizeMin+(span==0?0:
            (int)MathF.Floor(Math.Clamp(random(),0,.99999994f)*span));
        if(batchRemaining<=0)return false;
        windupTicks=aimTicks;Phase=ArmyAirAttackPhase.Windup;return true;
    }
    public bool BeginInitialCooldown()
    {
        if(Phase!=ArmyAirAttackPhase.Ready)return false;
        ScheduleBatchCooldown();
        return true;
    }
    public bool AdvanceTick()
    {
        if(Phase==ArmyAirAttackPhase.Windup)
        {
            if(windupTicks>0){windupTicks--;return false;}
            PrepareShot();return true;
        }
        if(Phase==ArmyAirAttackPhase.Cooldown&&--CooldownTicksRemaining<=0)
        {
            CooldownTicksRemaining=0;
            if(cadenceDelay){cadenceDelay=false;PrepareShot();return true;}
            Phase=ArmyAirAttackPhase.Ready;
        }
        return false;
    }
    public bool CommitShot()
    {
        if(!ShotDue||batchRemaining<=0)return false;
        batchRemaining--;
        if(batchRemaining>0)
        {
            cadenceDelay=true;CooldownTicksRemaining=cadenceTicks;Phase=ArmyAirAttackPhase.Cooldown;
        }
        else
        {
            ScheduleBatchCooldown();
        }
        return true;
    }
    private void ScheduleBatchCooldown()
    {
        int min=(int)MathF.Ceiling(definition.MinShootTime*MatchManifest.TickRate);
        int max=(int)MathF.Ceiling(definition.MaxShootTime*MatchManifest.TickRate);
        CooldownTicksRemaining=min+(max==min?0:(int)MathF.Floor(
            Math.Clamp(random(),0,.99999994f)*(max-min)));
        cadenceDelay=false;Phase=CooldownTicksRemaining==0?ArmyAirAttackPhase.Ready:ArmyAirAttackPhase.Cooldown;
    }
    private void PrepareShot()
    {CurrentShotIsReal=random()<definition.ProbabilityOfRealShot;Phase=ArmyAirAttackPhase.Firing;}
}
