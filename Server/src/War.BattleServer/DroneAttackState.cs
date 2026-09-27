using System.Numerics;
namespace War.BattleServer;

public sealed record DroneTargetDetails(IReadOnlyList<DroneShotTarget> Targets,bool IsPlayer,
    Vector3 Root,Vector3 AimForward,bool Hiding,Vector3 Velocity,float ShieldProbability);

// Drone.Update target/batch preparation, separated from BatchedWeapon.Update so
// the host can explicitly preserve script observation order.
public sealed class DroneAttackState
{
    private readonly DroneAttackClock clock;
    private readonly DroneWeaponCatalog weaponCatalog;
    private readonly DroneProjectileCatalog projectile;
    private readonly ArmyVehicleShotStats stats;
    private readonly Func<float> random;
    private readonly Func<int,int,int> integerRange;
    public DroneWeaponState Weapon { get; }
    public string? TargetId { get; private set; }
    public bool PlayerTarget { get; private set; }
    public float Deadline=>clock.Deadline;
    public DroneAttackState(float spawnTime,ArmyVehicleShotStats stats,DroneWeaponCatalog weapon,
        DroneProjectileCatalog projectile,Func<float> random,Func<int,int,int> integerRange)
    {
        if(stats is null||stats.FireBatchSizeMin<0||stats.FireBatchSizeMax<stats.FireBatchSizeMin||stats.FireBatchSizeMax>32||
           !float.IsFinite(stats.ProbabilityOfRealShot)||stats.ProbabilityOfRealShot<0||stats.ProbabilityOfRealShot>3)
            throw new InvalidDataException("Invalid Drone attack definition.");
        this.stats=stats;weaponCatalog=weapon??throw new ArgumentNullException(nameof(weapon));
        this.projectile=projectile??throw new ArgumentNullException(nameof(projectile));
        this.random=random??throw new ArgumentNullException(nameof(random));
        this.integerRange=integerRange??throw new ArgumentNullException(nameof(integerRange));
        _=projectile.Speed(stats.ShotSpeed,false,false);
        clock=new(spawnTime,stats.MinShootTime,stats.MaxShootTime);Weapon=new(weapon,random);
    }
    public bool Prepare(float time,bool alive,int fraction,Vector3 position,Quaternion rotation,
        IReadOnlyList<DroneTargetCandidate> registry,Func<DroneTargetCandidate,bool> canSee,
        Func<DroneTargetCandidate,DroneTargetDetails> resolve)
    {
        if(!clock.BeginAttempt(time,alive))return false;
        var target=DroneTargetPolicy.Select(fraction,registry,canSee);
        TargetId=target?.Id;PlayerTarget=false;
        if(target!=null)
        {
            var details=resolve(target);PlayerTarget=details.IsPlayer;
            var selected=DroneShotTargetPolicy.Select(position,details.Targets,details.IsPlayer,details.Root,
                details.AimForward,details.Hiding,details.ShieldProbability,random);
            if(selected!=null)
            {
                int size=integerRange(stats.FireBatchSizeMin,stats.FireBatchSizeMax);
                if(size<stats.FireBatchSizeMin||size>(stats.FireBatchSizeMax==stats.FireBatchSizeMin?
                    stats.FireBatchSizeMax:stats.FireBatchSizeMax-1))throw new InvalidDataException("Drone batch size escaped source range.");
                var predicted=DroneShotTargetPolicy.Predict(weaponCatalog.Muzzle(position,rotation),selected.Position,
                    details.IsPlayer?Vector3.Zero:details.Velocity,projectile.Speed(stats.ShotSpeed,details.IsPlayer,false),1);
                Weapon.Replace(predicted,size,stats.ProbabilityOfRealShot);
            }
        }
        // No target does not cancel an existing BatchedWeapon batch in the source.
        clock.CompleteAttempt(random());return true;
    }
}
