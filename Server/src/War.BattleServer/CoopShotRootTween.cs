using System.Numerics;

namespace War.BattleServer;

/// <summary>Models the recovered default NGUI rotation tween, including its one-time Start update.</summary>
internal sealed class CoopShotRootTween
{
    private const float UnitRotationTolerance = 0.0002f;
    private readonly float _durationSeconds;
    private Quaternion _startRotation;
    private Quaternion _targetRotation;
    private float _factor;
    private bool _hasStarted;

    internal CoopShotRootTween(float durationSeconds)
    {
        if (!float.IsFinite(durationSeconds) || durationSeconds <= 0f ||
            !float.IsFinite(1f / durationSeconds))
        {
            throw new InvalidDataException("A source root tween needs a finite positive duration.");
        }

        _durationSeconds = durationSeconds;
    }

    internal Quaternion Rotation { get; private set; } = Quaternion.Identity;

    internal bool IsRunning { get; private set; }

    internal void Begin(Quaternion startRotation, Quaternion targetRotation)
    {
        ValidateRotation(startRotation);
        ValidateRotation(targetRotation);
        _startRotation = Quaternion.Normalize(startRotation);
        _targetRotation = Quaternion.Normalize(targetRotation);
        Rotation = _startRotation;
        _factor = 0f;
        IsRunning = true;
        // UITweener.Begin resets its factor but Unity does not invoke Start again on a reused component.
    }

    internal void AdvanceFrame(float scaledDeltaSeconds)
    {
        float factorStep = scaledDeltaSeconds * (1f / _durationSeconds);
        if (!float.IsFinite(scaledDeltaSeconds) || scaledDeltaSeconds < 0f || !float.IsFinite(factorStep))
        {
            throw new InvalidDataException("A source root tween needs a finite nonnegative scaled delta.");
        }

        if (!IsRunning)
        {
            return;
        }

        if (!_hasStarted)
        {
            // UITweener.Start calls Update before Unity's regular Update on the first active frame.
            _hasStarted = true;
            AdvanceUpdate(factorStep);
        }

        if (IsRunning)
        {
            AdvanceUpdate(factorStep);
        }
    }

    private void AdvanceUpdate(float factorStep)
    {
        float nextFactor = _factor + factorStep;
        IsRunning = nextFactor <= 1f;
        _factor = Math.Min(nextFactor, 1f);
        float fullCircle = 2f * MathF.PI;
        float eased = _factor - MathF.Sin(_factor * fullCircle) / fullCircle;
        Rotation = Quaternion.Normalize(Quaternion.Slerp(_startRotation, _targetRotation, eased));
    }

    private static void ValidateRotation(Quaternion rotation)
    {
        float lengthSquared = rotation.LengthSquared();
        if (!float.IsFinite(lengthSquared) || Math.Abs(lengthSquared - 1f) > UnitRotationTolerance)
        {
            throw new InvalidDataException("A source root tween needs unit start and target rotations.");
        }
    }
}
