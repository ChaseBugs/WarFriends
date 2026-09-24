using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Fixed-tick infantry motion over a source-bound corridor. It owns published
/// covered-Rusher positions, but Unity NavMeshAgent avoidance and corner
/// steering still need broader comparison before combat collision uses them.
/// </summary>
public sealed class ArmyNavMeshMotionState
{
    internal readonly record struct Checkpoint(float Traveled,float Speed,Vector3 Position);
    private readonly IReadOnlyList<Vector3> points;
    private readonly float[] cumulative;
    private float maximumSpeed;
    private readonly float acceleration;
    private float traveled;
    private float speed;

    public Vector3 Position { get; private set; }
    public float Speed => speed;
    public float Traveled => traveled;
    public float Length => cumulative[^1];
    public bool Arrived => PlanarDistance(Position,points[^1])<.04f;
    public Vector2 PlanarDirection
    {
        get
        {
            if(Arrived)return Vector2.Zero;
            int segment=1;
            while(segment<cumulative.Length-1 && traveled>=cumulative[segment])segment++;
            var delta=new Vector2(points[segment].X-points[segment-1].X,
                points[segment].Z-points[segment-1].Z);
            return delta.LengthSquared()>1e-8f ? Vector2.Normalize(delta) : Vector2.Zero;
        }
    }

    internal Checkpoint Capture()=>new(traveled,speed,Position);
    internal void Restore(Checkpoint checkpoint)
    {traveled=checkpoint.Traveled;speed=checkpoint.Speed;Position=checkpoint.Position;}

    public ArmyNavMeshMotionState(ArmyNavMeshCorridor route,ArmyAgentConfig agent,
        float effectiveSpeed)
    {
        ArgumentNullException.ThrowIfNull(route);
        ArgumentNullException.ThrowIfNull(agent);
        if(!route.PlanarCovered || route.SmoothedPoints.Count<2 ||
           !float.IsFinite(effectiveSpeed) || effectiveSpeed<=0 || effectiveSpeed>20 ||
           !float.IsFinite(agent.Acceleration) || agent.Acceleration<=0 ||
           agent.Acceleration>100)
            throw new InvalidDataException("Invalid source-bound infantry motion inputs.");
        points=route.SmoothedPoints;
        cumulative=new float[points.Count];
        for(int i=1;i<points.Count;i++)
        {
            float segment=PlanarDistance(points[i-1],points[i]);
            if(!float.IsFinite(segment))throw new InvalidDataException("Non-finite infantry corridor.");
            cumulative[i]=cumulative[i-1]+segment;
        }
        if(!float.IsFinite(cumulative[^1]) || cumulative[^1]<=.04f || cumulative[^1]>10000)
            throw new InvalidDataException("Infantry corridor has invalid planar length.");
        Position=points[0];maximumSpeed=effectiveSpeed;acceleration=agent.Acceleration;
    }

    public void AdvanceTick()
    {
        if(Arrived)return;
        const float step=1f/MatchManifest.TickRate;
        float remaining=Length-traveled;
        // This braking acceleration is a measured candidate, not a Unity
        // NavMeshAgent source constant. It remains outside live authority.
        float brakingSpeed=MathF.Sqrt(3f*remaining);
        speed=MathF.Min(MathF.Min(maximumSpeed,speed+acceleration*step),brakingSpeed);
        traveled=MathF.Min(Length,traveled+speed*step);
        if(!float.IsFinite(traveled))throw new InvalidDataException("Invalid infantry motion progress.");
        int segment=1;
        while(segment<cumulative.Length-1 && traveled>cumulative[segment])segment++;
        float length=cumulative[segment]-cumulative[segment-1];
        float ratio=length>0 ? (traveled-cumulative[segment-1])/length : 1f;
        Position=Vector3.Lerp(points[segment-1],points[segment],Math.Clamp(ratio,0,1));
    }

    internal void SetMaximumSpeed(float value)
    {
        if(!float.IsFinite(value)||value<=0||value>20)
            throw new InvalidDataException("Invalid infantry speed override.");
        maximumSpeed=value;
    }

    private static float PlanarDistance(Vector3 a,Vector3 b)
        =>Vector2.Distance(new(a.X,a.Z),new(b.X,b.Z));
}
