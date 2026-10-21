namespace War.BattleServer;

/// <summary>Retains the two scaled waits of one dead source body until return or forced cancellation.</summary>
internal sealed class MortarCorpseReturnClock
{
    private const float MinimumHideDelaySeconds = 2f;
    private const float MaximumHideDelaySeconds = 3f;
    private const double ReturnAfterHideSeconds = 1d;
    private double _elapsedSeconds;
    private double _deadlineSeconds;
    private bool _hasHidden;
    private bool _hasReturned;

    internal bool HasHidden => _hasHidden;

    internal bool HasReturned => _hasReturned;

    internal MortarCorpseReturnClock(float hideDelaySeconds)
    {
        // EnemyController chooses Random.Range(2f, 3f); the host must own that sampled delay.
        if (!float.IsFinite(hideDelaySeconds) || hideDelaySeconds < MinimumHideDelaySeconds ||
            hideDelaySeconds > MaximumHideDelaySeconds)
        {
            throw new ArgumentOutOfRangeException(nameof(hideDelaySeconds));
        }
        _deadlineSeconds = hideDelaySeconds;
    }

    internal Transition Advance(float scaledDeltaSeconds)
    {
        if (!float.IsFinite(scaledDeltaSeconds) || scaledDeltaSeconds < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(scaledDeltaSeconds));
        }
        if (_hasReturned)
        {
            return Transition.None;
        }
        _elapsedSeconds += scaledDeltaSeconds;
        if (_elapsedSeconds < _deadlineSeconds)
        {
            return Transition.None;
        }
        if (!_hasHidden)
        {
            _hasHidden = true;
            // The second coroutine begins on this frame; do not carry an overshoot into its wait.
            _elapsedSeconds = 0d;
            _deadlineSeconds = ReturnAfterHideSeconds;
            return Transition.Hidden;
        }
        _hasReturned = true;
        return Transition.Returned;
    }

    internal void ForceReturn()
    {
        // ObjectPool deactivates the body, cancelling either body-owned source coroutine.
        // A successor receives a separate clock; this retired identity must never resume.
        _hasReturned = true;
    }

    internal enum Transition
    {
        None,
        Hidden,
        Returned
    }
}
