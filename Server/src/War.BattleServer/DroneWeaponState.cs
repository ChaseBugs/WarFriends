using System.Numerics;
namespace War.BattleServer;

public sealed record DroneWeaponShot(Vector3 Muzzle,DroneBatchShot Batch,float Time);

// Combines BatchedWeapon.Update with Gun.willShoot and Weapon.Shoot's clock.
// Returned shots still require authoritative projectile creation/collision.
public sealed class DroneWeaponState
{
    private readonly DroneWeaponCatalog catalog;
    private readonly DroneBatchState batch;
    private float lastObserved,lastShot;
    public bool Shooting=>batch.Shooting;
    public float LastShotTime=>lastShot;
    public DroneWeaponState(DroneWeaponCatalog catalog,Func<float> random,float lastShotTime=0)
    {
        this.catalog=catalog??throw new ArgumentNullException(nameof(catalog));
        if(!float.IsFinite(lastShotTime)||lastShotTime<0)
            throw new InvalidDataException("Invalid Drone initial shot clock.");
        lastObserved=lastShot=lastShotTime;batch=new DroneBatchState(random);
    }
    public void Replace(Vector3 target,int batchSize,float realProbability)
        =>batch.Replace(target,batchSize,realProbability);
    public DroneWeaponShot? Advance(float time,Vector3 rootPosition,Quaternion rootRotation)
    {
        if(!float.IsFinite(time)||time<lastObserved)
            throw new InvalidDataException("Invalid Drone weapon observation clock.");
        var muzzle=catalog.Muzzle(rootPosition,rootRotation);
        bool ready=catalog.Ready(time,lastShot);
        lastObserved=time;
        // Source fake dispersion is relative to BatchedWeapon's root, not muzzle.
        var shot=batch.Advance(rootPosition,ready,catalog.FakeDispersion);
        if(shot is null)return null;
        lastShot=time;
        return new(muzzle,shot,time);
    }
    public void Reset()=>batch.Reset(); // Source Reset does not reset the gun clock.
}
