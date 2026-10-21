using System.Numerics;

namespace War.BattleServer;

internal sealed record GrenadeFlightImpact(ulong ProjectileId,string OwnerId,Vector3 Position,ShotCollision Collision,ulong Tick);

internal sealed class GrenadeFlight
{
    private const float Gravity=GrenadeBallistics.Gravity;
    private const float Drag=.2f;
    private readonly ulong id;private readonly string owner;private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private readonly ulong expires;private ulong tick;private bool collisionEnabled;
    internal ulong Id=>id;internal string OwnerId=>owner;internal ulong CurrentTick=>tick;
    internal Vector3 Position{get;private set;}internal Vector3 Velocity{get;private set;}internal bool Finished{get;private set;}

    internal GrenadeFlight(ulong id,string owner,GrenadeBinding binding,Vector3 from,Vector3 requestedTarget,ulong tick,
        Func<Vector3,Vector3,float,ShotCollision?> trace)
        : this(id, owner, binding?.Angle ?? throw new InvalidDataException("Missing grenade binding."),
            binding.ThrowDistance, from, requestedTarget, tick, trace)
    {
    }

    // The KillStreak Manager owns a separate, infinite-ammo Grenade component.
    // Its scene setup supplies the angle and distance without an equipped weapon.
    internal GrenadeFlight(ulong id,string owner,float angle,float throwDistance,Vector3 from,Vector3 requestedTarget,ulong tick,
        Func<Vector3,Vector3,float,ShotCollision?> trace,bool allowStationary=false)
    {
        if(id==0||!War.Shared.CanonicalGuid.IsCanonical(owner)||
           !float.IsFinite(angle)||angle is <=0 or >=90||!float.IsFinite(throwDistance)||throwDistance<0||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(requestedTarget)||
           (!allowStationary&&Vector3.DistanceSquared(from,requestedTarget)<1e-10f)||
           tick>10_000_000||trace==null)throw new InvalidDataException("Invalid grenade launch.");
        this.id=id;this.owner=owner;this.tick=tick;this.trace=trace;Position=from;expires=checked(tick+15*MatchManifest.TickRate);
        var direction=requestedTarget-from;if(throwDistance>0&&direction.Length()>throwDistance)
            requestedTarget=from+Vector3.Normalize(direction)*throwDistance;
        // Unity returns zero velocity when the requested target is exactly
        // the spawn point. The recovered bonus fallback can draw that offset.
        Vector3 planarOffset=requestedTarget-from;
        planarOffset.Y=0;
        Velocity=allowStationary&&planarOffset.LengthSquared()<1e-10f
            ? Vector3.Zero : BallisticVelocity(from,requestedTarget,angle);
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
        return GrenadeBallistics.CalculateVelocity(from, target, angleDegrees);
    }
}
