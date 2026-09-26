using System.Numerics;

namespace War.BattleServer;

internal sealed record TankMissileImpact(ulong ProjectileId,ulong VehicleId,Vector3 Position,
    ShotCollision? Collision,ulong Tick);

/// <summary>Recovered straight Missile flight used by Tank.cannon.</summary>
internal sealed class TankMissileFlight
{
    private readonly ulong id,vehicleId;private readonly GroundVehicleMissileBinding binding;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;private readonly Func<Vector3> target;
    private readonly Vector3 start;private Vector3 last;private readonly float duration;
    private ulong tick;private float progress;private bool collisionEnabled;
    internal ulong VehicleId=>vehicleId;internal Vector3 Position{get;private set;}internal bool Finished{get;private set;}

    internal TankMissileFlight(ulong id,ulong vehicleId,GroundVehicleMissileBinding binding,
        Vector3 from,Func<Vector3> target,ulong tick,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        Vector3 to=target?.Invoke()??throw new InvalidDataException("Tank missile target disappeared.");
        if(id==0||vehicleId==0||binding==null||binding.CurvedTrajectory||binding.Speed<=0||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(to)||Vector3.DistanceSquared(from,to)<1e-10f||
           tick>10_000_000||trace==null)throw new InvalidDataException("Invalid Tank missile launch.");
        this.id=id;this.vehicleId=vehicleId;this.binding=binding;this.target=target;this.tick=tick;
        this.trace=trace;start=from;last=Position=from;
        duration=Math.Min(Vector3.Distance(from,to),50)/binding.Speed;
        if(!float.IsFinite(duration)||duration<=0||duration>1800)
            throw new InvalidDataException("Invalid Tank missile duration.");
        progress=-binding.StopTime/duration;
    }

    internal TankMissileImpact? Advance(ulong nextTick)
    {
        if(nextTick!=tick+1||nextTick>10_000_000||Finished)
            throw new InvalidOperationException("Advance each Tank missile exactly once per tick.");
        tick=nextTick;progress+=1f/MatchManifest.TickRate/duration;last=Position;
        Vector3 end=target();
        if(!PlayerHitbox.Finite(end)||Vector3.DistanceSquared(start,end)<1e-10f)
            throw new InvalidDataException("Tank missile target escaped host bounds.");
        var delta=end-start;if(delta.Length()>50)end=start+Vector3.Normalize(delta)*50;
        Position=start+(end-start)*Math.Max(progress,0);
        if(!PlayerHitbox.Finite(Position))throw new InvalidDataException("Tank trajectory escaped scene bounds.");
        if(collisionEnabled)
        {
            var move=Position-last;float distance=move.Length();
            if(distance>0)
            {
                float range=distance+2f/MatchManifest.TickRate;var hit=trace(last,move,range);
                if(hit!=null)
                {
                    if(!float.IsFinite(hit.Distance)||hit.Distance<0||hit.Distance>range||
                       !PlayerHitbox.Finite(hit.Position))throw new InvalidDataException("Invalid Tank collision.");
                    Position=hit.Position;Finished=true;return new(id,vehicleId,Position,hit,tick);
                }
            }
        }
        else if(Vector3.Distance(start,Position)>.5f)collisionEnabled=true;
        if(progress>3){Finished=true;return new(id,vehicleId,Position,null,tick);}
        return null;
    }
}
