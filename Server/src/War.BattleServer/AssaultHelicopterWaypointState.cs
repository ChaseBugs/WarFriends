using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// The recovered AssaultHelicopter follows one reserved air path. Its Update
/// applies the same steering velocity to the root transform twice per frame.
/// </summary>
internal sealed class AssaultHelicopterWaypointState
{
    private readonly IReadOnlyList<DroneWaypoint> waypoints;
    private readonly float radius;
    private readonly float speed;
    private readonly Func<float> nextRandom;
    private float lastTime;
    private float pointReachedTime;

    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }
    internal int TargetIndex { get; private set; }
    internal bool Forward { get; private set; } = true;
    internal bool UsingWaypoints { get; private set; } = true;

    internal AssaultHelicopterWaypointState(AirWaypointRoute route, Vector3 spawnPosition,
        float sourceSpeed, Func<float> nextRandom)
    {
        if (route == null || route.Waypoints == null || route.StopIndex != -1 ||
            route.Waypoints.Count is < 1 or > 100 ||
            route.JoinIndex < 0 || route.JoinIndex >= route.Waypoints.Count ||
            !PlayerHitbox.Finite(spawnPosition) || !float.IsFinite(route.Radius) ||
            route.Radius <= 0 || route.Radius > 100 || !float.IsFinite(sourceSpeed) ||
            sourceSpeed <= 0 || sourceSpeed > 20)
            throw new InvalidDataException("Invalid Assault Helicopter path authority.");
        if (route.Waypoints.Any(point => point == null || point.ComponentFileId <= 0 ||
            !PlayerHitbox.Finite(point.Position)))
            throw new InvalidDataException("Assault Helicopter path contains an invalid waypoint.");

        waypoints = route.Waypoints;
        radius = route.Radius;
        // AssaultHelicopter.UpgradesLoaded clamps the composed speed after
        // UpgradeSlotsGeneric has applied the selected movement perk.
        speed = Math.Clamp(sourceSpeed, 0.2f, 0.6f);
        this.nextRandom = nextRandom ?? throw new ArgumentNullException(nameof(nextRandom));
        TargetIndex = route.JoinIndex;
        Position = spawnPosition;
    }

    internal void Advance(float time, float deltaTime)
    {
        if (!float.IsFinite(time) || time < lastTime || time < 0 ||
            !float.IsFinite(deltaTime) || deltaTime <= 0 || deltaTime > 0.2f)
            throw new InvalidDataException("Invalid Assault Helicopter traversal clock.");

        if (!UsingWaypoints)
        {
            lastTime = time;
            return;
        }

        var currentWaypoint = waypoints[TargetIndex];
        if (Vector3.Distance(Position, currentWaypoint.Position) < radius)
        {
            float randomValue = nextRandom();
            if (!float.IsFinite(randomValue) || randomValue is < 0 or > 1)
                throw new InvalidDataException("Invalid Assault Helicopter direction sample.");

            if (randomValue < 0.1f)
                Forward = !Forward;

            pointReachedTime = time;
            if (Forward && TargetIndex < waypoints.Count - 1)
                TargetIndex++;
            else if (!Forward && TargetIndex > 0)
                TargetIndex--;
            else
            {
                // The recovered prefab has loop=false. Reaching either end
                // stops the path before applying another steering step.
                UsingWaypoints = false;
                lastTime = time;
                return;
            }
        }

        var steering = DroneSteeringStep.Advance(Position, Velocity,
            waypoints[TargetIndex].Position, time, deltaTime, pointReachedTime,
            cornerDelayTime: 0.1f, speed: speed, mass: 1f,
            breakDistance: 1f, breakSpeed: speed);
        Velocity = steering.Velocity;
        Position = steering.Position + Velocity;
        if (!PlayerHitbox.Finite(Position))
            throw new InvalidDataException("Assault Helicopter route escaped scene bounds.");
        lastTime = time;
    }
}
