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
    private readonly Vector3 target;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private ulong tick;
    private Vector3 position;
    private bool finished;

    internal ArmyProjectileFlight(ulong id,ulong entityKey,Vector3 origin,Vector3 target,
        float speed,ulong tick,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if(id==0 || entityKey==0 || !PlayerHitbox.Finite(origin) ||
           !PlayerHitbox.Finite(target) || Vector3.DistanceSquared(origin,target)<1e-8f ||
           !float.IsFinite(speed) || speed is <.01f or >10000 ||
           tick>10_000_000 || trace==null)
            throw new InvalidDataException("Invalid army projectile launch.");
        this.id=id;this.entityKey=entityKey;this.position=origin;this.target=target;
        this.speed=speed;this.tick=tick;this.trace=trace;
    }

    internal Vector3 Position=>position;
    internal bool Finished=>finished;

    internal ArmyProjectileImpact? Advance(ulong nextTick)
    {
        if(finished || nextTick==tick)return null;
        if(nextTick!=tick+1 || nextTick>10_000_000)
            throw new InvalidDataException("Army projectile ticks must be contiguous.");
        tick=nextTick;
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
}
