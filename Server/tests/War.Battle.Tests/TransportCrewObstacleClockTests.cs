using War.BattleServer;

/// <summary>Checks the pre-preparation source branch ordering and scaled reposition clock.</summary>
internal static class TransportCrewObstacleClockTests
{
    internal static int Run()
    {
        var context = TransportCrewPointEntryTests.Context(CoopInfantryPointState.ObstacleHiding, 1);
        var entry = new TransportCrewPointEntry(context, new ArmyBaseShotStats(1, 1, 1, 30, 30),
            new TransportCrewPointEntry.RandomDraws(0, 10, 0));
        var clock = new TransportCrewObstacleClock(entry, 10);
        var exact = new TransportCrewObstacleClock.Observation(11, 3, false, true);
        Require(clock.Select(exact) == TransportCrewObstacleClock.ActionKind.Waiting,
            "Exact reposition deadline must wait for a later scaled time.");
        clock.Accept(exact);
        var first = exact with { Frame = 12, ControllerTime = 3.01f };
        Require(clock.Select(first with { IsPreparingShot = true }) ==
            TransportCrewObstacleClock.ActionKind.Waiting, "Shot preparation did not suppress repositioning.");
        Require(clock.Select(first) == TransportCrewObstacleClock.ActionKind.Reposition,
            "Due source reposition was not selected.");
        Require(clock.RepositionDeadline(first, 0) == first.ControllerTime + 2 &&
            clock.RepositionDeadline(first, 1) == first.ControllerTime + 6,
            "Repeated source reposition must draw 2–6 seconds, rather than the initial 2–4 seconds.");
        clock.Accept(first, clock.RepositionDeadline(first, 1));
        var second = first with { Frame = 13, ControllerTime = 9.02f };
        clock.Accept(second, clock.RepositionDeadline(second, 1));
        var change = second with { Frame = 14, ControllerTime = 11.01f };
        Require(clock.Select(change) == TransportCrewObstacleClock.ActionKind.PointChangeRequired &&
            clock.Select(change with { CanChangePosition = false }) ==
                TransportCrewObstacleClock.ActionKind.Waiting, "Point-change guard or branch ordering changed.");
        var shot = change with { ControllerTime = 31.01f, IsPreparingShot = true };
        Require(clock.Select(shot) == TransportCrewObstacleClock.ActionKind.ShotPreparationRequired,
            "A due first shot must precede repositioning and must not be gated by mWillShoot.");

        Action[] invalid =
        {
            () => clock.Select(second),
            () => clock.Select(change with { ControllerTime = float.NaN }),
            () => clock.Select(change with { ControllerTime = 1 }),
            () => clock.RepositionDeadline(change, float.NaN),
            () => clock.RepositionDeadline(change with { ControllerTime = float.MaxValue }, 0),
        };
        foreach (Action action in invalid)
        {
            try
            {
                action();
                throw new Exception("Invalid source obstacle clock was accepted.");
            }
            catch (InvalidDataException)
            {
                // Rejected previews must not consume the later valid frame.
            }
        }
        Require(clock.Select(change) == TransportCrewObstacleClock.ActionKind.PointChangeRequired,
            "Rejected callback changed source scheduling.");
        clock.Accept(shot);
        Require(clock.PendingAction == TransportCrewObstacleClock.ActionKind.ShotPreparationRequired,
            "Required shot preparation did not retain pending ownership.");
        try
        {
            clock.Select(shot with { Frame = shot.Frame + 1 });
            throw new Exception("Unconsumed shot preparation was issued again.");
        }
        catch (InvalidOperationException)
        {
            // An absent preparation consumer must stop progression instead of manufacturing another shot.
        }
        return 9 + invalid.Length;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
