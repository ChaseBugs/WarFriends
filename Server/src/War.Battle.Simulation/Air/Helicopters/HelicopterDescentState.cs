using System.Numerics;

namespace War.BattleServer;

/// <summary>Current host-observed root, palm and aircraft facing before a descent update.</summary>
internal sealed record HelicopterDescentFrame(
    Vector3 RootPosition, Quaternion RootRotation, Vector3 LeftPalmPosition, Vector3 HelicopterRight);

/// <summary>A calculated descent pose; animation completion is not proof of NavMesh landing.</summary>
internal sealed record HelicopterDescentResult(Vector3 Position, Quaternion Rotation, float Progress)
{
    internal bool AnimationComplete => Progress >= 1f;
}

/// <summary>Source HelicopterUpdate progress and pose ordering, without rope physics or landing authority.</summary>
internal sealed class HelicopterDescentState
{
    private const float DirectionTolerance = 0.0001f;
    private const float MinimumPlanarDirectionSquared = 0.0000000001f;
    private readonly float _startingHeight;
    private readonly float _landingHeight;

    internal float Progress { get; private set; }

    internal HelicopterDescentState(float startingHeight, float landingHeight)
    {
        if (!float.IsFinite(startingHeight) || !float.IsFinite(landingHeight))
        {
            throw new InvalidDataException("Invalid host Helicopter descent heights.");
        }
        _startingHeight = startingHeight;
        _landingHeight = landingHeight;
    }

    internal HelicopterDescentResult Advance(
        HelicopterDescentFrame frame, float deltaTime, IReadOnlyList<Vector3>? joints)
    {
        ArgumentNullException.ThrowIfNull(frame);
        if (Progress >= 1f)
        {
            throw new InvalidOperationException("The Helicopter descent animation has already completed.");
        }
        ValidateFrame(frame, deltaTime);

        // HelicopterUpdate accumulates float deltaTime; elapsed-tick division can round differently.
        float nextProgress = HelicopterDescentProgress.Advance(Progress, deltaTime);
        Vector3 basePosition = frame.RootPosition;
        basePosition.Y = _startingHeight + (_landingHeight - _startingHeight) * nextProgress;
        Vector3 aligned = HelicopterRopeAlignment.Align(new HelicopterRopeAlignmentPose(
            basePosition, frame.RootPosition, frame.LeftPalmPosition, frame.RootRotation), joints);

        // The source aligns using the old root rotation, then faces the aircraft's right vector.
        Quaternion rotation = HelicopterOrientationState.LookRotation(frame.HelicopterRight);
        var result = new HelicopterDescentResult(aligned, rotation, nextProgress);
        Progress = nextProgress;
        return result;
    }

    private static void ValidateFrame(HelicopterDescentFrame frame, float deltaTime)
    {
        float directionLength = frame.HelicopterRight.LengthSquared();
        float planarDirection = Vector3.Cross(Vector3.UnitY, frame.HelicopterRight).LengthSquared();
        if (!float.IsFinite(deltaTime) || deltaTime < 0 || !PlayerHitbox.Finite(frame.HelicopterRight) ||
            !float.IsFinite(directionLength) || MathF.Abs(directionLength - 1f) > DirectionTolerance ||
            planarDirection < MinimumPlanarDirectionSquared)
        {
            throw new InvalidDataException("Invalid host Helicopter descent frame.");
        }
    }
}
