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
    private Quaternion flightHeading;

    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }
    internal Quaternion Rotation { get; private set; } = Quaternion.Identity;
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
        // Spawn assigns mFlyRot toward the join point. The prefab's root
        // transform itself remains at its serialized identity rotation.
        flightHeading = PlanarHeading(waypoints[TargetIndex].Position - Position);
    }

    internal void Advance(float time, float deltaTime, Vector3? lookTarget = null)
    {
        if (!float.IsFinite(time) || time < lastTime || time < 0 ||
            !float.IsFinite(deltaTime) || deltaTime <= 0 || deltaTime > 0.2f ||
            (lookTarget.HasValue && !PlayerHitbox.Finite(lookTarget.Value)))
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
        if (lookTarget.HasValue)
            flightHeading = PlanarHeading(lookTarget.Value - Position);
        Quaternion desiredRotation = ComputeRotation(Velocity, flightHeading);
        Rotation = Quaternion.Normalize(Quaternion.Slerp(Rotation, desiredRotation,
            Math.Clamp(deltaTime * 3f, 0, 1)));
        if (!float.IsFinite(Rotation.LengthSquared()) ||
            Math.Abs(Rotation.LengthSquared() - 1) > 0.001f)
            throw new InvalidDataException("Assault Helicopter rotation lost its source bounds.");
        lastTime = time;
    }

    private static Quaternion PlanarHeading(Vector3 direction)
    {
        direction.Y = 0;
        if (direction.LengthSquared() < 1e-10f) return Quaternion.Identity;
        return Quaternion.CreateFromAxisAngle(Vector3.UnitY,
            MathF.Atan2(direction.X, direction.Z));
    }

    private static Quaternion ComputeRotation(Vector3 velocity, Quaternion heading)
    {
        if (velocity.LengthSquared() < 1e-10f) return heading;
        float verticalCosine = Vector3.Dot(Vector3.UnitY, Vector3.Normalize(velocity));
        float angleFromUp = MathF.Acos(Math.Clamp(verticalCosine, -1, 1)) * 180f / MathF.PI;
        if (angleFromUp < 70f || angleFromUp > 110f) return heading;

        Vector3 forward = new(velocity.X, 0, velocity.Z);
        if (forward.LengthSquared() < 1e-10f) return heading;
        forward = Vector3.Normalize(forward);
        Vector3 headingForward = Vector3.Transform(Vector3.UnitZ, heading);
        headingForward.Y = 0;
        float signedAngle = MathF.Atan2(
            Vector3.Dot(Vector3.UnitY, Vector3.Cross(forward, headingForward)),
            Vector3.Dot(forward, headingForward));
        Vector3 pitchedForward = new(forward.X, -0.3f, forward.Z);
        return Quaternion.Normalize(HelicopterOrientationState.LookRotation(pitchedForward) *
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, signedAngle));
    }
}
