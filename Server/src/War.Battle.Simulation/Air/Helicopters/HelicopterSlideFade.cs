namespace War.BattleServer;

/// <summary>Raw legacy animation clock and weight; raw time is not clamped clip sample time.</summary>
internal sealed record HelicopterFadeLayer(float RawTime, float Weight, bool IsEnabled);

/// <summary>Two-layer transition from a fully weighted ordinary idle into the rope-slide clip.</summary>
internal sealed record HelicopterSlideFadeSnapshot(HelicopterFadeLayer Idle, HelicopterFadeLayer Slide)
{
    internal bool IsSettled => !Idle.IsEnabled && Slide.IsEnabled && Slide.Weight == 1f;
}

/// <summary>Projects the captured 30 Hz legacy CrossFade; other starting mixers require separate evidence.</summary>
internal static class HelicopterSlideFade
{
    // The captured Unity one-argument managed wrapper supplies this duration.
    private const float FadeSeconds = 0.3f;
    private const float FixedDelta = 1f / MatchManifest.TickRate;
    private const int FadeSteps = 10;
    private static readonly float[] IdleWeights = CreateWeights(1f, -1f);
    private static readonly float[] SlideWeights = CreateWeights(0f, 1f);

    internal static HelicopterSlideFadeSnapshot AtFixedTicks(float initialIdleTime, ulong elapsedTicks)
    {
        if (!float.IsFinite(initialIdleTime) || initialIdleTime is < 0f or >= 1f)
        {
            throw new InvalidDataException("Expected a phase inside the recovered one-second ordinary idle.");
        }
        int index = (int)Math.Min(elapsedTicks, (ulong)FadeSteps);
        bool isIdleEnabled = IdleWeights[index] > 0f;
        // Double precision matches the captured raw float clocks, including an idle crossing its loop end.
        double elapsed = elapsedTicks * (double)FixedDelta;
        float idleTime = isIdleEnabled ? (float)(initialIdleTime + elapsed) : 0f;
        return new HelicopterSlideFadeSnapshot(
            new HelicopterFadeLayer(idleTime, IdleWeights[index], isIdleEnabled),
            new HelicopterFadeLayer((float)elapsed, SlideWeights[index], true));
    }

    private static float[] CreateWeights(float initialWeight, float direction)
    {
        var weights = new float[FadeSteps + 1];
        weights[0] = initialWeight;
        for (int step = 1; step < weights.Length; step++)
        {
            // Independent float accumulation preserves the outgoing residual at tick nine.
            weights[step] = Math.Clamp(weights[step - 1] + direction * (FixedDelta / FadeSeconds), 0f, 1f);
        }
        return weights;
    }
}
