using System.Numerics;
namespace War.BattleServer;

public sealed record DroneWaypoint(int ComponentFileId,Vector3 Position,float StayTime);

// Source DroneSteering.Update path decisions. Rotation remains a separate gate.
public sealed class DroneWaypointState
{
    private readonly DroneWaypoint[] points;
    private readonly float radius,speed;
    private readonly bool loop;
    private readonly Func<float> random;
    private float stay,reached,lastTime;
    private readonly DroneOrientationState orientation=new();
    public Quaternion Rotation=>orientation.Rotation;
    public int TargetIndex { get; private set; }
    public bool Forward { get; private set; }
    public bool UsingWaypoints { get; private set; }=true;
    public Vector3 Position { get; private set; }
    public Vector3 Velocity { get; private set; }
    public DroneWaypointState(IReadOnlyList<DroneWaypoint> points,int joinIndex,Vector3 position,
        float radius,float speed,bool forward,bool loop,Func<float> random)
    {
        if(points==null||points.Count is <1 or >100||joinIndex<0||joinIndex>=points.Count||
           !Finite(position)||!float.IsFinite(radius)||radius<=0||radius>100||
           !float.IsFinite(speed)||speed<=0||speed>20)
            throw new InvalidDataException("Invalid Drone waypoint authority.");
        this.points=points.ToArray();
        if(this.points.Any(p=>p==null||p.ComponentFileId<=0||!Finite(p.Position)||
            !float.IsFinite(p.StayTime)||p.StayTime<0||p.StayTime>3600)||
            this.points.Select(p=>p.ComponentFileId).Distinct().Count()!=points.Count)
            throw new InvalidDataException("Invalid Drone waypoint definition.");
        this.radius=radius;this.speed=speed;this.loop=loop;
        this.random=random??throw new ArgumentNullException(nameof(random));
        TargetIndex=joinIndex;Position=position;Forward=forward;
    }
    // Returns the source arrival callback's waypoint index, if raised this frame.
    public int? Advance(float time,float deltaTime,bool enabled=true,Vector3? lookTarget=null)
    {
        if(!float.IsFinite(time)||time<lastTime||time<0||!float.IsFinite(deltaTime)||deltaTime<=0||deltaTime>.2f||
           (lookTarget.HasValue&&!Finite(lookTarget.Value)))
            throw new InvalidDataException("Invalid Drone traversal clock.");
        if(!enabled||!UsingWaypoints){lastTime=time;return null;}
        int index=TargetIndex;bool forward=Forward,usingPoints=true;
        float nextStay=stay,nextReached=reached;int? arrival=null;
        if(Vector3.Distance(Position,points[index].Position)<radius)
        {
            bool advance=true;
            if(points[index].StayTime>0)
            {
                if(nextStay==0){nextReached=time;arrival=index;}
                nextStay+=deltaTime;
                if(!float.IsFinite(nextStay))throw new InvalidDataException("Drone stay overflow.");
                if(nextStay<points[index].StayTime)advance=false;
            }
            else{nextReached=time;arrival=index;}
            if(advance)
            {
                nextStay=0;float draw=random();
                if(!float.IsFinite(draw)||draw<0||draw>1)throw new InvalidDataException("Invalid Drone direction sample.");
                if(draw<.1f)forward=!forward;
                if(index<points.Length-1&&forward)index++;
                else if(index!=0&&!forward)index--;
                else if(loop&&forward)index=0;
                else if(!loop||forward)usingPoints=false;
                else index=points.Length-1;
            }
        }
        var motion=usingPoints?DroneSteeringStep.Advance(Position,Velocity,points[index].Position,
            time,deltaTime,nextReached,.5f,speed,80,.6f,.5f):new DroneSteeringStep.Result(Position,Velocity,Vector3.Zero);
        // DroneSteering observes the selected root after movement, not the predicted shot point.
        if(usingPoints)orientation.Advance(motion.Position,motion.Velocity,motion.Steering,deltaTime,lookTarget);
        TargetIndex=index;Forward=forward;UsingWaypoints=usingPoints;
        stay=nextStay;reached=nextReached;lastTime=time;Position=motion.Position;Velocity=motion.Velocity;
        return arrival;
    }
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}
