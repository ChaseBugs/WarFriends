namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    internal TransportCrewPointEntry? TransportCrewHiddenEntry(TransportCrewNavigationCommand command)
    {
        return IsTransportCrewNavigationCurrent(command) &&
            _transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner)
                ? owner.PointEntry : null;
    }

    /// <summary>Consumes the exact current arrival once and initializes source hidden-state flags and deadlines.</summary>
    internal TransportCrewPointEntry EnterTransportCrewPoint(TransportCrewNavigationCommand command,
        TransportCrewPointArrival arrival, float controllerTime)
    {
        ArgumentNullException.ThrowIfNull(arrival);
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !ReferenceEquals(owner.Arrival, arrival) || owner.PointEntry != null ||
            TransportRopeSnapshot?.RenderFrames != arrival.Frame ||
            !float.IsFinite(controllerTime) || controllerTime < 0)
        {
            throw new InvalidOperationException("Crew point entry requires its exact unconsumed arrival and host time.");
        }

        CoopEnemyPoint point = enemyDestinations?.PointFor(command.ActorEntityId) ??
            throw new InvalidDataException("Crew point entry lost its reserved source point.");
        CoopAssignedEnemyDestination destination = enemyDestinations?.ForEnemy(command.ActorEntityId) ??
            throw new InvalidDataException("Crew point entry lost its source destination.");
        if (point.ComponentFileId != arrival.PointComponentFileId || destination.Position != command.Destination)
        {
            throw new InvalidDataException("Crew point entry lost its accepted destination.");
        }
        var context = new TransportCrewPointEntry.EntryContext(arrival,
            point with { Position = destination.Position }, controllerTime);
        var aircraft = enemySpawns.Single(row => row.EntityId == command.OriginalAircraftId);
        ArmyBaseShotStats shot = combat.TransportCrewShot(aircraft.Level);
        // Preserve source draw order: shot float, point-change int, then obstacle-only reposition float.
        float shotFraction = chooseInfantryShotFraction();
        int changeSeconds = chooseEnemyPointChangeSeconds();
        float? repositionFraction = arrival.State == CoopInfantryPointState.ObstacleHiding
            ? chooseInfantryRepositionFraction() : null;
        var draws = new TransportCrewPointEntry.RandomDraws(shotFraction, changeSeconds, repositionFraction);
        var entry = new TransportCrewPointEntry(context, shot, draws);
        owner.PointEntry = entry;
        owner.ObstacleClock = entry.IsCrawling ? new TransportCrewObstacleClock(entry, arrival.Frame) : null;
        return entry;
    }
}
