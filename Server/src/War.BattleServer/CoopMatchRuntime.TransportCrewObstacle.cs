using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Applies source same-obstacle SetFinalTarget without resetting hidden state or shot deadlines.</summary>
    internal TransportCrewObstacleClock.ActionKind AdvanceTransportCrewObstacle(
        TransportCrewNavigationCommand command, TransportCrewObstacleObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        ArgumentNullException.ThrowIfNull(observation.Clock);
        if (!IsTransportCrewNavigationCurrent(command) || !PlayerHitbox.Finite(observation.Position) ||
            TransportRopeSnapshot?.RenderFrames != observation.Clock.Frame ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !owner.HasBegun || owner.PointEntry is not TransportCrewPointEntry entry ||
            owner.ObstacleClock is not TransportCrewObstacleClock clock)
        {
            throw new InvalidOperationException(
                "Obstacle update requires its current live navigation and hidden entry.");
        }
        CoopAssignedEnemyDestination destination = enemyDestinations?.ForEnemy(command.ActorEntityId) ??
            throw new InvalidDataException("Obstacle crew lost its reserved destination.");
        if (destination.PointComponentFileId != command.PointComponentFileId ||
            destination.Position != command.Destination || enemyDestinations!.PointTypeFor(command.ActorEntityId) !=
                "EnemyPointObstacle")
        {
            throw new InvalidDataException("Obstacle crew navigation no longer matches its source point.");
        }

        TransportCrewObstacleClock.ActionKind action = clock.Select(observation.Clock);
        if (action == TransportCrewObstacleClock.ActionKind.Reposition)
        {
            float deadline = clock.RepositionDeadline(observation.Clock, chooseInfantryRepositionFraction());
            CoopAssignedEnemyDestination replacement = enemyDestinations.RegenerateObstaclePosition(
                command.ActorEntityId) ?? throw new InvalidDataException("Source obstacle could not regenerate.");
            var target = new CoopHelicopterEnemyTarget(replacement);
            var observedRoot = new HelicopterCrewRetryObservation(observation.Clock.Frame,
                observation.Clock.ControllerTime, observation.Position);
            IssueTransportCrewNavigation(_transportCrewActors[command.ActorEntityId], observedRoot, target);
            TransportCrewNavigationOwner replacementOwner = _transportCrewNavigation[command.ActorEntityId];
            replacementOwner.PointEntry = entry;
            replacementOwner.Arrival = owner.Arrival;
            replacementOwner.ObstacleClock = clock;
            _transportCrewExits[command.ActorEntityId] = target;
            clock.Accept(observation.Clock, deadline);
        }
        else
        {
            // Required actions remain explicit: returning one does not execute preparation, shooting or retargeting.
            clock.Accept(observation.Clock);
            if (clock.PendingAction.HasValue)
            {
                owner.PendingObstacleObservation = observation;
                if (clock.PendingAction == TransportCrewObstacleClock.ActionKind.ShotPreparationRequired)
                {
                    owner.CrewTargetChoiceAttempted = false;
                    owner.CrewTargetChoice = null;
                    owner.AcquiredCrewTarget = null;
                    owner.PreparedCrewShot = null;
                }
            }
        }
        return action;
    }

    internal sealed record TransportCrewObstacleObservation(
        TransportCrewObstacleClock.Observation Clock, Vector3 Position);
}
