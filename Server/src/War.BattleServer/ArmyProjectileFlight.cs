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
    private readonly ShotCollision? preflightStaticHit;
    private readonly bool fastBullet;
    private readonly bool shotgunFakePellet;
    private readonly ShotCollision? fastImpact;
    private readonly float fastDuration;
    private readonly Vector3 fastVelocity;
    private readonly ulong startTick;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private ulong tick;
    private Vector3 position;
    private bool finished;

    internal ArmyProjectileFlight(ulong id,ulong entityKey,Vector3 origin,Vector3 target,
        float speed,ulong tick,Func<Vector3,Vector3,float,ShotCollision?> trace,
        float extraCollisionDistance=0,bool fastBullet=false,
        Func<ShotCollision,Vector3>? targetVelocity=null,bool shotgunFakePellet=false)
    {
        if(id==0 || entityKey==0 || !PlayerHitbox.Finite(origin) ||
           !PlayerHitbox.Finite(target) || Vector3.DistanceSquared(origin,target)<1e-8f ||
           !float.IsFinite(speed) || speed is <.01f or >10000 ||
           tick>10_000_000 || trace==null ||
           !float.IsFinite(extraCollisionDistance) ||
           extraCollisionDistance is <0 or >5 ||
           (fastBullet && (extraCollisionDistance!=0 || targetVelocity==null)) ||
           (shotgunFakePellet && (fastBullet || extraCollisionDistance!=0)))
            throw new InvalidDataException("Invalid army projectile launch.");
        this.id=id;this.entityKey=entityKey;
        // BulletSlow.Fire starts its collision ray 0.1 units in front of the
        // visual muzzle. This keeps a muzzle beside scenery from immediately
        // hitting the surface behind the projectile's rendered start point.
        direction=Vector3.Normalize(target-origin);
        this.origin=origin;
        float requestedDistance=Vector3.Distance(origin,target);
        // BulletSlow.Fire limits a shot to 50 units before its preflight ray.
        float checkedDistance=MathF.Min(requestedDistance,50f);
        this.fastBullet=fastBullet;
        this.shotgunFakePellet=shotgunFakePellet;
        startTick=tick;
        this.speed=speed;this.tick=tick;this.trace=trace;
        if(shotgunFakePellet)
        {
            // BulletBase.AnimateShot sends fake shotgun trails through one
            // extra direction vector over twice the ordinary flight time.
            // The caller's trace is intentionally ignored for these visuals.
            this.target=origin+direction*(checkedDistance*2f);
            if(!PlayerHitbox.Finite(this.target))
                throw new InvalidDataException("Fake shotgun pellet left scene bounds.");
            position=origin;
            return;
        }
        if(fastBullet)
        {
            // BulletShotGun creates a fast BulletSlow for its one real pellet.
            // Its launch ray is unbounded and its hit is cached immediately.
            ShotCollision? launchHit=trace(origin+direction*.1f,direction,10000f);
            Vector3 visualEnd=origin+direction*(checkedDistance*2f);
            if(launchHit!=null)
            {
                if(!float.IsFinite(launchHit.Distance)||launchHit.Distance<0f||
                   launchHit.Distance>10000f||!PlayerHitbox.Finite(launchHit.Position)||
                   Vector3.Distance(origin+direction*(launchHit.Distance+.1f),
                       launchHit.Position)>.02f)
                    throw new InvalidDataException("Invalid fast bullet preflight collision.");
                if(launchHit.Static)
                    visualEnd=launchHit.Position;
                else
                {
                    visualEnd=origin+direction*checkedDistance;
                    if(launchHit.SourceDestroyable)
                    {
                        Vector3 velocity=targetVelocity!(launchHit);
                        if(!PlayerHitbox.Finite(velocity)||velocity.Length()>1000f)
                            throw new InvalidDataException("Invalid fast bullet target velocity.");
                        float flightTime=Vector3.Distance(origin,launchHit.Position)/speed+.1f;
                        visualEnd=launchHit.Position+velocity*flightTime;
                        launchHit=launchHit with {Position=visualEnd};
                    }
                }
            }
            if(!PlayerHitbox.Finite(visualEnd)||
               Vector3.Distance(origin,visualEnd)<.01f)
                throw new InvalidDataException("Invalid fast bullet endpoint.");
            fastImpact=launchHit;
            this.target=visualEnd;
            fastDuration=Vector3.Distance(origin,visualEnd)/speed;
            fastVelocity=(visualEnd-origin)/fastDuration;
            position=origin;
            return;
        }
        if(extraCollisionDistance>0f && checkedDistance>.2f)
        {
            Vector3 rayOrigin=origin+direction*.1f;
            ShotCollision? launchHit=trace(rayOrigin,direction,checkedDistance-.2f);
            if(launchHit!=null)
            {
                if(!float.IsFinite(launchHit.Distance) || launchHit.Distance<0f ||
                   launchHit.Distance>checkedDistance-.2f+.002f ||
                   !PlayerHitbox.Finite(launchHit.Position) ||
                   Vector3.Distance(rayOrigin+direction*launchHit.Distance,
                       launchHit.Position)>.02f)
                    throw new InvalidDataException("Invalid slow bullet preflight collision.");
                checkedDistance=Vector3.Distance(origin,launchHit.Position);
                if(launchHit.Static)
                    preflightStaticHit=launchHit;
            }
        }
        aimDistance=checkedDistance;
        slowCollisionMargin=extraCollisionDistance;
        this.position=origin+direction*.1f;
        // BulletSlow first checks two margins beyond its initial tween. When
        // that check misses, OnCheckingAnimationFinished sends it one more
        // full aim distance before the pooled bullet is destroyed.
        float finalDistance=extraCollisionDistance==0 ? aimDistance :
            MathF.Max(0,aimDistance-extraCollisionDistance)+
            2*extraCollisionDistance+aimDistance;
        Vector3 collisionEnd=origin+direction*finalDistance;
        if(finalDistance<.1f || !PlayerHitbox.Finite(collisionEnd))
            throw new InvalidDataException("Army projectile collision path left scene bounds.");
        this.target=collisionEnd;
    }

    internal Vector3 Position=>position;
    internal float Speed=>speed;
    internal Vector3 Velocity=>fastBullet?fastVelocity:direction*speed;
    internal bool Finished=>finished;

    internal ArmyProjectileImpact? Advance(ulong nextTick)
    {
        if(finished || nextTick==tick)return null;
        if(nextTick!=tick+1 || nextTick>10_000_000)
            throw new InvalidDataException("Army projectile ticks must be contiguous.");
        tick=nextTick;
        if(fastBullet)
            return AdvanceFastBullet();
        if(slowCollisionMargin>0)
        {
            if(preflightStaticHit!=null)
                return AdvancePreflightStaticHit();
            return AdvanceSlowBullet();
        }
        var delta=target-position;
        float distance=delta.Length();
        if(!float.IsFinite(distance)){finished=true;throw new InvalidDataException("Invalid army projectile distance.");}
        float step=Math.Min(distance,speed/MatchManifest.TickRate);
        var direction=Vector3.Normalize(delta);
        var hit=shotgunFakePellet?null:trace(position,direction,step+0.002f);
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

    private ArmyProjectileImpact? AdvanceFastBullet()
    {
        float elapsed=(float)(tick-startTick)/MatchManifest.TickRate;
        float progress=MathF.Min(1f,elapsed/fastDuration);
        position=Vector3.Lerp(origin,target,progress);
        if(progress<1f)return null;
        finished=true;
        return fastImpact==null?null:new(id,entityKey,fastImpact,tick);
    }

    private ArmyProjectileImpact? AdvancePreflightStaticHit()
    {
        // A launch ray that meets static scenery makes AnimateShot skip later
        // collision checks. Unity reports the cached hit when that tween ends.
        float duration=aimDistance/speed;
        float elapsed=(float)(tick-startTick)/MatchManifest.TickRate;
        float travelled=aimDistance*MathF.Min(1f,elapsed/duration);
        position=origin+direction*travelled;
        if(elapsed<duration)return null;
        position=preflightStaticHit!.Position;
        finished=true;
        return new(id,entityKey,preflightStaticHit,tick);
    }

    private ArmyProjectileImpact? AdvanceSlowBullet()
    {
        // BulletBase spends aimDistance / speed seconds travelling to the
        // point one check margin before its aim. BulletSlow then checks the
        // next two margins over three margins / speed seconds. A miss starts
        // one final visual tween. That last tween has no collision checks.
        float firstDuration=aimDistance/speed;
        float firstEnd=MathF.Max(0,aimDistance-slowCollisionMargin);
        float continuationDuration=3*slowCollisionMargin/speed;
        float secondEnd=firstEnd+2*slowCollisionMargin;
        float secondEndTime=firstDuration+continuationDuration;
        float elapsed=(float)(tick-startTick)/MatchManifest.TickRate;
        float travelled;
        if(elapsed<=firstDuration)
            travelled=firstEnd*MathF.Min(1,elapsed/firstDuration);
        else if(elapsed<=secondEndTime)
            travelled=firstEnd+2*slowCollisionMargin*MathF.Min(1,
                (elapsed-firstDuration)/continuationDuration);
        else
            travelled=secondEnd+aimDistance*MathF.Min(1,
                (elapsed-secondEndTime)/(aimDistance/speed));
        Vector3 next=origin+direction*MathF.Max(.1f,travelled);
        if(!PlayerHitbox.Finite(next))
        {
            finished=true;
            throw new InvalidDataException("Army projectile collision path left scene bounds.");
        }
        float step=Vector3.Distance(position,next);
        // The launch ray owns the first tween. BulletSlow begins CheckHit at
        // TryKill, then stops checking in OnCheckingAnimationFinished. Its
        // frame ray reaches two delta-time units beyond the moved distance.
        bool checksCollision=elapsed>=firstDuration && elapsed<=secondEndTime;
        if(step>0 && checksCollision)
        {
            float checkRange=step+2f/MatchManifest.TickRate;
            var hit=trace(position,direction,checkRange);
            if(hit!=null)
            {
                if(!float.IsFinite(hit.Distance) || hit.Distance<0 ||
                   hit.Distance>checkRange+.002f || !PlayerHitbox.Finite(hit.Position))
                    throw new InvalidDataException("Army projectile trace returned invalid impact.");
                position=hit.Position;
                finished=true;
                return new(id,entityKey,hit,tick);
            }
        }
        position=next;
        if(elapsed>=secondEndTime+aimDistance/speed)
        {
            position=target;
            finished=true;
        }
        return null;
    }
}
