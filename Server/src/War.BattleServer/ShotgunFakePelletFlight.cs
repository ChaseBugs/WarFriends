using System.Numerics;

namespace War.BattleServer;

// BulletShotGun.Fire's visual-only Random.onUnitSphere spread followed by
// BulletSlow's fast fake branch. No collision callback or damage is exposed.
internal sealed class ShotgunFakePelletFlight
{
    private readonly Vector3 origin,end;
    private readonly float duration;
    private readonly ulong start;
    private ulong observed;
    internal ulong Id { get; }
    internal string OwnerId { get; }
    internal string WeaponSourceId { get; }
    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; }
    internal bool Finished { get; private set; }

    internal static Vector3 SpreadTarget(Vector3 from,Vector3 aim,Vector3 unitSphere)
    {
        if(!PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(aim)||
           !PlayerHitbox.Finite(unitSphere)||
           Math.Abs(unitSphere.LengthSquared()-1)>.0002f)
            throw new InvalidDataException("Invalid shotgun fake-pellet spread.");
        float distance=Vector3.Distance(from,aim);
        if(!float.IsFinite(distance)||distance<1e-5f)
            throw new ProjectileTargetException();
        Vector3 target=aim+unitSphere*(Math.Clamp(distance/2,0,1)*.25f);
        if(!PlayerHitbox.Finite(target))
            throw new InvalidDataException("Shotgun fake-pellet target overflow.");
        return target;
    }

    internal ShotgunFakePelletFlight(ulong id,string owner,string weaponSourceId,Vector3 from,Vector3 target,
        float fakeSpeed,ulong tick)
    {
        if(id==0||!Guid.TryParseExact(owner,"N",out _)||owner!=owner.ToLowerInvariant()||
           string.IsNullOrEmpty(weaponSourceId)||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(fakeSpeed)||fakeSpeed is <.01f or >10000||tick>10000000)
            throw new InvalidDataException("Invalid shotgun fake-pellet launch.");
        Vector3 delta=target-from;
        float distance=delta.Length();
        if(!float.IsFinite(distance)||distance<1e-5f)
            throw new ProjectileTargetException();
        if(distance>50){delta=Vector3.Normalize(delta)*50;distance=50;}
        origin=from;end=from+delta*2;duration=distance/fakeSpeed*2;
        if(!PlayerHitbox.Finite(end)||!float.IsFinite(duration)||duration<=0||duration>1800)
            throw new InvalidDataException("Shotgun fake-pellet flight overflow.");
        Id=id;OwnerId=owner;WeaponSourceId=weaponSourceId;Velocity=(end-origin)/duration;
        start=observed=tick;Position=from;
    }

    internal void Advance(ulong tick)
    {
        if(tick<observed||tick>10000000)
            throw new InvalidDataException("Invalid shotgun fake-pellet clock.");
        observed=tick;if(Finished)return;
        float progress=Math.Clamp(((tick-start)/(float)MatchManifest.TickRate)/duration,0,1);
        Position=Vector3.Lerp(origin,end,progress);
        Finished=progress>=1;
    }
}
