namespace War.BattleServer;

/// <summary>Preserves FlameAmmo's accumulated binary32 deadlines and one pulse per source frame.</summary>
internal struct ArmyFlamePulseClock
{
    internal const int PulseCount = 6;
    internal const float SecondsBetweenPulses = 0.35f;
    private float _lastPulseSeconds;

    internal ArmyFlamePulseClock(float sourceSeconds)
    {
        ValidateSeconds(sourceSeconds, 0);
        _lastPulseSeconds = sourceSeconds;
        PulseIndex = 0;
        NextPulseSeconds = NextDeadline(sourceSeconds);
    }

    internal int PulseIndex { get; private set; }

    internal float NextPulseSeconds { get; private set; }

    internal bool Finished => PulseIndex >= PulseCount;

    internal bool Due(float sourceSeconds)
    {
        ValidateSeconds(sourceSeconds, _lastPulseSeconds);
        return !Finished && sourceSeconds > NextPulseSeconds;
    }

    internal void CommitPulse(float sourceSeconds)
    {
        if (!Due(sourceSeconds))
        {
            throw new InvalidOperationException("Army flame pulse is not due on its source clock.");
        }

        // FlameAmmo adds to its previous deadline, never to the delayed frame time or a rounded tick interval.
        float nextDeadline = NextDeadline(NextPulseSeconds);
        NextPulseSeconds = nextDeadline;
        PulseIndex++;
        _lastPulseSeconds = sourceSeconds;
    }

    private static float NextDeadline(float previous)
    {
        float next = previous + SecondsBetweenPulses;
        if (!float.IsFinite(next) || next <= previous)
        {
            throw new InvalidDataException("Army flame deadline cannot advance on the source clock.");
        }
        return next;
    }

    private static void ValidateSeconds(float sourceSeconds, float previous)
    {
        if (!float.IsFinite(sourceSeconds) || sourceSeconds < previous)
        {
            throw new InvalidDataException("Army flame source time must be finite, nonnegative and nondecreasing.");
        }
    }
}
