using System.Numerics;

namespace War.BattleServer;

internal sealed record BazookaMissileImpact(ulong ProjectileId,string OwnerId,Vector3 Position,
    ShotCollision? Collision,ulong Tick,bool Fake);

// Recovered Missile.Update movement at the fixed 30 Hz battle clock. The host
// supplies the two Unity random draws and the alternating curve sign.
internal sealed class BazookaMissileFlight
{
    private readonly ulong id;private readonly string owner;private readonly BazookaBinding binding;
    private readonly Func<Vector3,Vector3,float,ShotCollision?> trace;private readonly bool fake;
    private readonly Vector3 start,end,direction;private Vector3 last,lastUp;
    private readonly float duration,middleRotation,rotations,rotationMagnitude;private ulong tick;
    private float progress;private bool collisionEnabled;
    internal ulong Id=>id;internal string OwnerId=>owner;internal bool Fake=>fake;
    internal ulong CurrentTick=>tick;
    internal Vector3 Position{get;private set;}internal bool Finished{get;private set;}

    internal BazookaMissileFlight(ulong id,string owner,BazookaBinding binding,Vector3 from,Vector3 to,ulong tick,
        bool fake,float middleRoll,float rotationRoll,int curveSign,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if(id==0||!Guid.TryParseExact(owner,"N",out _)||owner!=owner.ToLowerInvariant()||binding==null||
           !PlayerHitbox.Finite(from)||!PlayerHitbox.Finite(to)||Vector3.DistanceSquared(from,to)<1e-10f||tick>10_000_000||
           !float.IsFinite(middleRoll)||middleRoll is <0 or >1||!float.IsFinite(rotationRoll)||rotationRoll is <0 or >1||
           curveSign is not (-1 or 1)||trace==null)throw new InvalidDataException("Invalid bazooka missile launch.");
        this.id=id;this.owner=owner;this.binding=binding;this.tick=tick;this.fake=fake;this.trace=trace;
        start=from;var delta=to-from;if(delta.Length()>50)to=from+Vector3.Normalize(delta)*50;end=to;direction=end-start;
        duration=direction.Length()/binding.Speed;if(!float.IsFinite(duration)||duration<=0||duration>1800)throw new InvalidDataException("Invalid bazooka missile duration.");
        progress=-binding.StopSeconds/duration;Position=last=lastUp=from;
        float scale=MathF.Pow(direction.Length()/10,2);
        middleRotation=curveSign*(60+50*middleRoll);
        rotations=Math.Clamp((binding.RotationRange.X+(binding.RotationRange.Y-binding.RotationRange.X)*rotationRoll)*scale,0,binding.RotationRange.Y*1.2f);
        rotationMagnitude=Math.Clamp(binding.RotationMagnitude*scale,0,.6f);
    }

    internal BazookaMissileImpact? Advance(ulong nextTick)
    {
        if(nextTick!=tick+1||nextTick>10_000_000||Finished)throw new InvalidOperationException("Advance each active bazooka missile exactly once per tick.");
        tick=nextTick;progress+=1f/MatchManifest.TickRate/duration;last=Position;
        float linearProgress=Math.Max(progress,0);var linear=start+direction*linearProgress;var offset=Vector3.Zero;
        if(binding.CurvedTrajectory)
        {
            var vertical=new Vector3(0,MathF.Sin(progress*MathF.PI)*1.6f*rotationMagnitude,0);
            var axis=linear+vertical-lastUp;lastUp=linear+vertical;
            if(axis.LengthSquared()>1e-12f)
            {
                float angle=middleRotation+360*rotations*(progress-.5f);
                var spin=Vector3.Transform(Vector3.UnitY,Quaternion.CreateFromAxisAngle(Vector3.Normalize(axis),angle*MathF.PI/180));
                offset=spin*rotationMagnitude*Curve(progress);
            }
            if(progress>1)vertical*=2;
            offset+=vertical;
        }
        Position=linear+offset;if(!PlayerHitbox.Finite(Position))throw new InvalidDataException("Bazooka trajectory escaped scene bounds.");
        if(collisionEnabled)
        {
            var move=Position-last;float distance=move.Length();
            if(distance>0)
            {
                float range=distance+2f/MatchManifest.TickRate;var hit=trace(last,move,range);
                if(hit!=null)
                {
                    if(!float.IsFinite(hit.Distance)||hit.Distance<0||hit.Distance>range||!PlayerHitbox.Finite(hit.Position))throw new InvalidDataException("Invalid bazooka collision result.");
                    Position=hit.Position;Finished=true;return new(id,owner,Position,hit,tick,fake);
                }
            }
        }
        else if(Vector3.Distance(start,Position)>.5f)collisionEnabled=true;
        if(progress>(binding.CurvedTrajectory?1.5f:3f))
        {Finished=true;return new(id,owner,Position,null,tick,fake);}
        return null;
    }

    private float Curve(float time)
    {
        var keys=binding.RotationProfile;if(keys.Count!=3)throw new InvalidDataException("Incomplete bazooka trajectory curve.");
        time-=MathF.Floor(time);var a=time<keys[1].Time?keys[0]:keys[1];var b=time<keys[1].Time?keys[1]:keys[2];
        float length=b.Time-a.Time,t=(time-a.Time)/length,t2=t*t,t3=t2*t;
        return (2*t3-3*t2+1)*a.Value+(t3-2*t2+t)*a.OutTangent*length+(-2*t3+3*t2)*b.Value+(t3-t2)*b.InTangent*length;
    }
}
