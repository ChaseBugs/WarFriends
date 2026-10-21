namespace War.BattleServer;

/// <summary>Validates monotonic Worker observations without deriving realtime from executed ticks.</summary>
internal static class BattleRealtime
{
    /// <summary>Converts a trusted observation only when Unity's float realtime can represent it.</summary>
    internal static float ToUnitySeconds(double seconds)
    {
        Validate(seconds, 0);
        float observation = (float)seconds;
        if (!float.IsFinite(observation))
        {
            throw new ArgumentOutOfRangeException(nameof(seconds), "Battle realtime exceeds Unity's finite clock.");
        }
        return observation;
    }

    internal static void Validate(double seconds, double previousSeconds)
    {
        if (!double.IsFinite(seconds) || seconds < 0d || seconds < previousSeconds)
        {
            throw new ArgumentOutOfRangeException(nameof(seconds),
                "Battle real time must be finite, nonnegative and nondecreasing.");
        }
    }
}
