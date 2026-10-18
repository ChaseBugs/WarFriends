namespace War.BattleServer;

/// <summary>Preserves EnemyController's stored binary32 time addition and strict deadline comparisons.</summary>
internal sealed class MortarControllerClock
{
    internal const float FixedDeltaSeconds = 1f / MatchManifest.TickRate;
    private const float MaximumTimeSeconds = 1_000_000f;
    private const float MaximumDeltaSeconds = 1f;
    private const float MaximumPredictionSeconds = 60f;
    private const ulong MaximumPredictionTicks = 4096;

    internal float Time { get; private set; }

    internal MortarControllerClock(float initialTime)
    {
        if (!float.IsFinite(initialTime) || initialTime < 0f || initialTime > MaximumTimeSeconds)
        {
            throw new InvalidDataException("Mortar controller clock has an invalid initial epoch.");
        }
        Time = initialTime;
    }

    internal void Advance(float deltaSeconds = FixedDeltaSeconds)
    {
        if (!float.IsFinite(deltaSeconds) || deltaSeconds < 0f || deltaSeconds > MaximumDeltaSeconds ||
            Time + deltaSeconds > MaximumTimeSeconds)
        {
            throw new InvalidDataException("Mortar controller clock has an invalid frame delta.");
        }
        Time += deltaSeconds;
    }

    internal ulong TicksUntilStrictDelay(float seconds)
    {
        if (!float.IsFinite(seconds) || seconds <= 0f || seconds > MaximumPredictionSeconds)
        {
            throw new InvalidDataException("Mortar controller deadline has an invalid source delay.");
        }
        float deadline = Time + seconds;
        float projected = Time;
        for (ulong ticks = 1; ticks <= MaximumPredictionTicks; ticks++)
        {
            projected += FixedDeltaSeconds;
            if (projected > deadline)
            {
                return ticks;
            }
        }
        throw new InvalidDataException("Mortar controller deadline has no bounded strict successor.");
    }
}
