using System.Numerics;

namespace War.BattleServer;

internal sealed record HelicopterTurretRound(Vector3 Muzzle,DroneBatchShot Batch,bool Shield);

// Helicopter.prefab binds BatchedWeapon 11483234 to Gun 11441888. The gun has
// infinite ammo, is not reloadable, and uses a strict 0.2-second cadence.
internal sealed class HelicopterTurretWeaponState
{
    private readonly DroneBatchState batch;
    private float lastShotTime;
    private bool shield;
    internal bool Shooting=>batch.Shooting;

    internal HelicopterTurretWeaponState(Func<float> random)
        =>batch=new(random);

    internal void Begin(Vector3 target,int batchSize,float realProbability,bool shield)
    {
        batch.Replace(target,batchSize,realProbability);
        this.shield=shield;
    }

    internal HelicopterTurretRound? Advance(float time,Vector3 turretPosition,Vector3 muzzle)
    {
        if(!float.IsFinite(time)||time<0||!PlayerHitbox.Finite(turretPosition)||
           !PlayerHitbox.Finite(muzzle))
            throw new InvalidDataException("Invalid Helicopter turret shot pose or time.");
        // Gun.Shoot adds shotOffset in world space after reading spawnPoint.
        muzzle+=new Vector3(0,.1f,0);
        var shot=batch.Advance(turretPosition,time>lastShotTime+.2f,1f);
        if(shot==null)return null;
        lastShotTime=time;
        return new(muzzle,shot,shield);
    }

    internal void Reset()=>batch.Reset();
}
