using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, CoopHelicopterExitTarget> _transportCrewExits = new();
    private readonly Dictionary<ulong, CoopHelicopterFallbackRetry> _transportCrewRetries = new();

    internal CoopHelicopterExitTarget? TransportCrewExit(ulong actorId)
    {
        return _transportCrewExits.GetValueOrDefault(actorId);
    }

    /// <summary>Executes one source completion callback from the accepted native descent frame.</summary>
    internal CoopHelicopterExitTarget CompleteTransportCrewDescent(
        ulong actorId, HelicopterCrewRetryObservation clock)
    {
        TransportCrewActorState actor = RequireCrewCallback(actorId, clock);
        if (_crewExitSpawns == null || _transportCrewExits.ContainsKey(actorId) ||
            !_transportCrewDescents.TryGetValue((actor.AircraftId, actor.Slot), out TransportCrewDescentOwner? owner) ||
            !owner.Snapshot.Pose.AnimationComplete || owner.Snapshot.RenderFrame != clock.Frame ||
            owner.Snapshot.Pose.Position != clock.Position)
        {
            throw new InvalidOperationException("Crew completion requires its unconsumed accepted descent result.");
        }

        // Validate the wait origin before selecting or reserving any point.
        var retry = new CoopHelicopterFallbackRetry(actorId, enemyDestinations!, clock);
        CoopHelicopterExitTarget target = enemyDestinations!.ResolveHelicopterAssaulterExit(
            actorId, _crewExitSpawns, chooseSpawnPoint);
        if (target is CoopHelicopterEnemyTarget)
        {
            if (!ConfirmTransportCrewSeatReleased(actorId, tick))
            {
                throw new InvalidDataException("Confirmed crew destination could not release its original seat.");
            }
        }
        else
        {
            // Walking toward a normal spawn does not call SetFinalTarget or release enemyPoint yet.
            _transportCrewExits.Add(actorId, target);
            _transportCrewRetries.Add(actorId, retry);
            RemoveTransportCrewMotion(actor);
            stateRevision++;
        }

        IssueTransportCrewNavigation(actor, clock, target);
        return target;
    }

    /// <summary>Consumes the source scaled wait using a host-observed fallback actor position.</summary>
    internal CoopAssignedEnemyDestination? AdvanceTransportCrewRetry(
        ulong actorId, HelicopterCrewRetryObservation observation)
    {
        TransportCrewActorState actor = RequireCrewCallback(actorId, observation);
        if (!_transportCrewRetries.TryGetValue(actorId, out CoopHelicopterFallbackRetry? retry))
        {
            throw new InvalidOperationException("Crew actor has no pending fallback retry.");
        }

        CoopAssignedEnemyDestination? destination = retry.Advance(observation);
        if (destination != null && !ConfirmTransportCrewSeatReleased(actorId, tick))
        {
            throw new InvalidDataException("Crew retry reserved a point without releasing its source seat.");
        }
        if (destination != null)
        {
            IssueTransportCrewNavigation(actor, observation, new CoopHelicopterEnemyTarget(destination));
        }

        return destination;
    }

    private TransportCrewActorState RequireCrewCallback(ulong actorId, HelicopterCrewRetryObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (phase != BattlePhase.Running || tick >= mission.DeadlineTick || enemyDestinations == null ||
            TransportRopeSnapshot?.RenderFrames != observation.Frame ||
            !float.IsFinite(observation.ScaledTime) || observation.ScaledTime < 0 ||
            !PlayerHitbox.Finite(observation.Position) ||
            !_transportCrewActors.TryGetValue(actorId, out TransportCrewActorState? actor))
        {
            throw new InvalidOperationException(
                "Crew callback requires the current host frame and bound destinations.");
        }

        RequireLiveAttachedTransportCrew(actor.AircraftId, actor.Slot, actorId);
        return actor;
    }

    private void CancelTransportCrewRetry(ulong actorId)
    {
        if (_transportCrewRetries.Remove(actorId, out CoopHelicopterFallbackRetry? retry))
        {
            retry.Cancel();
        }
    }
}
