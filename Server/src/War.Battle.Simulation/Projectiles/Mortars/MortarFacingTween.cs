using System.Numerics;

namespace War.BattleServer;

/// <summary>Samples the recovered planar NGUI EaseInOut rotation over its source 0.2-second duration.</summary>
internal sealed class MortarFacingTween
{
    private const float DurationSeconds = 0.2f;
    private const float MinimumDirectionLengthSquared = 0.00000001f;
    private const float NativeLinearInterpolationThreshold = 0.95f;
    private const ulong MaximumTick = 10_000_000;
    private readonly Quaternion _from;
    private readonly Quaternion _to;

    internal ulong StartedTick { get; }
    internal int TargetCoverIndex { get; }

    internal MortarFacingTween(ulong startedTick, int targetCoverIndex, Vector3 from, Vector3 to)
    {
        if (startedTick > MaximumTick || targetCoverIndex < 0)
        {
            throw new InvalidDataException("Mortar facing lost its bounded clock or target point identity.");
        }

        _from = Rotation(from);
        _to = Rotation(to);
        StartedTick = startedTick;
        TargetCoverIndex = targetCoverIndex;
    }

    /// <summary>Uses the source sine easing and shortest quaternion arc; the default NGUI curve is linear.</summary>
    internal Vector3 FacingAt(ulong tick)
    {
        if (tick < StartedTick || tick > MaximumTick)
        {
            throw new InvalidDataException("Mortar facing cannot sample outside its authoritative clock.");
        }

        float factor = Math.Clamp((tick - StartedTick) / (DurationSeconds * MatchManifest.TickRate), 0f, 1f);
        float eased = factor - MathF.Sin(factor * MathF.Tau) / MathF.Tau;
        Quaternion rotation = Interpolate(eased);
        return Vector3.Normalize(Vector3.Transform(Vector3.UnitZ, rotation));
    }

    private Quaternion Interpolate(float factor)
    {
        // Unity's native Slerp uses normalized linear interpolation for near rotations.
        // The 0.95 boundary is checked on both sides and at the boundary by the native reference.
        return MathF.Abs(Quaternion.Dot(_from, _to)) >= NativeLinearInterpolationThreshold
            ? Quaternion.Lerp(_from, _to, factor)
            : Quaternion.Slerp(_from, _to, factor);
    }

    private static Quaternion Rotation(Vector3 direction)
    {
        float lengthSquared = direction.LengthSquared();
        if (!PlayerHitbox.Finite(direction) || direction.Y != 0f ||
            !float.IsFinite(lengthSquared) || lengthSquared < MinimumDirectionLengthSquared)
        {
            throw new InvalidDataException("Mortar facing requires a finite nonzero planar direction.");
        }

        // TweenRotation captures Euler angles, including their positive wrap, before Slerp.
        float yaw = MathF.Atan2(direction.X, direction.Z);
        if (yaw < 0f)
        {
            yaw += MathF.Tau;
        }

        return Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
    }
}
