using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float MinimumPathMotorLength = 0.04f;
    private readonly ArmyAgentConfig? _transportCrewAgent;

    /// <summary>Starts a covered path from the descent root, without claiming Unity avoidance fidelity.</summary>
    internal bool TryBeginTransportCrewMotor(TransportCrewNavigationCommand command)
    {
        if (!IsTransportCrewNavigationCurrent(command) || _transportLandingNavigation == null ||
            _transportCrewAgent == null ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out var owner) ||
            !owner.HasBegun || owner.HasPathMotor || owner.Arrival != null || owner.PointEntry != null)
        {
            return false;
        }
        ArmyNavMeshCorridor? route = _transportLandingNavigation.PlanCorridor(missionCatalog,
            manifest.MissionIndex!.Value, command.StartPosition, command.Destination);
        if (route is not { PlanarCovered: true } || route.SmoothedPoints.Count < 2 ||
            route.SmoothedPoints[0] != command.StartPosition || route.SmoothedPoints[^1] != command.Destination)
        {
            // Do not silently teleport a descent root or substitute a different point to obtain a route.
            return false;
        }
        float planarLength = 0;
        for (int index = 1; index < route.SmoothedPoints.Count; index++)
        {
            Vector3 segment = route.SmoothedPoints[index] - route.SmoothedPoints[index - 1];
            planarLength += new Vector2(segment.X, segment.Z).Length();
        }
        if (planarLength > MinimumPathMotorLength)
        {
            owner.PathMotor = new ArmyNavMeshMotionState(route, _transportCrewAgent, command.MaximumSpeed);
        }
        owner.HasPathMotor = true;
        owner.PathMotorTick = tick;
        return true;
    }

    /// <summary>Advances one host tick and feeds its generated root into the existing source arrival policy.</summary>
    internal TransportCrewMotorSample AdvanceTransportCrewMotor(TransportCrewNavigationCommand command,
        TransportCrewMotorObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (!IsTransportCrewNavigationCurrent(command) || TransportRopeSnapshot?.RenderFrames != observation.Frame ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out var owner) || !owner.HasBegun ||
            !owner.HasPathMotor || owner.PathMotorTick == ulong.MaxValue ||
            tick != owner.PathMotorTick + 1 || owner.Arrival != null || owner.PointEntry != null ||
            (_transportCrewWalkingFrames.TryGetValue(command.ActorEntityId, out ulong walkingFrame) &&
                observation.Frame <= walkingFrame))
        {
            throw new InvalidOperationException(
                "Crew path motor requires its live owner and consecutive native ticks.");
        }
        CoopAssignedEnemyDestination? destination = enemyDestinations?.ForEnemy(command.ActorEntityId);
        if (command.PointComponentFileId.HasValue &&
            (destination?.PointComponentFileId != command.PointComponentFileId ||
                destination.Position != command.Destination))
        {
            throw new InvalidOperationException("Crew path motor lost its authored point reservation.");
        }
        ArmyNavMeshMotionState? motor = owner.PathMotor;
        Vector3 previousPosition = motor?.Position ?? command.StartPosition;
        Vector2 direction = motor?.PlanarDirection ?? Vector2.Zero;
        if (direction != Vector2.Zero)
        {
            owner.PathMotorFacing = new Vector3(direction.X, 0, direction.Y);
        }
        // Zero stopping distance keeps advancing until the source XZ arrival test accepts this authored point.
        motor?.AdvanceToRouteEndTick();
        owner.PathMotorTick = tick;
        Vector3 position = motor?.Position ?? command.StartPosition;
        Vector3 velocity = (position - previousPosition) * MatchManifest.TickRate;
        var walk = new TransportCrewWalkObservation(observation.Frame, position, observation.IsPreparingShot);
        TransportCrewPointArrival? arrival = ObserveTransportCrewWalk(command, walk);
        return new TransportCrewMotorSample(tick, position, owner.PathMotorFacing, velocity, arrival);
    }

    internal sealed record TransportCrewMotorObservation(ulong Frame, bool IsPreparingShot);

    /// <summary>Host corridor motion; facing is a path estimate, not authoritative collision rotation.</summary>
    internal sealed record TransportCrewMotorSample(ulong Tick, Vector3 Position, Vector3? PathFacing,
        Vector3 Velocity, TransportCrewPointArrival? Arrival);
}
