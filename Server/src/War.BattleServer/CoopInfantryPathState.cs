using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Advances one host-owned infantry position along a covered co-op corridor.
/// EnemyController.SetFinalTarget reserves its point and resumes a Unity
/// NavMeshAgent with zero stopping distance. This state supplies the fixed-step
/// route clock; it does not claim to reproduce Unity avoidance or animation.
/// </summary>
public sealed class CoopInfantryPathState
{
    private readonly IReadOnlyList<Vector3> points;
    private readonly float speed;
    private readonly double routeLength;
    private readonly ulong startTick;

    public CoopInfantryPathState(ArmyNavMeshCorridor corridor,
        float movementSpeed, ulong firstTick)
    {
        ArgumentNullException.ThrowIfNull(corridor);
        if (!corridor.PlanarCovered || corridor.SmoothedPoints.Count < 2 ||
            !float.IsFinite(corridor.SmoothedLength) ||
            corridor.SmoothedLength <= 0)
            throw new InvalidDataException("Infantry route is not a covered corridor.");
        if (!float.IsFinite(movementSpeed) || movementSpeed <= 0 ||
            movementSpeed > 100)
            throw new ArgumentOutOfRangeException(nameof(movementSpeed));

        foreach (Vector3 point in corridor.SmoothedPoints)
        {
            if (!PlayerHitbox.Finite(point))
                throw new InvalidDataException("Infantry route has an invalid point.");
        }

        points = Array.AsReadOnly(corridor.SmoothedPoints.ToArray());
        routeLength = PathLength(points);
        if (!double.IsFinite(routeLength) || routeLength <= 0 ||
            Math.Abs(routeLength - corridor.SmoothedLength) > 0.01)
            throw new InvalidDataException("Infantry route length does not match its points.");
        speed = movementSpeed;
        startTick = firstTick;
    }

    public Vector3 PositionAt(ulong tick)
    {
        if (tick <= startTick)
            return points[0];

        double distance = (double)(tick - startTick) * speed /
            MatchManifest.TickRate;
        for (int index = 1; index < points.Count; index++)
        {
            Vector3 from = points[index - 1];
            Vector3 to = points[index];
            float length = Vector3.Distance(from, to);
            if (length <= 0)
                continue;
            if (distance <= length)
                return Vector3.Lerp(from, to, (float)(distance / length));
            distance -= length;
        }

        return points[^1];
    }

    public bool HasArrived(ulong tick)
    {
        if (tick <= startTick)
            return false;
        double distance = (double)(tick - startTick) * speed /
            MatchManifest.TickRate;
        return distance >= routeLength;
    }

    public float SecondsSinceStart(ulong tick) =>
        tick <= startTick ? 0 :
        (float)((double)(tick - startTick) / MatchManifest.TickRate);

    public Vector3 PlanarDirectionAt(ulong tick)
    {
        double distance = tick <= startTick ? 0 :
            (double)(tick - startTick) * speed / MatchManifest.TickRate;
        Vector3 lastDirection = Vector3.Zero;
        for (int index = 1; index < points.Count; index++)
        {
            Vector3 segment = points[index] - points[index - 1];
            float length = segment.Length();
            var planar = new Vector3(segment.X, 0, segment.Z);
            if (planar.LengthSquared() > 0.000001f)
                lastDirection = Vector3.Normalize(planar);
            if (distance <= length && lastDirection != Vector3.Zero)
                return lastDirection;
            distance -= length;
        }
        return lastDirection;
    }

    private static double PathLength(IReadOnlyList<Vector3> route)
    {
        double total = 0;
        for (int index = 1; index < route.Count; index++)
            total += Vector3.Distance(route[index - 1], route[index]);
        return total;
    }
}
