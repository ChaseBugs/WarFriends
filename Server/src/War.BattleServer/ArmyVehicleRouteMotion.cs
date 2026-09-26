using System.Numerics;

namespace War.BattleServer;

/// <summary>Fixed-tick host traversal of one source SpawnPointCar waypoint list.</summary>
public sealed class ArmyVehicleRouteMotion
{
    private readonly IReadOnlyList<Vector3> points;
    private readonly float distancePerTick;
    private int next;
    public int CircuitFileId { get; }
    public Vector3 Position { get; private set; }
    public bool Arrived { get; private set; }

    internal ArmyVehicleRouteMotion(Vector3 start,ArmyVehicleRoute route,float sourceSpeed)
    {
        ArgumentNullException.ThrowIfNull(route);
        if(!PlayerHitbox.Finite(start)||!float.IsFinite(sourceSpeed)||sourceSpeed<=0||sourceSpeed>20||
           route.Positions.Count<2||route.SmoothRoute||route.IsLoop)
            throw new InvalidDataException("Invalid source vehicle motion authority.");
        Position=start;points=route.Positions;CircuitFileId=route.CircuitFileId;
        distancePerTick=sourceSpeed/MatchManifest.TickRate;
    }

    internal void AdvanceTick()
    {
        if(Arrived)return;
        float remaining=distancePerTick;
        while(remaining>0&&!Arrived)
        {
            Vector3 delta=points[next]-Position;
            float distance=delta.Length();
            if(!float.IsFinite(distance))throw new InvalidDataException("Invalid vehicle route distance.");
            if(distance<=remaining+.000001f)
            {
                Position=points[next++];remaining=Math.Max(0,remaining-distance);
                Arrived=next==points.Count;
            }
            else
            {
                Position+=delta/distance*remaining;remaining=0;
            }
        }
    }
}
