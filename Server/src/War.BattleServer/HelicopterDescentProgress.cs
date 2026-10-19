namespace War.BattleServer;

/// <summary>Source float accumulation for one-second descent animation and its fixed-step projection.</summary>
internal static class HelicopterDescentProgress
{
    private static readonly float[] FixedTickSamples = CreateFixedTickSamples();

    internal static float Advance(float progress, float deltaTime)
    {
        if (!float.IsFinite(progress) || progress is < 0 or > 1 ||
            !float.IsFinite(deltaTime) || deltaTime < 0)
        {
            throw new InvalidDataException("Invalid Helicopter descent animation time.");
        }
        return Math.Clamp(progress + deltaTime, 0f, 1f);
    }

    internal static float AtFixedTicks(ulong elapsedTicks)
    {
        int index = (int)Math.Min(elapsedTicks, (ulong)MatchManifest.TickRate);
        return FixedTickSamples[index];
    }

    private static float[] CreateFixedTickSamples()
    {
        var samples = new float[MatchManifest.TickRate + 1];
        for (int frame = 1; frame < samples.Length; frame++)
        {
            samples[frame] = Advance(samples[frame - 1], 1f / MatchManifest.TickRate);
        }
        return samples;
    }
}
