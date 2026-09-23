namespace War.BattleServer;

/// <summary>Ground-vehicle attack scheduler using the recovered serialized vehicle shot contract.</summary>
public sealed class VehicleAttackState
{
    private readonly ArmyAirAttackState inner;
    public float ShotSpeed { get; }
    public ArmyAirAttackPhase Phase => inner.Phase;
    public bool ShotDue => inner.ShotDue;
    public bool CurrentShotIsReal => inner.CurrentShotIsReal;
    public int CooldownTicksRemaining => inner.CooldownTicksRemaining;
    public VehicleAttackState(ArmyVehicleShotStats definition, Func<float>? random = null)
    { inner = new ArmyAirAttackState(definition, random); ShotSpeed = definition.ShotSpeed; }
    public bool TryBegin(bool eligible, int windupTicks) => inner.TryBegin(eligible, windupTicks);
    public bool AdvanceTick() => inner.AdvanceTick();
    public bool CommitShot() => inner.CommitShot();
}
