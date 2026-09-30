using System.Numerics;
namespace War.BattleServer;

// Recovered Helicopter.Update/Steer translation and stop trigger. Rendering,
// rotation, rope, crew deployment and combat remain separate integration gates.
internal sealed class HelicopterWaypointState
{
    private readonly DroneWaypoint[] points;
    private readonly float radius,speed;
    private readonly bool loop;
    private float lastRealtime,residual;
    private bool timeStarted;
    internal int TargetIndex {get;private set;}
    internal Vector3 Position {get;private set;}
    internal Vector3 Velocity {get;private set;}
    internal bool Breaking {get;private set;}
    internal bool StopReached {get;private set;}
    internal HelicopterWaypointState(AirWaypointRoute route,Vector3 position,float speed,bool loop=false)
    {
        ArgumentNullException.ThrowIfNull(route);
        if(route.Waypoints==null||route.Waypoints.Count is <2 or >100||route.JoinIndex<0||
           route.JoinIndex>=route.Waypoints.Count||route.StopIndex<0||route.StopIndex>=route.Waypoints.Count||
           route.StopIndex==route.JoinIndex||route.Waypoints.Any(p=>p==null||p.ComponentFileId<=0||
               !PlayerHitbox.Finite(p.Position)||!float.IsFinite(p.StayTime)||p.StayTime<0)||
           route.Waypoints.Select(p=>p.ComponentFileId).Distinct().Count()!=route.Waypoints.Count||
           !PlayerHitbox.Finite(position)||!float.IsFinite(route.Radius)||route.Radius<=0||route.Radius>100||
           !float.IsFinite(speed)||speed<=0||speed>20)
            throw new InvalidDataException("Invalid Helicopter route authority.");
        points=route.Waypoints.ToArray();TargetIndex=route.JoinIndex;
        Position=position;radius=route.Radius;this.speed=speed;this.loop=loop;routeStopIndex=route.StopIndex;
    }
    // Returns true only on the source's first stop-point arrival callback.
    internal bool Advance(float realtime)
    {
        if(!float.IsFinite(realtime)||realtime<0||(timeStarted&&realtime<lastRealtime))
            throw new InvalidDataException("Invalid Helicopter realtime authority.");
        float dt=0,nextResidual=residual;
        if(timeStarted)
        {
            nextResidual+=realtime-lastRealtime;
            dt=MathF.Round(nextResidual*1000f)/1000f;
            nextResidual-=dt;
            dt=Math.Min(dt,1f);
        }
        int nextIndex=TargetIndex;
        if(Vector3.Distance(Position,points[nextIndex].Position)<radius)
        {
            if(nextIndex<points.Length-1)nextIndex++;
            else if(loop)nextIndex=0;
        }
        var stop=points[routeStopIndex].Position;
        Vector3 target=points[nextIndex].Position-Position;
        float distance=Vector3.Distance(stop,Position);
        bool braking=distance<6f; // Helicopter.prefab breakDistance=6, mass=150.
        Vector3 desired=Vector3.Zero;
        if(braking)
        {
            var toward=stop-Position;
            if(toward.LengthSquared()>0)desired=Vector3.Normalize(toward)*(2f*dt*(distance/6f));
        }
        else if(target.LengthSquared()>0)desired=Vector3.Normalize(target)*(speed*dt);
        Vector3 steering=(desired-Velocity)/(braking?30f:150f);
        Vector3 nextVelocity=Velocity+steering;
        Vector3 nextPosition=Position+nextVelocity;
        if(!PlayerHitbox.Finite(nextVelocity)||!PlayerHitbox.Finite(nextPosition)||!float.IsFinite(nextResidual))
            throw new InvalidDataException("Helicopter motion overflow.");
        bool arrived=braking&&distance<1f&&!StopReached;
        Position=nextPosition;Velocity=nextVelocity;TargetIndex=nextIndex;
        Breaking=braking;StopReached|=arrived;
        residual=nextResidual;lastRealtime=realtime;timeStarted=true;
        return arrived;
    }
    private readonly int routeStopIndex;
}
