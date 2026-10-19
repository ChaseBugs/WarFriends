using System.Numerics;

using War.BattleServer;

/// <summary>Checks due-only retries, repeat waits, successful reservation and unresolved cancellation.</summary>
internal static class CoopHelicopterFallbackRetryTests
{
    internal static void Run(CoopMapEnemyPoints map, CoopEnemyPointMaskCatalog masks, CoopEnemyCombatCatalog combat)
    {
        var destinations = new CoopEnemyDestinationState(map, masks, combat, () => 0.5f);
        destinations.TryAssignInitial(1000, "Assaulter", true, Vector3.Zero);
        var retry = new CoopHelicopterFallbackRetry(1001, destinations, Observe(1, 0));
        Require(retry.Advance(Observe(2, 4.99f)) == null && retry.Advance(Observe(3, 5)) == null,
            "Full point list produced an early or fabricated retry target.");
        destinations.Release(1000);
        Require(retry.Advance(Observe(4, 7)) == null && destinations.ForEnemy(1001) == null,
            "Retry ignored its second five-second wait after a point became free.");
        CoopAssignedEnemyDestination? assigned = retry.Advance(Observe(5, 10));
        Require(assigned != null && retry.Status == HelicopterCrewRetryStatus.Assigned &&
            destinations.ForEnemy(1001) == assigned && retry.Advance(Observe(5, 10)) == assigned,
            "Due retry did not retain one accepted shared reservation.");
        retry.Cancel();
        Require(destinations.ForEnemy(1001) == assigned,
            "Cancelling a completed wait revoked the actor's destination.");
        destinations.Release(1001);

        var cancelled = new CoopHelicopterFallbackRetry(1002, destinations, Observe(1, 0));
        cancelled.Cancel();
        Require(cancelled.Advance(Observe(2, 100)) == null && destinations.ForEnemy(1002) == null &&
            cancelled.Status == HelicopterCrewRetryStatus.Cancelled, "Cancelled retry claimed a later free point.");
        VerifyRejectedPose(destinations);
        VerifyReservationFailure(map, masks, combat);
        VerifyRescheduleFailure(map, masks, combat);
        Console.WriteLine("PASS: fallback retry waits for due frames, repeats, reserves once " +
            "and cancels pending work.");
    }

    private static void VerifyRejectedPose(CoopEnemyDestinationState destinations)
    {
        var retry = new CoopHelicopterFallbackRetry(1003, destinations, Observe(1, 0));
        try
        {
            retry.Advance(Observe(2, 5) with { Position = new Vector3(float.NaN, 0, 0) });
            throw new Exception("Malformed retry pose consumed the due callback.");
        }
        catch (InvalidDataException)
        {
            Require(retry.Status == HelicopterCrewRetryStatus.Waiting && retry.Advance(Observe(2, 5)) != null,
                "Rejected retry pose changed its wait or prevented the valid same-frame callback.");
        }
    }

    private static HelicopterCrewRetryObservation Observe(ulong frame, float time)
    {
        return new HelicopterCrewRetryObservation(frame, time, Vector3.Zero);
    }

    private static void VerifyReservationFailure(CoopMapEnemyPoints map, CoopEnemyPointMaskCatalog masks,
        CoopEnemyCombatCatalog combat)
    {
        float fraction = float.NaN;
        var destinations = new CoopEnemyDestinationState(map, masks, combat, () => fraction);
        var retry = new CoopHelicopterFallbackRetry(1100, destinations, Observe(1, 0));
        try
        {
            retry.Advance(Observe(2, 5));
            throw new Exception("Invalid obstacle placement was converted into a successful retry.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Require(retry.Status == HelicopterCrewRetryStatus.Faulted && retry.Destination == null &&
                destinations.ForEnemy(1100) == null, "Failed retry retained assignment or concealed its fault.");
        }
        fraction = 0.5f;
        retry.Cancel();
        try
        {
            retry.Advance(Observe(3, 10));
            throw new Exception("Faulted retry resumed after its placement input was repaired.");
        }
        catch (InvalidOperationException)
        {
            Require(destinations.TryAssignInitial(1101, "Assaulter", true, Vector3.Zero) != null,
                "Faulted retry leaked its reservation and blocked another actor.");
        }
    }

    private static void VerifyRescheduleFailure(CoopMapEnemyPoints map, CoopEnemyPointMaskCatalog masks,
        CoopEnemyCombatCatalog combat)
    {
        var destinations = new CoopEnemyDestinationState(map, masks, combat, () => 0.5f);
        CoopAssignedEnemyDestination? occupied = destinations.TryAssignInitial(1200, "Assaulter", true, Vector3.Zero);
        var retry = new CoopHelicopterFallbackRetry(1201, destinations, Observe(1, 0));
        try
        {
            retry.Advance(Observe(2, float.MaxValue));
            throw new Exception("Unrepresentable next retry deadline was accepted.");
        }
        catch (InvalidDataException)
        {
            Require(retry.Status == HelicopterCrewRetryStatus.Faulted && retry.Destination == null &&
                destinations.ForEnemy(1201) == null && destinations.ForEnemy(1200) == occupied,
                "Failed rescheduling changed another actor's reservation or fabricated a destination.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
