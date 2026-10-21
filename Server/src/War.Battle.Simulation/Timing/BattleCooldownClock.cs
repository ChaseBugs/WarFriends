namespace War.BattleServer;

/// <summary>Preserves TimeManager's stored-float, pause-excluding real-time accumulator.</summary>
internal sealed class BattleCooldownClock
{
    private const float MaximumFrameSeconds = 0.2f;
    private double _lastObservation;
    private float _lastSourceSeconds;
    private bool _hasObservation;

    internal float ElapsedSeconds { get; private set; }

    internal float DeltaSeconds { get; private set; }

    /// <summary>Observes a frame; a missing initial observation establishes the source Start baseline.</summary>
    internal void Observe(double realTimeSeconds, bool isPaused)
    {
        ValidateObservation(realTimeSeconds);
        float sourceSeconds = (float)realTimeSeconds;

        float delta = !_hasObservation || isPaused
            ? 0f
            : Math.Clamp(sourceSeconds - _lastSourceSeconds, 0f, MaximumFrameSeconds);
        // Unity stores both timestamps and the accumulator as floats. Do not accumulate
        // double deltas or multiply by timeScale: nonzero timeScale only opens this gate.
        float elapsed = ElapsedSeconds + delta;
        DeltaSeconds = delta;
        ElapsedSeconds = elapsed;
        _lastObservation = realTimeSeconds;
        _lastSourceSeconds = sourceSeconds;
        _hasObservation = true;
    }

    internal void ValidateObservation(double realTimeSeconds)
    {
        BattleRealtime.Validate(realTimeSeconds, _lastObservation);
        float sourceSeconds = (float)realTimeSeconds;
        if (!float.IsFinite(sourceSeconds))
        {
            throw new ArgumentOutOfRangeException(nameof(realTimeSeconds));
        }
    }
}
