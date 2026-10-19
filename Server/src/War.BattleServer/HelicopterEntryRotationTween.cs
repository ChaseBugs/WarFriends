using System.Numerics;

namespace War.BattleServer;

/// <summary>One source TweenRotation.Update result; callers retain parent space and unscaled clock ownership.</summary>
internal sealed class HelicopterEntryRotationTween
{
    private const float DurationSeconds = 0.3f;
    private const float UnitTolerance = 0.0002f;
    private const float LinearInterpolationThreshold = 0.95f;
    private Quaternion _from;
    private Quaternion _target;

    internal float Factor { get; private set; }
    internal bool IsRunning { get; private set; }
    internal Quaternion LocalRotation { get; private set; } = Quaternion.Identity;

    /// <summary>Requires the source's captured Euler-roundtripped local endpoints.</summary>
    internal void Begin(Quaternion fromLocal, Quaternion targetLocal)
    {
        ValidateRotation(fromLocal);
        ValidateRotation(targetLocal);
        _from = fromLocal;
        _target = targetLocal;
        LocalRotation = fromLocal;
        Factor = 0;
        IsRunning = true;
    }

    /// <summary>Consumes one original Update invocation; Start dispatch and realtime rounding are separate.</summary>
    internal void AdvanceUpdate(float unscaledDelta)
    {
        if (!float.IsFinite(unscaledDelta) || unscaledDelta < 0 || unscaledDelta > 1)
        {
            throw new InvalidDataException("Entry tween requires a validated NGUI unscaled delta.");
        }
        if (!IsRunning)
        {
            throw new InvalidOperationException("Entry tween cannot update after completion without Begin.");
        }
        // Captured Mono updates round at assignment; rounding the product first drifts from frame four.
        float nextFactor = (float)(Factor + (double)(1f / DurationSeconds) * unscaledDelta);
        IsRunning = nextFactor <= 1f;
        Factor = MathF.Min(nextFactor, 1f);
        float circle = MathF.PI * 2f;
        float eased = Factor - MathF.Sin(Factor * circle) / circle;
        LocalRotation = MathF.Abs(Quaternion.Dot(_from, _target)) >= LinearInterpolationThreshold
            ? Quaternion.Lerp(_from, _target, eased)
            : Quaternion.Normalize(Quaternion.Slerp(_from, _target, eased));
    }

    private static void ValidateRotation(Quaternion rotation)
    {
        float length = rotation.LengthSquared();
        if (!float.IsFinite(length) || MathF.Abs(length - 1f) > UnitTolerance)
        {
            throw new InvalidDataException("Entry tween requires captured unit local rotations.");
        }
    }
}
