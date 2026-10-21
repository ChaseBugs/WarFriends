using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Final enemy-root rotation requested by EnemyController.PrepareToShoot.
/// Tween playback and procedural upper-body aiming are separate concerns.
/// </summary>
internal static class CoopAssaulterShotRotation
{
    // EnemyController.PrepareToShoot starts a 0.2-second obstacle tween or
    // 0.3-second corner tween. The final rotation is only a valid observed
    // pose after that duration has elapsed at the host's 30 Hz tick rate.
    internal static bool FinalRotationReached(
        CoopInfantryPointState state, ulong elapsedTicks)
    {
        ulong requiredTicks = state switch
        {
            CoopInfantryPointState.ObstacleHiding => 6,
            CoopInfantryPointState.CornerHiding => 9,
            _ => throw new InvalidDataException(
                "Co-op shot has no supported stationary point state.")
        };
        return elapsedTicks >= requiredTicks;
    }

    internal static Quaternion Obstacle(Vector3 enemyPosition,
        Vector3 targetPosition)
    {
        ValidatePosition(enemyPosition, targetPosition);
        Vector3 forward = targetPosition - enemyPosition;
        forward.Y = 0;
        if (forward.LengthSquared() < 0.0001f)
            throw new InvalidDataException(
                "Co-op obstacle shot has no planar facing direction.");

        float yaw = MathF.Atan2(forward.X, forward.Z);
        return Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
    }

    internal static Quaternion Corner(CoopEnemyPoint point,
        Vector3 enemyPosition, Vector3 targetPosition)
    {
        ArgumentNullException.ThrowIfNull(point);
        ValidatePosition(enemyPosition, targetPosition);
        if (point.CornerDirection is not Vector3 sourceDirection ||
            !PlayerHitbox.Finite(sourceDirection) ||
            Math.Abs(sourceDirection.Y) > 0.0001f ||
            !CoopCornerShotPolicy.CanExpose(point,
                enemyPosition, targetPosition))
            throw new InvalidDataException(
                "Co-op corner shot has no source-exposed target.");

        Vector3 towardTarget = targetPosition - enemyPosition;
        Vector3 outward = -sourceDirection;
        // GeometryTools.AngleSigned(-vector, -corner.direction, up).
        float signedAngle = MathF.Atan2(
            Vector3.Cross(-towardTarget, outward).Y,
            Vector3.Dot(-towardTarget, outward));
        float outwardYaw = MathF.Atan2(outward.X, outward.Z);
        Quaternion outwardRotation = Quaternion.CreateFromAxisAngle(
            Vector3.UnitY, outwardYaw);
        Quaternion correction = Quaternion.CreateFromAxisAngle(
            Vector3.UnitY, -signedAngle);
        return Quaternion.Normalize(outwardRotation * correction);
    }

    private static void ValidatePosition(Vector3 enemyPosition,
        Vector3 targetPosition)
    {
        if (!PlayerHitbox.Finite(enemyPosition) ||
            !PlayerHitbox.Finite(targetPosition))
            throw new InvalidDataException(
                "Co-op shot rotation needs finite source positions.");
    }
}
