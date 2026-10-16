namespace War.BattleServer;

/// <summary>One victim's recovered Flame skill-shot timing state.</summary>
internal readonly record struct PvpFlameHitThrottle(
    int IgnoredHits,
    float IgnoreUntil,
    float LastHitTime)
{
    private const int MaximumIgnoredHits = 6;
    private const float IgnoreSeconds = 0.5f;

    internal static PvpFlameHitThrottle Initial => new(MaximumIgnoredHits, 0f, 0f);

    /// <summary>Returns the next state and whether this hit may award a skill shot.</summary>
    internal (PvpFlameHitThrottle Next, bool ShouldScore) Advance(float sourceTime)
    {
        if (!float.IsFinite(sourceTime) || sourceTime < 0f || sourceTime < LastHitTime)
        {
            throw new InvalidDataException("Flame hit has invalid source time.");
        }

        float nextDeadline = sourceTime + IgnoreSeconds;
        if (!float.IsFinite(nextDeadline))
        {
            throw new InvalidDataException("Flame ignore deadline overflowed.");
        }

        if (IgnoredHits < MaximumIgnoredHits && sourceTime <= IgnoreUntil)
        {
            return (new(IgnoredHits + 1, nextDeadline, sourceTime), false);
        }

        return (new(0, nextDeadline, sourceTime), true);
    }
}
