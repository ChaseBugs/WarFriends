using System.Numerics;

namespace War.BattleServer;

/// <summary>Combines the observed entry tween and realtime clock under a fixed pool parent.</summary>
internal sealed class HelicopterCrewEntryState
{
    private const float UnitTolerance = 0.0002f;
    private readonly HelicopterEntryRotationTween _rotation = new();
    private readonly NguiRealtimeClock _clock;
    private readonly Quaternion _parentRotation;

    /// <summary>Endpoints must already include the source TweenRotation Euler round trip.</summary>
    internal HelicopterCrewEntryState(Quaternion fromLocal, Quaternion targetLocal,
        Quaternion parentRotation, float realtime)
    {
        float parentLength = parentRotation.LengthSquared();
        if (!float.IsFinite(parentLength) || MathF.Abs(parentLength - 1f) > UnitTolerance)
        {
            throw new InvalidDataException("Crew entry requires the observed unit pool-parent rotation.");
        }
        _rotation.Begin(fromLocal, targetLocal);
        _clock = new NguiRealtimeClock(realtime);
        _parentRotation = parentRotation;
    }

    internal bool IsRotating => _rotation.IsRunning;

    /// <summary>Models Begin on the same component; the source preserves fractional realtime residual.</summary>
    internal void Restart(Quaternion fromLocal, Quaternion targetLocal)
    {
        // Begin resets tween progress, not IgnoreTimeScale fields. An actual OnEnable is observed separately.
        _rotation.Begin(fromLocal, targetLocal);
    }

    /// <summary>Models an observed OnEnable; it does not invent a callback at crew spawn.</summary>
    internal void ReenableAt(float realtime)
    {
        _clock.ReenableAt(realtime);
    }

    /// <summary>Consumes one observed tween update and the current Driving point position.</summary>
    internal HelicopterRopeBodyPose AdvanceUpdate(float realtime, Vector3 pointPosition)
    {
        if (!float.IsFinite(realtime) || realtime < 0 ||
            !float.IsFinite(pointPosition.X) || !float.IsFinite(pointPosition.Y) ||
            !float.IsFinite(pointPosition.Z))
        {
            throw new InvalidDataException("Crew entry requires finite position and nonnegative realtime.");
        }
        if (_rotation.IsRunning)
        {
            _rotation.AdvanceUpdate(_clock.Advance(realtime));
        }
        // Driving follows position only. Aircraft turns must not overwrite the completed entry rotation.
        return new HelicopterRopeBodyPose(pointPosition, _parentRotation * _rotation.LocalRotation);
    }

    /// <summary>Uses observed Time.deltaTime without touching the retained unscaled clock.</summary>
    internal HelicopterRopeBodyPose AdvanceScaledUpdate(float scaledDelta, Vector3 pointPosition)
    {
        if (!float.IsFinite(scaledDelta) || scaledDelta < 0 ||
            !float.IsFinite(pointPosition.X) || !float.IsFinite(pointPosition.Y) ||
            !float.IsFinite(pointPosition.Z))
        {
            throw new InvalidDataException("Crew entry requires finite position and nonnegative scaled delta.");
        }
        if (_rotation.IsRunning)
        {
            _rotation.AdvanceScaledUpdate(scaledDelta);
        }
        return new HelicopterRopeBodyPose(pointPosition, _parentRotation * _rotation.LocalRotation);
    }
}
