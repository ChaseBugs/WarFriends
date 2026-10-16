using War.BattleServer;

/// <summary>Exercises the recovered obstacle branch order and post-volley timing.</summary>
internal static class CoopObstacleVolleyClockTests
{
    internal static int Run()
    {
        var clock = new CoopObstacleVolleyClock(10, 10);
        Check(clock.Decide(9) == CoopObstacleAction.None, "No action before its source gate.");
        Check(clock.Decide(10) == CoopObstacleAction.Shoot, "Shooting wins a shared deadline.");
        clock.BeginShot(10, 0);
        Check(clock.NextPositionTick == 71 && !clock.IsCrawling && clock.HasPendingShot,
            "Shot preparation uses the strict 2-second position delay.");
        Check(clock.Decide(100) == CoopObstacleAction.None, "A pending volley prevents repositioning.");
        clock.CompleteShot(100, new ObstacleShotDelay(1, 2, 0));
        Check(clock.NextShotTick == 131 && clock.IsCrawling && !clock.HasPendingShot,
            "The final round restores crawling and source shot timing.");
        Check(clock.Decide(100) == CoopObstacleAction.Reposition, "An overdue position gate survives shooting.");
        clock.Reposition(100, 0.5f);
        Check(clock.NextPositionTick == 221, "A later position change uses the 2-6-second source range.");
        Check(clock.Decide(130) == CoopObstacleAction.None && clock.Decide(131) == CoopObstacleAction.Shoot,
            "The second volley respects its exact readiness boundary.");
        clock.BeginShot(131, 0.5f);
        Check(clock.NextPositionTick == 207, "The second preparation replaces the old position deadline.");
        int checks = 9 + VerifyInvalidDrawIsAtomic(clock) + VerifyInvalidTimesAreAtomic(clock);
        Console.WriteLine($"PASS: {checks} co-op obstacle volley clock assertions");
        return checks;
    }

    private static int VerifyInvalidDrawIsAtomic(CoopObstacleVolleyClock clock)
    {
        int checks = 0;
        foreach (float invalid in new[] { float.NaN, float.PositiveInfinity, -1f, 1f })
        {
            try
            {
                clock.CompleteShot(150, new ObstacleShotDelay(1, 2, invalid));
                throw new Exception("Invalid draw completed a volley.");
            }
            catch (InvalidDataException)
            {
                Check(clock.HasPendingShot && !clock.IsCrawling && clock.NextShotTick == 131 &&
                    clock.NextPositionTick == 207, "Invalid draws leave both source clocks unchanged.");
                checks++;
            }
        }
        return checks;
    }

    private static int VerifyInvalidTimesAreAtomic(CoopObstacleVolleyClock clock)
    {
        try
        {
            clock.CompleteShot(130, new ObstacleShotDelay(1, 2, 0));
            throw new Exception("An earlier completion rewound the volley.");
        }
        catch (InvalidOperationException)
        {
            Check(clock.HasPendingShot && clock.NextShotTick == 131,
                "Backward time preserves the pending volley.");
        }
        try
        {
            clock.CompleteShot(ulong.MaxValue, new ObstacleShotDelay(1, 2, 0));
            throw new Exception("An overflowing deadline completed the volley.");
        }
        catch (OverflowException)
        {
            Check(clock.HasPendingShot && clock.NextShotTick == 131 && clock.NextPositionTick == 207,
                "Deadline overflow preserves both clocks.");
        }
        return 2;
    }

    private static void Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
