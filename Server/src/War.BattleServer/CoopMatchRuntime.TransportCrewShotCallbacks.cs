namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Observes a host preparation outcome without treating it as target, round or damage authority.</summary>
    internal TransportCrewObstacleClock.ShotCallbackTicket? ObserveTransportCrewPreparation(
        TransportCrewNavigationCommand command, TransportCrewObstacleObservation pending,
        TransportCrewPreparationObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        ArgumentNullException.ThrowIfNull(pending);
        ArgumentNullException.ThrowIfNull(pending.Clock);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, pending.Clock.Frame);
        if (!ReferenceEquals(owner.PendingObstacleObservation, pending) ||
            !Enum.IsDefined(observation.Outcome) || !float.IsFinite(observation.CoroutineTime) ||
            observation.CoroutineTime < 0)
        {
            throw new InvalidOperationException(
                "Preparation observation requires its pending source callback and clocks.");
        }
        TransportCrewObstacleClock clock = owner.ObstacleClock!;
        clock.RequireShotPreparation(pending.Clock);
        bool prepared = observation.Outcome == TransportCrewObstacleClock.PreparationOutcome.Prepared;
        float? clipLength = prepared ? (enemyPoses?.Clip("stand_up_begin").Length ??
            throw new InvalidDataException("Crew preparation lacks its recovered animation length.")) : null;
        var timing = new TransportCrewObstacleClock.PreparationTiming(
            observation.Outcome, observation.CoroutineTime, clipLength);
        ArmyBaseShotStats shot = CrewShotStats(command);
        // GenerateNextShootTime occurs within PrepareToShoot/Shoot; the 2–3 second draw follows its return.
        float? shotFraction = observation.Outcome == TransportCrewObstacleClock.PreparationOutcome.CannotShoot
            ? null : chooseInfantryShotFraction();
        var draws = new TransportCrewObstacleClock.PreparationDraws(shotFraction, chooseInfantryRepositionFraction());
        TransportCrewObstacleClock.ShotCallbackTicket? ticket = clock.ObservePreparation(
            pending.Clock, timing, shot, draws);
        owner.PendingObstacleObservation = null;
        return ticket;
    }

    internal void ObserveTransportCrewShotStarted(TransportCrewNavigationCommand command,
        TransportCrewObstacleClock.ShotCallbackTicket ticket, TransportCrewObstacleClock.ShotObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        owner.ObstacleClock!.ObserveShotStarted(ticket, observation);
    }

    internal void ObserveTransportCrewShotEnded(TransportCrewNavigationCommand command,
        TransportCrewObstacleClock.ShotCallbackTicket ticket, TransportCrewObstacleClock.ShotObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        TransportCrewObstacleClock clock = owner.ObstacleClock!;
        clock.RequireShotEnd(ticket, observation);
        ArmyBaseShotStats shot = CrewShotStats(command);
        clock.ObserveShotEnded(ticket, observation, shot, chooseInfantryShotFraction());
    }

    internal TransportCrewObstacleSnapshot? TransportCrewObstacleState(TransportCrewNavigationCommand command)
    {
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            owner.ObstacleClock is not TransportCrewObstacleClock clock)
        {
            return null;
        }
        return new TransportCrewObstacleSnapshot
        {
            IsCrawling = clock.IsCrawling,
            HasPendingVolley = clock.HasPendingVolley,
            IsShooting = clock.IsShooting,
            NextShootTime = clock.NextShootTime,
            NextRepositionTime = clock.NextRepositionTime,
            NextEnemyChangeTime = clock.NextEnemyChangeTime,
        };
    }

    private TransportCrewNavigationOwner RequireCrewShotOwner(TransportCrewNavigationCommand command, ulong frame)
    {
        if (!IsTransportCrewNavigationCurrent(command) || TransportRopeSnapshot?.RenderFrames != frame ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !owner.HasBegun || owner.ObstacleClock == null)
        {
            throw new InvalidOperationException(
                "Crew shot observation requires its live owner and current native frame.");
        }
        CoopAssignedEnemyDestination? destination = enemyDestinations?.ForEnemy(command.ActorEntityId);
        if (destination == null || destination.PointComponentFileId != command.PointComponentFileId ||
            destination.Position != command.Destination)
        {
            throw new InvalidDataException("Crew shot observation lost its current source point.");
        }
        return owner;
    }

    private ArmyBaseShotStats CrewShotStats(TransportCrewNavigationCommand command)
    {
        int parentLevel = enemySpawns.Single(row => row.EntityId == command.OriginalAircraftId).Level;
        return combat.TransportCrewShot(parentLevel);
    }

    internal sealed record TransportCrewPreparationObservation(
        TransportCrewObstacleClock.PreparationOutcome Outcome, float CoroutineTime);

    /// <summary>Observed source clock/flag state only; not evidence of emitted rounds or successful combat.</summary>
    internal sealed record TransportCrewObstacleSnapshot
    {
        internal required bool IsCrawling { get; init; }
        internal required bool HasPendingVolley { get; init; }
        internal required bool IsShooting { get; init; }
        internal required float NextShootTime { get; init; }
        internal required float NextRepositionTime { get; init; }
        internal required float NextEnemyChangeTime { get; init; }
    }
}
