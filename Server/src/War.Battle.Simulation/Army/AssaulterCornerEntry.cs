using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterCornerPose(Vector3 Position, Vector3 Facing);

/// <summary>Samples EnemyController's source half-second Corner root-position and rotation tweens.</summary>
internal sealed class AssaulterCornerEntry
{
    internal const ulong DurationTicks = MatchManifest.TickRate / 2;
    private readonly Vector3 _startPosition;
    private readonly Vector3 _finalPosition;
    private readonly Quaternion _startRotation;
    private readonly Quaternion _finalRotation;

    internal ulong StartTick { get; }

    internal ulong EndTick { get; }

    internal int PointFileId { get; }

    internal AssaulterCornerEntry(CardUnitInitialPoint point, AssaulterCornerPose start, ulong tick)
    {
        ArgumentNullException.ThrowIfNull(point);
        ArgumentNullException.ThrowIfNull(start);
        if (point.ComponentType != "EnemyPointCorner" || point.ComponentFileId <= 0 ||
            point.CornerDirection is not Vector3 direction || !PlayerHitbox.Finite(direction) ||
            MathF.Abs(direction.Y) > 0.0001f || direction.LengthSquared() < 0.0001f ||
            !PlayerHitbox.Finite(point.Position) || !PlayerHitbox.Finite(start.Position) ||
            !PlayerHitbox.Finite(start.Facing) || MathF.Abs(start.Facing.Y) > 0.0001f ||
            MathF.Abs(start.Facing.LengthSquared() - 1f) > 0.001f)
        {
            throw new InvalidDataException("Assaulter Corner entry requires its source point and current root pose.");
        }

        StartTick = tick;
        EndTick = checked(tick + DurationTicks);
        PointFileId = point.ComponentFileId;
        _startPosition = start.Position;
        // The source overwrites the destination Y with the soldier's current Y.
        _finalPosition = new Vector3(point.Position.X, start.Position.Y, point.Position.Z);
        _startRotation = Rotation(start.Facing);
        _finalRotation = Rotation(-direction);
    }

    internal AssaulterCornerPose Sample(ulong tick)
    {
        if (tick < StartTick)
        {
            throw new InvalidDataException("Assaulter Corner entry cannot sample before arrival.");
        }

        float fraction = tick >= EndTick ? 1f : (tick - StartTick) / (float)DurationTicks;
        // UITweener's default EaseInOut precedes the source linear animation curve.
        float eased = fraction - MathF.Sin(fraction * MathF.Tau) / MathF.Tau;
        Vector3 position = Vector3.Lerp(_startPosition, _finalPosition, eased);
        Quaternion rotation = Quaternion.Slerp(_startRotation, _finalRotation, eased);
        Vector3 facing = Vector3.Normalize(Vector3.Transform(Vector3.UnitZ, rotation));
        return new AssaulterCornerPose(position, facing);
    }

    private static Quaternion Rotation(Vector3 facing)
    {
        return Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
    }
}
