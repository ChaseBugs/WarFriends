using System.Numerics;

namespace War.BattleServer;

// Helicopter BulletSlow fake branch: twice the target displacement over twice
// the ordinary flight time, using BulletSetup.fakeSpeed and no collision query.
internal sealed class HelicopterFakeProjectileFlight
{
    private readonly Vector3 origin,end;
    private readonly float duration;
    private readonly ulong start;
    private ulong observed;
    internal Vector3 Position { get; private set; }
    internal bool Finished { get; private set; }

    internal HelicopterFakeProjectileFlight(Vector3 muzzle,Vector3 target,float setupSpeed,ulong tick)
    {
        if(!PlayerHitbox.Finite(muzzle)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(setupSpeed)||setupSpeed<=0||tick>10000000)
            throw new InvalidDataException("Invalid Helicopter fake projectile launch.");
        origin=muzzle;
        Vector3 delta=target-origin;
        float distance=delta.Length();
        if(!float.IsFinite(distance)||distance<1e-5f)throw new ProjectileTargetException();
        if(distance>50f){delta=Vector3.Normalize(delta)*50f;distance=50f;}
        float fakeSpeed=setupSpeed*1.5f;
        end=origin+delta*2f;
        duration=distance/fakeSpeed*2f;
        if(!PlayerHitbox.Finite(end)||!float.IsFinite(duration)||duration<=0)
            throw new InvalidDataException("Helicopter fake projectile overflow.");
        start=observed=tick;Position=origin;
    }

    internal void Advance(ulong tick)
    {
        if(tick<observed||tick>10000000)
            throw new InvalidDataException("Invalid Helicopter fake projectile clock.");
        observed=tick;
        if(Finished)return;
        float elapsed=(tick-start)/(float)MatchManifest.TickRate;
        float progress=Math.Clamp(elapsed/duration,0f,1f);
        Position=Vector3.Lerp(origin,end,progress);
        Finished=progress>=1f;
    }
}
