using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// The recovered EnemyController.PrepareToShoot side check shared by
/// mission soldiers and card Paratroopers. This only decides whether the
/// soldier can uncover; the attack clock and projectile remain separate.
/// </summary>
internal static class CornerShotPolicy
{
    internal static bool CanExpose(Vector3 cornerDirection, bool rightSide,
        Vector3 soldierPosition, Vector3 targetPosition)
    {
        if (!PlayerHitbox.Finite(cornerDirection) ||
            !PlayerHitbox.Finite(soldierPosition) ||
            !PlayerHitbox.Finite(targetPosition))
            return false;

        Vector3 from = -cornerDirection;
        Vector3 to = targetPosition - soldierPosition;
        if (from.LengthSquared() < 0.0001f ||
            to.LengthSquared() < 0.0001f)
            return false;

        float crossY = Vector3.Cross(from, to).Y;
        float dot = Vector3.Dot(from, to);
        float angleDegrees = MathF.Atan2(crossY, dot) * 57.29578f;
        return (angleDegrees > 0f) == rightSide &&
            MathF.Abs(angleDegrees) >= 10f;
    }
}
