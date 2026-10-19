using System.Numerics;
namespace War.BattleServer;

// Recovered Helicopter.Update/Steer translation and stop trigger. Rendering,
// rotation, rope, crew deployment and combat remain separate integration gates.
internal sealed class HelicopterWaypointState
{
    private const float NormalTimeScale = 1f;
    private const float MillisecondsPerSecond = 1000f;
    private const float MaximumSteeringDelta = 1f;
    private const float SourceBrakingDistance = 6f;
    private const float SourceBrakingSpeed = 2f;
    private const float SourceMass = 150f;
    private const float SourceBrakingMass = 30f;
    private const float SourceStopDistance = 1f;
    private readonly DroneWaypoint[] points;
    private readonly float radius,speed;
    private readonly bool loop;
    private float lastRealtime,residual;
    private bool timeStarted;
    internal int TargetIndex {get;private set;}
    internal Vector3 Position {get;private set;}
    internal Vector3 Velocity {get;private set;}
    internal Vector3 Steering {get;private set;}
    internal Vector3 TargetPosition=>points[TargetIndex].Position;
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
        return Advance(realtime, NormalTimeScale);
    }

    // Source Steer uses realtime; only the final Transform translation uses Time.timeScale.
    internal bool Advance(float realtime, float timeScale)
    {
        if (!float.IsFinite(realtime) || realtime < 0 || (timeStarted && realtime < lastRealtime) ||
            !float.IsFinite(timeScale) || timeScale < 0)
        {
            throw new InvalidDataException("Invalid Helicopter realtime authority.");
        }
        (float deltaTime, float nextResidual) = PrepareRealtime(realtime);
        int nextIndex = PrepareTargetIndex();
        Vector3 stop = points[routeStopIndex].Position;
        float distance = Vector3.Distance(stop, Position);
        bool isBraking = distance < SourceBrakingDistance;
        Vector3 desired = DesiredVelocity(nextIndex, deltaTime, distance);
        Vector3 steering = (desired - Velocity) / (isBraking ? SourceBrakingMass : SourceMass);
        Vector3 nextVelocity = Velocity + steering;
        Vector3 nextPosition = Position + nextVelocity * timeScale;
        if (!PlayerHitbox.Finite(nextVelocity) || !PlayerHitbox.Finite(nextPosition) || !float.IsFinite(nextResidual))
        {
            throw new InvalidDataException("Helicopter motion overflow.");
        }
        bool hasArrived = isBraking && distance < SourceStopDistance && !StopReached;
        Position = nextPosition;
        Velocity = nextVelocity;
        Steering = steering;
        TargetIndex = nextIndex;
        Breaking = isBraking;
        StopReached |= hasArrived;
        residual = nextResidual;
        lastRealtime = realtime;
        timeStarted = true;
        return hasArrived;
    }

    private (float DeltaTime, float Residual) PrepareRealtime(float realtime)
    {
        if (!timeStarted)
        {
            return (0, residual);
        }
        float nextResidual = residual + (realtime - lastRealtime);
        float deltaTime = MathF.Round(nextResidual * MillisecondsPerSecond) / MillisecondsPerSecond;
        nextResidual -= deltaTime;
        return (Math.Min(deltaTime, MaximumSteeringDelta), nextResidual);
    }

    private int PrepareTargetIndex()
    {
        int nextIndex = TargetIndex;
        if (Vector3.Distance(Position, points[nextIndex].Position) < radius)
        {
            if (nextIndex < points.Length - 1)
            {
                nextIndex++;
            }
            else if (loop)
            {
                nextIndex = 0;
            }
        }
        return nextIndex;
    }

    private Vector3 DesiredVelocity(int targetIndex, float deltaTime, float distanceToStop)
    {
        bool isBraking = distanceToStop < SourceBrakingDistance;
        Vector3 destination = isBraking ? points[routeStopIndex].Position : points[targetIndex].Position;
        Vector3 direction = destination - Position;
        if (direction.LengthSquared() == 0)
        {
            return Vector3.Zero;
        }
        float desiredSpeed = isBraking
            ? SourceBrakingSpeed * deltaTime * (distanceToStop / SourceBrakingDistance)
            : speed * deltaTime;
        return Vector3.Normalize(direction) * desiredSpeed;
    }
    private readonly int routeStopIndex;
}
