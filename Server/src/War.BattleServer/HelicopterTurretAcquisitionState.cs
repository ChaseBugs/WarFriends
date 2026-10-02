namespace War.BattleServer;

// TurretWeaponBasic.Reset/Update schedules target acquisition before Aim.
// ShootEnd and batch firing remain separate combat transitions.
internal sealed class HelicopterTurretAcquisitionState
{
    private readonly ArmyVehicleShotStats stats;
    private readonly Func<float> random;
    private bool disabled;
    internal bool Disabled=>disabled;
    internal ulong NextPickTick { get; private set; }
    internal string? TargetId { get; private set; }

    internal HelicopterTurretAcquisitionState(ulong spawnTick,ArmyVehicleShotStats stats,
        Func<float> random)
    {
        if(stats==null||!float.IsFinite(stats.MinShootTime)||
           !float.IsFinite(stats.MaxShootTime)||stats.MinShootTime<0||
           stats.MaxShootTime<stats.MinShootTime||stats.MaxShootTime>60)
            throw new InvalidDataException("Invalid Helicopter turret acquisition timing.");
        this.stats=stats;this.random=random??throw new ArgumentNullException(nameof(random));
        Reset(spawnTick);
    }

    internal void Disable()
    {
        disabled=true;TargetId=null;
    }

    internal void Reset(ulong tick)
    {
        disabled=false;TargetId=null;Schedule(tick);
    }

    internal bool Due(ulong tick)=>!disabled&&tick>NextPickTick;

    internal void Acquired(ulong tick,string? targetId)
    {
        if(disabled||tick<=NextPickTick||
           targetId is {Length:>100}||targetId?.Any(char.IsControl)==true)
            throw new InvalidDataException("Invalid Helicopter turret acquisition.");
        TargetId=targetId;
        if(targetId==null)Schedule(tick);
        else NextPickTick=checked(tick+(ulong)MathF.Ceiling(
            stats.MaxShootTime*2f*MatchManifest.TickRate));
    }

    private void Schedule(ulong tick)
    {
        float draw=random();
        if(!float.IsFinite(draw)||draw is <0 or >=1)
            throw new InvalidDataException("Invalid Helicopter turret random authority.");
        float seconds=stats.MinShootTime+(stats.MaxShootTime-stats.MinShootTime)*draw;
        NextPickTick=checked(tick+(ulong)MathF.Ceiling(seconds*MatchManifest.TickRate));
    }
}
