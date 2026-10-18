using War.BattleServer;

/// <summary>Checks source float precision, clamped frame hitches and discarded paused time.</summary>
internal static class BattleCooldownClockTests
{
    internal static int Run()
    {
        var clock = new BattleCooldownClock();
        clock.Observe(100d, false);
        Require(clock.ElapsedSeconds == 0f && clock.DeltaSeconds == 0f, "Start counted pre-allocation time.");
        clock.Observe(110d, false);
        Require(clock.ElapsedSeconds == 0.2f && clock.DeltaSeconds == 0.2f, "Frame hitch bypassed source clamp.");
        clock.Observe(110d, false);
        Require(clock.ElapsedSeconds == 0.2f && clock.DeltaSeconds == 0f, "Catch-up double-counted one sample.");
        clock.Observe(200d, true);
        Require(clock.ElapsedSeconds == 0.2f && clock.DeltaSeconds == 0f, "Pause accumulated elapsed time.");
        clock.Observe(200.125d, false);
        Require(clock.ElapsedSeconds == 0.325f && clock.DeltaSeconds == 0.125f, "Resume replayed pause backlog.");

        foreach (double invalid in new[] { double.NaN, double.PositiveInfinity, -1d, 199d, double.MaxValue })
        {
            Reject(clock, invalid);
            Require(clock.ElapsedSeconds == 0.325f && clock.DeltaSeconds == 0.125f,
                "Rejected source time changed the committed cooldown state.");
        }
        clock.Observe(200.25d, false);
        Require(clock.ElapsedSeconds == 0.45f, "Rejected input poisoned the next valid frame.");

        var rounded = new BattleCooldownClock();
        const double LargeSourceTime = 16_777_216d;
        rounded.Observe(LargeSourceTime, false);
        rounded.Observe(LargeSourceTime + 0.125d, false);
        Require(rounded.ElapsedSeconds == 0f, "Double accumulation changed source float precision.");
        return 17;
    }

    private static void Reject(BattleCooldownClock clock, double seconds)
    {
        try
        {
            clock.Observe(seconds, false);
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }
        throw new InvalidOperationException("Invalid source cooldown observation was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
