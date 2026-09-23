using System.Numerics;

namespace War.BattleServer;

internal sealed record GrenadeFlightImpact(ulong ProjectileId,string OwnerId,Vector3 Position,ShotCollision Collision,ulong Tick);

internal sealed class GrenadeFlight
{
    private const float Gravity=9.81f;
    private const float Drag=.2f;
    private readonly ulong id;private readonly string owner;private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private readonly ulong expires;private ulong tick;private bool collisionEnabled;
    internal ulong Id=>id;internal string OwnerId=>owner;internal ulong CurrentTick=>tick;
    internal Vector3 Position{get;private set;}internal Vector3 Velocity{get;private set;}internal bool Finished{get;private set;}

    internal GrenadeFlight(ulong id,string owner,GrenadeBinding binding,Vector3 from,Vector3 requestedTarget,ulong tick,
        Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if(id==0||!Guid.TryParseExact(owner,"N",out _)||owner!=owner.ToLowerInvariant()||binding==null||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(requestedTarget)||Vector3.DistanceSquared(from,requestedTarget)<1e-10f||
           tick>10_000_000||trace==null)throw new InvalidDataException("Invalid grenade launch.");
        this.id=id;this.owner=owner;this.tick=tick;this.trace=trace;Position=from;expires=checked(tick+15*MatchManifest.TickRate);
        var direction=requestedTarget-from;if(binding.ThrowDistance>0&&direction.Length()>binding.ThrowDistance)
            requestedTarget=from+Vector3.Normalize(direction)*binding.ThrowDistance;
        Velocity=BallisticVelocity(from,requestedTarget,binding.Angle);
    }
    internal GrenadeFlightImpact? Advance(ulong nextTick)
    {
        if(Finished||nextTick!=tick+1||nextTick>10_000_000)throw new InvalidOperationException("Advance each grenade exactly once per tick.");
        tick=nextTick;float dt=1f/MatchManifest.TickRate;Vector3 prior=Position;
        Velocity+=new Vector3(0,-Gravity*dt,0);Velocity/=1+Drag*dt;Position+=Velocity*dt;
        if(!PlayerHitbox.Finite(Position)||!PlayerHitbox.Finite(Velocity))throw new InvalidDataException("Grenade flight escaped finite authority.");
        if(collisionEnabled)
        {
            var movement=Position-prior;float distance=movement.Length();
            if(distance>0)
            {
                var hit=trace(prior,movement,distance+.001f);
                if(hit!=null)
                {
                    if(!float.IsFinite(hit.Distance)||hit.Distance<0||hit.Distance>distance+.001f||!PlayerHitbox.Finite(hit.Position))
                        throw new InvalidDataException("Invalid grenade collision result.");
                    Position=hit.Position;Finished=true;return new(id,owner,Position,hit,tick);
                }
            }
        }
        if(Velocity.Y<0)collisionEnabled=true;
        if(tick>=expires)throw new InvalidDataException("Grenade exceeded bounded source flight window.");
        return null;
    }
    internal static Vector3 BallisticVelocity(Vector3 from,Vector3 target,float angleDegrees)
    {
        if(!PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(target)||!float.IsFinite(angleDegrees)||angleDegrees is <=0 or >=90)
            throw new InvalidDataException("Invalid grenade ballistic input.");
        target+=.2f*Vector3.UnitY;var delta=target-from;float y=Math.Max(delta.Y,0);delta.Y=0;float planar=delta.Length();
        float angle=angleDegrees*MathF.PI/180;delta.Y=planar*MathF.Tan(angle);float adjusted=planar+y/MathF.Tan(angle);
        float denominator=MathF.Sin(2*angle);if(planar<=0||adjusted<0||denominator<=0)throw new InvalidDataException("Degenerate grenade trajectory.");
        float speed=MathF.Sqrt(adjusted*Gravity/denominator);var result=speed*Vector3.Normalize(delta);
        if(!PlayerHitbox.Finite(result)||result.LengthSquared()<1e-10f)throw new InvalidDataException("Invalid grenade ballistic velocity.");
        return result;
    }
}
