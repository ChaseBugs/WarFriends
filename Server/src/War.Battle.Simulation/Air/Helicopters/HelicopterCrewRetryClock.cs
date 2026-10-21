namespace War.BattleServer;

/// <summary>
/// Consumes host-observed scaled coroutine frames without deriving time from realtime or network input.
/// </summary>
internal sealed class HelicopterCrewRetryClock
{
    private ulong _scheduledFrame;
    private ulong _lastFrame;
    private float _lastTime;
    private float _deadline;
    private ulong _callbackFrame;
    private float _callbackTime;

    internal HelicopterCrewRetryClock(ulong frame, float scaledTime)
    {
        _deadline = Deadline(scaledTime);
        _scheduledFrame = frame;
        _lastFrame = frame;
        _lastTime = scaledTime;
        IsPending = true;
    }

    internal bool IsPending { get; private set; }

    /// <summary>Consumes at most one due callback, on a frame after the wait was scheduled.</summary>
    internal bool TryConsume(ulong frame, float scaledTime)
    {
        if (!float.IsFinite(scaledTime) || scaledTime < _lastTime || frame < _lastFrame ||
            (frame == _lastFrame && scaledTime != _lastTime))
        {
            throw new InvalidDataException("Crew retry requires coherent nondecreasing host scaled frames.");
        }
        _lastFrame = frame;
        _lastTime = scaledTime;
        if (!IsPending || frame <= _scheduledFrame || scaledTime < _deadline)
        {
            return false;
        }
        IsPending = false;
        _callbackFrame = frame;
        _callbackTime = scaledTime;
        return true;
    }

    /// <summary>Schedules the source's next wait from the callback that just failed to find a point.</summary>
    internal void ScheduleNext()
    {
        if (IsPending)
        {
            throw new InvalidOperationException("Crew retry cannot replace a pending wait.");
        }
        float deadline = Deadline(_callbackTime);
        _scheduledFrame = _callbackFrame;
        _deadline = deadline;
        IsPending = true;
    }

    private static float Deadline(float scaledTime)
    {
        float deadline = scaledTime + CoopHelicopterFallbackTarget.RetryDelayScaledSeconds;
        if (!float.IsFinite(scaledTime) || scaledTime < 0 || !float.IsFinite(deadline) || deadline <= scaledTime)
        {
            throw new InvalidDataException("Crew retry deadline must remain finite and later than its scaled origin.");
        }
        return deadline;
    }
}
