using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const string SourceCrewBehaviour = "Assaulter";
    private const float SourceCrewStoppingDistance = 0f;
    private const float MaximumCrewMovementSpeed = 100f;

    private readonly Dictionary<ulong, TransportCrewNavigationOwner> _transportCrewNavigation = new();
    private readonly Dictionary<ulong, NavigationAgentRecoveryState> _transportCrewAgentRecovery = new();

    internal TransportCrewNavigationCommand? TransportCrewNavigation(ulong actorId)
    {
        return _transportCrewNavigation.TryGetValue(actorId, out TransportCrewNavigationOwner? owner)
            ? owner.Command : null;
    }

    /// <summary>Claims the current host-issued navigation handoff once, without creating a walking pose.</summary>
    internal bool BeginTransportCrewNavigation(TransportCrewNavigationCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            owner.HasBegun || TransportRopeSnapshot is not HelicopterPhysicsWorldSnapshot physics ||
            physics.RenderFrames < command.IssuedRenderFrame || physics.PhysicsSteps < command.IssuedPhysicsSequence)
        {
            return false;
        }

        owner.HasBegun = true;
        return true;
    }

    /// <summary>Lets a future host motor reject a cancelled or superseded handoff before each update.</summary>
    internal bool IsTransportCrewNavigationCurrent(TransportCrewNavigationCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        return phase == BattlePhase.Running && tick < mission.DeadlineTick &&
            _transportCrewActors.TryGetValue(command.ActorEntityId, out TransportCrewActorState? actor) &&
            actor.Health > 0 && _transportCrewNavigation.TryGetValue(command.ActorEntityId, out var owner) &&
            ReferenceEquals(owner.Command, command);
    }

    private void IssueTransportCrewNavigation(TransportCrewActorState actor,
        HelicopterCrewRetryObservation observation, CoopHelicopterExitTarget target)
    {
        Vector3 destination = target switch
        {
            CoopHelicopterEnemyTarget point => point.Destination.Position,
            CoopHelicopterFallbackTarget fallback => fallback.Spawn.Position,
            _ => throw new InvalidDataException("Unknown source crew navigation target."),
        };
        float speed = combat.MovementSpeed(SourceCrewBehaviour);
        if (!PlayerHitbox.Finite(destination) || !float.IsFinite(speed) ||
            speed <= 0 || speed > MaximumCrewMovementSpeed)
        {
            throw new InvalidDataException("Crew navigation lost its source destination or movement speed.");
        }

        HelicopterPhysicsWorldSnapshot physics = TransportRopeSnapshot ??
            throw new InvalidOperationException("Crew navigation requires its current native frame.");
        var command = new TransportCrewNavigationCommand
        {
            ActorEntityId = actor.EntityId,
            OriginalAircraftId = actor.AircraftId,
            IssuedTick = tick,
            IssuedRenderFrame = observation.Frame,
            IssuedPhysicsSequence = physics.PhysicsSteps,
            StartPosition = observation.Position,
            Destination = destination,
            MaximumSpeed = speed,
            PointComponentFileId = target is CoopHelicopterEnemyTarget assigned
                ? assigned.Destination.PointComponentFileId : null,
        };
        _transportCrewNavigation[actor.EntityId] = new TransportCrewNavigationOwner(command);
        _transportCrewAgentRecovery.TryAdd(actor.EntityId, new NavigationAgentRecoveryState());
    }

    /// <summary>Accepts one real host wrapper callback; native movement and avoidance remain producer-owned.</summary>
    internal NavigationAgentRecoveryState.Recovery? ObserveTransportCrewNavigationAgent(
        TransportCrewNavigationCommand command, NavigationAgentRecoveryState.Observation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !owner.HasBegun || TransportRopeSnapshot?.RenderFrames != observation.Frame ||
            !_transportCrewAgentRecovery.TryGetValue(command.ActorEntityId, out NavigationAgentRecoveryState? state))
        {
            throw new InvalidOperationException("Agent callback requires current begun navigation and its host frame.");
        }

        return state.Observe(observation);
    }

    private void RetireTransportCrewNavigation(ulong actorId)
    {
        _transportCrewNavigation.Remove(actorId);
    }

    private sealed class TransportCrewNavigationOwner
    {
        internal TransportCrewNavigationOwner(TransportCrewNavigationCommand command)
        {
            Command = command;
        }

        internal TransportCrewNavigationCommand Command { get; }

        internal bool HasBegun { get; set; }

        internal TransportCrewPointArrival? Arrival { get; set; }

        internal TransportCrewPointEntry? PointEntry { get; set; }

        internal TransportCrewObstacleClock? ObstacleClock { get; set; }

        internal TransportCrewObstacleObservation? PendingObstacleObservation { get; set; }

        internal float? NextWalkingShotTime { get; set; }

        internal bool CrewTargetChoiceAttempted { get; set; }

        internal CrewPlayerTargetChoice? CrewTargetChoice { get; set; }

        internal TransportCrewTargetPlan? AcquiredCrewTarget { get; set; }

        internal TransportCrewPreparedShot? PreparedCrewShot { get; set; }

        internal TransportCrewRifleVolley? CrewRifleVolley { get; set; }
    }

    /// <summary>Immutable navigation input; it does not assert a simulated pose, arrival or combat readiness.</summary>
    internal sealed record TransportCrewNavigationCommand
    {
        internal required ulong ActorEntityId { get; init; }
        internal required ulong OriginalAircraftId { get; init; }
        internal required ulong IssuedTick { get; init; }
        internal required ulong IssuedRenderFrame { get; init; }
        internal required ulong IssuedPhysicsSequence { get; init; }
        internal required Vector3 StartPosition { get; init; }
        internal required Vector3 Destination { get; init; }
        internal required float MaximumSpeed { get; init; }
        internal int? PointComponentFileId { get; init; }
        internal float StoppingDistance => SourceCrewStoppingDistance;
    }
}
