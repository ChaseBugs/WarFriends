using System.Numerics;

namespace War.BattleServer;

internal sealed record BuggyMissileImpact(ulong ProjectileId,ulong VehicleId,Vector3 Position,
    ShotCollision? Collision,ulong Tick);

/// <summary>Recovered Missile curved trajectory with the Buggy's five-key looping profile.</summary>
internal sealed class BuggyMissileFlight
{
    private readonly ulong id,vehicleId;private readonly GroundVehicleMissileBinding binding;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;
    private readonly Vector3 start,end,direction;private Vector3 last,lastUp;
    private readonly float duration,middleRotation,rotations,rotationMagnitude;
    private ulong tick;private float progress;private bool collisionEnabled;
    internal ulong VehicleId=>vehicleId;internal Vector3 Position{get;private set;}internal bool Finished{get;private set;}

    internal BuggyMissileFlight(ulong id,ulong vehicleId,GroundVehicleMissileBinding binding,
        float runtimeSpeed,Vector3 from,Vector3 to,ulong tick,float middleRoll,float rotationRoll,
        int curveSign,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if(id==0||vehicleId==0||binding==null||!binding.CurvedTrajectory||
           binding.RotationProfile.Count!=5||!float.IsFinite(runtimeSpeed)||runtimeSpeed<=0||runtimeSpeed>100||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(to)||Vector3.DistanceSquared(from,to)<1e-10f||
           tick>10_000_000||!float.IsFinite(middleRoll)||middleRoll is <0 or >1||
           !float.IsFinite(rotationRoll)||rotationRoll is <0 or >1||curveSign is not (-1 or 1)||trace==null)
            throw new InvalidDataException("Invalid Buggy missile launch.");
        this.id=id;this.vehicleId=vehicleId;this.binding=binding;this.tick=tick;this.trace=trace;
        start=from;var delta=to-from;if(delta.Length()>50)to=from+Vector3.Normalize(delta)*50;
        end=to;direction=end-start;duration=direction.Length()/runtimeSpeed;
        if(!float.IsFinite(duration)||duration<=0||duration>1800)
            throw new InvalidDataException("Invalid Buggy missile duration.");
        progress=-binding.StopTime/duration;Position=last=lastUp=from;
        float scale=MathF.Pow(direction.Length()/10,2);
        middleRotation=curveSign*(60+50*middleRoll);
        rotations=Math.Clamp((binding.RotationRange.X+
            (binding.RotationRange.Y-binding.RotationRange.X)*rotationRoll)*scale,0,
            binding.RotationRange.Y*1.2f);
        rotationMagnitude=Math.Clamp(binding.BaseRotationMagnitude*scale,0,.6f);
    }

    internal BuggyMissileImpact? Advance(ulong nextTick)
    {
        if(nextTick!=tick+1||nextTick>10_000_000||Finished)
            throw new InvalidOperationException("Advance each Buggy missile exactly once per tick.");
        tick=nextTick;progress+=1f/MatchManifest.TickRate/duration;last=Position;
        float linearProgress=Math.Max(progress,0);var linear=start+direction*linearProgress;
        var vertical=new Vector3(0,MathF.Sin(progress*MathF.PI)*1.6f*rotationMagnitude,0);
        var axis=linear+vertical-lastUp;lastUp=linear+vertical;var offset=vertical;
        if(axis.LengthSquared()>1e-12f)
        {
            float angle=middleRotation+360*rotations*(progress-.5f);
            var spin=Vector3.Transform(Vector3.UnitY,
                Quaternion.CreateFromAxisAngle(Vector3.Normalize(axis),angle*MathF.PI/180));
            offset+=spin*rotationMagnitude*Curve(progress);
        }
        if(progress>1)offset+=vertical;
        Position=linear+offset;
        if(!PlayerHitbox.Finite(Position))throw new InvalidDataException("Buggy trajectory escaped scene bounds.");
        if(collisionEnabled)
        {
            var move=Position-last;float distance=move.Length();
            if(distance>0)
            {
                float range=distance+2f/MatchManifest.TickRate;var hit=trace(last,move,range);
                if(hit!=null)
                {
                    if(!float.IsFinite(hit.Distance)||hit.Distance<0||hit.Distance>range||
                       !PlayerHitbox.Finite(hit.Position))throw new InvalidDataException("Invalid Buggy collision.");
                    Position=hit.Position;Finished=true;return new(id,vehicleId,Position,hit,tick);
                }
            }
        }
        else if(Vector3.Distance(start,Position)>.5f)collisionEnabled=true;
        if(progress>1.5f){Finished=true;return new(id,vehicleId,Position,null,tick);}
        return null;
    }

    private float Curve(float time)
    {
        time-=MathF.Floor(time);var keys=binding.RotationProfile;
        int upper=1;while(upper<keys.Count-1&&time>=keys[upper].Time)upper++;
        var a=keys[upper-1];var b=keys[upper];float length=b.Time-a.Time;
        float t=(time-a.Time)/length,t2=t*t,t3=t2*t;
        return (2*t3-3*t2+1)*a.Value+(t3-2*t2+t)*a.OutTangent*length+
            (-2*t3+3*t2)*b.Value+(t3-t2)*b.InTangent*length;
    }
}
