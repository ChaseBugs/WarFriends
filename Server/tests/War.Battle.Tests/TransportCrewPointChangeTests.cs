using System.Numerics;
using War.BattleServer;

/// <summary>Uses real source maps and synthetic eligible clocks; it does not simulate the preceding volley.</summary>
internal static class TransportCrewPointChangeTests
{
    private const ulong ActorId = 91_000_001;
    private const int MaximumOccupants = 64;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        VerifySuccessAndRejectedDraw(sources);
        VerifyBlockedRetry(sources);
        VerifyPlanLifetime(sources);
        Console.WriteLine("PASS: crew point-change selection, card walk clock, atomic failure and old-deadline retry.");
    }

    private static void VerifySuccessAndRejectedDraw(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopEnemyDestinationState destinations = Destinations(sources);
        CoopAssignedEnemyDestination original = destinations.TryAssignHelicopterAssaulter(ActorId) ??
            throw new Exception("Point-change fixture could not reserve an initial obstacle.");
        var pending = Pending(destinations, original);
        float fraction = float.NaN;
        var coordinator = new TransportCrewPointChange(destinations, sources.Combat, () => fraction);
        var request = new TransportCrewPointChange.Request(ActorId, 0, pending.Observation);
        Reject(() => coordinator.Resolve(pending.Clock,
            request with { Observation = request.Observation with { Clock = request.Observation.Clock with { } } }));
        Reject(() => coordinator.Resolve(pending.Clock, request));
        Require(ReferenceEquals(destinations.ForEnemy(ActorId), original) &&
            pending.Clock.PendingAction == TransportCrewObstacleClock.ActionKind.PointChangeRequired,
            "Invalid walking draw changed a reservation or consumed the pending callback.");
        fraction = 0.5f;
        TransportCrewPointChange.Result result = coordinator.Resolve(pending.Clock, request);
        ArmyBaseShotStats sourceShot = sources.Combat.TransportCrewShot(0);
        float expected = request.Observation.Clock.ControllerTime +
            (sourceShot.MinShootTime + (sourceShot.MaxShootTime - sourceShot.MinShootTime) * fraction);
        Require(result.Destination != null &&
            result.Destination.PointComponentFileId != original.PointComponentFileId &&
            ReferenceEquals(result.Destination, destinations.ForEnemy(ActorId)) &&
            result.NextWalkingShotTime == expected,
            "Successful point change did not replace its source point or initialize the card walking shot clock.");
        Reject(() => coordinator.Resolve(pending.Clock, request));
        CoopAssignedEnemyDestination? released =
            destinations.TryAssignInitial(ActorId + 1, "Assaulter", true, original.Position);
        Require(released?.PointComponentFileId == original.PointComponentFileId,
            "Successful point change did not release the previous point.");
    }

    private static void VerifyBlockedRetry(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopEnemyDestinationState destinations = Destinations(sources);
        CoopAssignedEnemyDestination original = destinations.TryAssignHelicopterAssaulter(ActorId) ??
            throw new Exception("Blocked point-change fixture has no initial obstacle.");
        int occupied = 0;
        for (int index = 1; index <= MaximumOccupants; index++)
        {
            if (destinations.TryAssignHelicopterAssaulter(ActorId + (ulong)index) == null)
            {
                break;
            }
            occupied++;
        }
        Require(occupied is > 0 and < MaximumOccupants, "Fixture did not exhaust the bounded source point set.");
        var pending = Pending(destinations, original);
        int shotDraws = 0;
        var coordinator = new TransportCrewPointChange(destinations, sources.Combat, () => { shotDraws++; return 0; });
        var request = new TransportCrewPointChange.Request(ActorId, 0, pending.Observation);
        TransportCrewPointChange.Result result = coordinator.Resolve(pending.Clock, request);
        Require(result.Destination == null && result.NextWalkingShotTime == null && shotDraws == 0 &&
            ReferenceEquals(destinations.ForEnemy(ActorId), original) && pending.Clock.NextEnemyChangeTime == 21 &&
            pending.Clock.PendingAction == null,
            "Blocked change must preserve its point and add ten to old deadline 11, rather than current time 25.");
        Reject(() => coordinator.Resolve(pending.Clock, request));
        var catchUp = request.Observation with
        {
            Clock = request.Observation.Clock with { Frame = 15, ControllerTime = 25.1f },
        };
        Require(pending.Clock.Select(catchUp.Clock) == TransportCrewObstacleClock.ActionKind.PointChangeRequired,
            "Late source callback incorrectly scheduled a fresh ten-second wait from current time.");
        pending.Clock.Accept(catchUp.Clock);
        coordinator.Resolve(pending.Clock, request with { Observation = catchUp });
        Require(pending.Clock.NextEnemyChangeTime == 31,
            "Second failed source change lost its old-deadline increment.");
    }

    private static void VerifyPlanLifetime(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopEnemyDestinationState destinations = Destinations(sources);
        CoopAssignedEnemyDestination original = destinations.TryAssignHelicopterAssaulter(ActorId) ??
            throw new Exception("Plan fixture has no initial point.");
        var previous = destinations.PlanCrewRetarget(ActorId, original.Position) ??
            throw new Exception("Plan fixture has no alternative point.");
        var current = destinations.PlanCrewRetarget(ActorId, original.Position) ??
            throw new Exception("Replacement plan lost its alternative.");
        Reject(() => destinations.CommitCrewRetarget(previous));
        Reject(() => Destinations(sources).CommitCrewRetarget(current));
        Require(ReferenceEquals(destinations.ForEnemy(ActorId), original),
            "Preview or stale commit changed occupancy.");
        destinations.CommitCrewRetarget(current);
        Reject(() => destinations.CommitCrewRetarget(current));
        var cancelled = destinations.PlanCrewRetarget(ActorId, current.Destination.Position) ??
            throw new Exception("Release fixture lost its next point.");
        destinations.Release(ActorId);
        Reject(() => destinations.CommitCrewRetarget(cancelled));
    }

    private static CoopEnemyDestinationState Destinations(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        return new CoopEnemyDestinationState(sources.Map, sources.Masks, sources.Combat,
            chooseObstacleFraction: () => 0.5f, chooseNextPoint: count => count > 1 ? 1 : 0);
    }

    private static (TransportCrewObstacleClock Clock, CoopMatchRuntime.TransportCrewObstacleObservation Observation)
        Pending(CoopEnemyDestinationState destinations, CoopAssignedEnemyDestination original)
    {
        CoopEnemyPoint point = destinations.PointFor(ActorId) ?? throw new Exception("No source obstacle point.");
        Require(point.ComponentType == "EnemyPointObstacle", "Synthetic clock fixture must own a real obstacle.");
        var arrival = new CoopMatchRuntime.TransportCrewPointArrival(10, original.Position,
            original.PointComponentFileId, CoopInfantryPointState.ObstacleHiding);
        // A synthetic long shot delay isolates the change branch; this does not replace the catalog's live delay.
        var entry = new TransportCrewPointEntry(new TransportCrewPointEntry.EntryContext(arrival, point, 1),
            new ArmyBaseShotStats(1, 1, 1, 30, 30), new TransportCrewPointEntry.RandomDraws(0, 10, 0));
        var clock = new TransportCrewObstacleClock(entry, 10);
        var frame = new TransportCrewObstacleClock.Observation(11, 3.01f, false, true);
        clock.Accept(frame, clock.RepositionDeadline(frame, 1));
        frame = frame with { Frame = 12, ControllerTime = 9.02f };
        clock.Accept(frame, clock.RepositionDeadline(frame, 1));
        frame = frame with { Frame = 13, ControllerTime = 22 };
        clock.Accept(frame, clock.RepositionDeadline(frame, 1));
        frame = frame with { Frame = 14, ControllerTime = 25 };
        Require(clock.Select(frame) == TransportCrewObstacleClock.ActionKind.PointChangeRequired,
            "Synthetic clock did not isolate the source point-change branch.");
        clock.Accept(frame);
        return (clock, new CoopMatchRuntime.TransportCrewObstacleObservation(frame, original.Position + Vector3.UnitY));
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException)
        {
            return;
        }
        throw new Exception("Invalid, copied or replayed point-change callback was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
