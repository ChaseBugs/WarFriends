using War.BattleServer;

/// <summary>Replays source signal timing and flags without fabricating target, round or collision evidence.</summary>
internal static class TransportCrewShotCallbackTests
{
    internal static int Run()
    {
        VerifyPrepared();
        VerifyRejections();
        Console.WriteLine("PASS: crew observed preparation, delayed start, EndShooting order and failure flags.");
        return 22;
    }

    private static void VerifyPrepared()
    {
        var fixture = Pending();
        var shot = new ArmyBaseShotStats(1, 1, 1, 2, 4);
        var timing = new TransportCrewObstacleClock.PreparationTiming(
            TransportCrewObstacleClock.PreparationOutcome.Prepared, 100, 0.25f);
        var invalid = new TransportCrewObstacleClock.PreparationDraws(float.NaN, 0.5f);
        Reject(() => fixture.Clock.ObservePreparation(fixture.Request, timing, shot, invalid));
        Require(fixture.Clock.IsCrawling && fixture.Clock.PendingAction.HasValue,
            "Rejected preparation consumed the source pending action.");
        TransportCrewObstacleClock.ShotCallbackTicket ticket = fixture.Clock.ObservePreparation(
            fixture.Request, timing, shot, invalid with { ShotFraction = 0.5f }) ??
                throw new Exception("Prepared source observation lost its callback identity.");
        Require(!fixture.Clock.IsCrawling && fixture.Clock.HasPendingVolley && !fixture.Clock.IsShooting &&
            fixture.Clock.NextShootTime == 10 && fixture.Clock.NextRepositionTime == 9.5f,
            "Prepared branch changed source flags or draw order.");
        Reject(() => fixture.Clock.ObservePreparation(fixture.Request, timing, shot,
            new TransportCrewObstacleClock.PreparationDraws(0, 0)));
        var start = new TransportCrewObstacleClock.ShotObservation(12, 8, ticket.CoroutineDeadline);
        Reject(() => fixture.Clock.ObserveShotStarted(ticket, start with
        {
            CoroutineTime = MathF.BitDecrement(ticket.CoroutineDeadline),
        }));
        Reject(() => fixture.Clock.ObserveShotStarted(
            new TransportCrewObstacleClock.ShotCallbackTicket(ticket.ScheduledFrame, ticket.CoroutineDeadline), start));
        Require(fixture.Clock.Select(new TransportCrewObstacleClock.Observation(12, 8, false, true)) ==
            TransportCrewObstacleClock.ActionKind.Waiting, "Pending source volley allowed repositioning.");
        fixture.Clock.ObserveShotStarted(ticket, start);
        Require(fixture.Clock.IsShooting, "Delayed callback did not set the observed shooting flag.");
        Reject(() => fixture.Clock.ObserveShotStarted(ticket, start));
        Reject(() => fixture.Clock.RequireShotEnd(ticket, start));
        var end = new TransportCrewObstacleClock.ShotObservation(13, 9, 101);
        Reject(() => fixture.Clock.ObserveShotEnded(ticket, end, shot, float.NaN));
        Require(fixture.Clock.IsShooting && fixture.Clock.HasPendingVolley,
            "Rejected EndShooting consumed the active source observation.");
        fixture.Clock.ObserveShotEnded(ticket, end, shot, 0.25f);
        Require(fixture.Clock.IsCrawling && !fixture.Clock.IsShooting && !fixture.Clock.HasPendingVolley &&
            fixture.Clock.NextShootTime == 11.5f && fixture.Clock.NextRepositionTime == 9.5f,
            "EndShooting failed to restore crawling or overwrote the existing position timer.");
        var sameUpdate = new TransportCrewObstacleClock.Observation(13, 9, false, true);
        Require(fixture.Clock.Select(sameUpdate) == TransportCrewObstacleClock.ActionKind.Waiting,
            "EndShooting prevented this same frame's later ObstacleHidingUpdate.");
        fixture.Clock.Accept(sameUpdate);
        Reject(() => fixture.Clock.ObserveShotEnded(ticket, end, shot, 0));
        Reject(() => fixture.Clock.ObserveShotStarted(ticket, end));
    }

    private static void VerifyRejections()
    {
        var shot = new ArmyBaseShotStats(1, 1, 1, 2, 4);
        foreach (var outcome in new[]
        {
            TransportCrewObstacleClock.PreparationOutcome.CannotShoot,
            TransportCrewObstacleClock.PreparationOutcome.NoTarget,
        })
        {
            var fixture = Pending();
            float? fraction = outcome == TransportCrewObstacleClock.PreparationOutcome.CannotShoot ? null : 0;
            var timing = new TransportCrewObstacleClock.PreparationTiming(outcome, 100, null);
            Require(fixture.Clock.ObservePreparation(fixture.Request, timing, shot,
                new TransportCrewObstacleClock.PreparationDraws(fraction, 0)) == null &&
                !fixture.Clock.IsCrawling && !fixture.Clock.HasPendingVolley,
                "Failed PrepareToShoot must still clear crawling, without inventing a volley.");
            float expected = outcome == TransportCrewObstacleClock.PreparationOutcome.CannotShoot ? 3 : 9;
            Require(fixture.Clock.NextShootTime == expected,
                "CannotShoot and target rejection must differ in GenerateNextShootTime behavior.");
            Require(fixture.Clock.Select(new TransportCrewObstacleClock.Observation(12, 10, false, true)) ==
                TransportCrewObstacleClock.ActionKind.Reposition,
                "Rejected preparation was incorrectly rearmed to shoot.");
        }
    }

    private static (TransportCrewObstacleClock Clock, TransportCrewObstacleClock.Observation Request) Pending()
    {
        var context = TransportCrewPointEntryTests.Context(CoopInfantryPointState.ObstacleHiding, 1);
        var entry = new TransportCrewPointEntry(context, new ArmyBaseShotStats(1, 1, 1, 2, 4),
            new TransportCrewPointEntry.RandomDraws(0, 10, 0));
        var clock = new TransportCrewObstacleClock(entry, 10);
        var request = new TransportCrewObstacleClock.Observation(11, 7, false, true);
        clock.Accept(request);
        return (clock, request);
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
        throw new Exception("Early, copied, invalid or replayed source shot callback was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
