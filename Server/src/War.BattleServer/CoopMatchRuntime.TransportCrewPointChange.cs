namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Consumes a point-change callback bound to its current actor and native frame.</summary>
    internal TransportCrewPointChange.Result ResolveTransportCrewPointChange(TransportCrewNavigationCommand command,
        TransportCrewObstacleObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !owner.HasBegun || !ReferenceEquals(owner.PendingObstacleObservation, observation) ||
            owner.ObstacleClock is not TransportCrewObstacleClock clock ||
            TransportRopeSnapshot?.RenderFrames != observation.Clock.Frame || enemyDestinations == null)
        {
            throw new InvalidOperationException("Point change requires the current exact pending host callback.");
        }
        CoopAssignedEnemyDestination current = enemyDestinations.ForEnemy(command.ActorEntityId) ??
            throw new InvalidDataException("Crew point change lost its current reservation.");
        if (current.PointComponentFileId != command.PointComponentFileId || current.Position != command.Destination)
        {
            throw new InvalidDataException("Crew point change lost its accepted destination.");
        }

        int parentLevel = enemySpawns.Single(row => row.EntityId == command.OriginalAircraftId).Level;
        var coordinator = new TransportCrewPointChange(enemyDestinations, combat, chooseInfantryShotFraction);
        var request = new TransportCrewPointChange.Request(command.ActorEntityId, parentLevel, observation);
        TransportCrewPointChange.Result result = coordinator.Resolve(clock, request);
        if (result.Destination != null)
        {
            var target = new CoopHelicopterEnemyTarget(result.Destination);
            var root = new HelicopterCrewRetryObservation(observation.Clock.Frame,
                observation.Clock.ControllerTime, observation.Position);
            IssueTransportCrewNavigation(_transportCrewActors[command.ActorEntityId], root, target);
            _transportCrewNavigation[command.ActorEntityId].NextWalkingShotTime = result.NextWalkingShotTime;
            _transportCrewExits[command.ActorEntityId] = target;
            // SwitchState(Walk) occurs inside this frame's obstacle update; WalkingUpdate starts next frame.
            _transportCrewWalkingFrames[command.ActorEntityId] = observation.Clock.Frame;
        }
        owner.PendingObstacleObservation = null;
        return result;
    }
}
