namespace War.BattleServer;

/// <summary>Validates monotonic Worker observations without deriving real time from executed simulation ticks.</summary>
internal static class BattleRealtime
{
    internal static void Validate(double seconds, double previousSeconds)
    {
        if (!double.IsFinite(seconds) || seconds < 0d || seconds < previousSeconds)
        {
            throw new ArgumentOutOfRangeException(nameof(seconds),
                "Battle real time must be finite, nonnegative and nondecreasing.");
        }
    }
}
