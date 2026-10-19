namespace War.BattleServer;

/// <summary>Recovered IgnoreTimeScale rounding, carried residual and post-rounding one-second cap.</summary>
internal sealed class NguiRealtimeClock
{
    private const float MillisecondsPerSecond = 1000f;
    private const float SecondsPerMillisecond = 0.001f;
    private const float MaximumDeltaSeconds = 1f;
    private float _previousTime;
    private float _residual;

    internal NguiRealtimeClock(float realtime)
    {
        ReenableAt(realtime);
    }

    internal float Residual => _residual;

    /// <summary>OnEnable resets the observation origin, but the source keeps its fractional residual.</summary>
    internal void ReenableAt(float realtime)
    {
        ValidateTime(realtime);
        _previousTime = realtime;
    }

    internal float Advance(float realtime)
    {
        ValidateTime(realtime);
        float accumulated = _residual + MathF.Max(0f, realtime - _previousTime);
        float milliseconds = accumulated * MillisecondsPerSecond;
        if (!float.IsFinite(milliseconds))
        {
            throw new InvalidDataException("NGUI realtime accumulation overflowed.");
        }
        float rounded = SecondsPerMillisecond * MathF.Round(milliseconds, MidpointRounding.ToEven);
        float residual = accumulated - rounded;

        // IgnoreTimeScale subtracts the complete rounded interval before clamping the returned delta.
        // A long frame therefore discards excess seconds instead of carrying them as later tween debt.
        _previousTime = realtime;
        _residual = residual;
        return MathF.Min(rounded, MaximumDeltaSeconds);
    }

    private static void ValidateTime(float realtime)
    {
        if (!float.IsFinite(realtime) || realtime < 0)
        {
            throw new InvalidDataException("NGUI realtime requires a finite nonnegative observation.");
        }
    }
}
