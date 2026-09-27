using System.Numerics;
namespace War.BattleServer;

// BulletSlow fake branch: one linear presentation tween, no collision authority.
internal sealed class DroneFakeProjectileFlight
{
    private readonly Vector3 origin,end;
    private readonly float duration;
    private readonly ulong start;
    private ulong observed;
    internal Vector3 Position { get; private set; }
    internal bool Finished { get; private set; }
    internal DroneFakeProjectileFlight(DroneProjectileIntent intent,ulong tick)
    {
        if(!intent.Shot.Batch.IsFake||!float.IsFinite(intent.Speed)||intent.Speed<=0||tick>10000000||
           !PlayerHitbox.Finite(intent.Shot.Muzzle)||!PlayerHitbox.Finite(intent.Shot.Batch.Target))
            throw new InvalidDataException("Invalid Drone fake projectile launch.");
        origin=intent.Shot.Muzzle;Vector3 delta=intent.Shot.Batch.Target-origin;
        float distance=delta.Length();
        if(!float.IsFinite(distance)||distance<1e-5f)throw new ProjectileTargetException();
        if(distance>50){delta=Vector3.Normalize(delta)*50;distance=50;}
        end=origin+delta*2;duration=distance/intent.Speed*2;
        if(!PlayerHitbox.Finite(end)||!float.IsFinite(duration)||duration<=0)
            throw new InvalidDataException("Drone fake projectile overflow.");
        start=observed=tick;Position=origin;
    }
    internal void Advance(ulong tick)
    {
        if(tick<observed||tick>10000000)throw new InvalidDataException("Invalid Drone fake projectile clock.");
        observed=tick;if(Finished)return;
        float elapsed=(tick-start)/(float)MatchManifest.TickRate;
        float progress=Math.Clamp(elapsed/duration,0,1);
        Position=Vector3.Lerp(origin,end,progress);Finished=progress>=1;
    }
}
