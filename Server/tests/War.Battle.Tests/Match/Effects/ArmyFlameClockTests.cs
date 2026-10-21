using War.BattleServer;

namespace War.Battle.Tests.Match.Effects;

internal static class ArmyFlameClockTests
{
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    internal static int Run()
    {
        FlameAmmoClockReference.VerifyRecoveredBodies();
        CheckFixedRate();
        CheckAbsoluteOffsets();
        CheckStrictThresholds();
        CheckLateFrames();
        CheckPausedClock();
        CheckInvalidTime();
        CheckIsolation();
        return 7 + ArmyFlameHostClockTests.Run();
    }

    private static void CheckFixedRate()
    {
        var source = new FlameAmmoClockReference(0);
        var burst = new ArmyFlameBurst(1, 2, Owner, 0);
        var clock = new BattleCooldownClock();
        clock.Observe(0, false);
        var expected = new List<ulong>();
        var actual = new List<ulong>();
        for (ulong tick = 1; tick <= 100; tick++)
        {
            clock.Observe(tick / (double)MatchManifest.TickRate, false);
            int previous = source.PulseCount;
            source.Advance(clock.ElapsedSeconds);
            if (source.PulseCount > previous)
            {
                expected.Add(tick);
            }
            if (burst.Due(clock.ElapsedSeconds))
            {
                burst.CommitPulse(clock.ElapsedSeconds);
                actual.Add(tick);
            }
        }
        if (!actual.SequenceEqual(expected))
        {
            throw new InvalidOperationException("Flame source pulse frames: " + string.Join(',', expected) +
                "; server pulse frames: " + string.Join(',', actual));
        }
    }

    private static void CheckAbsoluteOffsets()
    {
        foreach (float start in new[] { 1f, 100.125f, 12345.5f })
        {
            var source = new FlameAmmoClockReference(start);
            var burst = new ArmyFlameBurst(1, 2, Owner, start);
            for (int frame = 0; frame <= 100; frame++)
            {
                AdvanceTogether(source, burst, start + frame / (float)MatchManifest.TickRate);
            }
            Require(burst.Finished && source.DestroyDelay == 0.5f, "Offset flame clock did not complete six pulses.");
        }
    }

    private static void CheckStrictThresholds()
    {
        var source = new FlameAmmoClockReference(0);
        var burst = new ArmyFlameBurst(1, 2, Owner, 0);
        for (int pulse = 0; pulse < ArmyFlameBurst.HitsPerShot; pulse++)
        {
            float deadline = source.NextDeadline;
            AdvanceTogether(source, burst, deadline);
            Require(burst.PulseIndex == pulse, "Equality must not pass the recovered strict deadline.");
            AdvanceTogether(source, burst, MathF.BitIncrement(deadline));
            Require(burst.PulseIndex == pulse + 1, "The next binary32 time did not pass the source deadline.");
        }
    }

    private static void CheckLateFrames()
    {
        var source = new FlameAmmoClockReference(0);
        var burst = new ArmyFlameBurst(1, 2, Owner, 0);
        foreach (float seconds in new[] { 0.35f, 0.4f, 1.5f, 1.5f, 1.5f, 1.5f, 2.2f, 2.2f, 3f })
        {
            AdvanceTogether(source, burst, seconds);
        }
        Require(burst.Finished && source.HitTimes.Count == ArmyFlameBurst.HitsPerShot,
            "A delayed frame skipped pulses, caught up in one loop or exceeded six callbacks.");
    }

    private static void CheckPausedClock()
    {
        var source = new FlameAmmoClockReference(0);
        var burst = new ArmyFlameBurst(1, 2, Owner, 0);
        var clock = new BattleCooldownClock();
        clock.Observe(0, false);
        clock.Observe(0.2, false);
        AdvanceTogether(source, burst, clock.ElapsedSeconds);
        clock.Observe(0.4, false);
        AdvanceTogether(source, burst, clock.ElapsedSeconds);
        float before = clock.ElapsedSeconds;
        clock.Observe(100, true);
        Require(clock.ElapsedSeconds == before && burst.PulseIndex == 1, "Paused host time advanced flame authority.");
        clock.Observe(100.1, false);
        AdvanceTogether(source, burst, clock.ElapsedSeconds);
        Require(burst.PulseIndex == 1, "Resume consumed the paused wall-time backlog.");
    }

    private static void CheckInvalidTime()
    {
        foreach (float seconds in new[] { -1f, float.NaN, float.PositiveInfinity, float.MaxValue })
        {
            Expect<InvalidDataException>(() => new ArmyFlamePulseClock(seconds));
        }
        var clock = new ArmyFlamePulseClock(0);
        Expect<InvalidOperationException>(() => clock.CommitPulse(0.35f));
        foreach (float seconds in new[] { -1f, float.NaN, float.PositiveInfinity })
        {
            Expect<InvalidDataException>(() => clock.Due(seconds));
        }
        Require(clock.PulseIndex == 0 && clock.NextPulseSeconds == 0.35f, "Rejected time mutated flame authority.");
        clock.CommitPulse(0.4f);
        Expect<InvalidDataException>(() => clock.Due(0.3f));
        Require(clock.PulseIndex == 1, "Reversed source time consumed a pulse.");
    }

    private static void CheckIsolation()
    {
        var first = new ArmyFlamePulseClock(0);
        var second = new ArmyFlamePulseClock(0);
        first.CommitPulse(0.4f);
        Require(first.PulseIndex == 1 && second.PulseIndex == 0 && second.NextPulseSeconds == 0.35f,
            "Independent flame bursts shared mutable deadline state.");
        Require(typeof(ArmyFlamePulseClock).IsValueType, "A flame burst allocated a separate clock wrapper.");
    }

    private static void AdvanceTogether(FlameAmmoClockReference source, ArmyFlameBurst burst, float seconds)
    {
        int before = source.PulseCount;
        source.Advance(seconds);
        if (burst.Due(seconds))
        {
            burst.CommitPulse(seconds);
        }
        Require(burst.PulseIndex == source.PulseCount && burst.PulseIndex - before <= 1 &&
            BitConverter.SingleToInt32Bits(burst.NextPulseSeconds) ==
                BitConverter.SingleToInt32Bits(source.NextDeadline),
            "Flame callbacks or accumulated deadline bits differ from the recovered method bodies.");
    }

    private static void Expect<TException>(Action action) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException)
        {
            return;
        }
        throw new InvalidOperationException("The invalid flame clock operation was accepted.");
    }

    internal static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
