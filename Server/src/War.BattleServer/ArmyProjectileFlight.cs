using System.Numerics;

namespace War.BattleServer;

internal sealed record ArmyProjectileImpact(ulong ProjectileId,ulong EntityKey,
    ShotCollision Collision,ulong Tick);

/// <summary>Fixed-tick projectile flight owned by a spawned army entity.</summary>
internal sealed class ArmyProjectileFlight
{
    private readonly ulong id;
    private readonly ulong entityKey;
    private readonly float speed;
    private readonly Vector3 direction;
    private readonly Vector3 target;
    private readonly Vector3 origin;
    private readonly float aimDistance;
    private readonly float slowCollisionMargin;
    private readonly ulong startTick;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private ulong tick;
    private Vector3 position;
    private bool finished;

    internal ArmyProjectileFlight(ulong id,ulong entityKey,Vector3 origin,Vector3 target,
        float speed,ulong tick,Func<Vector3,Vector3,float,ShotCollision?> trace,
        float extraCollisionDistance=0)
    {
        if(id==0 || entityKey==0 || !PlayerHitbox.Finite(origin) ||
           !PlayerHitbox.Finite(target) || Vector3.DistanceSquared(origin,target)<1e-8f ||
           !float.IsFinite(speed) || speed is <.01f or >10000 ||
           tick>10_000_000 || trace==null ||
           !float.IsFinite(extraCollisionDistance) ||
           extraCollisionDistance is <0 or >5)
            throw new InvalidDataException("Invalid army projectile launch.");
        this.id=id;this.entityKey=entityKey;
        // BulletSlow.Fire starts its collision ray 0.1 units in front of the
        // visual muzzle. This keeps a muzzle beside scenery from immediately
        // hitting the surface behind the projectile's rendered start point.
        direction=Vector3.Normalize(target-origin);
        this.origin=origin;
        aimDistance=Vector3.Distance(origin,target);
        slowCollisionMargin=extraCollisionDistance;
        startTick=tick;
        this.position=origin+direction*.1f;
        // BulletSlow with collision checking travels beyond its aim point.
        // The caller supplies the validated runtime distanceToCheck margin.
        float finalDistance=extraCollisionDistance==0 ? aimDistance :
            MathF.Max(0,aimDistance-extraCollisionDistance)+2*extraCollisionDistance;
        Vector3 collisionEnd=origin+direction*finalDistance;
        if(finalDistance<.1f || !PlayerHitbox.Finite(collisionEnd))
            throw new InvalidDataException("Army projectile collision path left scene bounds.");
        this.target=collisionEnd;
        this.speed=speed;this.tick=tick;this.trace=trace;
    }

    internal Vector3 Position=>position;
    internal float Speed=>speed;
    internal Vector3 Velocity=>direction*speed;
    internal bool Finished=>finished;

    internal ArmyProjectileImpact? Advance(ulong nextTick)
    {
        if(finished || nextTick==tick)return null;
        if(nextTick!=tick+1 || nextTick>10_000_000)
            throw new InvalidDataException("Army projectile ticks must be contiguous.");
        tick=nextTick;
        if(slowCollisionMargin>0)
            return AdvanceSlowBullet();
        var delta=target-position;
        float distance=delta.Length();
        if(!float.IsFinite(distance)){finished=true;throw new InvalidDataException("Invalid army projectile distance.");}
        float step=Math.Min(distance,speed/MatchManifest.TickRate);
        var direction=Vector3.Normalize(delta);
        var hit=trace(position,direction,step+0.002f);
        if(hit!=null)
        {
            if(!float.IsFinite(hit.Distance) || hit.Distance<0 || hit.Distance>step+.002f ||
               !PlayerHitbox.Finite(hit.Position))
                throw new InvalidDataException("Army projectile trace returned invalid impact.");
            position=hit.Position;finished=true;
            return new(id,entityKey,hit,tick);
        }
        position+=direction*step;
        if(distance<=step+.0001f){position=target;finished=true;}
        return null;
    }

    private ArmyProjectileImpact? AdvanceSlowBullet()
    {
        // BulletBase spends aimDistance / speed seconds travelling to the
        // point one check margin before its aim. BulletSlow then checks the
        // next two margins over three margins / speed seconds.
        float firstDuration=aimDistance/speed;
        float firstEnd=MathF.Max(0,aimDistance-slowCollisionMargin);
        float continuationDuration=3*slowCollisionMargin/speed;
        float elapsed=(float)(tick-startTick)/MatchManifest.TickRate;
        float travelled=elapsed<=firstDuration ?
            firstEnd*MathF.Min(1,elapsed/firstDuration) :
            firstEnd+2*slowCollisionMargin*MathF.Min(1,
                (elapsed-firstDuration)/continuationDuration);
        Vector3 next=origin+direction*MathF.Max(.1f,travelled);
        if(!PlayerHitbox.Finite(next))
        {
            finished=true;
            throw new InvalidDataException("Army projectile collision path left scene bounds.");
        }
        float step=Vector3.Distance(position,next);
        if(step>0)
        {
            var hit=trace(position,direction,step+.002f);
            if(hit!=null)
            {
                if(!float.IsFinite(hit.Distance) || hit.Distance<0 ||
                   hit.Distance>step+.002f || !PlayerHitbox.Finite(hit.Position))
                    throw new InvalidDataException("Army projectile trace returned invalid impact.");
                position=hit.Position;
                finished=true;
                return new(id,entityKey,hit,tick);
            }
            position=next;
        }
        if(elapsed>=firstDuration+continuationDuration)
        {
            position=target;
            finished=true;
        }
        return null;
    }
}
